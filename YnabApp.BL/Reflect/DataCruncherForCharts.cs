using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.BL.Reflect
{
    public class DataCruncherForCharts
    {
        List<string> categoryGroupExcludeList = new List<string>()
        {
            "Credit Card Payments",
            "Hidden Categories",
            "Internal Master Category",
            "Uncategorized"
        };

        public async Task<ReflectChartSummary> GenerateSummaryDataAsync(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            ReflectChartSummary result = null;

            await Task.Run(() =>
            {
                result = GenerateSummaryData(categoryGroupData, transactionDatas, isYearly, reportDate, person);

            });

            return result;
        }



        public ReflectChartSummary GenerateSummaryData(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            //Filter by Date Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (person != Person.All)
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();

            decimal income = 0, expense = 0, savings = 0;

            foreach (var transaction in matchingTransactions)
            {
                //Exclude YNAB Formula Categories
                if (categoryGroupExcludeList.Contains(transaction.CategoryName) || transaction.CategoryName.Contains("[?]"))
                    continue;

                var catGroupData = GetCategoryGroupFromCategory(categoryGroupData, transaction.CategoryId);

                if (transaction.IsIncome)
                    income += transaction.Amount;
                else if (catGroupData != null && !catGroupData.IsActualSavings)
                    expense += transaction.Amount;
            }
            expense = Math.Abs(expense);
            savings = income - expense;

            ReflectChartSummary summary = new ReflectChartSummary(income, expense, savings);

            return summary;
        }


        public async Task<ReflectChartCategoryGroup> GenerateCategoryGroupDataAsync(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            ReflectChartCategoryGroup result = null;

            await Task.Run(() =>
            {
                result = GenerateCategoryGroupData(categoryGroupData, transactionDatas, isYearly, reportDate, person);

            });

            return result;
        }

        public ReflectChartCategoryGroup GenerateCategoryGroupData(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            //Filter by Date Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (person != Person.All)
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();

            decimal necessities = 0, discretionary = 0, help = 0;

            foreach (var transaction in matchingTransactions)
            {
                //Exclude YNAB Formula Categories
                if (categoryGroupExcludeList.Contains(transaction.CategoryName) || transaction.CategoryName.Contains("[?]"))
                    continue;

                var catGroupData = GetCategoryGroupFromCategory(categoryGroupData, transaction.CategoryId);

                if (catGroupData == null)
                    continue;

                else if (catGroupData.Name == "NECESSITIES" || catGroupData.Name == "NECESSITIES-TAX")
                    necessities += transaction.Amount;

                else if (catGroupData.Name == "DISCRETIONARY")
                    discretionary += transaction.Amount;

                else if (catGroupData.Name == "HELP")
                    help += transaction.Amount;
            }

            necessities = Math.Abs(necessities);
            discretionary = Math.Abs(discretionary);
            help = Math.Abs(help);

            return new ReflectChartCategoryGroup(necessities, discretionary, help);
        }

        private CategoryGroupData GetCategoryGroupFromCategory(CategoryGroupData[] categoryGroupData, string categoryId)
        {
            return categoryGroupData.SingleOrDefault(cg => cg.HasCategory(categoryId) == true);
        }


        public async Task<List<ReflectCategoryData>> CrunchCategroyData2Async(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, DateTime startDate, DateTime endDate,
                                                                                   decimal totalIncome, Person person = Person.All, bool isHideZeroCategorties = true)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            await Task.Run(() =>
            {
                reflectCategoryDatas = GenerateCrunchCategoryData2(categoryGroupDatas, transactionDatas, startDate, endDate, totalIncome, person, isHideZeroCategorties);
            });

            return reflectCategoryDatas;
        }

        private List<ReflectCategoryData> GenerateCrunchCategoryData2(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, DateTime startDate, DateTime endDate,
                                                                                   decimal totalIncome, Person person = Person.All, bool isHideZeroCategorties = true)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            IEnumerable<TransactionData> matchingTransactions;
            //Match Date limits and ignore refunds (positive amounts)
            matchingTransactions = transactionDatas.Where(t => t.TransDateTime >= startDate && t.TransDateTime <= endDate);

            //Filter by Person
            if (person != Person.All)
            {
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            foreach (var categoryGroup in categoryGroupDatas)
            {
                if (categoryGroupExcludeList.Contains(categoryGroup.Name) || categoryGroup.Name.Contains("[?]") 
                    || categoryGroup.Name.Equals("INVESTMENTS")
                    || categoryGroup.Name.Equals("SAVINGS"))
                    continue;

                foreach (var category in categoryGroup.Categories)
                {
                    ReflectCategoryData reflectCategory = new(category.Id, categoryGroup.Name, category.Name, category);

                    var categoryTransactions = matchingTransactions.Where(t => t.CategoryId == category.Id);
                    if (categoryTransactions.Any())
                    {
                        decimal categoryTotal = categoryTransactions.Sum(t => t.Amount);
                        if(categoryTotal > 0)
                            continue; //Ignore Refunds
                        reflectCategory.Amount += -(categoryTotal);
                        reflectCategoryDatas.Add(reflectCategory);
                    }
                    else if (!isHideZeroCategorties)
                    {
                        //Do not Show if there are not transactions for the Category
                        reflectCategoryDatas.Add(reflectCategory);
                    }
                }
            }

            //Calculate Percentages
            reflectCategoryDatas.ForEach(r => r.Percentage = (totalIncome == 0) ? 0 : Math.Abs(r.Amount) * 100 / totalIncome);

            return reflectCategoryDatas.OrderBy(cg => cg.Amount).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListAccounts;
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



        public async Task GenerateSummaryDataForChartPointAsync(ReflectChartPoint chartPoint, CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, AccountData[] personAccounts)
        {
            await Task.Run(() =>
            {
                GenerateSummaryDataForChartPoint(chartPoint, categoryGroupData, transactionDatas, isYearly, reportDate, personAccounts);

            });

        }



        public void GenerateSummaryDataForChartPoint(ReflectChartPoint chartPoint, CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, AccountData[] personAccounts)
        {
            //Filter by Date Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (personAccounts != null && personAccounts.Length > 0)
            {
                matchingTransactions = matchingTransactions.Where(t => personAccounts.ToList().Exists(pa => pa.Id == t.AccountId)).ToList();
            }

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

            chartPoint.IncomeAmount = income;
            chartPoint.ExpenseAmount = expense;
            chartPoint.SavingsAmount = savings;
        }


        public async Task GenerateCategoryGroupDataAsync(ReflectChartPoint chartPoint, CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, AccountData[] personAccounts)
        {
            await Task.Run(() =>
            {
                GenerateCategoryGroupData(chartPoint, categoryGroupData, transactionDatas, isYearly, reportDate, personAccounts);

            });
        }

        public void GenerateCategoryGroupData(ReflectChartPoint chartPoint, CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas,
                                                        bool isYearly, DateTime reportDate, AccountData[] personAccounts)
        {
            //Filter by Date Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (personAccounts != null && personAccounts.Length > 0)
            {
                matchingTransactions = matchingTransactions.Where(t => personAccounts.ToList().Exists(pa => pa.Id == t.AccountId)).ToList();
            }

            foreach (var transaction in matchingTransactions)
            {
                ////Exclude YNAB Formula Categories
                //if (categoryGroupExcludeList.Contains(transaction.CategoryName) || transaction.CategoryName.Contains("[?]"))
                //    continue;

                var catGroupData = GetCategoryGroupFromCategory(categoryGroupData, transaction.CategoryId);

                if (catGroupData == null)
                    continue;

                if (chartPoint.CategoryGroupAmounts.ContainsKey(catGroupData.Name))
                    chartPoint.CategoryGroupAmounts[catGroupData.Name] = chartPoint.CategoryGroupAmounts[catGroupData.Name] + -(transaction.Amount);
                else
                    chartPoint.CategoryGroupAmounts[catGroupData.Name] = -(transaction.Amount);
            }

            //Add Missing CategoryGroups to address the bug in the charting software that does not handle missing categories well
            foreach (var categoryGroup in categoryGroupData)
            {
                if (!chartPoint.CategoryGroupAmounts.ContainsKey(categoryGroup.Name))
                    chartPoint.CategoryGroupAmounts[categoryGroup.Name] = 0;
            }
        }

        private CategoryGroupData GetCategoryGroupFromCategory(CategoryGroupData[] categoryGroupData, string categoryId)
        {
            return categoryGroupData.SingleOrDefault(cg => cg.HasCategory(categoryId) == true);
        }


        public async Task<List<ReflectCategoryData>> CrunchCategroyData2Async(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, DateTime startDate, DateTime endDate,
                                                                                   decimal totalIncome, AccountData[] personAccounts, bool isHideZeroCategorties = true)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            await Task.Run(() =>
            {
                reflectCategoryDatas = GenerateCrunchCategoryData2(categoryGroupDatas, transactionDatas, startDate, endDate, totalIncome, personAccounts, isHideZeroCategorties);
            });

            return reflectCategoryDatas;
        }

        private List<ReflectCategoryData> GenerateCrunchCategoryData2(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, DateTime startDate, DateTime endDate,
                                                                                   decimal totalIncome, AccountData[] personAccounts, bool isHideZeroCategorties = true)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            IEnumerable<TransactionData> matchingTransactions;
            //Match Date limits and ignore refunds (positive amounts)
            matchingTransactions = transactionDatas.Where(t => t.TransDateTime >= startDate && t.TransDateTime <= endDate);

            //Filter by Person
            if (personAccounts != null && personAccounts.Length > 0)
            {
                matchingTransactions = matchingTransactions.Where(t => personAccounts.ToList().Exists(pa => pa.Id == t.AccountId)).ToList();
            }

            foreach (var categoryGroup in categoryGroupDatas)
            {
                //if (categoryGroupExcludeList.Contains(categoryGroup.Name) || categoryGroup.Name.Contains("[?]") 
                //    || categoryGroup.Name.Equals("INVESTMENTS")
                //    || categoryGroup.Name.Equals("SAVINGS"))
                //    continue;

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

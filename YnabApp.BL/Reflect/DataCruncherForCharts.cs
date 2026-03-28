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

    }
}

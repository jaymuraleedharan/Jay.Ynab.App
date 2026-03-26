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
                else if (catGroupData == null || !catGroupData.IsActualSavings)
                    expense += transaction.Amount;
            }
            expense = Math.Abs(expense);
            savings = income - expense;

            ReflectChartSummary summary = new ReflectChartSummary(income, expense, savings);

            return summary;
        }


        private CategoryGroupData GetCategoryGroupFromCategory(CategoryGroupData[] categoryGroupData, string categoryId)
        {
            return categoryGroupData.SingleOrDefault(cg => cg.HasCategory(categoryId) == true);
        }

    }
}

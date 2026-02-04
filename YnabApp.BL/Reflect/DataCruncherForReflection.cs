using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.BL.Reflect
{
    public class DataCruncherForReflection
    {
        List<string> categoryGroupExcludeList = new List<string>()
        {
            "Credit Card Payments",
            "Hidden Categories",
            "Internal Master Category",
            "Uncategorized"
        };

        public DataCruncherForReflection()
        {

        }

        #region Category Group & Category Expenses Summary
        public async Task<List<ReflectCategoryGroupData>> CrunchCategroyGroupDataAsync(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate,
                                                                                        decimal totalIncome, Person person = Person.All)
        {
            List<ReflectCategoryGroupData> reflectCategoryGroupDatas = new List<ReflectCategoryGroupData>();

            await Task.Run(() =>
            {
                reflectCategoryGroupDatas = GenerateCrunchCategroyGroupData(categoryGroupDatas, transactionDatas, isYearly, reportDate, totalIncome, person);

            });

            return reflectCategoryGroupDatas;
        }

        private List<ReflectCategoryGroupData> GenerateCrunchCategroyGroupData(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate, 
                                                                                    decimal totalIncome, Person person = Person.All)
        {
            List<ReflectCategoryGroupData> reflectCategoryGroupDatas = new List<ReflectCategoryGroupData>();

            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (person != Person.All)
            {
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            foreach (var categoryGroup in categoryGroupDatas)
            {
                if (categoryGroupExcludeList.Contains(categoryGroup.Name) || categoryGroup.Name.Contains("[?]"))
                    continue;

                ReflectCategoryGroupData reflectCategoryGroup = new(categoryGroup.Id, categoryGroup.Name, categoryGroup);
                foreach (var caregory in categoryGroup.Categories)
                {
                    var categoryTransactions = matchingTransactions.Where(t => t.CategoryId == caregory.Id);
                    if (categoryTransactions.Any())
                    {
                        decimal categoryTotal = categoryTransactions.Sum(t => t.Amount);
                        reflectCategoryGroup.Amount += categoryTotal;
                    }
                }
                reflectCategoryGroupDatas.Add(reflectCategoryGroup);
            }

            //Calculate Percentages
            //decimal totalAmount = Math.Abs(reflectCategoryGroupDatas.Sum(r => r.Amount));
            reflectCategoryGroupDatas.ForEach(r => r.Percentage = (totalIncome == 0) ? 0 : Math.Abs(r.Amount) * 100 / totalIncome);

            return reflectCategoryGroupDatas.OrderBy(cg => cg.Amount).ToList();
        }


        public async Task<List<ReflectCategoryData>> CrunchCategroyDataAsync(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate,
                                                                                    decimal totalIncome, Person person = Person.All, bool isHideZeroCategorties = true)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            await Task.Run(() =>
            {
                reflectCategoryDatas = GenerateCrunchCategoryData(categoryGroupData, transactionDatas, isYearly, reportDate, totalIncome, person, isHideZeroCategorties);
            });

            return reflectCategoryDatas;
        }

        private List<ReflectCategoryData> GenerateCrunchCategoryData(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate,
                                                                                    decimal totalIncome, Person person = Person.All, bool isHideZeroCategorties = true)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (person != Person.All)
            {
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            foreach (var categoryGroup in categoryGroupDatas)
            {
                if (categoryGroupExcludeList.Contains(categoryGroup.Name) || categoryGroup.Name.Contains("[?]"))
                    continue;

                foreach (var category in categoryGroup.Categories)
                {
                    ReflectCategoryData reflectCategory = new(category.Id, categoryGroup.Name, category.Name, category);

                    var categoryTransactions = matchingTransactions.Where(t => t.CategoryId == category.Id);
                    if (categoryTransactions.Any())
                    {
                        decimal categoryTotal = categoryTransactions.Sum(t => t.Amount);
                        reflectCategory.Amount += categoryTotal;
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
        #endregion

        #region Category Group & Category Expenses Transactions
        public List<TransactionData> FilterCategoryGroupTransactions(ReflectCategoryGroupData categoryGroupData, TransactionData[] transactionDatas, 
                                                                    bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);


            //Filter by Person
            if (person != Person.All)
            {
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            List<TransactionData> filteredTransactions = new List<TransactionData>();
            foreach (TransactionData transactionData in matchingTransactions)
            {
                foreach (var categoryData in categoryGroupData.CategoryGroup.Categories)
                {
                    if (transactionData.CategoryId == categoryData.Id)
                        filteredTransactions.Add(transactionData);
                }
            }
            return filteredTransactions;
        }

        public List<TransactionData> FilterCategoryTransactions(ReflectCategoryData categoryData, TransactionData[] transactionDatas, 
                                                            bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (person != Person.All)
            {
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            List<TransactionData> filteredTransactions = new List<TransactionData>();
            foreach (TransactionData transactionData in matchingTransactions)
            {
                if (transactionData.CategoryId == categoryData.ID)
                    filteredTransactions.Add(transactionData);
            }
            return filteredTransactions;
        }
        #endregion

        #region Income Summary & Transactions
        public async Task<List<ReflectIncomeData>> CrunchIncomeDataAsync(TransactionData[] transactionDatas, bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            List<ReflectIncomeData> reflectIncomeDatas = new List<ReflectIncomeData>();

            await Task.Run(() =>
            {
                reflectIncomeDatas = GenerateIncomeData(transactionDatas, isYearly, reportDate, person);

            });

            return reflectIncomeDatas;
        }
        private List<ReflectIncomeData> GenerateIncomeData(TransactionData[] transactionDatas, bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            List<ReflectIncomeData> reflectIncomeDatas = new();

            //Filter by Data Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Identify Income Transactions
            var filteredList = matchingTransactions.Where(t => t.IsIncome).ToList();

            //Filter by Person
            if (person != Person.All)
            {
                filteredList = filteredList.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            //Get Total Income
            decimal totalIncome = filteredList.Sum(t => t.Amount);

            //Group by Payee & Account
            var groupedList = filteredList.GroupBy(t => new { t.PayeeName, t.AccountName });

            //Generate Reflection Data
            reflectIncomeDatas = groupedList.Select(y => new ReflectIncomeData(y.Key.PayeeName, y.Key.AccountName) { Amount = y.Sum(z => z.Amount) }).ToList();

            //Calculate Percentage
            reflectIncomeDatas.ForEach( r => r.Percentage = (r.Amount * 100) / totalIncome);

            //Sorrt by Amount 
            reflectIncomeDatas = reflectIncomeDatas.OrderByDescending(y => y.Amount).ToList();

            return reflectIncomeDatas;
        }
        #endregion

        #region Income Transactions

        public List<TransactionData> FilterIncomeTransactions(ReflectIncomeData incomeData, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            //Filter by Data Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Identify Income Transactions
            var filteredList = matchingTransactions.Where(t => t.IsIncome).ToList();

            //Filter by Person
            if(person != Person.All)
            {
                filteredList = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            //Identify Payee and Account
            var incomeList = filteredList.Where(t => t.PayeeName.Equals(incomeData.payeeName, StringComparison.InvariantCultureIgnoreCase)
                                                    && t.AccountName.Equals(incomeData.accountName, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return incomeList;
        }

        #endregion

        #region Overall Summary & Transactions
        public async Task<List<ReflectSummaryData>> CrunchSummaryDataAsync(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas, 
                                                                                        bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            List<ReflectSummaryData> reflectIncomeDatas = new List<ReflectSummaryData>();

            await Task.Run(() =>
            {
                reflectIncomeDatas = GenerateSummaryData(categoryGroupData, transactionDatas, isYearly, reportDate, person);

            });

            return reflectIncomeDatas;
        }

        private List<ReflectSummaryData> GenerateSummaryData(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas, 
                                                        bool isYearly, DateTime reportDate, Person person = Person.All)
        {
            List<ReflectSummaryData> reflectSummaryDatas = new();


            //Filter by Data Criteria
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            //Filter by Person
            if (person != Person.All)
            {
                matchingTransactions = matchingTransactions.Where(t => AccountFilter.IsPersonAccount(t.AccountId, person)).ToList();
            }

            ReflectSummaryData incomeSummaryData = new("All Incomes");
            ReflectSummaryData expenseSummaryData = new("All Expenses");
            ReflectSummaryData indirectSavingsSummaryData = new("Savings");
            ReflectSummaryData unspentSummaryData = new("Unspent");
            ReflectSummaryData netChangeSummaryData = new("Net Change");

            foreach (var transaction in matchingTransactions)
            {
                //Exclude YNAB Formula Categories
                if (categoryGroupExcludeList.Contains(transaction.CategoryName) || transaction.CategoryName.Contains("[?]"))
                    continue;

                var catGroupData = GetCategoryGroupFromCategory(categoryGroupData, transaction.CategoryId);

                if (transaction.IsIncome)
                {
                    incomeSummaryData.Amount += transaction.Amount;
                }
                else if (catGroupData != null && catGroupData.IsActualSavings)
                {
                    indirectSavingsSummaryData.Amount += -(transaction.Amount);
                }
                else
                {
                    expenseSummaryData.Amount += transaction.Amount;
                }
                unspentSummaryData.Amount += transaction.Amount;
            }
            //Corection for No Savings
            if (unspentSummaryData.Amount < 0)
                unspentSummaryData.Amount = 0;

            //Net Change
            netChangeSummaryData.Amount = incomeSummaryData.Amount + expenseSummaryData.Amount;

            //Setting Percentages
            incomeSummaryData.Percentage = 100;
            expenseSummaryData.Percentage = (incomeSummaryData.Amount == 0)? 0 : (Math.Abs(expenseSummaryData.Amount) * 100) / Math.Abs(incomeSummaryData.Amount);
            indirectSavingsSummaryData.Percentage = (incomeSummaryData.Amount == 0) ? 0 : (Math.Abs(indirectSavingsSummaryData.Amount) * 100) / Math.Abs(incomeSummaryData.Amount);
            unspentSummaryData.Percentage = (incomeSummaryData.Amount == 0) ? 0 :  (Math.Abs(unspentSummaryData.Amount) * 100) / Math.Abs(incomeSummaryData.Amount);
            netChangeSummaryData.Percentage = (incomeSummaryData.Amount == 0) ? 0 : (Math.Abs(netChangeSummaryData.Amount) * 100) / Math.Abs(incomeSummaryData.Amount);

            reflectSummaryDatas.Add(incomeSummaryData);
            reflectSummaryDatas.Add(expenseSummaryData);
            reflectSummaryDatas.Add(indirectSavingsSummaryData);
            reflectSummaryDatas.Add(unspentSummaryData);
            reflectSummaryDatas.Add(netChangeSummaryData);

            return reflectSummaryDatas;
        }     
        #endregion

        
        private CategoryGroupData GetCategoryGroupFromCategory(CategoryGroupData[] categoryGroupData, string categoryId)
        {
            return categoryGroupData.SingleOrDefault(cg => cg.HasCategory(categoryId) == true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.ListCategories;

namespace YnabApp.UI.ListAccounts
{
    public class ListAccountsPresenter
    {
        private readonly IListAccountsView _view;

        public ListAccountsPresenter(IListAccountsView view)
        {
            _view = view;
        }

        public async Task<AccountData[]> GetAllAccountsAsync(string budgetID)
        {
            ListAccountsExecute exe = new();
            var data = await exe.ListAccountsAsync(budgetID);
            return data;
        }

        public async Task<TransactionData[]> GetTransactionsAsync(string budgetId, DateTime startDate)
        {
            ListTransactionsExecute exe = new();
            var data = await exe.GetTransactionsAsync(budgetId, startDate);
            return data;
        }

        public async Task AnalyzeTransactionsForAccountsAsync(AccountData[] accounts, TransactionData[] transactions)
        {
            AnalyzeTransactionsForAccounts analyze = new();
            await analyze.ProcessAsync(accounts, transactions);
        }

        public AccountData[] FilterAccounts(AccountData[] accountData, string accountOwner)
        {
            AccountsFilter filter = new();
            return filter.Filter(accountData, accountOwner);
        }

        public async Task<CategoryGroupData[]> GetCategoriesAsync(string budgetID)
        {
            ListCategoriesExecute listCategoriesExecute = new();
            var data = await listCategoriesExecute.ListCAtegoriesAsync(budgetID);
            return data;
        }
    }
}

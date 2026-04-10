using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.ListCategories;
using YnabApp.BL.BudgetSettings;
using System.Drawing;

namespace YnabApp.UI.ListAccounts
{
    public class ListAccountsPresenter
    {
        public static readonly Color LIGHTYELLOW = Color.FromArgb(255, 255, 204);
        public static readonly Color LIGHTGREEN = Color.FromArgb(204, 255, 204);
        public static readonly Color LIGHTRED = Color.FromArgb(255, 204, 204);
        public static readonly Color LIGHTBLUE = Color.FromArgb(204, 236, 255);


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

        public AccountData[] FilterAccounts(AccountData[] accountData, PersonSetting accountOwner = null)
        {
            if(accountOwner == null)
                return accountData;
            else
                return accountData.ToList().Where(a => accountOwner.Accounts.Any(aset => aset.Id == a.Id)).ToArray();
        }

        public async Task<CategoryGroupData[]> GetCategoriesAsync(string budgetID)
        {
            ListCategoriesExecute listCategoriesExecute = new();
            var data = await listCategoriesExecute.ListCAtegoriesAsync(budgetID);
            return data;
        }
    }
}

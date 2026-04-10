using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.BudgetSettings;

namespace YnabApp.UI.Reflect
{
    public interface IReflectColumnView
    {
        IReflectView ReflectView { get; }

        void InitializeView(BudgetData budgetData, bool isYearlyReport, DateTime reportDate, PersonSetting personSelected, AccountData[] personAccounts, bool isHideZeroCategorties);

        void ShowReport(CategoryGroupData[] categoryDatas, TransactionData[] transactionDatas);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.UI.Reflect
{
    public interface IReflectColumnView
    {
        IReflectView ReflectView { get; }

        void InitializeView(bool isYearlyReport, DateTime reportDate, PersonSelected personSelected, bool isHideZeroCategorties);

        void ShowReport(CategoryGroupData[] categoryDatas, TransactionData[] transactionDatas);
    }
}

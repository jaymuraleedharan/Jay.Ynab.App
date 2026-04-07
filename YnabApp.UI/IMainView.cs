using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;

namespace YnabApp.UI
{
    public interface IMainView
    {
        BudgetData CurrentBudget { get; }

        void ShowAccountsView(BudgetData budgetData);

        void ShowReflectView(BudgetData budgetData);

        void ShowChartsView(BudgetData budgetData);
    }
}

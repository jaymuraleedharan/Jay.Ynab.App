using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;

namespace YnabApp.UI.ListAccounts
{
    public interface IListAccountsView
    {
        IMainView MainView { get; }

        void InitializeView(BudgetData budgetData);
    }
}

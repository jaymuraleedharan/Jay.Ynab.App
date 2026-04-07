using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;

namespace YnabApp.UI
{
    public interface IBudgetView
    {
        IMainView MainView { get; }

        BudgetData CurrentBudget { get; }

        void InitializeView(BudgetData budget, IMainView mainView);
    }
}

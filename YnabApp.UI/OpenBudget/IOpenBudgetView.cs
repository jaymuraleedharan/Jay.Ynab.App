using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.UI.OpenBudget
{
    public interface IOpenBudgetView
    {
        IMainView MainView { get; }

        void InitializeView();
    }
}

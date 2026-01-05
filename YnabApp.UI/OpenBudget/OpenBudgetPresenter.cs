using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;

namespace YnabApp.UI.OpenBudget
{
    public class OpenBudgetPresenter
    {
        private readonly IOpenBudgetView _view;

        public OpenBudgetPresenter(IOpenBudgetView view)
        {
            _view = view;
        }

        public async Task<BudgetData[]> GetAllBudgetsAsync()
        {
            ListBudgetsExecute exe = new();
            var data = await exe.ListBudgetsAsync();
            return data;
        }
    }
}

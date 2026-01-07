using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.UI.Reflect
{
    public class ReflectColumnPresenter
    {
        private readonly IReflectColumnView _view = null;

        public ReflectColumnPresenter(IReflectColumnView view)
        {
            _view = view;
        }

        public async Task GenerateCategoryReportAsync(CategoryGroupData[] categoryGroups, TransactionData[] transactions, DateTime reportDate, bool isMonthlyReport)
        {

        }
    }
}

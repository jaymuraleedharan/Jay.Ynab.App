using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.UI.Reflect
{
    public class ReflectPresenter
    {
        private readonly IReflectView _view = null;

        public ReflectPresenter(IReflectView view)
        {
            _view = view;
        }

        public async Task<CategoryGroupData[]> GetCategoriesAsync(string budgetID)
        {
            ListCategoriesExecute listCategoriesExecute = new();
            var data = await listCategoriesExecute.ListCAtegoriesAsync(budgetID);
            return data;
        }

        public async Task<TransactionData[]> GetTransactionsAsync(string budgetId, DateTime startDate)
        {
            ListTransactionsExecute exe = new();
            var data = await exe.GetTransactionsAsync(budgetId, startDate);
            return data;
        }

        public bool ClearCache()
        {
            CacheManager cache = new CacheManager(CacheType.Accounts);
            return cache.ClearCache();
        }
    }
}

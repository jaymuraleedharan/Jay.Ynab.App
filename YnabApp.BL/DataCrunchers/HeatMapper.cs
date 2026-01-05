using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.BL.DataCrunchers
{
    public class HeatMapper
    {
        BudgetData _budgetData = null;
        AccountData[] _accountDatas = null;
        CategoryGroupData[] _catGroupDatas = null;
        TransactionData[] _transactionDatas = null;

        public HeatMapper(BudgetData budgetData, AccountData[] accountDatas, CategoryGroupData[] catGroupDatas, TransactionData[] transactionDatas)
        {
            _budgetData = budgetData;
            _accountDatas = accountDatas;
            _catGroupDatas = catGroupDatas;
            _transactionDatas = transactionDatas;
        }

        public HeatMapData[] GenerateHeatMap()
        {
            List<HeatMapData> heatMapList = new();

            DateTime startDate = _transactionDatas.Min(t => t.TransDateTime);
            DateTime endDate = _transactionDatas.Max(t => t.TransDateTime);

            DateTime currentDate = startDate;

            while(DateTime.Compare(currentDate, endDate) <= 0)
            {
                var mapData = BuildHeatMapData(currentDate);
                
                heatMapList.Add(mapData);

                currentDate = currentDate.AddDays(1);
            }

            return heatMapList.ToArray();
        }

        private HeatMapData BuildHeatMapData(DateTime currentDate)
        {
            HeatMapData mapData = new();

            mapData.MapDate = currentDate;
            mapData.BuildAccounts(_accountDatas);
            mapData.BuildCategories(_catGroupDatas);

            var transactionsForDate = _transactionDatas.Where(t => t.TransDateTime.Equals(currentDate));
            foreach(var transData in transactionsForDate)
            {
                mapData.CrunchedAmount += transData.Amount;

                var acc = mapData.Accounts.Find(a => a.Id == transData.AccountId);
                acc.CrunchedAmount += transData.Amount;

                var cat = mapData.Categories.Find(c => c.Id == transData.CategoryId);
                cat.CrunchedAmount += transData.Amount;
            }

            return mapData;
        }
    }
}

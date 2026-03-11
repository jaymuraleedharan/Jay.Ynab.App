using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace YnabApp.BL.ListBudgets
{
    public class ListBudgetsExecute : ExecuteBase
    {
        public ListBudgetsExecute() : base() { }

        protected override string ExecuteUrl => "/budgets?include_accounts=false";

        public async Task<BudgetData[]> ListBudgetsAsync()
        {
            await base.ExecuteAsync();

            if (ParseRawResponse())
                throw new YnabException("Error while getting Budget List", GetError());

            return ConvertData();
        }

        protected BudgetData[] ConvertData()
        {
            List<BudgetData> list = new();

            JToken budgets = JsonResponse["data"]["budgets"];
            if (budgets != null)
                foreach (var budget in budgets)
                    list.Add(new BudgetData()
                    {
                        Id = budget["id"].ToString(),
                        Name = budget["name"].ToString(),
                        LastModifiedOn = budget["last_modified_on"].ToString(),
                        FirstMonth = budget["first_month"].ToString(),
                        LastMonth = budget["last_month"].ToString(),
                    });

            return list.ToArray();
        }
    }
}

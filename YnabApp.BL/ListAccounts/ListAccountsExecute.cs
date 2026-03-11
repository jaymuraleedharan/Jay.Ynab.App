using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace YnabApp.BL.ListAccounts
{
    public class ListAccountsExecute : ExecuteBase
    {
        public ListAccountsExecute() : base() { }

        protected override string ExecuteUrl
        {
            get { return $"/budgets/{BudgetID}/accounts"; }
        }

        public string BudgetID { get; set; }

        public async Task<AccountData[]> ListAccountsAsync(string budgetID)
        {
            BudgetID = budgetID;

            CacheManager cache = new CacheManager(CacheType.Accounts);
            string dataFromCache = await cache.GetDataFromCacheAsync();
            if (!string.IsNullOrEmpty(dataFromCache))
            {
                RawResponse = dataFromCache;
            }
            else
            {
                await base.ExecuteAsync();
                await cache.SaveToCacheAsync(base.RawResponse);
            }


            if (ParseRawResponse())
                throw new YnabException("Error while getting Account List", GetError());

            return ConvertData();
        }


        protected AccountData[] ConvertData()
        {
            List<AccountData> list = new();

            JToken accounts = JsonResponse["data"]["accounts"];
            if (accounts != null)
                foreach (var account in accounts)
                    list.Add(new AccountData()
                    {
                        Id = account["id"].ToString(),
                        Name = account["name"].ToString(),
                        Type = account["type"].ToString(),
                        IsClosed = Boolean.Parse(account["closed"].ToString()),
                        Balance = Decimal.Parse(account["balance"].ToString()) / 1000,
                        UnclearedBalance = Decimal.Parse(account["uncleared_balance"].ToString()) / 1000,
                        IsDeleted = Boolean.Parse(account["deleted"].ToString()),
                        Group = GetAccountGroup(account)
                    });

            return list.ToArray();
        }

        protected AccountGroup GetAccountGroup(JToken account)
        {
            switch (account["type"].ToString())
            {
                case "checking":
                case "savings":
                    if (account["name"].ToString().Contains("_HSA", StringComparison.InvariantCultureIgnoreCase))
                        return AccountGroup.Retirement;
                    else
                        return AccountGroup.Deposits;

                case "creditCard":
                case "otherLiability":
                     return AccountGroup.Liability;

                case "otherAsset":
                    return AccountGroup.Stocks;

                default:
                    return AccountGroup.Deposits;
            }
        }
    }
}

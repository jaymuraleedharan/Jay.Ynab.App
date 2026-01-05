using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace YnabApp.BL.ListTransactions
{
    public class ListTransactionsExecute : ExecuteBase
    {
        protected override string ExecuteUrl
        {
            get { return $"/budgets/{BudgetID}/transactions?since_date={StartDate.IsoFormat()}"; }
        }

        public string BudgetID { get; set; }

        public DateTime StartDate { get; set; }

        public async Task<TransactionData[]> GetTransactionsAsync(string budgetID, DateTime startDate)
        {
            BudgetID = budgetID;
            StartDate = startDate;

            await base.ExecuteAsync();

            if (IsError())
                throw new YnabException("Error while getting Transactions", GetError());

            return ConvertData();
        }


        protected TransactionData[] ConvertData()
        {
            List<TransactionData> list = new();

            JToken transactions = JsonResponse["data"]["transactions"];
            if (transactions != null)
                foreach (var transaction in transactions)
                    list.Add(new TransactionData()
                    {
                        Id = transaction["id"].ToString(),
                        TransactionDate = transaction["date"].ToString(),
                        TransDateTime = transaction["date"].ToString().ConvertToDateTimeFromIso(),
                        Amount = Decimal.Parse(transaction["amount"].ToString()) / 1000,
                        Memo = transaction["memo"].ToString(),
                        Cleared = transaction["cleared"].ToString(),
                        IsApproved = Boolean.Parse(transaction["approved"].ToString()),
                        AccountId = transaction["account_id"].ToString(),
                        AccountName = transaction["account_name"].ToString(),
                        PayeeId = transaction["payee_id"].ToString(),
                        PayeeName = transaction["payee_name"].ToString(),
                        CategoryId = transaction["category_id"].ToString(),
                        CategoryName = transaction["category_name"].ToString(),
                    }) ;

            return list.ToArray();
        }
    }
}

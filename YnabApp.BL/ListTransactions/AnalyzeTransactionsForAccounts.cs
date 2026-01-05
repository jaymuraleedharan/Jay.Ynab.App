using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListAccounts;

namespace YnabApp.BL.ListTransactions
{
    public class AnalyzeTransactionsForAccounts
    {
        public AnalyzeTransactionsForAccounts()
        {

        }

        public async Task ProcessAsync(AccountData[] accounts, TransactionData[] transactions)
        {
            await Task.Run(() =>
            {
                foreach (var account in accounts)
                {
                    account.CreditTotal = transactions.Where(t => t.AccountId == account.Id && t.Amount >= 0).Sum(c => c.Amount);
                    account.DebitTotal = transactions.Where(t => t.AccountId == account.Id && t.Amount < 0).Sum(c => c.Amount);
                    account.NetChange = account.CreditTotal + account.DebitTotal;
                }
            });

        }
    }
}

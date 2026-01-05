using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListTransactions
{
    public class TransactionData
    {
        public string Id { get; set; }

        public string TransactionDate { get; set; }

        public DateTime TransDateTime { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }

        public string Cleared { get; set; }

        public bool IsApproved { get; set; }

        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string PayeeId { get; set; }

        public string PayeeName { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

    }
}

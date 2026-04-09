using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListAccounts
{
    public class AccountData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsClosed { get; set; }

        public decimal Balance { get; set; }

        public decimal UnclearedBalance { get; set; }

        public bool IsDeleted { get; set; }

        public decimal CreditTotal { get; set; }

        public decimal DebitTotal { get; set; }

        public decimal NetChange { get; set; }

        public decimal CrunchedAmount { get; set; }

        public AccountGroup Group { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public enum AccountGroup
    {
        Deposits = 0,
        Stocks = 1,
        HomeEquity = 3,
        Liability = 4,
        Retirement = 5
    }
}

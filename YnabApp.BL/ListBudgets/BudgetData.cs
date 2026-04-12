using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListBudgets
{
    public class BudgetData
    {
        private string _firstMonth, _lastMonth;

        public string Id { get; set; }

        public string Name { get; set; }

        public string LastModifiedOn { get; set; }

        public string FirstMonth 
        {
            get { return _firstMonth; }
            set 
            {
                _firstMonth = value;
                StartDate = new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(5, 2)), int.Parse(value.Substring(8, 2)));
                FirstFullYear = StartDate.Month == 1 ? StartDate.Year : StartDate.Year + 1;
            } 
        }

        public string LastMonth
        {
            get { return _lastMonth; }
            set
            {
                _lastMonth = value;
                EndDate = new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(5, 2)), int.Parse(value.Substring(8, 2)));
            }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int FirstFullYear { get; set; }

        public string CurrencySymbol { get; set; }

        public string CurrencyFormat
        {
            get { return $"{CurrencySymbol} #,###,##0.00"; }
        }

        public string FormatAmount(decimal amount)
        {
            return amount.ToString(CurrencyFormat);
        }
    }
}

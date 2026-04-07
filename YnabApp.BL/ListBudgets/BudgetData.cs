using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListBudgets
{
    /* 
      {
                "id": "d4b2040a-64e0-4936-bd03-0bf3aec84dc3",
                "name": "Jay's Budget",
                "last_modified_on": "2026-04-04T17:06:26Z",
                "first_month": "2016-12-01",
                "last_month": "2026-04-01",
                "date_format": {
                    "format": "MM/DD/YYYY"
                },
                "currency_format": {
                    "iso_code": "USD",
                    "example_format": "123,456.78",
                    "decimal_digits": 2,
                    "decimal_separator": ".",
                    "symbol_first": true,
                    "group_separator": ",",
                    "currency_symbol": "$",
                    "display_symbol": true
                }
            },
    */
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

    }
}

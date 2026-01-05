using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListBudgets
{
    public class BudgetData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastModifiedOn { get; set; }

        public string FirstMonth { get; set; }

        public string LastMonth { get; set; }
    }
}

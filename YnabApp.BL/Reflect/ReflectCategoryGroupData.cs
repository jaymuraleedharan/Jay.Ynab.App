using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.Reflect
{
    public record ReflectCategoryGroupData(string CategoryGroupName)
    {
        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } } 
    }

    public record ReflectCategoryData(string CategoryGroupName, string CategoryName)
    {
        public string FullCategoryName => $"{CategoryGroupName} :: {CategoryName}";

        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } }
    };
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListCategories;

namespace YnabApp.BL.Reflect
{
    public record ReflectCategoryGroupData(string ID, string CategoryGroupName, CategoryGroupData CategoryGroup)
    {
        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } } 
    }

    public record ReflectCategoryData(string ID, string CategoryGroupName, string CategoryName, CategoryData Category)
    {
        public string FullCategoryName => $"{CategoryGroupName} ▶ {CategoryName}";

        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } }
    };
}

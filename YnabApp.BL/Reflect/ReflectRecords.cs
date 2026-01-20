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

        public decimal MonthlyAmountAccurate(DateTime reportDate)
        {
            if (reportDate.Year == DateTime.Today.Year)
                return Amount / DateTime.Today.Month;
            else
                return MonthlyAmount;
        }

        public decimal Percentage { get; set; }
    }

    public record ReflectCategoryData(string ID, string CategoryGroupName, string CategoryName, CategoryData Category)
    {
        public string FullCategoryName => $"{CategoryGroupName} ▶ {CategoryName}";

        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } }

        public decimal MonthlyAmountAccurate(DateTime reportDate)
        {
            if (reportDate.Year == DateTime.Today.Year)
                return Amount / DateTime.Today.Month;
            else
                return MonthlyAmount;
        }

        public decimal Percentage { get; set; }
    };

    public record ReflectIncomeData(string payeeName, string accountName)
    {
        public string FullName => $"{payeeName} -> {accountName}";

        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } }

        public decimal MonthlyAmountAccurate(DateTime reportDate)
        {
            if (reportDate.Year == DateTime.Today.Year)
                return Amount / DateTime.Today.Month;
            else
                return MonthlyAmount;
        }

        public decimal Percentage { get; set; }
    }

    public record ReflectSummaryData(string SummaryName)
    {
        public decimal Amount { get; set; }

        public decimal MonthlyAmount { get { return Amount / 12; } }

        public decimal MonthlyAmountAccurate(DateTime reportDate)
        {
            if (reportDate.Year == DateTime.Today.Year)
                return Amount / DateTime.Today.Month;
            else
                return MonthlyAmount;
        }

        public decimal Percentage { get; set; }
    }
}

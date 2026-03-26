using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.Reflect
{
    public class ReflectChartPoint
    {
        public ReflectChartPoint(DateTime StartDate, DateTime EndDate, Boolean isYearly)
        {
            TimeChunk = new ReflectTimeChunk(StartDate, EndDate, isYearly);
        }

        public ReflectTimeChunk TimeChunk { get; set; }

        public ReflectChartSummary Summary { get; set; }

        public Dictionary<string, decimal> CategoryGroup { get; set; } = new Dictionary<string, decimal>();
    }

    public record ReflectTimeChunk(DateTime StartDate, DateTime EndDate, Boolean isYearly)
    {
        public string Label
        {
            get
            {
                if (isYearly)
                    return StartDate.Year.ToString();
                else
                    return StartDate.ToString("MMM/yyyy");
            }
        }
    }

    public record ReflectChartSummary(decimal Income, decimal Expense, decimal Savings)
    {
    } 
}

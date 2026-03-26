using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.Reflect;
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class ReflectGraphForm : Form
    {
        internal List<ReflectChartPoint> ChartPoints { get; set; }

        public ReflectGraphForm()
        {
            InitializeComponent();
        }

        public static void ShowModal(List<ReflectChartPoint> chartPoints)
        {
            ReflectGraphForm reflectGraph = new ReflectGraphForm();
            reflectGraph.Activate();
            reflectGraph.ChartPoints = chartPoints;
            reflectGraph.ShowGraphs();
            reflectGraph.ShowDialog();
        }

        public void ShowGraphs()
        {
            this.Text = ChartPoints[0].TimeChunk.isYearly ? "Yearly Summary Chart" : "Monthly Summary Chart";

            //CHART
            var ynabChart = new Chart();
            ynabChart.BackColor = SystemColors.ControlLight;
            ynabChart.Dock = DockStyle.Fill;
            ynabChart.BackGradientStyle = GradientStyle.DiagonalRight;
            ynabChart.Legends.Add(new Legend { Font = this.Font, Docking = Docking.Top, Alignment = StringAlignment.Center, LegendStyle = LegendStyle.Table });

            //CHART AREA
            var ynabChartArea = new ChartArea();
            ynabChartArea.IsSameFontSizeForAllAxes = true;

            ynabChartArea.AxisX.TitleFont = this.Font;
            ynabChartArea.AxisX.IsMarginVisible = true;
            ynabChartArea.AxisX.IsInterlaced = false;

            ynabChartArea.AxisY.TitleFont = this.Font;
            if (ChartPoints[0].TimeChunk.isYearly)
                ynabChartArea.AxisY.Interval = 50000;
            else
                ynabChartArea.AxisY.Interval = 5000;

            ynabChartArea.AxisY.IsStartedFromZero = true;
            ynabChartArea.AxisY.LabelStyle.Format = "$ #,###,000";

            ynabChartArea.Area3DStyle.Enable3D = false;
            ynabChartArea.Area3DStyle.IsRightAngleAxes = true;
            ynabChartArea.Area3DStyle.Inclination = 0;
            ynabChartArea.Area3DStyle.Rotation = 0;
            ynabChartArea.Area3DStyle.LightStyle = LightStyle.Realistic;
            ynabChart.ChartAreas.Add(ynabChartArea);

            //CHART SERIES
            Series incomeSeries = new Series
            {
                Name = "Income",
                Color =  Color.Green,
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                LegendText = "Income",
                IsVisibleInLegend = true
            };
            ynabChart.Series.Add(incomeSeries);

            Series expenseSeries = new Series
            {
                Name = "Expense",
                Color = Color.Red,
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font
            };
            ynabChart.Series.Add(expenseSeries);

            Series savingsSeries = new Series
            {
                Name = "Savings",
                Color = Color.Blue,
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font
            };
            ynabChart.Series.Add(savingsSeries);

            foreach (var point in ChartPoints)
            {
                incomeSeries.Points.Add(new DataPoint { 
                    YValues = new double[] { (double)point.Summary.Income }, 
                        AxisLabel = point.TimeChunk.Label });

                expenseSeries.Points.Add(new DataPoint { 
                    YValues = new double[] { (double)point.Summary.Expense }, 
                        AxisLabel = point.TimeChunk.Label });

                savingsSeries.Points.Add(new DataPoint { 
                    YValues = new double[] { (double)point.Summary.Savings }, 
                        AxisLabel = point.TimeChunk.Label });
            }

            //Random random = new Random();
            //DateTime startDate = DateTime.Now.AddMonths(-10);
            //for (int pointIndex = 0; pointIndex < 10; pointIndex++)
            //{
            //    int incomeValue = random.Next(3000, 4000);
            //    int expenseValue = random.Next(incomeValue/2, incomeValue);
            //    int savingsValue = incomeValue - expenseValue;
            //    string label = startDate.AddMonths(pointIndex).ToString("MMM/yyyy");

            //    //incomeSeries.Points.AddY(incomeValue);
            //    incomeSeries.Points.Add( new DataPoint { YValues = new double[] { incomeValue }, AxisLabel = label } );

            //    //expenseSeries.Points.AddY(expenseValue);
            //    expenseSeries.Points.Add(new DataPoint { YValues = new double[] { expenseValue }, AxisLabel = label });

            //    //savingsSeries.Points.AddY(savingsValue);
            //    savingsSeries.Points.Add(new DataPoint { YValues = new double[] { savingsValue }, AxisLabel = label });
            //}

            this.Controls.Add(ynabChart);
        }

    }
}


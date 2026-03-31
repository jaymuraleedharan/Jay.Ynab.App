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
using YnabApp.BL;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.Reflect;
using YnabApp.UI;
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class ReflectGraphForm : FormBase, IReflectGraphView
    {
        BudgetData _budgetData = null;

        internal List<ReflectChartPoint> ChartPoints { get; set; }
        internal List<ReflectCategoryData> CategoryResults { get; set; }

        public IMainView MainView
        {
            get { return this.MdiParent as IMainView; }
        }

        public ReflectGraphForm()
        {
            InitializeComponent();
        }


        public void InitializeView(BudgetData budgetData)
        {
            _budgetData = budgetData;
            ResetUI();
        }

        private void ResetUI()
        {
            c_dtPckCustomStart.Value = DateTime.Today;
            c_dtPckCustomStart.Value = DateTime.Today.AddMonths(-12);
        }

        private bool IsYearly
        {
            get
            {
                if (c_radBtnByMonthThisYear.Checked)
                    return false;

                else if (c_radBtnByMonthLastYear.Checked)
                    return false;

                else if (c_radBtnCustom.Checked)
                    return false;

                else
                    return true;
            }
        }

        private DateTime StartDate
        {
            get
            {
                if (c_radBtnByMonthThisYear.Checked)
                    return new DateTime(DateTime.Today.Year, 1, 1);

                else if (c_radBtnByMonthLastYear.Checked)
                    return new DateTime(DateTime.Today.Year - 1, 1, 1);

                else if (c_radBtnCustom.Checked)
                    return c_dtPckCustomStart.Value;

                else
                    return new DateTime(2016, 1, 1);
            }
        }

        private DateTime EndDate
        {
            get
            {
                if (c_radBtnByMonthThisYear.Checked)
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);

                else if (c_radBtnByMonthLastYear.Checked)
                    return new DateTime(DateTime.Today.Year - 1, 12, 31);

                else if (c_radBtnCustom.Checked)
                    return c_dtPckCustomEnd.Value;

                else
                    return DateTime.Today;
            }
        }

        private List<DateTime> GetSelectedDatesForCharts()
        {
            List<DateTime> dates = new List<DateTime>();

            if (IsYearly)
            {
                DateTime loopDate = StartDate;
                while (loopDate <= EndDate)
                {
                    dates.Add(loopDate);
                    loopDate = loopDate.AddYears(1);
                }
            }
            else
            {
                DateTime loopDate = StartDate;
                while (loopDate <= EndDate)
                {
                    dates.Add(loopDate);
                    loopDate = loopDate.AddMonths(1);
                }
            }
            return dates;
        }

        private PersonSelected GetPersonSelected()
        {
            if (c_radioPersonAll.Checked)
                return PersonSelected.All;
            else if (c_radioPersonJay.Checked)
                return PersonSelected.Jay;
            else if (c_radioPersonShar.Checked)
                return PersonSelected.Shar;
            else
                return PersonSelected.All;
        }

        public async Task<CategoryGroupData[]> GetCategoriesAsync(string budgetID)
        {
            ListCategoriesExecute listCategoriesExecute = new();
            var data = await listCategoriesExecute.ListCAtegoriesAsync(budgetID);
            return data;
        }

        public async Task<TransactionData[]> GetTransactionsAsync(string budgetId, DateTime startDate)
        {
            ListTransactionsExecute exe = new();
            var data = await exe.GetTransactionsAsync(budgetId, startDate);
            return data;
        }

        public bool ClearCache()
        {
            CacheManager cache = new CacheManager(CacheType.Accounts);
            return cache.ClearCache();
        }

        private async void btnShowGraph_Click(object sender, EventArgs e)
        {
            try
            {
                btnShowGraph.Enabled = false;

                //BUILDING PARAMETERS
                var datesSelected = GetSelectedDatesForCharts();
                var personSelected = GetPersonSelected();
                Person person = ReflectPresenter.GetPerson(personSelected);

                //DOWNLOADING DATA FROM YNAB
                var categoriesData = await GetCategoriesAsync(_budgetData.Id);
                var transactionsData = await GetTransactionsAsync(_budgetData.Id, StartDate);

                //BUILDING CHART DATA
                ChartPoints = new List<ReflectChartPoint>();
                DataCruncherForCharts dataCruncher = new DataCruncherForCharts();
                decimal TotalIncome = 0;

                foreach (var dateSel in datesSelected)
                {
                    DateTime chartPointStartDate = dateSel;
                    DateTime chartPointEndDate = IsYearly ? dateSel.AddYears(1).AddDays(-1) : dateSel.AddMonths(1).AddDays(-1);

                    ReflectChartPoint chartPoint = null;
                    chartPoint = new ReflectChartPoint(chartPointStartDate, chartPointEndDate, IsYearly);
                    
                    chartPoint.Summary = await dataCruncher.GenerateSummaryDataAsync(categoriesData, transactionsData, IsYearly, chartPointStartDate, person);
                    TotalIncome += chartPoint.Summary.Income;

                    chartPoint.CategoryGroup = await dataCruncher.GenerateCategoryGroupDataAsync(categoriesData, transactionsData, IsYearly, chartPointStartDate, person);

                    ChartPoints.Add(chartPoint);
                }

                DateTime catStartDate = ChartPoints.OrderBy(c => c.TimeChunk.StartDate).First().TimeChunk.StartDate;
                DateTime catEndDate = ChartPoints.OrderBy(c => c.TimeChunk.EndDate).Last().TimeChunk.EndDate;
                CategoryResults = await dataCruncher.CrunchCategroyData2Async(categoriesData, transactionsData, catStartDate, catEndDate, TotalIncome, person);

                //SHOWING GRAPH
                ShowGraphs();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                btnShowGraph.Enabled = true;
            }
        }

        private Chart CreateChart()
        {
            //CHART
            var ynabChart = new Chart();
            ynabChart.Dock = DockStyle.Fill;

            //APPEARANCE
            ynabChart.BackColor = SystemColors.ControlLight;
            ynabChart.BackSecondaryColor = SystemColors.ControlDark;
            ynabChart.BackGradientStyle = GradientStyle.LeftRight;
            ynabChart.BackHatchStyle = ChartHatchStyle.None;

            ynabChart.BorderlineDashStyle = ChartDashStyle.NotSet;
            ynabChart.IsSoftShadows = false;

            ynabChart.Legends.Add(new Legend { Font = this.Font, Docking = Docking.Top, Alignment = StringAlignment.Center, LegendStyle = LegendStyle.Table });

            //CHART AREA
            var ynabChartArea = new ChartArea();

            ynabChartArea.BackColor = SystemColors.ControlLightLight;
            

            ynabChartArea.IsSameFontSizeForAllAxes = true;
            ynabChartArea.AxisX.TitleFont = this.Font;            

            ynabChartArea.AxisX.IsMarginVisible = true;
            ynabChartArea.AxisX.IsInterlaced = false;
            
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

            return ynabChart;
        }


        private Chart CreateCategoryChart()
        {
            //CHART
            var ynabChart = new Chart();
            ynabChart.Dock = DockStyle.Fill;

            //APPEARANCE
            ynabChart.BackColor = SystemColors.ControlLight;
            ynabChart.BackSecondaryColor = SystemColors.ControlDark;
            ynabChart.BackGradientStyle = GradientStyle.LeftRight;
            ynabChart.BackHatchStyle = ChartHatchStyle.None;

            ynabChart.BorderlineDashStyle = ChartDashStyle.NotSet;
            ynabChart.IsSoftShadows = false;

            ynabChart.Legends.Add(new Legend { Font = this.Font, Docking = Docking.Top, Alignment = StringAlignment.Center, LegendStyle = LegendStyle.Table });

            //CHART AREA
            var ynabChartArea = new ChartArea();

            ynabChartArea.BackColor = SystemColors.ControlLightLight;

            ynabChartArea.IsSameFontSizeForAllAxes = true;

            ynabChartArea.AxisX.TitleFont = this.Font;
            ynabChartArea.AxisY.LabelStyle.Format = "$ #,###,000";
            ynabChartArea.AxisX.IsMarginVisible = true;
            ynabChartArea.AxisX.IsInterlaced = false;
            ynabChartArea.AxisX.MajorGrid.Enabled = false;
            ynabChartArea.AxisX.MinorGrid.Enabled = false;


            ynabChartArea.AxisY.IsMarginVisible = false;            
            ynabChartArea.AxisY.LabelStyle.IntervalType = DateTimeIntervalType.NotSet;
            ynabChartArea.AxisY.MajorGrid.Enabled = true;
            ynabChartArea.AxisY.MinorGrid.Enabled = false;
            ynabChartArea.AxisY.LineDashStyle = ChartDashStyle.NotSet;
            ynabChartArea.AxisY.IntervalType = DateTimeIntervalType.NotSet;
            ynabChartArea.AxisY.Interval = 0;

            ynabChart.ChartAreas.Add(ynabChartArea);

            return ynabChart;
        }

        private Series CreateIncomeSeries()
        {
            return new Series
            {
                Name = "Income",
                Color = Color.LightGreen, // ReflectColorizer.GetSummaryBackColor("All Incomes"), //Color.Green,
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Green,
                ShadowOffset = 2,
            };
        }

        private Series CreateExpenseSeries()
        {
            return new Series
            {
                Name = "Expense",
                Color = Color.LightSalmon, // ReflectColorizer.GetSummaryBackColor("All Expenses"), //Color.Red,
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Salmon,
                ShadowOffset = 2
            };
        }

        private Series CreateSavingsSeries()
        {
            return new Series
            {
                Name = "Savings",
                Color = Color.LightBlue, // ReflectColorizer.GetSummaryBackColor("Savings"),               //Color.Blue,
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Blue,
                ShadowOffset = 2
            };
        }

        private Series CreateNecessitiesSeries()
        {
            return new Series
            {
                Name = "Necessities",
                Color = Color.LightYellow, // ReflectColorizer.GetBackColor("NECESSITIES"),
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Gray,
                ShadowOffset = 1
            };
        }

        private Series CreateDiscretionarySeries()
        {
            return new Series
            {
                Name = "Discretionary",
                Color = Color.LightCoral, // ReflectColorizer.GetBackColor("DISCRETIONARY"),
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Gray,
                ShadowOffset = 1
            };
        }

        private Series CreateHelpSeries()
        {
            return new Series
            {
                Name = "Help",
                Color = Color.LightBlue, // ReflectColorizer.GetBackColor("HELP"),
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Gray,
                ShadowOffset = 1
            };
        }

        private Series CreateCategorySeries()
        {
            return new Series
            {
                Name = "Major Expense Categories",
                Color = Color.LightCoral, // ReflectColorizer.GetBackColor("HELP"),
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                BorderWidth = 4,
                LabelFormat = "$ #,###,000",
                Font = this.Font,
                ShadowColor = Color.Gray,
                ShadowOffset = 1
            };
        }

        public void ShowGraphs()
        {
            this.Text = ChartPoints[0].TimeChunk.isYearly ? "Yearly Summary Chart" : "Monthly Summary Chart";

            //SUMMARY CHART
            var summaryChart = CreateChart();

            //CATEGORY CHART
            var categoryChart = CreateCategoryChart();

            Series necessitiesSeries = CreateNecessitiesSeries();
            summaryChart.Series.Add(necessitiesSeries);

            Series discretionarySeries = CreateDiscretionarySeries();
            summaryChart.Series.Add(discretionarySeries);

            Series helpSeries = CreateHelpSeries();
            summaryChart.Series.Add(helpSeries);

            Series incomeSeries = CreateIncomeSeries();
            summaryChart.Series.Add(incomeSeries);

            Series expenseSeries = CreateExpenseSeries();
            summaryChart.Series.Add(expenseSeries);

            //Series savingsSeries = CreateSavingsSeries();
            //ynabChart.Series.Add(savingsSeries);

            Series categorySeries = CreateCategorySeries();
            categoryChart.Series.Add(categorySeries);

            //var sortedChartPoints = ChartPoints.OrderByDescending(x => x.TimeChunk.StartDate).ToList();

            //ADDING POINTS TO CHARTS
            foreach (var point in ChartPoints)
            {
                incomeSeries.Points.Add(new DataPoint
                {
                    YValues = new double[] { (double)point.Summary.Income },
                    AxisLabel = point.TimeChunk.Label
                });

                expenseSeries.Points.Add(new DataPoint
                {
                    YValues = new double[] { (double)point.Summary.Expense },
                    AxisLabel = point.TimeChunk.Label
                });

                //savingsSeries.Points.Add(new DataPoint
                //{
                //    YValues = new double[] { (double)point.Summary.Savings },
                //    AxisLabel = point.TimeChunk.Label
                //});

                necessitiesSeries.Points.Add(new DataPoint
                {
                    YValues = new double[] { (double)point.CategoryGroup.Necessities },
                    AxisLabel = point.TimeChunk.Label
                });

                discretionarySeries.Points.Add(new DataPoint
                {
                    YValues = new double[] { (double)point.CategoryGroup.Discretionary },
                    AxisLabel = point.TimeChunk.Label
                });

                helpSeries.Points.Add(new DataPoint
                {
                    YValues = new double[] { (double)point.CategoryGroup.Help },
                    AxisLabel = point.TimeChunk.Label
                });
            }

            //Ignore % less than 1% to avoid cluttering the graph with too many categories
            foreach (var catData in CategoryResults.Where(c => c.Percentage >= 1))
            {
                categorySeries.Points.Add(new DataPoint
                {
                    YValues = new double[] { (double)catData.Amount },
                    Label = $"{catData.CategoryGroupName}-{catData.CategoryName} | {catData.Amount.ToString("$ #,###,##0")} | {catData.Percentage.ToString("#0")}%",
                    Color = ReflectColorizer.GetBackColor(catData.CategoryGroupName)
                });
            }

            c_splitContainer.Panel1.Controls.Clear();
            c_splitContainer.Panel1.Controls.Add(summaryChart);

            c_splitContainer.Panel2.Controls.Clear();
            c_splitContainer.Panel2.Controls.Add(categoryChart);

        }
    }
    
}


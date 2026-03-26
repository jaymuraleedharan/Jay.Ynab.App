using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.Reflect;
using YnabApp.UI;
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class ReflectForm : FormBase, IReflectView
    {
        private readonly ReflectPresenter _presenter = null;
        BudgetData _budgetData = null;
        List<ReflectColumnControl> ReflectColumnControls = new List<ReflectColumnControl>();

        public ReflectForm()
        {
            InitializeComponent();

            _presenter = new ReflectPresenter(this);
        }

        private void ReflectForm_Load(object sender, EventArgs e)
        {
            c_chkBoxData1.Tag = c_dtPckData1;
            c_chkBoxData2.Tag = c_dtPckData2;
            c_chkBoxData3.Tag = c_dtPckData3;
            c_chkBoxData4.Tag = c_dtPckData4;
            c_chkBoxData5.Tag = c_dtPckData5;
            c_chkBoxData6.Tag = c_dtPckData6;



        }

        public IMainView MainView
        {
            get { return this.MdiParent as IMainView; }
        }

        public void InitializeView(BudgetData budgetData)
        {
            _budgetData = budgetData;

            ResetUI();
        }

        //------------------------------------------------//

        private void ResetUI()
        {
            c_radioDurationYearly.Checked = true;

            ShowLastMonths(DateTime.Today);
        }

        private async void c_btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateControls();

                var datesSelected = GetSelectedDates();
                var personSelected = GetPersonSelected();

                //CLEAR REFLECT CONTROLS TABLE
                c_reflectControlsTable.RowCount = 0;
                c_reflectControlsTable.ColumnCount = 0;
                c_reflectControlsTable.Controls.Clear();
                c_reflectControlsTable.RowStyles.Clear();
                c_reflectControlsTable.ColumnStyles.Clear();

                //CREATING REFLECTCOLUMNCONTROLS BASED ON THE NUMBER OF DATES SELECTED
                c_reflectControlsTable.RowCount = 1;
                c_reflectControlsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                c_reflectControlsTable.ColumnCount = datesSelected.Count;
                float columnWidthPercentage = 100 / datesSelected.Count;

                int controlCounter = 0;
                foreach (var reportDate in datesSelected)
                {
                    c_reflectControlsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidthPercentage));
                    ReflectColumnControl reflectColumnControl = new ReflectColumnControl();
                    reflectColumnControl.InitializeView(c_radioDurationYearly.Checked, reportDate, personSelected, c_chkBoxHideZeroCategories.Checked);

                    c_reflectControlsTable.Controls.Add(reflectColumnControl, controlCounter, 0);
                    reflectColumnControl.Dock = DockStyle.Fill;
                    controlCounter++;
                }

                //DOWNLOADING DATA FROM YNAB
                var categoriesData = await _presenter.GetCategoriesAsync(_budgetData.Id);

                DateTime earliestDate = GetEarliestDate();

                var transactionsData = await _presenter.GetTransactionsAsync(_budgetData.Id, earliestDate);

                //RENDERING DATA
                foreach (Control ctrl in c_reflectControlsTable.Controls)
                {
                    var reflectCtrl = ctrl as ReflectColumnControl;
                    if (reflectCtrl != null)
                        reflectCtrl.ShowReport(categoriesData, transactionsData);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        private void ValidateControls()
        {
            if (!c_chkBoxData1.Checked && !c_chkBoxData2.Checked && !c_chkBoxData3.Checked)
            {
                throw new Exception("At least one Date must be selected.");
            }
        }

        private DateTime GetEarliestDate()
        {
            DateTime earliestDate = DateTime.MaxValue;
            if (c_radioDurationYearly.Checked)
            {
                if (c_chkBoxData1.Checked && c_dtPckData1.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData1.Value.Year, 1, 1);

                if (c_chkBoxData2.Checked && c_dtPckData2.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData3.Value.Year, 1, 1);

                if (c_chkBoxData3.Checked && c_dtPckData3.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData3.Value.Year, 1, 1);

                if (c_chkBoxData4.Checked && c_dtPckData4.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData4.Value.Year, 1, 1);

                if (c_chkBoxData5.Checked && c_dtPckData5.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData5.Value.Year, 1, 1);

                if (c_chkBoxData6.Checked && c_dtPckData6.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData6.Value.Year, 1, 1);

            }
            else
            {
                if (c_chkBoxData1.Checked && c_dtPckData1.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData1.Value.Year, c_dtPckData1.Value.Month, 1);

                if (c_chkBoxData2.Checked && c_dtPckData2.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData2.Value.Year, c_dtPckData2.Value.Month, 1);

                if (c_chkBoxData3.Checked && c_dtPckData3.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData3.Value.Year, c_dtPckData3.Value.Month, 1);

                if (c_chkBoxData4.Checked && c_dtPckData4.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData4.Value.Year, c_dtPckData4.Value.Month, 1);

                if (c_chkBoxData5.Checked && c_dtPckData5.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData5.Value.Year, c_dtPckData5.Value.Month, 1);

                if (c_chkBoxData6.Checked && c_dtPckData6.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData6.Value.Year, c_dtPckData6.Value.Month, 1);
            }

            return earliestDate;
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

        private void c_selectLastThreeYears_Click(object sender, EventArgs e)
        {
            try
            {
                ShowLastYears(DateTime.Today);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_selectLastThreeMonths_Click(object sender, EventArgs e)
        {
            try
            {
                ShowLastMonths(DateTime.Today);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_chkBoxData_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (cb != null)
                {
                    DateTimePicker dp = cb.Tag as DateTimePicker;
                    if (dp != null)
                        dp.Enabled = cb.Checked;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowLastMonths(DateTime start)
        {
            c_radioDurationMonthly.Checked = true;

            c_dtPckData1.Value = start;
            c_dtPckData2.Value = start.AddMonths(-1);
            c_dtPckData3.Value = start.AddMonths(-2);
            c_dtPckData4.Value = start.AddMonths(-3);
            c_dtPckData5.Value = start.AddMonths(-4);
            c_dtPckData6.Value = start.AddMonths(-5);
        }

        private void ShowLastYears(DateTime start)
        {
            c_radioDurationYearly.Checked = true;

            c_dtPckData1.Value = start;
            c_dtPckData2.Value = start.AddYears(-1);
            c_dtPckData3.Value = start.AddYears(-2);
            c_dtPckData4.Value = start.AddYears(-3);
            c_dtPckData5.Value = start.AddYears(-4);
            c_dtPckData6.Value = start.AddYears(-5);
        }

        private List<DateTime> GetSelectedDates()
        {
            List<DateTime> dates = new List<DateTime>();

            if (c_chkBoxData1.Checked)
                dates.Add(c_dtPckData1.Value);
            if (c_chkBoxData2.Checked)
                dates.Add(c_dtPckData2.Value);
            if (c_chkBoxData3.Checked)
                dates.Add(c_dtPckData3.Value);
            if (c_chkBoxData4.Checked)
                dates.Add(c_dtPckData4.Value);
            if (c_chkBoxData5.Checked)
                dates.Add(c_dtPckData5.Value);
            if (c_chkBoxData6.Checked)
                dates.Add(c_dtPckData6.Value);

            return dates;
        }

        //Contrary to the button name, this is actually for moving forward in time
        private void c_moveBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (c_radioDurationYearly.Checked)
                {
                    if (c_dtPckData1.Value.Year == DateTime.Today.Year)
                        return;
                    DateTime start = c_dtPckData1.Value.AddYears(1);
                    ShowLastYears(start);
                }
                else
                {
                    if (c_dtPckData1.Value.Year == DateTime.Today.Year && c_dtPckData1.Value.Month == DateTime.Today.Month)
                        return;
                    DateTime start = c_dtPckData1.Value.AddMonths(1);
                    ShowLastMonths(start);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        //Contrary to the button name, this is actually for moving back in time
        private void c_moveForwardButton_Click(object sender, EventArgs e)
        {
            try
            {
                int minYear = 2016, minMonth = 1;

                if (c_radioDurationYearly.Checked)
                {
                    if (c_dtPckData6.Value.Year == minYear)
                        return;
                    DateTime start = c_dtPckData1.Value.AddYears(-1);
                    ShowLastYears(start);
                }
                else
                {
                    if (c_dtPckData6.Value.Year == minYear && c_dtPckData6.Value.Month == minMonth)
                        return;
                    DateTime start = c_dtPckData1.Value.AddMonths(-1);
                    ShowLastMonths(start);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_btnClearCache_Click(object sender, EventArgs e)
        {
            try
            {
                var isSuccess = _presenter.ClearCache();
                if (isSuccess)
                    MessageBox.Show("Cache cleared successfully", "Clear Cache", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to clear Cache", "Clear Cache", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private async void btnShowGraph_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateControls();

                //BUILDING PARAMETERS
                var datesSelected = GetSelectedDatesForCharts();
                DateTime earliestDate = GetEarliestDateForCharts();
                var personSelected = GetPersonSelected();
                Person person = ReflectPresenter.GetPerson(personSelected);
                bool isYearly = c_radioDurationYearly.Checked;

                //DOWNLOADING DATA FROM YNAB
                var categoriesData = await _presenter.GetCategoriesAsync(_budgetData.Id);
                var transactionsData = await _presenter.GetTransactionsAsync(_budgetData.Id, earliestDate);

                //BUILDING CHART DATA
                List<ReflectChartPoint> chartPoints = new List<ReflectChartPoint>();                
                DataCruncherForCharts dataCruncher = new DataCruncherForCharts();                

                foreach (var dateSel in datesSelected)
                {
                    DateTime dateAdjusted  = new DateTime(dateSel.Year, dateSel.Month, 1);

                    ReflectChartPoint chartPoint = null;
                    if (c_radioDurationYearly.Checked)
                        chartPoint = new ReflectChartPoint(dateAdjusted, dateAdjusted.AddYears(1).AddDays(-1), isYearly);
                    else
                        chartPoint = new ReflectChartPoint(dateAdjusted, dateAdjusted.AddMonths(1).AddDays(-1), isYearly);

                    chartPoint.Summary = dataCruncher.GenerateSummaryData(categoriesData, transactionsData, isYearly, dateAdjusted, person);

                    chartPoints.Add(chartPoint);
                }

                //SHOWING GRAPH
                ReflectGraphForm.ShowModal(chartPoints);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private List<DateTime> GetSelectedDatesForCharts()
        {
            List<DateTime> dates = new List<DateTime>();

            dates.Add(c_dtPckData1.Value);
            dates.Add(c_dtPckData2.Value);
            dates.Add(c_dtPckData3.Value);
            dates.Add(c_dtPckData4.Value);
            dates.Add(c_dtPckData5.Value);
            dates.Add(c_dtPckData6.Value);

            return dates;
        }

        private DateTime GetEarliestDateForCharts()
        {
            DateTime earliestDate = DateTime.MaxValue;
            if (c_radioDurationYearly.Checked)
            {
                if (c_dtPckData1.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData1.Value.Year, 1, 1);

                if (c_dtPckData2.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData3.Value.Year, 1, 1);

                if (c_dtPckData3.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData3.Value.Year, 1, 1);

                if (c_dtPckData4.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData4.Value.Year, 1, 1);

                if (c_dtPckData5.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData5.Value.Year, 1, 1);

                if (c_dtPckData6.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData6.Value.Year, 1, 1);

            }
            else
            {
                if (c_dtPckData1.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData1.Value.Year, c_dtPckData1.Value.Month, 1);

                if (c_dtPckData2.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData2.Value.Year, c_dtPckData2.Value.Month, 1);

                if (c_dtPckData3.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData3.Value.Year, c_dtPckData3.Value.Month, 1);

                if (c_dtPckData4.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData4.Value.Year, c_dtPckData4.Value.Month, 1);

                if (c_dtPckData5.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData5.Value.Year, c_dtPckData5.Value.Month, 1);

                if (c_dtPckData6.Value < earliestDate)
                    earliestDate = new DateTime(c_dtPckData6.Value.Year, c_dtPckData6.Value.Month, 1);
            }

            return earliestDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.Reflect;
using YnabApp.BL.Export;
using YnabApp.UI;
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class ReflectColumnControl : UserControl, IReflectColumnView
    {
        ReflectColumnPresenter _presenter = null;
        DateTime _asOfDate;
        bool _isYearlyReport;
        PersonSelected _personSelected;
        bool _isHideZeroCategorties;

        CategoryGroupData[] _categoryDatas;
        TransactionData[] _transactionDatas;

        List<ReflectSummaryData> _summaryResults;
        List<ReflectIncomeData> _incomeResults;
        List<ReflectCategoryGroupData> _categoryGroupResults;
        List<ReflectCategoryData> _categoryResults;

        decimal TotalIncome { get; set; }


        public ReflectColumnControl()
        {
            InitializeComponent();

            _presenter = new ReflectColumnPresenter(this);
        }

        public IReflectView ReflectView
        {
            get { return this.ParentForm as IReflectView; }
        }

        public void InitializeView(bool isYearlyReport, DateTime reportDate, PersonSelected personSelected, bool isHideZeroCategorties)
        {
            _isYearlyReport = isYearlyReport;
            _asOfDate = reportDate;
            _personSelected = personSelected;
            _isHideZeroCategorties = isHideZeroCategorties;

            ResetUI(isYearlyReport);
        }

        private Person BL_Person
        {
            get
            {
                switch (_personSelected)
                {
                    case PersonSelected.All: return Person.All;
                    case PersonSelected.Jay: return Person.Jay;
                    case PersonSelected.Shar: return Person.Shar;
                    default: return Person.All;
                }
            }
        }

        public async void ShowReport(CategoryGroupData[] categoryDatas, TransactionData[] transactionDatas)
        {
            _transactionDatas = transactionDatas;
            _categoryDatas = categoryDatas;

            //-------------------------------------------//

            this.Cursor = Cursors.WaitCursor;

            if (_isYearlyReport)
                c_headerLabel.Text = $"Year: {_asOfDate:yyyy}";
            else
                c_headerLabel.Text = $"Month: {_asOfDate:MMM/yyyy}";

            DataCruncherForReflection dataCruncher = new DataCruncherForReflection();

            //-------------------------------------------//
            // Summary
            //-------------------------------------------//
            _summaryResults = await dataCruncher.CrunchSummaryDataAsync(categoryDatas, transactionDatas, _isYearlyReport, _asOfDate, BL_Person);

            foreach (var summaryData in _summaryResults)
            {
                ListViewItem item = new ListViewItem(summaryData.SummaryName);
                item.SubItems.Add(summaryData.Amount.ToString("#,###,##0.00"));
                item.SubItems.Add(summaryData.Percentage.ToString("#0.00"));
                if (_isYearlyReport)
                    item.SubItems.Add(summaryData.MonthlyAmountAccurate(_asOfDate).ToString("#,###,##0.00"));
                item.Tag = summaryData;
                if (summaryData.SummaryName == "Net Change")
                {
                    item.BackColor = ReflectColorizer.GetNetChangeBackColor(summaryData.Amount);
                    item.ForeColor = ReflectColorizer.GetNetChangeFontColor(summaryData.Amount);
                }
                else
                {
                    item.BackColor = ReflectColorizer.GetSummaryBackColor(summaryData.SummaryName);
                    item.ForeColor = ReflectColorizer.GetSummaryFontColor(summaryData.SummaryName);
                }
                c_summaryListView.Items.Add(item);

                if (summaryData.SummaryName.Equals("All Incomes"))
                    TotalIncome = summaryData.Amount;
            }
            c_summaryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //-------------------------------------------//
            // Incomes
            //-------------------------------------------//
            _incomeResults = await dataCruncher.CrunchIncomeDataAsync(transactionDatas, _isYearlyReport, _asOfDate, BL_Person);

            foreach (var incomeData in _incomeResults)
            {
                ListViewItem item = new ListViewItem(incomeData.FullName);
                item.SubItems.Add(incomeData.Amount.ToString("#,###,##0.00"));
                item.SubItems.Add(incomeData.Percentage.ToString("#0.00"));
                if (_isYearlyReport)
                    item.SubItems.Add(incomeData.MonthlyAmountAccurate(_asOfDate).ToString("#,###,##0.00"));
                item.Tag = incomeData;
                c_incomeListView.Items.Add(item);
            }
            c_incomeListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //-------------------------------------------//
            // Category Groups
            //-------------------------------------------//

            _categoryGroupResults = await dataCruncher.CrunchCategroyGroupDataAsync(categoryDatas, transactionDatas, _isYearlyReport, _asOfDate, TotalIncome, BL_Person);

            //Disabling Checked Event during data load            
            c_categoryGroupDataListView.ItemChecked -= c_categoryGroupDataListView_ItemChecked;

            foreach (var categoryGroup in _categoryGroupResults)
            {
                ListViewItem item = new ListViewItem(categoryGroup.CategoryGroupName);
                item.SubItems.Add(categoryGroup.Amount.ToString("#,###,##0.00"));
                item.SubItems.Add(categoryGroup.Percentage.ToString("#0.00"));
                if (_isYearlyReport)
                    item.SubItems.Add(categoryGroup.MonthlyAmountAccurate(_asOfDate).ToString("#,###,##0.00"));

                item.Checked = true;
                item.Tag = categoryGroup;
                item.BackColor = ReflectColorizer.GetBackColor(categoryGroup.CategoryGroupName);
                item.ForeColor = ReflectColorizer.GetFontColor(categoryGroup.CategoryGroupName);
                c_categoryGroupDataListView.Items.Add(item);
            }

            c_categoryGroupDataListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //Enabling back Checked Event
            c_categoryGroupDataListView.ItemChecked += c_categoryGroupDataListView_ItemChecked;


            //-------------------------------------------//
            // Categories
            //-------------------------------------------//

            _categoryResults = await dataCruncher.CrunchCategroyDataAsync(categoryDatas, transactionDatas, _isYearlyReport, _asOfDate, TotalIncome, BL_Person);

            ShowCategoriesFilteredByCatGroups();

            //-------------------------------------------//

            this.Cursor = Cursors.Default;
        }


        private void ResetUI(bool isYearlyReport)
        {
            c_headerLabel.Text = string.Empty;
            ResetListView(c_summaryListView, "Summary", isYearlyReport);
            ResetListView(c_incomeListView, "Income", isYearlyReport);
            ResetListView(c_categoryGroupDataListView, "Category Group", isYearlyReport);
            ResetListView(c_categoryDataListView, "Category", isYearlyReport);
        }

        private void ResetListView(ListView listViewControl, string columnName, bool isYearly)
        {
            listViewControl.Columns.Clear();
            listViewControl.Columns.Add(columnName);
            listViewControl.Columns.Add("Amount", 300, HorizontalAlignment.Right);
            listViewControl.Columns.Add("% of Income", 150, HorizontalAlignment.Right);
            if (isYearly)
                listViewControl.Columns.Add("Monthly", 300, HorizontalAlignment.Right);
            listViewControl.Groups.Clear();
            listViewControl.Items.Clear();
        }

        private void c_categoryGroupDataListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (c_categoryGroupDataListView.SelectedItems.Count > 0)
                {
                    var catGroupData = c_categoryGroupDataListView.SelectedItems[0].Tag as ReflectCategoryGroupData;

                    ReflectTransactionsForm.ShowModal(catGroupData, null, _asOfDate, _isYearlyReport, _personSelected, _transactionDatas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void c_categoryDataListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (c_categoryDataListView.SelectedItems.Count > 0)
                {
                    var catData = c_categoryDataListView.SelectedItems[0].Tag as ReflectCategoryData;

                    ReflectTransactionsForm.ShowModal(null, catData, _asOfDate, _isYearlyReport, _personSelected, _transactionDatas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void c_incomeListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (c_incomeListView.SelectedItems.Count > 0)
                {
                    var incomeData = c_incomeListView.SelectedItems[0].Tag as ReflectIncomeData;

                    ReflectTransactionsForm.ShowModal(incomeData, _asOfDate, _isYearlyReport, _personSelected, _transactionDatas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void c_categoryGroupDataListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                ResetListView(c_categoryDataListView, "Category", _isYearlyReport);
                ShowCategoriesFilteredByCatGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ShowCategoriesFilteredByCatGroups()
        {
            List<ReflectCategoryGroupData> selectedCatGroups = new List<ReflectCategoryGroupData>();
            foreach (ListViewItem item in c_categoryGroupDataListView.Items)
                if (item.Checked)
                    selectedCatGroups.Add(item.Tag as ReflectCategoryGroupData);

            foreach (var category in _categoryResults)
            {
                if (selectedCatGroups.Exists(cg => cg.CategoryGroupName == category.CategoryGroupName))
                {
                    ListViewItem item = new ListViewItem(category.FullCategoryName);
                    item.SubItems.Add(category.Amount.ToString("#,###,##0.00"));
                    item.SubItems.Add(category.Percentage.ToString("#0.00"));
                    if (_isYearlyReport)
                        item.SubItems.Add(category.MonthlyAmountAccurate(_asOfDate).ToString("#,###,##0.00"));
                    item.Tag = category;
                    item.BackColor = ReflectColorizer.GetBackColor(category.CategoryGroupName);
                    item.ForeColor = ReflectColorizer.GetFontColor(category.CategoryGroupName);
                    c_categoryDataListView.Items.Add(item);
                }
            }

            c_categoryDataListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void c_menuItemExport_Click(object sender, EventArgs e)
        {
            try
            {
                ReflectExport exporter = new ReflectExport(_isYearlyReport, BL_Person, _asOfDate,  _summaryResults, _incomeResults, _categoryGroupResults, _categoryResults);
                string filePath = exporter.GenerateReport();

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
    }

}

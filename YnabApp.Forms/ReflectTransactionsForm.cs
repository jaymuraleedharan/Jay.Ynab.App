using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabApp.BL.BudgetSettings;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.Reflect;
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class ReflectTransactionsForm : Form
    {
        BudgetData _currentBudget;
        BudgetSettings CurrentBudgetSettings { get; set; }

        ReflectCategoryGroupData _catGroupData;
        ReflectCategoryData _catData;
        ReflectIncomeData _incomeData;

        DateTime _asOfDate;
        bool _isYearlyReport;
        PersonSetting _personSelected;

        TransactionData[] _transactionDatas;
        List<TransactionData> _filteredTransactions = null;

        public ReflectTransactionsForm()
        {
            InitializeComponent();
        }

        private void c_btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetData(BudgetData currentBudget, ReflectCategoryGroupData catGroupData, ReflectCategoryData catData, ReflectIncomeData incomeData, DateTime asOfDate, bool isYearlyReport, PersonSetting personSelected, AccountData[] personAccounts, TransactionData[] transactionDatas)
        {
            _currentBudget = currentBudget;
            CurrentBudgetSettings = BudgetSettings.Load(_currentBudget.Id);
            _catGroupData = catGroupData;
            _catData = catData;
            _incomeData = incomeData;
            _asOfDate = asOfDate;
            _isYearlyReport = isYearlyReport;
            _personSelected = personSelected;
            _transactionDatas = transactionDatas;

            DataCruncherForReflection dataCruncher = new();
            if (catGroupData != null)
                _filteredTransactions = dataCruncher.FilterCategoryGroupTransactions(catGroupData, transactionDatas, isYearlyReport, asOfDate, personAccounts);
            else if(catData != null)
                _filteredTransactions = dataCruncher.FilterCategoryTransactions(catData, transactionDatas, isYearlyReport, asOfDate, personAccounts);
            else if(incomeData != null)
                _filteredTransactions = dataCruncher.FilterIncomeTransactions(incomeData, transactionDatas, isYearlyReport, asOfDate, personAccounts);

            _filteredTransactions = _filteredTransactions.OrderBy(t => t.Amount).ToList();

            ShowData();
        }



        private void ShowData()
        {
            if (_catGroupData != null)
                c_cateogryLabel.Text = _catGroupData.CategoryGroupName;
            else if (_catData != null)
                c_cateogryLabel.Text = _catData.FullCategoryName;
            else if (_incomeData != null)
                c_cateogryLabel.Text = _incomeData.FullName;

            if (_isYearlyReport)
                c_durationLabel.Text = $"Year: {_asOfDate.Year}";
            else
                c_durationLabel.Text = $"Month: {_asOfDate.ToString("MMM/yyyy")}";

            c_transactionsGrid.AutoGenerateColumns = false;

            c_transactionsGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Date", DataPropertyName = "TransDateTime", 
                SortMode= DataGridViewColumnSortMode.Automatic });
            c_transactionsGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "CategoryName", DataPropertyName = "CategoryName",
                SortMode = DataGridViewColumnSortMode.Automatic });
            c_transactionsGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "AccountName", DataPropertyName = "AccountName",
                SortMode = DataGridViewColumnSortMode.Automatic });
            c_transactionsGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "PayeeName", DataPropertyName = "PayeeName",
                SortMode = DataGridViewColumnSortMode.Automatic });
            var amountCol = new DataGridViewTextBoxColumn() { HeaderText = "Amount", DataPropertyName = "Amount",
                SortMode = DataGridViewColumnSortMode.Automatic };
            amountCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            amountCol.DefaultCellStyle.Format =  "##,###,##0.00";
            c_transactionsGrid.Columns.Add(amountCol);
            c_transactionsGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Memo", DataPropertyName = "Memo",
                SortMode = DataGridViewColumnSortMode.Automatic
            });
            c_transactionsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (_catGroupData != null)
                c_transactionsGrid.DefaultCellStyle.BackColor = CurrentBudgetSettings.GetCatGroupBackColor(_catGroupData.CategoryGroupName);
            else if(_catData != null)
                c_transactionsGrid.DefaultCellStyle.BackColor = CurrentBudgetSettings.GetCatGroupBackColor(_catData.CategoryGroupName);
            else if (_incomeData != null)
                c_transactionsGrid.DefaultCellStyle.BackColor = CurrentBudgetSettings.GeneralColors.IncomeColor.GetColor();

            c_transactionsGrid.DataSource = _filteredTransactions;            
        }

        public static void ShowModal(BudgetData currentBudget, ReflectCategoryGroupData catGroupData, ReflectCategoryData catData, DateTime asOfDate, bool isYearlyReport, PersonSetting personSelected, AccountData[] personAccounts, TransactionData[] transactionDatas)
        {
            ReflectTransactionsForm reflectTransactionsForm = new ReflectTransactionsForm();
            reflectTransactionsForm.Activate();
            reflectTransactionsForm.SetData(currentBudget, catGroupData, catData, null, asOfDate, isYearlyReport, personSelected, personAccounts, transactionDatas);
            reflectTransactionsForm.ShowDialog();
        }


        public static void ShowModal(BudgetData currentBudget, ReflectIncomeData incomeData, DateTime asOfDate, bool isYearlyReport, PersonSetting personSelected, AccountData[] personAccounts, TransactionData[] transactionDatas)
        {
            ReflectTransactionsForm reflectTransactionsForm = new ReflectTransactionsForm();
            reflectTransactionsForm.Activate();
            reflectTransactionsForm.SetData(currentBudget, null, null, incomeData, asOfDate, isYearlyReport, personSelected, personAccounts, transactionDatas);
            reflectTransactionsForm.ShowDialog();
        }

    }
}

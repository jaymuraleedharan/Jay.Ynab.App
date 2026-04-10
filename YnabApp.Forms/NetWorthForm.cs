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
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.ListCategories;
using YnabApp.UI;
using YnabApp.UI.ListAccounts;
using YnabApp.BL.BudgetSettings;

namespace YnabApp.Forms
{
    public partial class NetWorthForm : FormBase, IListAccountsView
    {
        private readonly ListAccountsPresenter _presenter = null;
        private BudgetData _budgetData = null;
        private BudgetSettings CurrentBudgetSettings { get; set; }
        private AccountData[] _accountsData = null;
        private TransactionData[] _transactionsData = null;
        private CategoryGroupData[] _categoriesData = null;

        public NetWorthForm()
        {
            InitializeComponent();

            _presenter = new ListAccountsPresenter(this);
        }

        public async void InitializeView(BudgetData budgetData)
        {
            try
            {
                _budgetData = budgetData;
                CurrentBudgetSettings = BudgetSettings.Load(_budgetData.Id);

                ResetUI();

                await GetAccountsDataAsync();

                await GetCategoriesDataAsync();

                PresentAllAssets();

                //c_startDatePicker.ValueChanged += C_startDatePicker_ValueChanged;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public IMainView MainView
        {
            get { return this.MdiParent as IMainView; }
        }

        private void ResetUI()
        {
            LoadPersonList();

            ResetAllAssetsListView();
        }

        private void LoadPersonList()
        {
            c_personList.Items.Clear();
            c_personList.Items.Add("ALL");
            CurrentBudgetSettings.People.ForEach(p => c_personList.Items.Add(p));
            c_personList.SelectedIndex = 0;
        }

        private void c_personList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var person = c_personList.SelectedItem as PersonSetting;
                var filteredAccs = PersonAccount.GetPersonAccounts(_accountsData, person);
                ResetAllAssetsListView();
                PresentAllAssets(filteredAccs);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private async Task GetAccountsDataAsync()
        {
            this.Text = _budgetData.Name;
            _accountsData = await _presenter.GetAllAccountsAsync(_budgetData.Id);
        }

        private async Task GetCategoriesDataAsync()
        {
            _categoriesData = await _presenter.GetCategoriesAsync(_budgetData.Id);
        }

        //private async Task GetTransactionsAsync()
        //{
        //    _transactionsData = await _presenter.GetTransactionsAsync(_budgetData.Id, c_startDatePicker.Value);

        //    await _presenter.AnalyzeTransactionsForAccountsAsync(_accountsData, _transactionsData);
        //}


        //private void PresentAccountsTreeView()
        //{
        //    c_AccountsTreeView.SuspendLayout();

        //    var rootAll = c_AccountsTreeView.Nodes.Add("ACCOUNTS", "ACCOUNTS");

        //    var types = (from a in _accountsData select a.Type).Distinct();
        //    foreach (var type in types)
        //    {
        //        var root = rootAll.Nodes.Add(type, type);
        //        var accs = _accountsData.Where(a => a.Type == type);

        //        decimal typeTotal = 0;
        //        foreach (var acc in accs)
        //        {
        //            if (acc.IsClosed || acc.IsDeleted)
        //                continue;

        //            var node = root.Nodes.Add(acc.Id, $"{acc.Name}");
        //            node.Tag = acc;
        //            typeTotal += acc.Balance;
        //        }

        //        root.Text = $"{type.ToUpper()}";
        //        //root.Expand();
        //    }
        //    rootAll.ExpandAll();
        //    c_AccountsTreeView.SelectedNode = rootAll;

        //    c_AccountsTreeView.ResumeLayout();
        //}


        //private void PresentCategoriesTreeView()
        //{
        //    c_AccountsTreeView.SuspendLayout();

        //    var rootAll = c_AccountsTreeView.Nodes.Add("CATEGORIES", "CATEGORIES");

        //    foreach (var catGroupData in _categoriesData)
        //    {
        //        if (catGroupData.IsDeleted || catGroupData.IsHidden)
        //            continue;

        //        if (catGroupData.Name == "Internal Master Category" || catGroupData.Name == "Credit Card Payments"
        //            || catGroupData.Name == "Hidden Categories")
        //            continue;

        //        decimal catTotal = GetCategoryTotal(catGroupData);
        //        var catGroupNode = rootAll.Nodes.Add(catGroupData.Id, $"{catGroupData.Name} {catTotal.Format()}");
        //        catGroupNode.Tag = catGroupData;

        //        foreach (var catData in catGroupData.Categories)
        //        {
        //            if (catData.IsDeleted || catData.IsHidden)
        //                continue;

        //            var catNode = catGroupNode.Nodes.Add(catData.Id, catData.Name);
        //            catNode.Tag = catData;
        //        }
        //        catGroupNode.Collapse();
        //    }
        //    rootAll.Expand();
        //    c_AccountsTreeView.ResumeLayout();

        //    c_AccountsTreeView.AfterSelect += c_AccountsTreeView_AfterSelect;
        //}


        private decimal GetCategoryTotal(CategoryGroupData catGroupData)
        {
            var catIds = catGroupData.Categories.Select(c => c.Id).ToArray(); //Get Ids of all Categories under the Category Group
            return _transactionsData.Where(t => catIds.Contains(t.CategoryId)).Sum(t => t.Amount); //Get all transaction belonging to the list Category Ids

        }

        //private void c_AccountsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    try
        //    {
        //        if (c_AccountsTreeView.SelectedNode == null)
        //            return;

        //        ResetTransactionListView();

        //        if (c_AccountsTreeView.SelectedNode.Text == "ACCOUNTS" ||
        //            c_AccountsTreeView.SelectedNode.Text == "CATEGORIES")
        //        {
        //            //ALL Transactions
        //            PresentTransactionData();
        //        }
        //        else
        //        {
        //            var acc = c_AccountsTreeView.SelectedNode.Tag as AccountData;
        //            if (acc != null)
        //            {
        //                //ACCOUNT Transactions
        //                var filteredTransactions = FilterTransactions(acc);
        //                PresentTransactionData(filteredTransactions);
        //            }
        //            else
        //            {
        //                var catGroupData = c_AccountsTreeView.SelectedNode.Tag as CategoryGroupData;
        //                var catData = c_AccountsTreeView.SelectedNode.Tag as CategoryData;
        //                if (catGroupData != null)
        //                {
        //                    var filteredTransactions = FilterTransactions(catGroupData);
        //                    PresentTransactionData(filteredTransactions);
        //                }
        //                else if (catData != null)
        //                {
        //                    var filteredTransactions = FilterTransactions(catData);
        //                    PresentTransactionData(filteredTransactions);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError(ex);
        //    }
        //}

        //private void c_ownerList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var owner = c_ownerList.SelectedItem as string;
        //        var filteredAccs = _presenter.FilterAccounts(_accountsData, owner);
        //        ResetAccountsListView();
        //        PresentAccountsData(filteredAccs);
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError(ex);
        //    }
        //}

        private TransactionData[] FilterTransactions(AccountData accData)
        {
            return _transactionsData.Where(t => t.AccountId == accData.Id).ToArray();
        }

        private TransactionData[] FilterTransactions(CategoryGroupData catGroupData)
        {
            var catIds = catGroupData.Categories.Select(c => c.Id).ToArray(); //Get Ids of all Categories under the Category Group
            return _transactionsData.Where(t => catIds.Contains(t.CategoryId)).ToArray(); //Get all transaction belonging to the list Category Ids
        }

        private TransactionData[] FilterTransactions(CategoryData catData)
        {
            return _transactionsData.Where(t => t.CategoryId == catData.Id).ToArray();
        }

        //private void LoadTransactionsListView()
        //{
        //    ResetTransactionListView();

        //    PresentTransactionData();

        //    ResetAccountsListView();

        //    PresentAccountsData();
        //}

        //private void ResetTransactionListView()
        //{
        //    c_TransactionsListView.Columns.Clear();
        //    c_TransactionsListView.Columns.Add("Date");
        //    c_TransactionsListView.Columns.Add("CategoryName");
        //    c_TransactionsListView.Columns.Add("AccountName");
        //    c_TransactionsListView.Columns.Add("PayeeName");
        //    c_TransactionsListView.Columns.Add("Memo");
        //    c_TransactionsListView.Columns.Add("Amount", 300, HorizontalAlignment.Right);

        //    c_TransactionsListView.Items.Clear();
        //}

        //private void PresentTransactionData()
        //{
        //    PresentTransactionData(_transactionsData);
        //}

        //private void PresentTransactionData(TransactionData[] filteredTransactions)
        //{
        //    if (filteredTransactions != null)
        //    {
        //        c_TransactionsListView.SuspendLayout();

        //        decimal totalAmount = 0;
        //        foreach (TransactionData transData in filteredTransactions)
        //        {
        //            var item = new ListViewItem(new string[]
        //            {
        //                transData.TransactionDate, transData.CategoryName, transData.AccountName, transData.PayeeName,  transData.Memo,
        //                transData.Amount.Format()
        //            });
        //            totalAmount += transData.Amount;
        //            if (transData.Amount > 0)
        //                item.ForeColor = Color.Green;
        //            c_TransactionsListView.Items.Add(item);
        //        }

        //        var totalItem = new ListViewItem(new string[]
        //        {
        //                "TOTAL", string.Empty, string.Empty, string.Empty,  string.Empty,  totalAmount.Format()
        //        });
        //        totalItem.Font = new Font(totalItem.Font, FontStyle.Bold);
        //        c_TransactionsListView.Items.Add(totalItem);

        //        c_TransactionsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        //        c_TransactionsListView.ResumeLayout();
        //    }
        //}

        //private void ResetAccountsListView()
        //{
        //    c_accountsListView.Columns.Clear();
        //    c_accountsListView.Columns.Add("Name");
        //    c_accountsListView.Columns.Add("Type");
        //    c_accountsListView.Columns.Add("Balance", 300, HorizontalAlignment.Right);
        //    c_accountsListView.Columns.Add("Uncleared Balance", 300, HorizontalAlignment.Right);
        //    c_accountsListView.Columns.Add("Total Credit", 300, HorizontalAlignment.Right);
        //    c_accountsListView.Columns.Add("Total Debit", 300, HorizontalAlignment.Right);
        //    c_accountsListView.Columns.Add("Net Change", 300, HorizontalAlignment.Right);

        //    c_accountsListView.Groups.Clear();
        //    c_accountsListView.Items.Clear();
        //}


        private void ResetAllAssetsListView()
        {
            c_allAssetsListView.Columns.Clear();
            c_allAssetsListView.Columns.Add("Name");
            c_allAssetsListView.Columns.Add("Type");
            c_allAssetsListView.Columns.Add("Balance", 300, HorizontalAlignment.Right);

            c_allAssetsListView.Groups.Clear();
            c_allAssetsListView.Items.Clear();
        }

        //private void PresentAccountsData(AccountData[] accountData)
        //{
        //    if (accountData != null)
        //    {
        //        c_accountsListView.SuspendLayout();

        //        decimal nwBalance = 0;

        //        //Group Acounts by Account Type
        //        var types = (from a in accountData select a.Type).Distinct();
        //        foreach (var type in types)
        //        {
        //            //GROUP
        //            var typeGroup = new ListViewGroup(type.ToUpper(), HorizontalAlignment.Left);
        //            c_accountsListView.Groups.Add(typeGroup);

        //            //GROUP ITEMS
        //            var typeAccounts = accountData.Where(a => a.Type == type);
        //            if (typeAccounts.Count() == 0)
        //                continue;

        //            decimal balanceTotal = 0, groupTotalCredit = 0, groupTotalDebit = 0, groupNetChange = 0;

        //            foreach (var accData in typeAccounts)
        //            {
        //                if (accData.IsClosed || accData.IsDeleted)
        //                    continue;

        //                //Correcting Negative Balances for liabilities
        //                if (accData.Type == "otherLiability" && accData.Balance > 0)
        //                    accData.Balance = -(accData.Balance);

        //                var item = new ListViewItem(new string[]
        //                {
        //                    accData.Name, accData.Type, accData.Balance.Format(), accData.UnclearedBalance.Format(),
        //                    accData.CreditTotal.Format(), accData.DebitTotal.Format(), accData.NetChange.Format()
        //                });

        //                c_accountsListView.Items.Add(item);
        //                Colorize(item, accData);
        //                item.Group = typeGroup;

        //                balanceTotal += accData.Balance;
        //                groupTotalCredit += accData.CreditTotal;
        //                groupTotalDebit += accData.DebitTotal;
        //                groupNetChange += accData.NetChange;
        //                nwBalance += accData.Balance;
        //            }

        //            //GROUP TOTAL
        //            var groupTotal = new ListViewItem(new string[]
        //                {
        //                    "TOTAL", string.Empty, balanceTotal.Format(), string.Empty,
        //                    groupTotalCredit.Format(), groupTotalDebit.Format(), groupNetChange.Format()
        //                });
        //            groupTotal.Font = new Font(groupTotal.Font, FontStyle.Bold);
        //            c_accountsListView.Items.Add(groupTotal);
        //            groupTotal.Group = typeGroup;
        //        }

        //        //Net Worth Group & Total
        //        var nwGroup = new ListViewGroup("NET WORTH", HorizontalAlignment.Left);
        //        c_accountsListView.Groups.Add(nwGroup);
        //        var nwTotal = new ListViewItem(new string[]
        //            {
        //                    "TOTAL", string.Empty, nwBalance.Format(), string.Empty,
        //                    string.Empty, string.Empty, string.Empty
        //            });
        //        nwTotal.Font = new Font(nwTotal.Font, FontStyle.Bold);
        //        c_accountsListView.Items.Add(nwTotal);
        //        nwTotal.Group = nwGroup;


        //        c_accountsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        //        c_accountsListView.ResumeLayout();
        //    }
        //}

        //private void PresentAccountsData()
        //{
        //    if (_accountsData != null)
        //    {
        //        PresentAccountsData(_accountsData);
        //    }
        //}

        private void PresentAllAssets()
        {
            PresentAllAssets(_accountsData);
        }

        private void PresentAllAssets(AccountData[] accountDatas)
        {
            if (accountDatas == null)
                return;

            c_allAssetsListView.SuspendLayout();

            decimal nwBalance = 0;

            //Group Acounts by Account Type
            var groups = (from a in accountDatas select a.Group).Distinct();
            foreach (var group in groups)
            {
                //GROUP
                var typeGroup = new ListViewGroup(group.ToString(), HorizontalAlignment.Left);
                c_allAssetsListView.Groups.Add(typeGroup);

                //GROUP ITEMS
                var accountsInGroup = accountDatas.Where(a => a.Group == group);
                if (accountsInGroup.Count() == 0)
                    continue;

                decimal balanceTotal = 0, groupTotalCredit = 0, groupTotalDebit = 0, groupNetChange = 0;

                foreach (var accData in accountsInGroup)
                {
                    if (accData.IsClosed || accData.IsDeleted)
                        continue;

                    //Correcting Negative Balances for liabilities
                    if (accData.Type == "otherLiability" && accData.Balance > 0)
                        accData.Balance = -(accData.Balance);

                    var item = new ListViewItem(new string[]
                    {
                            accData.Name, accData.Type, accData.Balance.Format()
                    });

                    c_allAssetsListView.Items.Add(item);
                    ColorizeAsset(item, accData);
                    item.Group = typeGroup;

                    balanceTotal += accData.Balance;
                    groupTotalCredit += accData.CreditTotal;
                    groupTotalDebit += accData.DebitTotal;
                    groupNetChange += accData.NetChange;
                    nwBalance += accData.Balance;
                }

                //GROUP TOTAL
                var groupTotal = new ListViewItem(new string[]
                    {
                            "TOTAL", string.Empty, balanceTotal.Format()
                    });
                groupTotal.Font = new Font(groupTotal.Font, FontStyle.Bold);
                c_allAssetsListView.Items.Add(groupTotal);
                groupTotal.Group = typeGroup;
            }

            //Net Worth Group & Total
            var nwGroup = new ListViewGroup("NET WORTH", HorizontalAlignment.Left);
            c_allAssetsListView.Groups.Add(nwGroup);
            var nwTotal = new ListViewItem(new string[]
                {
                            "TOTAL", string.Empty, nwBalance.Format()
                });
            nwTotal.Font = new Font(nwTotal.Font, FontStyle.Bold);
            c_allAssetsListView.Items.Add(nwTotal);
            nwTotal.Group = nwGroup;


            c_allAssetsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            c_allAssetsListView.ResumeLayout();

        }

        private void Colorize(ListViewItem item, AccountData accData)
        {
            switch (accData.Type)
            {
                case "creditCard":
                case "otherLiability":
                    if (accData.Balance < 0)
                        item.ForeColor = Color.Red;
                    break;

                default:
                    if (accData.NetChange < 0)
                        item.ForeColor = Color.Red;
                    break;
            }
        }

        private void ColorizeAsset(ListViewItem item, AccountData accData)
        {
            switch (accData.Group)
            {
                case AccountGroup.Liability:
                    item.BackColor = CurrentBudgetSettings.GeneralColors.ExpenseColor.GetColor(); break;
                default:
                    item.BackColor = CurrentBudgetSettings.GeneralColors.IncomeColor.GetColor(); break;
            }
        }

    }
}

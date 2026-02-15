
namespace YnabApp.Forms
{
    partial class ShowAccountsTransactionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new System.Windows.Forms.Label();
            c_startDatePicker = new System.Windows.Forms.DateTimePicker();
            c_tabView = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            label5 = new System.Windows.Forms.Label();
            c_TransactionsListView = new System.Windows.Forms.ListView();
            label3 = new System.Windows.Forms.Label();
            c_AccountsTreeView = new System.Windows.Forms.TreeView();
            tabPage2 = new System.Windows.Forms.TabPage();
            c_accountsListView = new System.Windows.Forms.ListView();
            c_ownerList = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            c_allAssetsListView = new System.Windows.Forms.ListView();
            c_personList = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            c_tabView.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(12, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 3;
            label2.Text = "Start Date:";
            // 
            // c_startDatePicker
            // 
            c_startDatePicker.Location = new System.Drawing.Point(98, 3);
            c_startDatePicker.Name = "c_startDatePicker";
            c_startDatePicker.Size = new System.Drawing.Size(200, 23);
            c_startDatePicker.TabIndex = 4;
            c_startDatePicker.ValueChanged += C_startDatePicker_ValueChanged;
            // 
            // c_tabView
            // 
            c_tabView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_tabView.Controls.Add(tabPage1);
            c_tabView.Controls.Add(tabPage2);
            c_tabView.Controls.Add(tabPage3);
            c_tabView.Location = new System.Drawing.Point(14, 32);
            c_tabView.Name = "c_tabView";
            c_tabView.SelectedIndex = 0;
            c_tabView.Size = new System.Drawing.Size(1344, 615);
            c_tabView.TabIndex = 12;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(c_TransactionsListView);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(c_AccountsTreeView);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1336, 587);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Transactions";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(259, 8);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(172, 15);
            label5.TabIndex = 12;
            label5.Text = "Selected Account Transactions:";
            // 
            // c_TransactionsListView
            // 
            c_TransactionsListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_TransactionsListView.BackColor = System.Drawing.SystemColors.Control;
            c_TransactionsListView.GridLines = true;
            c_TransactionsListView.Location = new System.Drawing.Point(259, 26);
            c_TransactionsListView.Name = "c_TransactionsListView";
            c_TransactionsListView.Size = new System.Drawing.Size(1071, 555);
            c_TransactionsListView.TabIndex = 9;
            c_TransactionsListView.UseCompatibleStateImageBehavior = false;
            c_TransactionsListView.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(6, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "Accounts:";
            // 
            // c_AccountsTreeView
            // 
            c_AccountsTreeView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            c_AccountsTreeView.BackColor = System.Drawing.SystemColors.Control;
            c_AccountsTreeView.FullRowSelect = true;
            c_AccountsTreeView.HideSelection = false;
            c_AccountsTreeView.Location = new System.Drawing.Point(6, 26);
            c_AccountsTreeView.Name = "c_AccountsTreeView";
            c_AccountsTreeView.Size = new System.Drawing.Size(247, 555);
            c_AccountsTreeView.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(c_accountsListView);
            tabPage2.Controls.Add(c_ownerList);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1336, 587);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Accounts Summary";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // c_accountsListView
            // 
            c_accountsListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_accountsListView.BackColor = System.Drawing.SystemColors.Control;
            c_accountsListView.GridLines = true;
            c_accountsListView.Location = new System.Drawing.Point(11, 45);
            c_accountsListView.Name = "c_accountsListView";
            c_accountsListView.Size = new System.Drawing.Size(1319, 536);
            c_accountsListView.TabIndex = 15;
            c_accountsListView.UseCompatibleStateImageBehavior = false;
            c_accountsListView.View = System.Windows.Forms.View.Details;
            // 
            // c_ownerList
            // 
            c_ownerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            c_ownerList.FormattingEnabled = true;
            c_ownerList.Items.AddRange(new object[] { "ALL", "JAY", "SHAR" });
            c_ownerList.Location = new System.Drawing.Point(131, 12);
            c_ownerList.Name = "c_ownerList";
            c_ownerList.Size = new System.Drawing.Size(105, 23);
            c_ownerList.TabIndex = 14;
            c_ownerList.SelectedIndexChanged += c_ownerList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(11, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 15);
            label1.TabIndex = 13;
            label1.Text = "Account Owner:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(c_allAssetsListView);
            tabPage3.Controls.Add(c_personList);
            tabPage3.Controls.Add(label4);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(1336, 587);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Net Worth Summary";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // c_allAssetsListView
            // 
            c_allAssetsListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_allAssetsListView.BackColor = System.Drawing.SystemColors.Control;
            c_allAssetsListView.GridLines = true;
            c_allAssetsListView.Location = new System.Drawing.Point(9, 40);
            c_allAssetsListView.Name = "c_allAssetsListView";
            c_allAssetsListView.Size = new System.Drawing.Size(1319, 536);
            c_allAssetsListView.TabIndex = 18;
            c_allAssetsListView.UseCompatibleStateImageBehavior = false;
            c_allAssetsListView.View = System.Windows.Forms.View.Details;
            // 
            // c_personList
            // 
            c_personList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            c_personList.FormattingEnabled = true;
            c_personList.Items.AddRange(new object[] { "ALL", "JAY", "SHAR" });
            c_personList.Location = new System.Drawing.Point(129, 7);
            c_personList.Name = "c_personList";
            c_personList.Size = new System.Drawing.Size(105, 23);
            c_personList.TabIndex = 17;
            c_personList.SelectedIndexChanged += c_personList_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(9, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(97, 15);
            label4.TabIndex = 16;
            label4.Text = "Account Owner:";
            // 
            // ShowAccountsTransactionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1370, 659);
            Controls.Add(c_tabView);
            Controls.Add(c_startDatePicker);
            Controls.Add(label2);
            Name = "ShowAccountsTransactionsForm";
            c_tabView.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker c_startDatePicker;
        private System.Windows.Forms.TabControl c_tabView;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView c_TransactionsListView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView c_AccountsTreeView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView c_accountsListView;
        private System.Windows.Forms.ComboBox c_ownerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView c_allAssetsListView;
        private System.Windows.Forms.ComboBox c_personList;
        private System.Windows.Forms.Label label4;
    }
}
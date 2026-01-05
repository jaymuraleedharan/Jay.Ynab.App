
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
            this.label2 = new System.Windows.Forms.Label();
            this.c_startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.c_tabView = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.c_TransactionsListView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.c_AccountsTreeView = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.c_accountsListView = new System.Windows.Forms.ListView();
            this.c_ownerList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.c_heatMapGrid = new System.Windows.Forms.DataGridView();
            this.c_tabView.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_heatMapGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Date:";
            // 
            // c_startDatePicker
            // 
            this.c_startDatePicker.Location = new System.Drawing.Point(98, 3);
            this.c_startDatePicker.Name = "c_startDatePicker";
            this.c_startDatePicker.Size = new System.Drawing.Size(200, 23);
            this.c_startDatePicker.TabIndex = 4;
            this.c_startDatePicker.ValueChanged += new System.EventHandler(this.C_startDatePicker_ValueChanged);
            // 
            // c_tabView
            // 
            this.c_tabView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_tabView.Controls.Add(this.tabPage1);
            this.c_tabView.Controls.Add(this.tabPage2);
            this.c_tabView.Controls.Add(this.tabPage3);
            this.c_tabView.Location = new System.Drawing.Point(14, 32);
            this.c_tabView.Name = "c_tabView";
            this.c_tabView.SelectedIndex = 0;
            this.c_tabView.Size = new System.Drawing.Size(1344, 615);
            this.c_tabView.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.c_TransactionsListView);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.c_AccountsTreeView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1336, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transactions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(259, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Selected Account Transactions:";
            // 
            // c_TransactionsListView
            // 
            this.c_TransactionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_TransactionsListView.BackColor = System.Drawing.SystemColors.Control;
            this.c_TransactionsListView.GridLines = true;
            this.c_TransactionsListView.HideSelection = false;
            this.c_TransactionsListView.Location = new System.Drawing.Point(259, 26);
            this.c_TransactionsListView.Name = "c_TransactionsListView";
            this.c_TransactionsListView.Size = new System.Drawing.Size(1071, 555);
            this.c_TransactionsListView.TabIndex = 9;
            this.c_TransactionsListView.UseCompatibleStateImageBehavior = false;
            this.c_TransactionsListView.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Accounts:";
            // 
            // c_AccountsTreeView
            // 
            this.c_AccountsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.c_AccountsTreeView.BackColor = System.Drawing.SystemColors.Control;
            this.c_AccountsTreeView.FullRowSelect = true;
            this.c_AccountsTreeView.HideSelection = false;
            this.c_AccountsTreeView.Location = new System.Drawing.Point(6, 26);
            this.c_AccountsTreeView.Name = "c_AccountsTreeView";
            this.c_AccountsTreeView.Size = new System.Drawing.Size(247, 555);
            this.c_AccountsTreeView.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.c_accountsListView);
            this.tabPage2.Controls.Add(this.c_ownerList);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1336, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Accounts Summary";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // c_accountsListView
            // 
            this.c_accountsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_accountsListView.BackColor = System.Drawing.SystemColors.Control;
            this.c_accountsListView.GridLines = true;
            this.c_accountsListView.HideSelection = false;
            this.c_accountsListView.Location = new System.Drawing.Point(11, 45);
            this.c_accountsListView.Name = "c_accountsListView";
            this.c_accountsListView.Size = new System.Drawing.Size(1319, 536);
            this.c_accountsListView.TabIndex = 15;
            this.c_accountsListView.UseCompatibleStateImageBehavior = false;
            this.c_accountsListView.View = System.Windows.Forms.View.Details;
            // 
            // c_ownerList
            // 
            this.c_ownerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_ownerList.FormattingEnabled = true;
            this.c_ownerList.Items.AddRange(new object[] {
            "ALL",
            "JAY",
            "SHAR"});
            this.c_ownerList.Location = new System.Drawing.Point(131, 16);
            this.c_ownerList.Name = "c_ownerList";
            this.c_ownerList.Size = new System.Drawing.Size(105, 23);
            this.c_ownerList.TabIndex = 14;
            this.c_ownerList.SelectedIndexChanged += new System.EventHandler(this.c_ownerList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Account Owner:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.c_heatMapGrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1336, 587);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Daily Net Map";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // c_heatMapGrid
            // 
            this.c_heatMapGrid.AllowUserToAddRows = false;
            this.c_heatMapGrid.AllowUserToDeleteRows = false;
            this.c_heatMapGrid.AllowUserToResizeColumns = false;
            this.c_heatMapGrid.AllowUserToResizeRows = false;
            this.c_heatMapGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_heatMapGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.c_heatMapGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c_heatMapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_heatMapGrid.Location = new System.Drawing.Point(12, 18);
            this.c_heatMapGrid.MultiSelect = false;
            this.c_heatMapGrid.Name = "c_heatMapGrid";
            this.c_heatMapGrid.ReadOnly = true;
            this.c_heatMapGrid.RowTemplate.Height = 25;
            this.c_heatMapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.c_heatMapGrid.Size = new System.Drawing.Size(1310, 553);
            this.c_heatMapGrid.TabIndex = 0;
            // 
            // ShowAccountsTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 659);
            this.Controls.Add(this.c_tabView);
            this.Controls.Add(this.c_startDatePicker);
            this.Controls.Add(this.label2);
            this.Name = "ShowAccountsTransactionsForm";
            this.c_tabView.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_heatMapGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridView c_heatMapGrid;
    }
}
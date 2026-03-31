
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
            c_tabView = new System.Windows.Forms.TabControl();
            tabPage3 = new System.Windows.Forms.TabPage();
            c_allAssetsListView = new System.Windows.Forms.ListView();
            c_personList = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            c_tabView.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // c_tabView
            // 
            c_tabView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_tabView.Controls.Add(tabPage3);
            c_tabView.Location = new System.Drawing.Point(14, 6);
            c_tabView.Name = "c_tabView";
            c_tabView.SelectedIndex = 0;
            c_tabView.Size = new System.Drawing.Size(1344, 641);
            c_tabView.TabIndex = 12;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(c_allAssetsListView);
            tabPage3.Controls.Add(c_personList);
            tabPage3.Controls.Add(label4);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(1336, 613);
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
            c_allAssetsListView.Size = new System.Drawing.Size(1319, 562);
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
            Name = "ShowAccountsTransactionsForm";
            c_tabView.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl c_tabView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView c_allAssetsListView;
        private System.Windows.Forms.ComboBox c_personList;
        private System.Windows.Forms.Label label4;
    }
}
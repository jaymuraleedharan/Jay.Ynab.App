namespace YnabApp.Forms
{
    partial class ReflectColumnControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            c_headerLabel = new System.Windows.Forms.Label();
            c_summaryListView = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            c_incomeListView = new System.Windows.Forms.ListView();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            c_categoryGroupDataListView = new System.Windows.Forms.ListView();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            c_categoryDataListView = new System.Windows.Forms.ListView();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            SuspendLayout();
            // 
            // c_headerLabel
            // 
            c_headerLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            c_headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            c_headerLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            c_headerLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            c_headerLabel.Location = new System.Drawing.Point(0, 0);
            c_headerLabel.Name = "c_headerLabel";
            c_headerLabel.Size = new System.Drawing.Size(557, 23);
            c_headerLabel.TabIndex = 0;
            c_headerLabel.Text = "Jan / 2025";
            c_headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c_summaryListView
            // 
            c_summaryListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_summaryListView.BackColor = System.Drawing.SystemColors.Control;
            c_summaryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_summaryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            c_summaryListView.FullRowSelect = true;
            c_summaryListView.GridLines = true;
            c_summaryListView.Location = new System.Drawing.Point(5, 26);
            c_summaryListView.Name = "c_summaryListView";
            c_summaryListView.Size = new System.Drawing.Size(546, 145);
            c_summaryListView.TabIndex = 17;
            c_summaryListView.UseCompatibleStateImageBehavior = false;
            c_summaryListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "SUMMARY";
            columnHeader1.Width = 100;
            // 
            // c_incomeListView
            // 
            c_incomeListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_incomeListView.BackColor = System.Drawing.SystemColors.Control;
            c_incomeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_incomeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader2 });
            c_incomeListView.FullRowSelect = true;
            c_incomeListView.GridLines = true;
            c_incomeListView.Location = new System.Drawing.Point(5, 174);
            c_incomeListView.Name = "c_incomeListView";
            c_incomeListView.Size = new System.Drawing.Size(546, 177);
            c_incomeListView.TabIndex = 18;
            c_incomeListView.UseCompatibleStateImageBehavior = false;
            c_incomeListView.View = System.Windows.Forms.View.Details;
            c_incomeListView.DoubleClick += c_incomeListView_DoubleClick;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "INCOME";
            // 
            // c_categoryGroupDataListView
            // 
            c_categoryGroupDataListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_categoryGroupDataListView.BackColor = System.Drawing.SystemColors.Control;
            c_categoryGroupDataListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_categoryGroupDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader3 });
            c_categoryGroupDataListView.FullRowSelect = true;
            c_categoryGroupDataListView.Location = new System.Drawing.Point(5, 354);
            c_categoryGroupDataListView.Name = "c_categoryGroupDataListView";
            c_categoryGroupDataListView.Size = new System.Drawing.Size(546, 168);
            c_categoryGroupDataListView.TabIndex = 19;
            c_categoryGroupDataListView.UseCompatibleStateImageBehavior = false;
            c_categoryGroupDataListView.View = System.Windows.Forms.View.Details;
            c_categoryGroupDataListView.DoubleClick += c_categoryGroupDataListView_DoubleClick;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "EXPENSE CATEGORY GROUPS";
            columnHeader3.Width = 200;
            // 
            // c_categoryDataListView
            // 
            c_categoryDataListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_categoryDataListView.BackColor = System.Drawing.SystemColors.Control;
            c_categoryDataListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_categoryDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader4 });
            c_categoryDataListView.FullRowSelect = true;
            c_categoryDataListView.Location = new System.Drawing.Point(5, 528);
            c_categoryDataListView.Name = "c_categoryDataListView";
            c_categoryDataListView.Size = new System.Drawing.Size(546, 390);
            c_categoryDataListView.TabIndex = 20;
            c_categoryDataListView.UseCompatibleStateImageBehavior = false;
            c_categoryDataListView.View = System.Windows.Forms.View.Details;
            c_categoryDataListView.DoubleClick += c_categoryDataListView_DoubleClick;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "EXPENSE CATEGORIES";
            columnHeader4.Width = 200;
            // 
            // ReflectColumnControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(c_categoryDataListView);
            Controls.Add(c_categoryGroupDataListView);
            Controls.Add(c_incomeListView);
            Controls.Add(c_summaryListView);
            Controls.Add(c_headerLabel);
            Name = "ReflectColumnControl";
            Size = new System.Drawing.Size(557, 921);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label c_headerLabel;
        private System.Windows.Forms.ListView c_summaryListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView c_incomeListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView c_categoryGroupDataListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView c_categoryDataListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

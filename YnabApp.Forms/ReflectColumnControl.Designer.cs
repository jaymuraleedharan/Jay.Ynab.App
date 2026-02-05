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
            groupBox1 = new System.Windows.Forms.GroupBox();
            c_categoryGroupDataListView = new System.Windows.Forms.ListView();
            groupBox2 = new System.Windows.Forms.GroupBox();
            c_categoryDataListView = new System.Windows.Forms.ListView();
            groupBox3 = new System.Windows.Forms.GroupBox();
            c_incomeListView = new System.Windows.Forms.ListView();
            groupBox4 = new System.Windows.Forms.GroupBox();
            c_summaryListView = new System.Windows.Forms.ListView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
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
            c_headerLabel.Size = new System.Drawing.Size(559, 23);
            c_headerLabel.TabIndex = 0;
            c_headerLabel.Text = "Jan / 2025";
            c_headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(c_categoryGroupDataListView);
            groupBox1.Location = new System.Drawing.Point(7, 357);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(549, 168);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Expense Category Groups";
            // 
            // c_categoryGroupDataListView
            // 
            c_categoryGroupDataListView.BackColor = System.Drawing.SystemColors.Control;
            c_categoryGroupDataListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_categoryGroupDataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            c_categoryGroupDataListView.FullRowSelect = true;
            c_categoryGroupDataListView.Location = new System.Drawing.Point(3, 19);
            c_categoryGroupDataListView.Name = "c_categoryGroupDataListView";
            c_categoryGroupDataListView.Size = new System.Drawing.Size(543, 146);
            c_categoryGroupDataListView.TabIndex = 16;
            c_categoryGroupDataListView.UseCompatibleStateImageBehavior = false;
            c_categoryGroupDataListView.View = System.Windows.Forms.View.Details;
            c_categoryGroupDataListView.DoubleClick += c_categoryGroupDataListView_DoubleClick;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(c_categoryDataListView);
            groupBox2.Location = new System.Drawing.Point(7, 528);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(549, 390);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Expense Categories";
            // 
            // c_categoryDataListView
            // 
            c_categoryDataListView.BackColor = System.Drawing.SystemColors.Control;
            c_categoryDataListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_categoryDataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            c_categoryDataListView.FullRowSelect = true;
            c_categoryDataListView.Location = new System.Drawing.Point(3, 19);
            c_categoryDataListView.Name = "c_categoryDataListView";
            c_categoryDataListView.Size = new System.Drawing.Size(543, 368);
            c_categoryDataListView.TabIndex = 16;
            c_categoryDataListView.UseCompatibleStateImageBehavior = false;
            c_categoryDataListView.View = System.Windows.Forms.View.Details;
            c_categoryDataListView.DoubleClick += c_categoryDataListView_DoubleClick;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(c_incomeListView);
            groupBox3.Location = new System.Drawing.Point(7, 177);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(549, 177);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Income";
            // 
            // c_incomeListView
            // 
            c_incomeListView.BackColor = System.Drawing.SystemColors.Control;
            c_incomeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_incomeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            c_incomeListView.FullRowSelect = true;
            c_incomeListView.GridLines = true;
            c_incomeListView.Location = new System.Drawing.Point(3, 19);
            c_incomeListView.Name = "c_incomeListView";
            c_incomeListView.Size = new System.Drawing.Size(543, 155);
            c_incomeListView.TabIndex = 16;
            c_incomeListView.UseCompatibleStateImageBehavior = false;
            c_incomeListView.View = System.Windows.Forms.View.Details;
            c_incomeListView.DoubleClick += c_incomeListView_DoubleClick;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(c_summaryListView);
            groupBox4.Location = new System.Drawing.Point(7, 26);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(549, 148);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Summary";
            // 
            // c_summaryListView
            // 
            c_summaryListView.BackColor = System.Drawing.SystemColors.Control;
            c_summaryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_summaryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            c_summaryListView.FullRowSelect = true;
            c_summaryListView.GridLines = true;
            c_summaryListView.Location = new System.Drawing.Point(3, 19);
            c_summaryListView.Name = "c_summaryListView";
            c_summaryListView.Size = new System.Drawing.Size(543, 126);
            c_summaryListView.TabIndex = 16;
            c_summaryListView.UseCompatibleStateImageBehavior = false;
            c_summaryListView.View = System.Windows.Forms.View.Details;
            // 
            // ReflectColumnControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(c_headerLabel);
            Name = "ReflectColumnControl";
            Size = new System.Drawing.Size(559, 921);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label c_headerLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView c_categoryGroupDataListView;
        private System.Windows.Forms.ListView c_categoryDataListView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView c_incomeListView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView c_summaryListView;
    }
}

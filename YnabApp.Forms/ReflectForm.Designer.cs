namespace YnabApp.Forms
{
    partial class ReflectForm
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            c_selectLastThreeMonths = new System.Windows.Forms.Button();
            c_selectLastThreeYears = new System.Windows.Forms.Button();
            c_btnShow = new System.Windows.Forms.Button();
            c_chkColumn3 = new System.Windows.Forms.CheckBox();
            c_chkColumn2 = new System.Windows.Forms.CheckBox();
            c_chkColumn1 = new System.Windows.Forms.CheckBox();
            c_radioDurationYearly = new System.Windows.Forms.RadioButton();
            c_radioDurationMonthly = new System.Windows.Forms.RadioButton();
            c_datePicker3 = new System.Windows.Forms.DateTimePicker();
            c_datePicker2 = new System.Windows.Forms.DateTimePicker();
            c_datePicker1 = new System.Windows.Forms.DateTimePicker();
            c_splitContainer1 = new System.Windows.Forms.SplitContainer();
            c_reflectColumn1 = new ReflectColumnControl();
            c_splitContainer2 = new System.Windows.Forms.SplitContainer();
            c_reflectColumn2 = new ReflectColumnControl();
            c_reflectColumn3 = new ReflectColumnControl();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c_splitContainer1).BeginInit();
            c_splitContainer1.Panel1.SuspendLayout();
            c_splitContainer1.Panel2.SuspendLayout();
            c_splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c_splitContainer2).BeginInit();
            c_splitContainer2.Panel1.SuspendLayout();
            c_splitContainer2.Panel2.SuspendLayout();
            c_splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(c_selectLastThreeMonths);
            groupBox1.Controls.Add(c_selectLastThreeYears);
            groupBox1.Controls.Add(c_btnShow);
            groupBox1.Controls.Add(c_chkColumn3);
            groupBox1.Controls.Add(c_chkColumn2);
            groupBox1.Controls.Add(c_chkColumn1);
            groupBox1.Controls.Add(c_radioDurationYearly);
            groupBox1.Controls.Add(c_radioDurationMonthly);
            groupBox1.Controls.Add(c_datePicker3);
            groupBox1.Controls.Add(c_datePicker2);
            groupBox1.Controls.Add(c_datePicker1);
            groupBox1.Location = new System.Drawing.Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1030, 109);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Criteria";
            // 
            // c_selectLastThreeMonths
            // 
            c_selectLastThreeMonths.Location = new System.Drawing.Point(502, 72);
            c_selectLastThreeMonths.Name = "c_selectLastThreeMonths";
            c_selectLastThreeMonths.Size = new System.Drawing.Size(155, 25);
            c_selectLastThreeMonths.TabIndex = 15;
            c_selectLastThreeMonths.Text = "Select Last Three Months";
            c_selectLastThreeMonths.UseVisualStyleBackColor = true;
            c_selectLastThreeMonths.Click += c_selectLastThreeMonths_Click;
            // 
            // c_selectLastThreeYears
            // 
            c_selectLastThreeYears.Location = new System.Drawing.Point(320, 72);
            c_selectLastThreeYears.Name = "c_selectLastThreeYears";
            c_selectLastThreeYears.Size = new System.Drawing.Size(155, 25);
            c_selectLastThreeYears.TabIndex = 14;
            c_selectLastThreeYears.Text = "Select Last Three Years";
            c_selectLastThreeYears.UseVisualStyleBackColor = true;
            c_selectLastThreeYears.Click += c_selectLastThreeYears_Click;
            // 
            // c_btnShow
            // 
            c_btnShow.Location = new System.Drawing.Point(833, 18);
            c_btnShow.Name = "c_btnShow";
            c_btnShow.Size = new System.Drawing.Size(105, 43);
            c_btnShow.TabIndex = 13;
            c_btnShow.Text = "Show";
            c_btnShow.UseVisualStyleBackColor = true;
            c_btnShow.Click += c_btnShow_Click;
            // 
            // c_chkColumn3
            // 
            c_chkColumn3.AutoSize = true;
            c_chkColumn3.Location = new System.Drawing.Point(672, 32);
            c_chkColumn3.Name = "c_chkColumn3";
            c_chkColumn3.Size = new System.Drawing.Size(15, 14);
            c_chkColumn3.TabIndex = 12;
            c_chkColumn3.UseVisualStyleBackColor = true;
            // 
            // c_chkColumn2
            // 
            c_chkColumn2.AutoSize = true;
            c_chkColumn2.Checked = true;
            c_chkColumn2.CheckState = System.Windows.Forms.CheckState.Checked;
            c_chkColumn2.Location = new System.Drawing.Point(502, 32);
            c_chkColumn2.Name = "c_chkColumn2";
            c_chkColumn2.Size = new System.Drawing.Size(15, 14);
            c_chkColumn2.TabIndex = 11;
            c_chkColumn2.UseVisualStyleBackColor = true;
            // 
            // c_chkColumn1
            // 
            c_chkColumn1.AutoSize = true;
            c_chkColumn1.Checked = true;
            c_chkColumn1.CheckState = System.Windows.Forms.CheckState.Checked;
            c_chkColumn1.Location = new System.Drawing.Point(320, 32);
            c_chkColumn1.Name = "c_chkColumn1";
            c_chkColumn1.Size = new System.Drawing.Size(15, 14);
            c_chkColumn1.TabIndex = 10;
            c_chkColumn1.UseVisualStyleBackColor = true;
            // 
            // c_radioDurationYearly
            // 
            c_radioDurationYearly.AutoSize = true;
            c_radioDurationYearly.Checked = true;
            c_radioDurationYearly.Location = new System.Drawing.Point(6, 30);
            c_radioDurationYearly.Name = "c_radioDurationYearly";
            c_radioDurationYearly.Size = new System.Drawing.Size(63, 19);
            c_radioDurationYearly.TabIndex = 9;
            c_radioDurationYearly.TabStop = true;
            c_radioDurationYearly.Text = "By Year";
            c_radioDurationYearly.UseVisualStyleBackColor = true;
            // 
            // c_radioDurationMonthly
            // 
            c_radioDurationMonthly.AutoSize = true;
            c_radioDurationMonthly.Location = new System.Drawing.Point(75, 30);
            c_radioDurationMonthly.Name = "c_radioDurationMonthly";
            c_radioDurationMonthly.Size = new System.Drawing.Size(77, 19);
            c_radioDurationMonthly.TabIndex = 8;
            c_radioDurationMonthly.Text = "By Month";
            c_radioDurationMonthly.UseVisualStyleBackColor = true;
            // 
            // c_datePicker3
            // 
            c_datePicker3.CustomFormat = "MMM/yyyy";
            c_datePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_datePicker3.Location = new System.Drawing.Point(693, 28);
            c_datePicker3.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_datePicker3.Name = "c_datePicker3";
            c_datePicker3.Size = new System.Drawing.Size(105, 23);
            c_datePicker3.TabIndex = 6;
            c_datePicker3.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // c_datePicker2
            // 
            c_datePicker2.CustomFormat = "MMM/yyyy";
            c_datePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_datePicker2.Location = new System.Drawing.Point(523, 28);
            c_datePicker2.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_datePicker2.Name = "c_datePicker2";
            c_datePicker2.Size = new System.Drawing.Size(105, 23);
            c_datePicker2.TabIndex = 4;
            c_datePicker2.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // c_datePicker1
            // 
            c_datePicker1.CustomFormat = "MMM/yyyy";
            c_datePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_datePicker1.Location = new System.Drawing.Point(341, 28);
            c_datePicker1.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_datePicker1.Name = "c_datePicker1";
            c_datePicker1.Size = new System.Drawing.Size(105, 23);
            c_datePicker1.TabIndex = 2;
            c_datePicker1.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // c_splitContainer1
            // 
            c_splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_splitContainer1.Location = new System.Drawing.Point(10, 126);
            c_splitContainer1.Name = "c_splitContainer1";
            // 
            // c_splitContainer1.Panel1
            // 
            c_splitContainer1.Panel1.Controls.Add(c_reflectColumn1);
            // 
            // c_splitContainer1.Panel2
            // 
            c_splitContainer1.Panel2.Controls.Add(c_splitContainer2);
            c_splitContainer1.Size = new System.Drawing.Size(1030, 657);
            c_splitContainer1.SplitterDistance = 343;
            c_splitContainer1.TabIndex = 1;
            // 
            // c_reflectColumn1
            // 
            c_reflectColumn1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            c_reflectColumn1.Dock = System.Windows.Forms.DockStyle.Fill;
            c_reflectColumn1.Location = new System.Drawing.Point(0, 0);
            c_reflectColumn1.Name = "c_reflectColumn1";
            c_reflectColumn1.Size = new System.Drawing.Size(343, 657);
            c_reflectColumn1.TabIndex = 0;
            // 
            // c_splitContainer2
            // 
            c_splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            c_splitContainer2.Location = new System.Drawing.Point(0, 0);
            c_splitContainer2.Name = "c_splitContainer2";
            // 
            // c_splitContainer2.Panel1
            // 
            c_splitContainer2.Panel1.Controls.Add(c_reflectColumn2);
            // 
            // c_splitContainer2.Panel2
            // 
            c_splitContainer2.Panel2.Controls.Add(c_reflectColumn3);
            c_splitContainer2.Size = new System.Drawing.Size(683, 657);
            c_splitContainer2.SplitterDistance = 226;
            c_splitContainer2.TabIndex = 0;
            // 
            // c_reflectColumn2
            // 
            c_reflectColumn2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            c_reflectColumn2.Dock = System.Windows.Forms.DockStyle.Fill;
            c_reflectColumn2.Location = new System.Drawing.Point(0, 0);
            c_reflectColumn2.Name = "c_reflectColumn2";
            c_reflectColumn2.Size = new System.Drawing.Size(226, 657);
            c_reflectColumn2.TabIndex = 0;
            // 
            // c_reflectColumn3
            // 
            c_reflectColumn3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            c_reflectColumn3.Dock = System.Windows.Forms.DockStyle.Fill;
            c_reflectColumn3.Location = new System.Drawing.Point(0, 0);
            c_reflectColumn3.Name = "c_reflectColumn3";
            c_reflectColumn3.Size = new System.Drawing.Size(453, 657);
            c_reflectColumn3.TabIndex = 0;
            // 
            // ReflectForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1052, 779);
            Controls.Add(c_splitContainer1);
            Controls.Add(groupBox1);
            Name = "ReflectForm";
            Text = "Reflect";
            Load += ReflectForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            c_splitContainer1.Panel1.ResumeLayout(false);
            c_splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c_splitContainer1).EndInit();
            c_splitContainer1.ResumeLayout(false);
            c_splitContainer2.Panel1.ResumeLayout(false);
            c_splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c_splitContainer2).EndInit();
            c_splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker c_datePicker1;
        private System.Windows.Forms.DateTimePicker c_datePicker3;
        private System.Windows.Forms.DateTimePicker c_datePicker2;
        private System.Windows.Forms.RadioButton c_radioDurationYearly;
        private System.Windows.Forms.RadioButton c_radioDurationMonthly;
        private System.Windows.Forms.CheckBox c_chkColumn3;
        private System.Windows.Forms.CheckBox c_chkColumn2;
        private System.Windows.Forms.CheckBox c_chkColumn1;
        private System.Windows.Forms.Button c_btnShow;
        private System.Windows.Forms.SplitContainer c_splitContainer1;
        private System.Windows.Forms.SplitContainer c_splitContainer2;
        private ReflectColumnControl c_reflectColumn1;
        private ReflectColumnControl c_reflectColumn2;
        private ReflectColumnControl c_reflectColumn3;
        private System.Windows.Forms.Button c_selectLastThreeMonths;
        private System.Windows.Forms.Button c_selectLastThreeYears;
    }
}
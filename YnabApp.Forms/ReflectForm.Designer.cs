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
            c_moveForwardButton = new System.Windows.Forms.Button();
            c_moveBackButton = new System.Windows.Forms.Button();
            groupBox7 = new System.Windows.Forms.GroupBox();
            c_chkBoxData6 = new System.Windows.Forms.CheckBox();
            c_dtPckData6 = new System.Windows.Forms.DateTimePicker();
            groupBox6 = new System.Windows.Forms.GroupBox();
            c_chkBoxData5 = new System.Windows.Forms.CheckBox();
            c_dtPckData5 = new System.Windows.Forms.DateTimePicker();
            groupBox5 = new System.Windows.Forms.GroupBox();
            c_chkBoxData4 = new System.Windows.Forms.CheckBox();
            c_dtPckData4 = new System.Windows.Forms.DateTimePicker();
            groupBox4 = new System.Windows.Forms.GroupBox();
            c_chkBoxData3 = new System.Windows.Forms.CheckBox();
            c_dtPckData3 = new System.Windows.Forms.DateTimePicker();
            groupBox3 = new System.Windows.Forms.GroupBox();
            c_chkBoxData2 = new System.Windows.Forms.CheckBox();
            c_dtPckData2 = new System.Windows.Forms.DateTimePicker();
            groupBox2 = new System.Windows.Forms.GroupBox();
            c_chkBoxData1 = new System.Windows.Forms.CheckBox();
            c_dtPckData1 = new System.Windows.Forms.DateTimePicker();
            c_selectLastThreeMonths = new System.Windows.Forms.Button();
            c_selectLastThreeYears = new System.Windows.Forms.Button();
            c_btnShow = new System.Windows.Forms.Button();
            c_radioDurationYearly = new System.Windows.Forms.RadioButton();
            c_radioDurationMonthly = new System.Windows.Forms.RadioButton();
            c_reflectControlsPanel = new System.Windows.Forms.Panel();
            c_reflectControlsTable = new System.Windows.Forms.TableLayoutPanel();
            groupBox8 = new System.Windows.Forms.GroupBox();
            c_radioPersonAll = new System.Windows.Forms.RadioButton();
            c_radioPersonJay = new System.Windows.Forms.RadioButton();
            c_radioPersonShar = new System.Windows.Forms.RadioButton();
            groupBox1.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            c_reflectControlsPanel.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox8);
            groupBox1.Controls.Add(c_moveForwardButton);
            groupBox1.Controls.Add(c_moveBackButton);
            groupBox1.Controls.Add(groupBox7);
            groupBox1.Controls.Add(groupBox6);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(c_selectLastThreeMonths);
            groupBox1.Controls.Add(c_selectLastThreeYears);
            groupBox1.Controls.Add(c_btnShow);
            groupBox1.Controls.Add(c_radioDurationYearly);
            groupBox1.Controls.Add(c_radioDurationMonthly);
            groupBox1.Location = new System.Drawing.Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1603, 146);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Criteria";
            // 
            // c_moveForwardButton
            // 
            c_moveForwardButton.Location = new System.Drawing.Point(659, 21);
            c_moveForwardButton.Name = "c_moveForwardButton";
            c_moveForwardButton.Size = new System.Drawing.Size(34, 26);
            c_moveForwardButton.TabIndex = 22;
            c_moveForwardButton.Text = "▶";
            c_moveForwardButton.UseVisualStyleBackColor = true;
            c_moveForwardButton.Click += c_moveForwardButton_Click;
            // 
            // c_moveBackButton
            // 
            c_moveBackButton.Location = new System.Drawing.Point(252, 21);
            c_moveBackButton.Name = "c_moveBackButton";
            c_moveBackButton.Size = new System.Drawing.Size(34, 26);
            c_moveBackButton.TabIndex = 21;
            c_moveBackButton.Text = "◀";
            c_moveBackButton.UseVisualStyleBackColor = true;
            c_moveBackButton.Click += c_moveBackButton_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(c_chkBoxData6);
            groupBox7.Controls.Add(c_dtPckData6);
            groupBox7.Location = new System.Drawing.Point(873, 55);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(166, 79);
            groupBox7.TabIndex = 17;
            groupBox7.TabStop = false;
            groupBox7.Text = "Data #6";
            // 
            // c_chkBoxData6
            // 
            c_chkBoxData6.AutoSize = true;
            c_chkBoxData6.Location = new System.Drawing.Point(18, 35);
            c_chkBoxData6.Name = "c_chkBoxData6";
            c_chkBoxData6.Size = new System.Drawing.Size(15, 14);
            c_chkBoxData6.TabIndex = 12;
            c_chkBoxData6.Tag = "c_dtPckData6";
            c_chkBoxData6.UseVisualStyleBackColor = true;
            c_chkBoxData6.CheckStateChanged += c_chkBoxData_CheckedChanged;
            // 
            // c_dtPckData6
            // 
            c_dtPckData6.CustomFormat = "MMM/yyyy";
            c_dtPckData6.Enabled = false;
            c_dtPckData6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckData6.Location = new System.Drawing.Point(39, 31);
            c_dtPckData6.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckData6.Name = "c_dtPckData6";
            c_dtPckData6.Size = new System.Drawing.Size(105, 23);
            c_dtPckData6.TabIndex = 11;
            c_dtPckData6.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(c_chkBoxData5);
            groupBox6.Controls.Add(c_dtPckData5);
            groupBox6.Location = new System.Drawing.Point(701, 55);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(166, 79);
            groupBox6.TabIndex = 20;
            groupBox6.TabStop = false;
            groupBox6.Text = "Data #5";
            // 
            // c_chkBoxData5
            // 
            c_chkBoxData5.AutoSize = true;
            c_chkBoxData5.Location = new System.Drawing.Point(18, 35);
            c_chkBoxData5.Name = "c_chkBoxData5";
            c_chkBoxData5.Size = new System.Drawing.Size(15, 14);
            c_chkBoxData5.TabIndex = 12;
            c_chkBoxData5.Tag = "c_dtPckData5";
            c_chkBoxData5.UseVisualStyleBackColor = true;
            c_chkBoxData5.CheckStateChanged += c_chkBoxData_CheckedChanged;
            // 
            // c_dtPckData5
            // 
            c_dtPckData5.CustomFormat = "MMM/yyyy";
            c_dtPckData5.Enabled = false;
            c_dtPckData5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckData5.Location = new System.Drawing.Point(39, 31);
            c_dtPckData5.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckData5.Name = "c_dtPckData5";
            c_dtPckData5.Size = new System.Drawing.Size(105, 23);
            c_dtPckData5.TabIndex = 11;
            c_dtPckData5.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(c_chkBoxData4);
            groupBox5.Controls.Add(c_dtPckData4);
            groupBox5.Location = new System.Drawing.Point(529, 55);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(166, 79);
            groupBox5.TabIndex = 19;
            groupBox5.TabStop = false;
            groupBox5.Text = "Data #4";
            // 
            // c_chkBoxData4
            // 
            c_chkBoxData4.AutoSize = true;
            c_chkBoxData4.Location = new System.Drawing.Point(18, 35);
            c_chkBoxData4.Name = "c_chkBoxData4";
            c_chkBoxData4.Size = new System.Drawing.Size(15, 14);
            c_chkBoxData4.TabIndex = 12;
            c_chkBoxData4.Tag = "c_dtPckData4";
            c_chkBoxData4.UseVisualStyleBackColor = true;
            c_chkBoxData4.CheckStateChanged += c_chkBoxData_CheckedChanged;
            // 
            // c_dtPckData4
            // 
            c_dtPckData4.CustomFormat = "MMM/yyyy";
            c_dtPckData4.Enabled = false;
            c_dtPckData4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckData4.Location = new System.Drawing.Point(39, 31);
            c_dtPckData4.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckData4.Name = "c_dtPckData4";
            c_dtPckData4.Size = new System.Drawing.Size(105, 23);
            c_dtPckData4.TabIndex = 11;
            c_dtPckData4.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(c_chkBoxData3);
            groupBox4.Controls.Add(c_dtPckData3);
            groupBox4.Location = new System.Drawing.Point(357, 55);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(166, 79);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Text = "Data #3";
            // 
            // c_chkBoxData3
            // 
            c_chkBoxData3.AutoSize = true;
            c_chkBoxData3.Checked = true;
            c_chkBoxData3.CheckState = System.Windows.Forms.CheckState.Checked;
            c_chkBoxData3.Location = new System.Drawing.Point(18, 35);
            c_chkBoxData3.Name = "c_chkBoxData3";
            c_chkBoxData3.Size = new System.Drawing.Size(15, 14);
            c_chkBoxData3.TabIndex = 12;
            c_chkBoxData3.Tag = "c_dtPckData3";
            c_chkBoxData3.UseVisualStyleBackColor = true;
            c_chkBoxData3.CheckedChanged += c_chkBoxData_CheckedChanged;
            // 
            // c_dtPckData3
            // 
            c_dtPckData3.CustomFormat = "MMM/yyyy";
            c_dtPckData3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckData3.Location = new System.Drawing.Point(39, 31);
            c_dtPckData3.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckData3.Name = "c_dtPckData3";
            c_dtPckData3.Size = new System.Drawing.Size(105, 23);
            c_dtPckData3.TabIndex = 11;
            c_dtPckData3.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(c_chkBoxData2);
            groupBox3.Controls.Add(c_dtPckData2);
            groupBox3.Location = new System.Drawing.Point(181, 55);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(166, 79);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Data #2";
            // 
            // c_chkBoxData2
            // 
            c_chkBoxData2.AutoSize = true;
            c_chkBoxData2.Checked = true;
            c_chkBoxData2.CheckState = System.Windows.Forms.CheckState.Checked;
            c_chkBoxData2.Location = new System.Drawing.Point(18, 35);
            c_chkBoxData2.Name = "c_chkBoxData2";
            c_chkBoxData2.Size = new System.Drawing.Size(15, 14);
            c_chkBoxData2.TabIndex = 12;
            c_chkBoxData2.Tag = "c_dtPckData2";
            c_chkBoxData2.UseVisualStyleBackColor = true;
            c_chkBoxData2.CheckedChanged += c_chkBoxData_CheckedChanged;
            // 
            // c_dtPckData2
            // 
            c_dtPckData2.CustomFormat = "MMM/yyyy";
            c_dtPckData2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckData2.Location = new System.Drawing.Point(39, 31);
            c_dtPckData2.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckData2.Name = "c_dtPckData2";
            c_dtPckData2.Size = new System.Drawing.Size(105, 23);
            c_dtPckData2.TabIndex = 11;
            c_dtPckData2.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(c_chkBoxData1);
            groupBox2.Controls.Add(c_dtPckData1);
            groupBox2.Location = new System.Drawing.Point(9, 55);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(166, 79);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data #1";
            // 
            // c_chkBoxData1
            // 
            c_chkBoxData1.AutoSize = true;
            c_chkBoxData1.Checked = true;
            c_chkBoxData1.CheckState = System.Windows.Forms.CheckState.Checked;
            c_chkBoxData1.Enabled = false;
            c_chkBoxData1.Location = new System.Drawing.Point(18, 35);
            c_chkBoxData1.Name = "c_chkBoxData1";
            c_chkBoxData1.Size = new System.Drawing.Size(15, 14);
            c_chkBoxData1.TabIndex = 12;
            c_chkBoxData1.Tag = "c_dtPckData1";
            c_chkBoxData1.UseVisualStyleBackColor = true;
            c_chkBoxData1.CheckedChanged += c_chkBoxData_CheckedChanged;
            // 
            // c_dtPckData1
            // 
            c_dtPckData1.CustomFormat = "MMM/yyyy";
            c_dtPckData1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckData1.Location = new System.Drawing.Point(39, 31);
            c_dtPckData1.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckData1.Name = "c_dtPckData1";
            c_dtPckData1.Size = new System.Drawing.Size(105, 23);
            c_dtPckData1.TabIndex = 11;
            c_dtPckData1.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // c_selectLastThreeMonths
            // 
            c_selectLastThreeMonths.Location = new System.Drawing.Point(483, 21);
            c_selectLastThreeMonths.Name = "c_selectLastThreeMonths";
            c_selectLastThreeMonths.Size = new System.Drawing.Size(155, 26);
            c_selectLastThreeMonths.TabIndex = 15;
            c_selectLastThreeMonths.Text = "Select Recent Months";
            c_selectLastThreeMonths.UseVisualStyleBackColor = true;
            c_selectLastThreeMonths.Click += c_selectLastThreeMonths_Click;
            // 
            // c_selectLastThreeYears
            // 
            c_selectLastThreeYears.Location = new System.Drawing.Point(307, 21);
            c_selectLastThreeYears.Name = "c_selectLastThreeYears";
            c_selectLastThreeYears.Size = new System.Drawing.Size(155, 26);
            c_selectLastThreeYears.TabIndex = 14;
            c_selectLastThreeYears.Text = "Select Recent Years";
            c_selectLastThreeYears.UseVisualStyleBackColor = true;
            c_selectLastThreeYears.Click += c_selectLastThreeYears_Click;
            // 
            // c_btnShow
            // 
            c_btnShow.Location = new System.Drawing.Point(1143, 72);
            c_btnShow.Name = "c_btnShow";
            c_btnShow.Size = new System.Drawing.Size(105, 43);
            c_btnShow.TabIndex = 13;
            c_btnShow.Text = "Show";
            c_btnShow.UseVisualStyleBackColor = true;
            c_btnShow.Click += c_btnShow_Click;
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
            // c_reflectControlsPanel
            // 
            c_reflectControlsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_reflectControlsPanel.Controls.Add(c_reflectControlsTable);
            c_reflectControlsPanel.Location = new System.Drawing.Point(10, 163);
            c_reflectControlsPanel.Name = "c_reflectControlsPanel";
            c_reflectControlsPanel.Size = new System.Drawing.Size(1603, 604);
            c_reflectControlsPanel.TabIndex = 1;
            // 
            // c_reflectControlsTable
            // 
            c_reflectControlsTable.ColumnCount = 1;
            c_reflectControlsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            c_reflectControlsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            c_reflectControlsTable.Location = new System.Drawing.Point(0, 0);
            c_reflectControlsTable.Name = "c_reflectControlsTable";
            c_reflectControlsTable.RowCount = 1;
            c_reflectControlsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            c_reflectControlsTable.Size = new System.Drawing.Size(1603, 604);
            c_reflectControlsTable.TabIndex = 0;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(c_radioPersonShar);
            groupBox8.Controls.Add(c_radioPersonJay);
            groupBox8.Controls.Add(c_radioPersonAll);
            groupBox8.Location = new System.Drawing.Point(1045, 21);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new System.Drawing.Size(92, 113);
            groupBox8.TabIndex = 23;
            groupBox8.TabStop = false;
            groupBox8.Text = "Select Person";
            // 
            // c_radioPersonAll
            // 
            c_radioPersonAll.AutoSize = true;
            c_radioPersonAll.Checked = true;
            c_radioPersonAll.Location = new System.Drawing.Point(17, 28);
            c_radioPersonAll.Name = "c_radioPersonAll";
            c_radioPersonAll.Size = new System.Drawing.Size(39, 19);
            c_radioPersonAll.TabIndex = 0;
            c_radioPersonAll.Tag = "c_radioPersonAll";
            c_radioPersonAll.Text = "All";
            c_radioPersonAll.UseVisualStyleBackColor = true;
            // 
            // c_radioPersonJay
            // 
            c_radioPersonJay.AutoSize = true;
            c_radioPersonJay.Location = new System.Drawing.Point(17, 53);
            c_radioPersonJay.Name = "c_radioPersonJay";
            c_radioPersonJay.Size = new System.Drawing.Size(41, 19);
            c_radioPersonJay.TabIndex = 1;
            c_radioPersonJay.Tag = "c_radioPersonJay";
            c_radioPersonJay.Text = "Jay";
            c_radioPersonJay.UseVisualStyleBackColor = true;
            // 
            // c_radioPersonShar
            // 
            c_radioPersonShar.AutoSize = true;
            c_radioPersonShar.Location = new System.Drawing.Point(17, 78);
            c_radioPersonShar.Name = "c_radioPersonShar";
            c_radioPersonShar.Size = new System.Drawing.Size(48, 19);
            c_radioPersonShar.TabIndex = 2;
            c_radioPersonShar.Tag = "c_radioPersonShar";
            c_radioPersonShar.Text = "Shar";
            c_radioPersonShar.UseVisualStyleBackColor = true;
            // 
            // ReflectForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1625, 779);
            Controls.Add(c_reflectControlsPanel);
            Controls.Add(groupBox1);
            Name = "ReflectForm";
            Text = "Reflect";
            Load += ReflectForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            c_reflectControlsPanel.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton c_radioDurationYearly;
        private System.Windows.Forms.RadioButton c_radioDurationMonthly;
        private System.Windows.Forms.Button c_btnShow;
        private System.Windows.Forms.Button c_selectLastThreeMonths;
        private System.Windows.Forms.Button c_selectLastThreeYears;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox c_chkBoxData1;
        private System.Windows.Forms.DateTimePicker c_dtPckData1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox c_chkBoxData6;
        private System.Windows.Forms.DateTimePicker c_dtPckData6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox c_chkBoxData5;
        private System.Windows.Forms.DateTimePicker c_dtPckData5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox c_chkBoxData4;
        private System.Windows.Forms.DateTimePicker c_dtPckData4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox c_chkBoxData3;
        private System.Windows.Forms.DateTimePicker c_dtPckData3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox c_chkBoxData2;
        private System.Windows.Forms.DateTimePicker c_dtPckData2;
        private System.Windows.Forms.Panel c_reflectControlsPanel;
        private System.Windows.Forms.TableLayoutPanel c_reflectControlsTable;
        private System.Windows.Forms.Button c_moveForwardButton;
        private System.Windows.Forms.Button c_moveBackButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton c_radioPersonAll;
        private System.Windows.Forms.RadioButton c_radioPersonShar;
        private System.Windows.Forms.RadioButton c_radioPersonJay;
    }
}
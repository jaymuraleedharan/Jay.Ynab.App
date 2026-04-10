namespace YnabApp.Forms
{
    partial class ReflectGraphForm
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
            c_grpBoxCriteria = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            btnShowGraph = new System.Windows.Forms.Button();
            c_radBtnCustom = new System.Windows.Forms.RadioButton();
            c_dtPckCustomEnd = new System.Windows.Forms.DateTimePicker();
            c_dtPckCustomStart = new System.Windows.Forms.DateTimePicker();
            radioButton1 = new System.Windows.Forms.RadioButton();
            label2 = new System.Windows.Forms.Label();
            c_radBtnByMonthLastYear = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            c_radBtnByMonthThisYear = new System.Windows.Forms.RadioButton();
            c_splitContainer = new System.Windows.Forms.SplitContainer();
            c_personList = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            c_grpBoxCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c_splitContainer).BeginInit();
            c_splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // c_grpBoxCriteria
            // 
            c_grpBoxCriteria.Controls.Add(c_personList);
            c_grpBoxCriteria.Controls.Add(label4);
            c_grpBoxCriteria.Controls.Add(label3);
            c_grpBoxCriteria.Controls.Add(btnShowGraph);
            c_grpBoxCriteria.Controls.Add(c_radBtnCustom);
            c_grpBoxCriteria.Controls.Add(c_dtPckCustomEnd);
            c_grpBoxCriteria.Controls.Add(c_dtPckCustomStart);
            c_grpBoxCriteria.Controls.Add(radioButton1);
            c_grpBoxCriteria.Controls.Add(label2);
            c_grpBoxCriteria.Controls.Add(c_radBtnByMonthLastYear);
            c_grpBoxCriteria.Controls.Add(label1);
            c_grpBoxCriteria.Controls.Add(c_radBtnByMonthThisYear);
            c_grpBoxCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            c_grpBoxCriteria.Location = new System.Drawing.Point(0, 0);
            c_grpBoxCriteria.Name = "c_grpBoxCriteria";
            c_grpBoxCriteria.Size = new System.Drawing.Size(1254, 108);
            c_grpBoxCriteria.TabIndex = 0;
            c_grpBoxCriteria.TabStop = false;
            c_grpBoxCriteria.Text = "Charting Criteria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(494, 23);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(20, 15);
            label3.TabIndex = 29;
            label3.Text = "To";
            // 
            // btnShowGraph
            // 
            btnShowGraph.Location = new System.Drawing.Point(637, 17);
            btnShowGraph.Name = "btnShowGraph";
            btnShowGraph.Size = new System.Drawing.Size(98, 26);
            btnShowGraph.TabIndex = 28;
            btnShowGraph.Text = "Show Charts";
            btnShowGraph.UseVisualStyleBackColor = true;
            btnShowGraph.Click += btnShowGraph_Click;
            // 
            // c_radBtnCustom
            // 
            c_radBtnCustom.AutoSize = true;
            c_radBtnCustom.Location = new System.Drawing.Point(269, 21);
            c_radBtnCustom.Name = "c_radBtnCustom";
            c_radBtnCustom.Size = new System.Drawing.Size(101, 19);
            c_radBtnCustom.TabIndex = 17;
            c_radBtnCustom.Text = "Custom: From";
            c_radBtnCustom.UseVisualStyleBackColor = true;
            // 
            // c_dtPckCustomEnd
            // 
            c_dtPckCustomEnd.CustomFormat = "MMM/yyyy";
            c_dtPckCustomEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckCustomEnd.Location = new System.Drawing.Point(531, 19);
            c_dtPckCustomEnd.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckCustomEnd.Name = "c_dtPckCustomEnd";
            c_dtPckCustomEnd.Size = new System.Drawing.Size(91, 23);
            c_dtPckCustomEnd.TabIndex = 16;
            c_dtPckCustomEnd.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // c_dtPckCustomStart
            // 
            c_dtPckCustomStart.CustomFormat = "MMM/yyyy";
            c_dtPckCustomStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            c_dtPckCustomStart.Location = new System.Drawing.Point(384, 19);
            c_dtPckCustomStart.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            c_dtPckCustomStart.Name = "c_dtPckCustomStart";
            c_dtPckCustomStart.Size = new System.Drawing.Size(91, 23);
            c_dtPckCustomStart.TabIndex = 15;
            c_dtPckCustomStart.Value = new System.DateTime(2026, 1, 6, 0, 0, 0, 0);
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(90, 46);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(69, 19);
            radioButton1.TabIndex = 14;
            radioButton1.Text = "All Time";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(16, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 15);
            label2.TabIndex = 13;
            label2.Text = "By Year";
            // 
            // c_radBtnByMonthLastYear
            // 
            c_radBtnByMonthLastYear.AutoSize = true;
            c_radBtnByMonthLastYear.Location = new System.Drawing.Point(176, 21);
            c_radBtnByMonthLastYear.Name = "c_radBtnByMonthLastYear";
            c_radBtnByMonthLastYear.Size = new System.Drawing.Size(71, 19);
            c_radBtnByMonthLastYear.TabIndex = 12;
            c_radBtnByMonthLastYear.Text = "Last Year";
            c_radBtnByMonthLastYear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(16, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 15);
            label1.TabIndex = 11;
            label1.Text = "By Month";
            // 
            // c_radBtnByMonthThisYear
            // 
            c_radBtnByMonthThisYear.AutoSize = true;
            c_radBtnByMonthThisYear.Checked = true;
            c_radBtnByMonthThisYear.Location = new System.Drawing.Point(90, 21);
            c_radBtnByMonthThisYear.Name = "c_radBtnByMonthThisYear";
            c_radBtnByMonthThisYear.Size = new System.Drawing.Size(72, 19);
            c_radBtnByMonthThisYear.TabIndex = 10;
            c_radBtnByMonthThisYear.TabStop = true;
            c_radBtnByMonthThisYear.Text = "This Year";
            c_radBtnByMonthThisYear.UseVisualStyleBackColor = true;
            // 
            // c_splitContainer
            // 
            c_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            c_splitContainer.Location = new System.Drawing.Point(0, 108);
            c_splitContainer.Name = "c_splitContainer";
            c_splitContainer.Size = new System.Drawing.Size(1254, 736);
            c_splitContainer.SplitterDistance = 739;
            c_splitContainer.TabIndex = 1;
            // 
            // c_personList
            // 
            c_personList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            c_personList.FormattingEnabled = true;
            c_personList.Items.AddRange(new object[] { "ALL", "JAY", "SHAR" });
            c_personList.Location = new System.Drawing.Point(517, 48);
            c_personList.Name = "c_personList";
            c_personList.Size = new System.Drawing.Size(105, 23);
            c_personList.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            label4.Location = new System.Drawing.Point(418, 52);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(93, 15);
            label4.TabIndex = 30;
            label4.Text = "Account Owner:";
            // 
            // ReflectGraphForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1254, 844);
            Controls.Add(c_splitContainer);
            Controls.Add(c_grpBoxCriteria);
            Name = "ReflectGraphForm";
            Text = "Charts";
            c_grpBoxCriteria.ResumeLayout(false);
            c_grpBoxCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c_splitContainer).EndInit();
            c_splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox c_grpBoxCriteria;
        private System.Windows.Forms.RadioButton c_radBtnByMonthThisYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton c_radBtnByMonthLastYear;
        private System.Windows.Forms.DateTimePicker c_dtPckCustomStart;
        private System.Windows.Forms.RadioButton c_radBtnCustom;
        private System.Windows.Forms.DateTimePicker c_dtPckCustomEnd;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer c_splitContainer;
        private System.Windows.Forms.ComboBox c_personList;
        private System.Windows.Forms.Label label4;
    }
}
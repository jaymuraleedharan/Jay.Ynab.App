namespace YnabApp.Forms
{
    partial class BudgetSettingsForm
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
            c_renamePersonButton = new System.Windows.Forms.Button();
            c_removePersonButton = new System.Windows.Forms.Button();
            c_addPersonButton = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            c_infoBudgetEndDate = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            c_infoBudgetStartDate = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            c_infoBudgetLastModifed = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            c_infoBudgetName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            c_infoBudgetID = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            c_personAccRemoveButton = new System.Windows.Forms.Button();
            c_personAccAddButton = new System.Windows.Forms.Button();
            c_personAccountsAddedList = new System.Windows.Forms.ListBox();
            c_personAccountsAvailableList = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            c_personList = new System.Windows.Forms.ComboBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            c_fontColorButton = new System.Windows.Forms.Button();
            c_backColorButton = new System.Windows.Forms.Button();
            c_catGroupListview = new System.Windows.Forms.ListView();
            c_colorDialog = new System.Windows.Forms.ColorDialog();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // c_renamePersonButton
            // 
            c_renamePersonButton.Location = new System.Drawing.Point(276, 26);
            c_renamePersonButton.Name = "c_renamePersonButton";
            c_renamePersonButton.Size = new System.Drawing.Size(40, 23);
            c_renamePersonButton.TabIndex = 3;
            c_renamePersonButton.Text = "Ren";
            c_renamePersonButton.UseVisualStyleBackColor = true;
            c_renamePersonButton.Click += c_renamePersonButton_Click;
            // 
            // c_removePersonButton
            // 
            c_removePersonButton.Location = new System.Drawing.Point(322, 26);
            c_removePersonButton.Name = "c_removePersonButton";
            c_removePersonButton.Size = new System.Drawing.Size(40, 23);
            c_removePersonButton.TabIndex = 2;
            c_removePersonButton.Text = "-";
            c_removePersonButton.UseVisualStyleBackColor = true;
            c_removePersonButton.Click += c_removePersonButton_Click;
            // 
            // c_addPersonButton
            // 
            c_addPersonButton.Location = new System.Drawing.Point(230, 26);
            c_addPersonButton.Name = "c_addPersonButton";
            c_addPersonButton.Size = new System.Drawing.Size(40, 23);
            c_addPersonButton.TabIndex = 1;
            c_addPersonButton.Text = "+";
            c_addPersonButton.UseVisualStyleBackColor = true;
            c_addPersonButton.Click += c_addPersonButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(c_infoBudgetEndDate);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(c_infoBudgetStartDate);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(c_infoBudgetLastModifed);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(c_infoBudgetName);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(c_infoBudgetID);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new System.Drawing.Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(367, 180);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Basic Information";
            // 
            // c_infoBudgetEndDate
            // 
            c_infoBudgetEndDate.Location = new System.Drawing.Point(101, 144);
            c_infoBudgetEndDate.Name = "c_infoBudgetEndDate";
            c_infoBudgetEndDate.ReadOnly = true;
            c_infoBudgetEndDate.Size = new System.Drawing.Size(260, 23);
            c_infoBudgetEndDate.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 148);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(57, 15);
            label6.TabIndex = 8;
            label6.Text = "End Date:";
            // 
            // c_infoBudgetStartDate
            // 
            c_infoBudgetStartDate.Location = new System.Drawing.Point(101, 115);
            c_infoBudgetStartDate.Name = "c_infoBudgetStartDate";
            c_infoBudgetStartDate.ReadOnly = true;
            c_infoBudgetStartDate.Size = new System.Drawing.Size(260, 23);
            c_infoBudgetStartDate.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 119);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(61, 15);
            label5.TabIndex = 6;
            label5.Text = "Start Date:";
            // 
            // c_infoBudgetLastModifed
            // 
            c_infoBudgetLastModifed.Location = new System.Drawing.Point(101, 86);
            c_infoBudgetLastModifed.Name = "c_infoBudgetLastModifed";
            c_infoBudgetLastModifed.ReadOnly = true;
            c_infoBudgetLastModifed.Size = new System.Drawing.Size(260, 23);
            c_infoBudgetLastModifed.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 90);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(82, 15);
            label4.TabIndex = 4;
            label4.Text = "Last Modified:";
            // 
            // c_infoBudgetName
            // 
            c_infoBudgetName.Location = new System.Drawing.Point(101, 54);
            c_infoBudgetName.Name = "c_infoBudgetName";
            c_infoBudgetName.ReadOnly = true;
            c_infoBudgetName.Size = new System.Drawing.Size(260, 23);
            c_infoBudgetName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 58);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Name:";
            // 
            // c_infoBudgetID
            // 
            c_infoBudgetID.Location = new System.Drawing.Point(101, 25);
            c_infoBudgetID.Name = "c_infoBudgetID";
            c_infoBudgetID.ReadOnly = true;
            c_infoBudgetID.Size = new System.Drawing.Size(260, 23);
            c_infoBudgetID.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 28);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(21, 15);
            label2.TabIndex = 0;
            label2.Text = "ID:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(c_removePersonButton);
            groupBox3.Controls.Add(c_renamePersonButton);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(c_addPersonButton);
            groupBox3.Controls.Add(c_personAccRemoveButton);
            groupBox3.Controls.Add(c_personAccAddButton);
            groupBox3.Controls.Add(c_personAccountsAddedList);
            groupBox3.Controls.Add(c_personAccountsAvailableList);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(c_personList);
            groupBox3.Location = new System.Drawing.Point(397, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(368, 360);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Person && Accounts";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(201, 58);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(107, 15);
            label8.TabIndex = 10;
            label8.Text = "Selected Accounts:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(11, 58);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(77, 15);
            label7.TabIndex = 9;
            label7.Text = "All Accounts:";
            // 
            // c_personAccRemoveButton
            // 
            c_personAccRemoveButton.Location = new System.Drawing.Point(171, 171);
            c_personAccRemoveButton.Name = "c_personAccRemoveButton";
            c_personAccRemoveButton.Size = new System.Drawing.Size(27, 23);
            c_personAccRemoveButton.TabIndex = 7;
            c_personAccRemoveButton.Text = "◀";
            c_personAccRemoveButton.UseVisualStyleBackColor = true;
            c_personAccRemoveButton.Click += c_personAccRemoveButton_Click;
            // 
            // c_personAccAddButton
            // 
            c_personAccAddButton.Location = new System.Drawing.Point(171, 142);
            c_personAccAddButton.Name = "c_personAccAddButton";
            c_personAccAddButton.Size = new System.Drawing.Size(27, 23);
            c_personAccAddButton.TabIndex = 6;
            c_personAccAddButton.Text = "▶";
            c_personAccAddButton.UseVisualStyleBackColor = true;
            c_personAccAddButton.Click += c_personAccAddButton_Click;
            // 
            // c_personAccountsAddedList
            // 
            c_personAccountsAddedList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_personAccountsAddedList.FormattingEnabled = true;
            c_personAccountsAddedList.ItemHeight = 15;
            c_personAccountsAddedList.Location = new System.Drawing.Point(201, 76);
            c_personAccountsAddedList.Name = "c_personAccountsAddedList";
            c_personAccountsAddedList.Size = new System.Drawing.Size(161, 270);
            c_personAccountsAddedList.TabIndex = 5;
            c_personAccountsAddedList.DoubleClick += c_personAccountsAddedList_DoubleClick;
            // 
            // c_personAccountsAvailableList
            // 
            c_personAccountsAvailableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_personAccountsAvailableList.FormattingEnabled = true;
            c_personAccountsAvailableList.ItemHeight = 15;
            c_personAccountsAvailableList.Location = new System.Drawing.Point(9, 76);
            c_personAccountsAvailableList.Name = "c_personAccountsAvailableList";
            c_personAccountsAvailableList.Size = new System.Drawing.Size(161, 270);
            c_personAccountsAvailableList.TabIndex = 4;
            c_personAccountsAvailableList.DoubleClick += c_personAccountsAvailableList_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 15);
            label1.TabIndex = 3;
            label1.Text = "Select Person:";
            // 
            // c_personList
            // 
            c_personList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            c_personList.FormattingEnabled = true;
            c_personList.Location = new System.Drawing.Point(96, 26);
            c_personList.Name = "c_personList";
            c_personList.Size = new System.Drawing.Size(128, 23);
            c_personList.TabIndex = 0;
            c_personList.SelectedIndexChanged += c_personList_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(c_fontColorButton);
            groupBox4.Controls.Add(c_backColorButton);
            groupBox4.Controls.Add(c_catGroupListview);
            groupBox4.Location = new System.Drawing.Point(12, 198);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(368, 174);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Category Group Colors";
            // 
            // c_fontColorButton
            // 
            c_fontColorButton.Location = new System.Drawing.Point(282, 99);
            c_fontColorButton.Name = "c_fontColorButton";
            c_fontColorButton.Size = new System.Drawing.Size(75, 40);
            c_fontColorButton.TabIndex = 8;
            c_fontColorButton.Text = "Font Color...";
            c_fontColorButton.UseVisualStyleBackColor = true;
            c_fontColorButton.Click += c_fontColorButton_Click;
            // 
            // c_backColorButton
            // 
            c_backColorButton.Location = new System.Drawing.Point(282, 48);
            c_backColorButton.Name = "c_backColorButton";
            c_backColorButton.Size = new System.Drawing.Size(75, 38);
            c_backColorButton.TabIndex = 7;
            c_backColorButton.Text = "Back Color...";
            c_backColorButton.UseVisualStyleBackColor = true;
            c_backColorButton.Click += c_backColorButton_Click;
            // 
            // c_catGroupListview
            // 
            c_catGroupListview.FullRowSelect = true;
            c_catGroupListview.Location = new System.Drawing.Point(15, 22);
            c_catGroupListview.MultiSelect = false;
            c_catGroupListview.Name = "c_catGroupListview";
            c_catGroupListview.Size = new System.Drawing.Size(261, 139);
            c_catGroupListview.TabIndex = 6;
            c_catGroupListview.UseCompatibleStateImageBehavior = false;
            c_catGroupListview.View = System.Windows.Forms.View.Details;
            c_catGroupListview.DoubleClick += c_catGroupListview_DoubleClick;
            // 
            // BudgetSettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(841, 1014);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Name = "BudgetSettingsForm";
            Text = "Budget Settings";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button c_renamePersonButton;
        private System.Windows.Forms.Button c_removePersonButton;
        private System.Windows.Forms.Button c_addPersonButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox c_infoBudgetEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox c_infoBudgetStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox c_infoBudgetLastModifed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox c_infoBudgetName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_infoBudgetID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button c_personAccRemoveButton;
        private System.Windows.Forms.Button c_personAccAddButton;
        private System.Windows.Forms.ListBox c_personAccountsAddedList;
        private System.Windows.Forms.ListBox c_personAccountsAvailableList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox c_personList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button c_fontColorButton;
        private System.Windows.Forms.Button c_backColorButton;
        private System.Windows.Forms.ListView c_catGroupListview;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog c_colorDialog;
    }
}
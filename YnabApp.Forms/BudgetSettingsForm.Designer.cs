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
            components = new System.ComponentModel.Container();
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
            c_accountOwnerBlock = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            c_personAccRemoveButton = new System.Windows.Forms.Button();
            c_personAccAddButton = new System.Windows.Forms.Button();
            c_personAccountsAddedList = new System.Windows.Forms.ListBox();
            c_personAccountsAvailableList = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            c_personList = new System.Windows.Forms.ComboBox();
            c_catGroupColorBlock = new System.Windows.Forms.GroupBox();
            c_expenseColorButton = new System.Windows.Forms.Button();
            c_incomeColorButton = new System.Windows.Forms.Button();
            c_fontColorButton = new System.Windows.Forms.Button();
            c_backColorButton = new System.Windows.Forms.Button();
            c_colorContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            customColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            c_catGroupListview = new System.Windows.Forms.ListView();
            c_colorDialog = new System.Windows.Forms.ColorDialog();
            groupBox2.SuspendLayout();
            c_accountOwnerBlock.SuspendLayout();
            c_catGroupColorBlock.SuspendLayout();
            c_colorContextMenu.SuspendLayout();
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
            groupBox2.Text = "Budget Information";
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
            // c_accountOwnerBlock
            // 
            c_accountOwnerBlock.Controls.Add(c_removePersonButton);
            c_accountOwnerBlock.Controls.Add(c_renamePersonButton);
            c_accountOwnerBlock.Controls.Add(label8);
            c_accountOwnerBlock.Controls.Add(label7);
            c_accountOwnerBlock.Controls.Add(c_addPersonButton);
            c_accountOwnerBlock.Controls.Add(c_personAccRemoveButton);
            c_accountOwnerBlock.Controls.Add(c_personAccAddButton);
            c_accountOwnerBlock.Controls.Add(c_personAccountsAddedList);
            c_accountOwnerBlock.Controls.Add(c_personAccountsAvailableList);
            c_accountOwnerBlock.Controls.Add(label1);
            c_accountOwnerBlock.Controls.Add(c_personList);
            c_accountOwnerBlock.Enabled = false;
            c_accountOwnerBlock.Location = new System.Drawing.Point(397, 12);
            c_accountOwnerBlock.Name = "c_accountOwnerBlock";
            c_accountOwnerBlock.Size = new System.Drawing.Size(368, 408);
            c_accountOwnerBlock.TabIndex = 2;
            c_accountOwnerBlock.TabStop = false;
            c_accountOwnerBlock.Text = "Person && Accounts";
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
            c_personAccRemoveButton.Enabled = false;
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
            c_personAccAddButton.Enabled = false;
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
            c_personAccountsAddedList.Size = new System.Drawing.Size(161, 315);
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
            c_personAccountsAvailableList.Size = new System.Drawing.Size(161, 315);
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
            // c_catGroupColorBlock
            // 
            c_catGroupColorBlock.Controls.Add(c_expenseColorButton);
            c_catGroupColorBlock.Controls.Add(c_incomeColorButton);
            c_catGroupColorBlock.Controls.Add(c_fontColorButton);
            c_catGroupColorBlock.Controls.Add(c_backColorButton);
            c_catGroupColorBlock.Controls.Add(c_catGroupListview);
            c_catGroupColorBlock.Enabled = false;
            c_catGroupColorBlock.Location = new System.Drawing.Point(12, 198);
            c_catGroupColorBlock.Name = "c_catGroupColorBlock";
            c_catGroupColorBlock.Size = new System.Drawing.Size(368, 222);
            c_catGroupColorBlock.TabIndex = 3;
            c_catGroupColorBlock.TabStop = false;
            c_catGroupColorBlock.Text = "Category Group Colors";
            // 
            // c_expenseColorButton
            // 
            c_expenseColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            c_expenseColorButton.Location = new System.Drawing.Point(160, 167);
            c_expenseColorButton.Name = "c_expenseColorButton";
            c_expenseColorButton.Size = new System.Drawing.Size(116, 40);
            c_expenseColorButton.TabIndex = 10;
            c_expenseColorButton.Text = "General Expense Color";
            c_expenseColorButton.UseVisualStyleBackColor = true;
            c_expenseColorButton.Click += c_expenseColorButton_Click;
            // 
            // c_incomeColorButton
            // 
            c_incomeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            c_incomeColorButton.Location = new System.Drawing.Point(15, 167);
            c_incomeColorButton.Name = "c_incomeColorButton";
            c_incomeColorButton.Size = new System.Drawing.Size(125, 40);
            c_incomeColorButton.TabIndex = 9;
            c_incomeColorButton.Text = "General Income Color";
            c_incomeColorButton.UseVisualStyleBackColor = true;
            c_incomeColorButton.Click += c_incomeColorButton_Click;
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
            c_backColorButton.ContextMenuStrip = c_colorContextMenu;
            c_backColorButton.Location = new System.Drawing.Point(282, 48);
            c_backColorButton.Name = "c_backColorButton";
            c_backColorButton.Size = new System.Drawing.Size(75, 38);
            c_backColorButton.TabIndex = 7;
            c_backColorButton.Text = "Back Color...";
            c_backColorButton.UseVisualStyleBackColor = true;
            c_backColorButton.Click += c_backColorButton_Click;
            // 
            // c_colorContextMenu
            // 
            c_colorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, customColorToolStripMenuItem });
            c_colorContextMenu.Name = "c_colorContextMenu";
            c_colorContextMenu.Size = new System.Drawing.Size(158, 114);
            c_colorContextMenu.Tag = "";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            toolStripMenuItem1.Tag = "LIGHTRED";
            toolStripMenuItem1.Text = "Light Red";
            toolStripMenuItem1.Click += c_colorContextMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
            toolStripMenuItem2.Tag = "LIGHTGREEN";
            toolStripMenuItem2.Text = "Light Green";
            toolStripMenuItem2.Click += c_colorContextMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(157, 22);
            toolStripMenuItem3.Tag = "LIGHTBLUE";
            toolStripMenuItem3.Text = "Light Blue";
            toolStripMenuItem3.Click += c_colorContextMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(157, 22);
            toolStripMenuItem4.Tag = "LIGHTYELLOW";
            toolStripMenuItem4.Text = "Light Yellow";
            toolStripMenuItem4.Click += c_colorContextMenuItem_Click;
            // 
            // customColorToolStripMenuItem
            // 
            customColorToolStripMenuItem.Name = "customColorToolStripMenuItem";
            customColorToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            customColorToolStripMenuItem.Text = "Custom Color...";
            customColorToolStripMenuItem.Click += c_colorContextMenuItem_Click;
            // 
            // c_catGroupListview
            // 
            c_catGroupListview.ContextMenuStrip = c_colorContextMenu;
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
            Controls.Add(c_catGroupColorBlock);
            Controls.Add(c_accountOwnerBlock);
            Controls.Add(groupBox2);
            Name = "BudgetSettingsForm";
            Text = "Budget Settings";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            c_accountOwnerBlock.ResumeLayout(false);
            c_accountOwnerBlock.PerformLayout();
            c_catGroupColorBlock.ResumeLayout(false);
            c_colorContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox c_accountOwnerBlock;
        private System.Windows.Forms.Button c_personAccRemoveButton;
        private System.Windows.Forms.Button c_personAccAddButton;
        private System.Windows.Forms.ListBox c_personAccountsAddedList;
        private System.Windows.Forms.ListBox c_personAccountsAvailableList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox c_personList;
        private System.Windows.Forms.GroupBox c_catGroupColorBlock;
        private System.Windows.Forms.Button c_fontColorButton;
        private System.Windows.Forms.Button c_backColorButton;
        private System.Windows.Forms.ListView c_catGroupListview;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog c_colorDialog;
        private System.Windows.Forms.ContextMenuStrip c_colorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem customColorToolStripMenuItem;
        private System.Windows.Forms.Button c_expenseColorButton;
        private System.Windows.Forms.Button c_incomeColorButton;
    }
}
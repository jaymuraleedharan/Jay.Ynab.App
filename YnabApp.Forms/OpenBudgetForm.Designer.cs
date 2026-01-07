
namespace YnabApp.Forms
{
    partial class OpenBudgetForm
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
            c_budgetGrid = new System.Windows.Forms.DataGridView();
            c_openBudget = new System.Windows.Forms.Button();
            c_reflectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)c_budgetGrid).BeginInit();
            SuspendLayout();
            // 
            // c_budgetGrid
            // 
            c_budgetGrid.AllowUserToAddRows = false;
            c_budgetGrid.AllowUserToDeleteRows = false;
            c_budgetGrid.AllowUserToResizeColumns = false;
            c_budgetGrid.AllowUserToResizeRows = false;
            c_budgetGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_budgetGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            c_budgetGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_budgetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            c_budgetGrid.Location = new System.Drawing.Point(13, 13);
            c_budgetGrid.MultiSelect = false;
            c_budgetGrid.Name = "c_budgetGrid";
            c_budgetGrid.ReadOnly = true;
            c_budgetGrid.RowHeadersVisible = false;
            c_budgetGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            c_budgetGrid.Size = new System.Drawing.Size(1230, 592);
            c_budgetGrid.TabIndex = 0;
            // 
            // c_openBudget
            // 
            c_openBudget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            c_openBudget.Location = new System.Drawing.Point(1272, 12);
            c_openBudget.Name = "c_openBudget";
            c_openBudget.Size = new System.Drawing.Size(132, 33);
            c_openBudget.TabIndex = 2;
            c_openBudget.Text = "Open Budget...";
            c_openBudget.UseVisualStyleBackColor = true;
            c_openBudget.Click += c_openBudget_Click;
            // 
            // c_reflectButton
            // 
            c_reflectButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            c_reflectButton.Location = new System.Drawing.Point(1272, 63);
            c_reflectButton.Name = "c_reflectButton";
            c_reflectButton.Size = new System.Drawing.Size(132, 33);
            c_reflectButton.TabIndex = 3;
            c_reflectButton.Text = "Reflect...";
            c_reflectButton.UseVisualStyleBackColor = true;
            c_reflectButton.Click += c_reflectButton_Click;
            // 
            // OpenBudgetForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1416, 617);
            Controls.Add(c_reflectButton);
            Controls.Add(c_openBudget);
            Controls.Add(c_budgetGrid);
            Name = "OpenBudgetForm";
            Text = "OpenBudgetForm";
            ((System.ComponentModel.ISupportInitialize)c_budgetGrid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView c_budgetGrid;
        private System.Windows.Forms.Button c_openBudget;
        private System.Windows.Forms.Button c_reflectButton;
    }
}
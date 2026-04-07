
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
            c_selectBudgetButton = new System.Windows.Forms.Button();
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
            c_budgetGrid.Size = new System.Drawing.Size(817, 592);
            c_budgetGrid.TabIndex = 0;
            // 
            // c_selectBudgetButton
            // 
            c_selectBudgetButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            c_selectBudgetButton.Location = new System.Drawing.Point(904, 13);
            c_selectBudgetButton.Name = "c_selectBudgetButton";
            c_selectBudgetButton.Size = new System.Drawing.Size(235, 47);
            c_selectBudgetButton.TabIndex = 5;
            c_selectBudgetButton.Text = "Open Selected Budget";
            c_selectBudgetButton.UseVisualStyleBackColor = true;
            c_selectBudgetButton.Click += c_selectBudgetButton_Click;
            // 
            // OpenBudgetForm
            // 
            AcceptButton = c_selectBudgetButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1181, 617);
            Controls.Add(c_selectBudgetButton);
            Controls.Add(c_budgetGrid);
            Name = "OpenBudgetForm";
            Text = "OpenBudgetForm";
            ((System.ComponentModel.ISupportInitialize)c_budgetGrid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView c_budgetGrid;
        private System.Windows.Forms.Button c_selectBudgetButton;
    }
}
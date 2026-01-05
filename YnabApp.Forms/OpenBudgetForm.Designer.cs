
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
            this.c_budgetGrid = new System.Windows.Forms.DataGridView();
            this.c_openBudget = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.c_budgetGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // c_budgetGrid
            // 
            this.c_budgetGrid.AllowUserToAddRows = false;
            this.c_budgetGrid.AllowUserToDeleteRows = false;
            this.c_budgetGrid.AllowUserToResizeColumns = false;
            this.c_budgetGrid.AllowUserToResizeRows = false;
            this.c_budgetGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_budgetGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.c_budgetGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c_budgetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_budgetGrid.Location = new System.Drawing.Point(13, 13);
            this.c_budgetGrid.MultiSelect = false;
            this.c_budgetGrid.Name = "c_budgetGrid";
            this.c_budgetGrid.ReadOnly = true;
            this.c_budgetGrid.RowHeadersVisible = false;
            this.c_budgetGrid.RowTemplate.Height = 25;
            this.c_budgetGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_budgetGrid.Size = new System.Drawing.Size(1230, 592);
            this.c_budgetGrid.TabIndex = 0;
            // 
            // c_openBudget
            // 
            this.c_openBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_openBudget.Location = new System.Drawing.Point(1272, 12);
            this.c_openBudget.Name = "c_openBudget";
            this.c_openBudget.Size = new System.Drawing.Size(132, 33);
            this.c_openBudget.TabIndex = 2;
            this.c_openBudget.Text = "Open Budget...";
            this.c_openBudget.UseVisualStyleBackColor = true;
            this.c_openBudget.Click += new System.EventHandler(this.c_openBudget_Click);
            // 
            // OpenBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 617);
            this.Controls.Add(this.c_openBudget);
            this.Controls.Add(this.c_budgetGrid);
            this.Name = "OpenBudgetForm";
            this.Text = "OpenBudgetForm";
            ((System.ComponentModel.ISupportInitialize)(this.c_budgetGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView c_budgetGrid;
        private System.Windows.Forms.Button c_openBudget;
    }
}
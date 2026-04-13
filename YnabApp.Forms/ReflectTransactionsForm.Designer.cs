namespace YnabApp.Forms
{
    partial class ReflectTransactionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            c_cateogryLabel = new System.Windows.Forms.Label();
            c_durationLabel = new System.Windows.Forms.Label();
            c_transactionsGrid = new System.Windows.Forms.DataGridView();
            c_btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)c_transactionsGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 15);
            label1.TabIndex = 0;
            label1.Text = "Category Group:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 44);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Duration:";
            // 
            // c_cateogryLabel
            // 
            c_cateogryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            c_cateogryLabel.Location = new System.Drawing.Point(155, 4);
            c_cateogryLabel.Name = "c_cateogryLabel";
            c_cateogryLabel.Size = new System.Drawing.Size(264, 25);
            c_cateogryLabel.TabIndex = 2;
            c_cateogryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_durationLabel
            // 
            c_durationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            c_durationLabel.Location = new System.Drawing.Point(155, 39);
            c_durationLabel.Name = "c_durationLabel";
            c_durationLabel.Size = new System.Drawing.Size(264, 25);
            c_durationLabel.TabIndex = 3;
            c_durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_transactionsGrid
            // 
            c_transactionsGrid.AllowUserToAddRows = false;
            c_transactionsGrid.AllowUserToDeleteRows = false;
            c_transactionsGrid.AllowUserToOrderColumns = true;
            c_transactionsGrid.AllowUserToResizeRows = false;
            c_transactionsGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            c_transactionsGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            c_transactionsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            c_transactionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            c_transactionsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            c_transactionsGrid.Location = new System.Drawing.Point(12, 77);
            c_transactionsGrid.MultiSelect = false;
            c_transactionsGrid.Name = "c_transactionsGrid";
            c_transactionsGrid.ReadOnly = true;
            c_transactionsGrid.RowHeadersVisible = false;
            c_transactionsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            c_transactionsGrid.Size = new System.Drawing.Size(926, 824);
            c_transactionsGrid.TabIndex = 4;
            // 
            // c_btnOK
            // 
            c_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            c_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            c_btnOK.Location = new System.Drawing.Point(858, 24);
            c_btnOK.Name = "c_btnOK";
            c_btnOK.Size = new System.Drawing.Size(80, 35);
            c_btnOK.TabIndex = 5;
            c_btnOK.Text = "OK";
            c_btnOK.UseVisualStyleBackColor = true;
            c_btnOK.Click += c_btnOK_Click;
            // 
            // ReflectTransactionsForm
            // 
            AcceptButton = c_btnOK;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = c_btnOK;
            ClientSize = new System.Drawing.Size(950, 913);
            Controls.Add(c_btnOK);
            Controls.Add(c_transactionsGrid);
            Controls.Add(c_durationLabel);
            Controls.Add(c_cateogryLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Name = "ReflectTransactionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Reflect Transactions";
            ((System.ComponentModel.ISupportInitialize)c_transactionsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label c_cateogryLabel;
        private System.Windows.Forms.Label c_durationLabel;
        private System.Windows.Forms.DataGridView c_transactionsGrid;
        private System.Windows.Forms.Button c_btnOK;
    }
}

namespace YnabApp.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.c_OpenBudgetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_OpenBudgetMenuItem,
            this.c_AboutMenuItem,
            this.c_QuitMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1452, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // c_OpenBudgetMenuItem
            // 
            this.c_OpenBudgetMenuItem.Name = "c_OpenBudgetMenuItem";
            this.c_OpenBudgetMenuItem.Size = new System.Drawing.Size(98, 20);
            this.c_OpenBudgetMenuItem.Text = "Open Budget...";
            this.c_OpenBudgetMenuItem.Click += new System.EventHandler(this.c_OpenBudgetMenuItem_Click);
            // 
            // c_AboutMenuItem
            // 
            this.c_AboutMenuItem.Name = "c_AboutMenuItem";
            this.c_AboutMenuItem.Size = new System.Drawing.Size(61, 20);
            this.c_AboutMenuItem.Text = "About...";
            this.c_AboutMenuItem.Click += new System.EventHandler(this.c_AboutMenuItem_Click);
            // 
            // c_QuitMenuItem
            // 
            this.c_QuitMenuItem.Name = "c_QuitMenuItem";
            this.c_QuitMenuItem.Size = new System.Drawing.Size(42, 20);
            this.c_QuitMenuItem.Text = "Quit";
            this.c_QuitMenuItem.Click += new System.EventHandler(this.c_QuitMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 526);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem c_OpenBudgetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c_AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c_QuitMenuItem;
    }
}
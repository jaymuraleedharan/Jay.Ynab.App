
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            c_OpenBudgetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            c_AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            c_QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { c_OpenBudgetMenuItem, c_AboutMenuItem, c_QuitMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1452, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // c_OpenBudgetMenuItem
            // 
            c_OpenBudgetMenuItem.Name = "c_OpenBudgetMenuItem";
            c_OpenBudgetMenuItem.Size = new System.Drawing.Size(98, 20);
            c_OpenBudgetMenuItem.Text = "Open Budget...";
            c_OpenBudgetMenuItem.Click += c_OpenBudgetMenuItem_Click;
            // 
            // c_AboutMenuItem
            // 
            c_AboutMenuItem.Name = "c_AboutMenuItem";
            c_AboutMenuItem.Size = new System.Drawing.Size(61, 20);
            c_AboutMenuItem.Text = "About...";
            c_AboutMenuItem.Click += c_AboutMenuItem_Click;
            // 
            // c_QuitMenuItem
            // 
            c_QuitMenuItem.Name = "c_QuitMenuItem";
            c_QuitMenuItem.Size = new System.Drawing.Size(42, 20);
            c_QuitMenuItem.Text = "Quit";
            c_QuitMenuItem.Click += c_QuitMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1452, 526);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "YNAB APP";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem c_OpenBudgetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c_AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c_QuitMenuItem;
    }
}
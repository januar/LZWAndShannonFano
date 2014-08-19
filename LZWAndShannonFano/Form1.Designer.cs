namespace LZWAndShannonFano
{
    partial class frmUtama
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tentangPengembangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kompresiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZWAlgorithimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shannonFanoAlgorithimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dekompresiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZWAlgorithimToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.shannonFanoAlgorithimToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kompresiToolStripMenuItem,
            this.dekompresiToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tentangPengembangToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tentangPengembangToolStripMenuItem
            // 
            this.tentangPengembangToolStripMenuItem.Name = "tentangPengembangToolStripMenuItem";
            this.tentangPengembangToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tentangPengembangToolStripMenuItem.Text = "Tentang Pengembang";
            // 
            // kompresiToolStripMenuItem
            // 
            this.kompresiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lZWAlgorithimToolStripMenuItem,
            this.shannonFanoAlgorithimToolStripMenuItem});
            this.kompresiToolStripMenuItem.Name = "kompresiToolStripMenuItem";
            this.kompresiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kompresiToolStripMenuItem.Text = "Kompresi";
            // 
            // lZWAlgorithimToolStripMenuItem
            // 
            this.lZWAlgorithimToolStripMenuItem.Name = "lZWAlgorithimToolStripMenuItem";
            this.lZWAlgorithimToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.lZWAlgorithimToolStripMenuItem.Text = "LZW Algorithim";
            this.lZWAlgorithimToolStripMenuItem.Click += new System.EventHandler(this.lZWAlgorithimToolStripMenuItem_Click);
            // 
            // shannonFanoAlgorithimToolStripMenuItem
            // 
            this.shannonFanoAlgorithimToolStripMenuItem.Name = "shannonFanoAlgorithimToolStripMenuItem";
            this.shannonFanoAlgorithimToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.shannonFanoAlgorithimToolStripMenuItem.Text = "Shannon-Fano Algorithim";
            // 
            // dekompresiToolStripMenuItem
            // 
            this.dekompresiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lZWAlgorithimToolStripMenuItem1,
            this.shannonFanoAlgorithimToolStripMenuItem1});
            this.dekompresiToolStripMenuItem.Name = "dekompresiToolStripMenuItem";
            this.dekompresiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dekompresiToolStripMenuItem.Text = "Dekompresi";
            // 
            // lZWAlgorithimToolStripMenuItem1
            // 
            this.lZWAlgorithimToolStripMenuItem1.Name = "lZWAlgorithimToolStripMenuItem1";
            this.lZWAlgorithimToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.lZWAlgorithimToolStripMenuItem1.Text = "LZW Algorithim";
            // 
            // shannonFanoAlgorithimToolStripMenuItem1
            // 
            this.shannonFanoAlgorithimToolStripMenuItem1.Name = "shannonFanoAlgorithimToolStripMenuItem1";
            this.shannonFanoAlgorithimToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.shannonFanoAlgorithimToolStripMenuItem1.Text = "Shannon-Fano Algorithim";
            // 
            // frmUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 362);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmUtama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LZW And Shannon-Fano Algorithim for Bitmap Data";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kompresiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZWAlgorithimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shannonFanoAlgorithimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dekompresiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZWAlgorithimToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shannonFanoAlgorithimToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tentangPengembangToolStripMenuItem;
    }
}


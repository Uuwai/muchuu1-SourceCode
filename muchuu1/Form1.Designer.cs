namespace muchuu1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bg = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.muchuuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpspicsumphotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.BackColor = System.Drawing.Color.Black;
            this.bg.ContextMenuStrip = this.contextMenuStrip1;
            this.bg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(484, 461);
            this.bg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg.TabIndex = 1;
            this.bg.TabStop = false;
            this.bg.Paint += new System.Windows.Forms.PaintEventHandler(this.bg_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muchuuToolStripMenuItem,
            this.toolStripSeparator1,
            this.imagesToolStripMenuItem,
            this.httpspicsumphotosToolStripMenuItem,
            this.urlToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 98);
            // 
            // muchuuToolStripMenuItem
            // 
            this.muchuuToolStripMenuItem.Name = "muchuuToolStripMenuItem";
            this.muchuuToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.muchuuToolStripMenuItem.Text = "Muchuu!";
            this.muchuuToolStripMenuItem.Click += new System.EventHandler(this.genbutton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Enabled = false;
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.imagesToolStripMenuItem.Text = "Images:";
            // 
            // httpspicsumphotosToolStripMenuItem
            // 
            this.httpspicsumphotosToolStripMenuItem.Name = "httpspicsumphotosToolStripMenuItem";
            this.httpspicsumphotosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.httpspicsumphotosToolStripMenuItem.Text = "https://picsum.photos";
            this.httpspicsumphotosToolStripMenuItem.Click += new System.EventHandler(this.httpspicsumphotosToolStripMenuItem_Click);
            // 
            // urlToolStripMenuItem
            // 
            this.urlToolStripMenuItem.Name = "urlToolStripMenuItem";
            this.urlToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.urlToolStripMenuItem.Text = "url";
            this.urlToolStripMenuItem.Click += new System.EventHandler(this.urlToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.bg);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Loading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bg)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem muchuuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem httpspicsumphotosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlToolStripMenuItem;
    }
}


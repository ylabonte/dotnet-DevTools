namespace EnvLoaderWindows
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.environmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envSetUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envUnsetUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envSetSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envUnsetSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.topMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.environmentToolStripMenuItem});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.topMenuStrip.Size = new System.Drawing.Size(914, 30);
            this.topMenuStrip.TabIndex = 0;
            this.topMenuStrip.Text = "topMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.File;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.New;
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.Open;
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // environmentToolStripMenuItem
            // 
            this.environmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.envSetUserToolStripMenuItem,
            this.envUnsetUserToolStripMenuItem,
            this.envSetSystemToolStripMenuItem,
            this.envUnsetSystemToolStripMenuItem});
            this.environmentToolStripMenuItem.Name = "environmentToolStripMenuItem";
            this.environmentToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.environmentToolStripMenuItem.Text = "Environment";
            // 
            // envSetUserToolStripMenuItem
            // 
            this.envSetUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("envSetToolStripMenuItem.Image")));
            this.envSetUserToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.envSetUserToolStripMenuItem.Name = "envSetToolStripMenuItem";
            this.envSetUserToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.envSetUserToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.envSetUserToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.SetUser;
            this.envSetUserToolStripMenuItem.Click += new System.EventHandler(this.setUserToolStripMenuItem_Click);
            // 
            // envUnsetSystemToolStripMenuItem
            // 
            this.envUnsetUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("envUnsetToolStripMenuItem.Image")));
            this.envUnsetUserToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.envUnsetUserToolStripMenuItem.Name = "envUnsetToolStripMenuItem";
            this.envUnsetUserToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.envUnsetUserToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.envUnsetUserToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.UnsetUser;
            this.envUnsetUserToolStripMenuItem.Click += new System.EventHandler(this.unsetUserToolStripMenuItem_Click);
            // 
            // envSetSystemToolStripMenuItem
            // 
            this.envSetSystemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("envSetToolStripMenuItem.Image")));
            this.envSetSystemToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.envSetSystemToolStripMenuItem.Name = "envSetToolStripMenuItem";
            this.envSetSystemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.E)));
            this.envSetSystemToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.envSetSystemToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.SetSystem;
            this.envSetSystemToolStripMenuItem.Click += new System.EventHandler(this.setSystemToolStripMenuItem_Click);
            // 
            // envUnsetSystemToolStripMenuItem
            // 
            this.envUnsetSystemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("envUnsetToolStripMenuItem.Image")));
            this.envUnsetSystemToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.envUnsetSystemToolStripMenuItem.Name = "envUnsetSystemToolStripMenuItem";
            this.envUnsetSystemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.U)));
            this.envUnsetSystemToolStripMenuItem.Size = new System.Drawing.Size(331, 26);
            this.envUnsetSystemToolStripMenuItem.Text = global::EnvLoaderWindows.ProgramResources.UnsetSystem;
            this.envUnsetSystemToolStripMenuItem.Click += new System.EventHandler(this.unsetSystemToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 30);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(914, 570);
            this.dataGridView.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.topMenuStrip);
            this.MainMenuStrip = this.topMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "EnvLoader";
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envSetUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envUnsetUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envSetSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envUnsetSystemToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem environmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}
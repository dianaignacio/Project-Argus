namespace MissionPlanner
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.list_status = new System.Windows.Forms.ListView();
            this.list_connections = new System.Windows.Forms.ListView();
            this.app_console = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mapModeSel = new System.Windows.Forms.ToolStripComboBox();
            this.areaClear = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.New = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapControl = new GMap.NET.WindowsForms.GMapControl();
            this.camera1 = new Emgu.CV.UI.ImageBox();
            this.redButtonSelect = new System.Windows.Forms.Button();
            this.yellowButtonSelect = new System.Windows.Forms.Button();
            this.blueButtonSelect = new System.Windows.Forms.Button();
            this.currentColorLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camera1)).BeginInit();
            this.SuspendLayout();
            // 
            // list_status
            // 
            this.list_status.BackColor = System.Drawing.Color.Lavender;
            this.list_status.Location = new System.Drawing.Point(1664, 51);
            this.list_status.Name = "list_status";
            this.list_status.Size = new System.Drawing.Size(228, 927);
            this.list_status.TabIndex = 2;
            this.list_status.UseCompatibleStateImageBehavior = false;
            this.list_status.SelectedIndexChanged += new System.EventHandler(this.list_status_SelectedIndexChanged);
            // 
            // list_connections
            // 
            this.list_connections.BackColor = System.Drawing.Color.Lavender;
            this.list_connections.Location = new System.Drawing.Point(12, 51);
            this.list_connections.Name = "list_connections";
            this.list_connections.Size = new System.Drawing.Size(214, 927);
            this.list_connections.TabIndex = 3;
            this.list_connections.UseCompatibleStateImageBehavior = false;
            // 
            // app_console
            // 
            this.app_console.BackColor = System.Drawing.Color.Lavender;
            this.app_console.Location = new System.Drawing.Point(589, 805);
            this.app_console.Name = "app_console";
            this.app_console.Size = new System.Drawing.Size(701, 176);
            this.app_console.TabIndex = 4;
            this.app_console.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(74)))), ((int)(((byte)(129)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapModeSel,
            this.areaClear});
            this.toolStrip1.Location = new System.Drawing.Point(1306, 816);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(177, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mapModeSel
            // 
            this.mapModeSel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mapModeSel.Items.AddRange(new object[] {
            "Set Route",
            "Set Area"});
            this.mapModeSel.Name = "mapModeSel";
            this.mapModeSel.Size = new System.Drawing.Size(90, 25);
            this.mapModeSel.Text = "Map Mode";
            // 
            // areaClear
            // 
            this.areaClear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.areaClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.areaClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.areaClear.Name = "areaClear";
            this.areaClear.Size = new System.Drawing.Size(73, 22);
            this.areaClear.Text = "Area Clear";
            this.areaClear.Click += new System.EventHandler(this.areaClear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(74)))), ((int)(((byte)(129)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 35);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 31);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // New
            // 
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(108, 22);
            this.New.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // mapControl
            // 
            this.mapControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mapControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapControl.Bearing = 0F;
            this.mapControl.CanDragMap = true;
            this.mapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl.GrayScaleMode = false;
            this.mapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl.LevelsKeepInMemmory = 5;
            this.mapControl.Location = new System.Drawing.Point(939, 51);
            this.mapControl.MarkersEnabled = true;
            this.mapControl.MaxZoom = 2;
            this.mapControl.MinZoom = 2;
            this.mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl.Name = "mapControl";
            this.mapControl.NegativeMode = false;
            this.mapControl.PolygonsEnabled = true;
            this.mapControl.RetryLoadTile = 0;
            this.mapControl.RoutesEnabled = true;
            this.mapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl.ShowTileGridLines = false;
            this.mapControl.Size = new System.Drawing.Size(719, 748);
            this.mapControl.TabIndex = 7;
            this.mapControl.Zoom = 0D;
            this.mapControl.Load += new System.EventHandler(this.mapControl_Load);
            this.mapControl.DoubleClick += new System.EventHandler(this.mapControl_DoubleClick);
            this.mapControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
            // 
            // camera1
            // 
            this.camera1.BackColor = System.Drawing.Color.Lavender;
            this.camera1.Location = new System.Drawing.Point(232, 51);
            this.camera1.Name = "camera1";
            this.camera1.Size = new System.Drawing.Size(701, 748);
            this.camera1.TabIndex = 2;
            this.camera1.TabStop = false;
            this.camera1.Click += new System.EventHandler(this.imageBox1_Click);
            // 
            // redButtonSelect
            // 
            this.redButtonSelect.Location = new System.Drawing.Point(232, 813);
            this.redButtonSelect.Name = "redButtonSelect";
            this.redButtonSelect.Size = new System.Drawing.Size(75, 23);
            this.redButtonSelect.TabIndex = 9;
            this.redButtonSelect.Text = "Red";
            this.redButtonSelect.UseVisualStyleBackColor = true;
            this.redButtonSelect.Click += new System.EventHandler(this.redButtonSelect_Click);
            // 
            // yellowButtonSelect
            // 
            this.yellowButtonSelect.Location = new System.Drawing.Point(232, 842);
            this.yellowButtonSelect.Name = "yellowButtonSelect";
            this.yellowButtonSelect.Size = new System.Drawing.Size(75, 23);
            this.yellowButtonSelect.TabIndex = 10;
            this.yellowButtonSelect.Text = "Yellow";
            this.yellowButtonSelect.UseVisualStyleBackColor = true;
            this.yellowButtonSelect.Click += new System.EventHandler(this.yellowButtonSelect_Click);
            // 
            // blueButtonSelect
            // 
            this.blueButtonSelect.Location = new System.Drawing.Point(232, 871);
            this.blueButtonSelect.Name = "blueButtonSelect";
            this.blueButtonSelect.Size = new System.Drawing.Size(75, 23);
            this.blueButtonSelect.TabIndex = 11;
            this.blueButtonSelect.Text = "Blue";
            this.blueButtonSelect.UseVisualStyleBackColor = true;
            this.blueButtonSelect.Click += new System.EventHandler(this.blueButtonSelect_Click);
            // 
            // currentColorLabel
            // 
            this.currentColorLabel.Location = new System.Drawing.Point(323, 816);
            this.currentColorLabel.Name = "currentColorLabel";
            this.currentColorLabel.Size = new System.Drawing.Size(120, 20);
            this.currentColorLabel.TabIndex = 12;
            this.currentColorLabel.Text = "Color Selected: Red";
            this.currentColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1306, 861);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 42);
            this.button1.TabIndex = 13;
            this.button1.Text = "Manual";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1379, 861);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 42);
            this.button2.TabIndex = 14;
            this.button2.Text = "Auto";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::MissionPlanner.Properties.Resources.WCAPmoW;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1904, 990);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentColorLabel);
            this.Controls.Add(this.blueButtonSelect);
            this.Controls.Add(this.yellowButtonSelect);
            this.Controls.Add(this.redButtonSelect);
            this.Controls.Add(this.camera1);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.app_console);
            this.Controls.Add(this.list_connections);
            this.Controls.Add(this.list_status);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Olympos";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camera1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_status;
        private System.Windows.Forms.ListView list_connections;
        private System.Windows.Forms.RichTextBox app_console;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private GMap.NET.WindowsForms.GMapControl mapControl;
        private System.Windows.Forms.ToolStripButton areaClear;
        private Emgu.CV.UI.ImageBox camera1;
        private System.Windows.Forms.Button redButtonSelect;
        private System.Windows.Forms.Button yellowButtonSelect;
        private System.Windows.Forms.Button blueButtonSelect;
        private System.Windows.Forms.Label currentColorLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem New;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox mapModeSel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        //private Emgu.CV.UI.ImageBox camera1;
        //private Emgu.CV.UI.ImageBox camera2;
    }
}
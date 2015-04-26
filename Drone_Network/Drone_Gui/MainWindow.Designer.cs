namespace Drone_Gui
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
            this.list_status = new System.Windows.Forms.ListView();
            this.list_connections = new System.Windows.Forms.ListView();
            this.app_console = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapControl = new GMap.NET.WindowsForms.GMapControl();
            this.mapModeSel = new System.Windows.Forms.ToolStripComboBox();
            this.areaClear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_status
            // 
            this.list_status.Location = new System.Drawing.Point(1120, 52);
            this.list_status.Name = "list_status";
            this.list_status.Size = new System.Drawing.Size(228, 571);
            this.list_status.TabIndex = 2;
            this.list_status.UseCompatibleStateImageBehavior = false;
            this.list_status.SelectedIndexChanged += new System.EventHandler(this.list_status_SelectedIndexChanged);
            // 
            // list_connections
            // 
            this.list_connections.Location = new System.Drawing.Point(12, 52);
            this.list_connections.Name = "list_connections";
            this.list_connections.Size = new System.Drawing.Size(214, 389);
            this.list_connections.TabIndex = 3;
            this.list_connections.UseCompatibleStateImageBehavior = false;
            // 
            // app_console
            // 
            this.app_console.Location = new System.Drawing.Point(232, 527);
            this.app_console.Name = "app_console";
            this.app_console.Size = new System.Drawing.Size(882, 96);
            this.app_console.TabIndex = 4;
            this.app_console.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapModeSel,
            this.areaClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1356, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1356, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
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
            this.mapControl.Location = new System.Drawing.Point(12, 447);
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
            this.mapControl.Size = new System.Drawing.Size(214, 176);
            this.mapControl.TabIndex = 7;
            this.mapControl.Zoom = 0D;
            this.mapControl.Load += new System.EventHandler(this.mapControl_Load);
            this.mapControl.DoubleClick += new System.EventHandler(this.mapControl_DoubleClick);
            this.mapControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
            // 
            // mapModeSel
            // 
            this.mapModeSel.Items.AddRange(new object[] {
            "Set Route",
            "Set Area"});
            this.mapModeSel.Name = "mapModeSel";
            this.mapModeSel.Size = new System.Drawing.Size(75, 25);
            // 
            // areaClear
            // 
            this.areaClear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.areaClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.areaClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.areaClear.Name = "areaClear";
            this.areaClear.Size = new System.Drawing.Size(65, 22);
            this.areaClear.Text = "Area Clear";
            this.areaClear.Click += new System.EventHandler(this.areaClear_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 635);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.app_console);
            this.Controls.Add(this.list_connections);
            this.Controls.Add(this.list_status);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripComboBox mapModeSel;
        private System.Windows.Forms.ToolStripButton areaClear;
        //private Emgu.CV.UI.ImageBox camera1;
        //private Emgu.CV.UI.ImageBox camera2;
    }
}
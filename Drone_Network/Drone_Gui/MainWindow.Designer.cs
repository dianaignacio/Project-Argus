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
            this.main_view = new System.Windows.Forms.PictureBox();
            this.secondary_view = new System.Windows.Forms.PictureBox();
            this.list_status = new System.Windows.Forms.ListView();
            this.list_connections = new System.Windows.Forms.ListView();
            this.app_console = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.main_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondary_view)).BeginInit();
            this.SuspendLayout();
            // 
            // main_view
            // 
            this.main_view.Image = global::Drone_Gui.Properties.Resources.test1;
            this.main_view.Location = new System.Drawing.Point(232, 52);
            this.main_view.Name = "main_view";
            this.main_view.Size = new System.Drawing.Size(882, 469);
            this.main_view.TabIndex = 0;
            this.main_view.TabStop = false;
            this.main_view.Click += new System.EventHandler(this.main_view_Click);
            // 
            // secondary_view
            // 
            this.secondary_view.Image = global::Drone_Gui.Properties.Resources.test2;
            this.secondary_view.Location = new System.Drawing.Point(12, 447);
            this.secondary_view.Name = "secondary_view";
            this.secondary_view.Size = new System.Drawing.Size(214, 176);
            this.secondary_view.TabIndex = 1;
            this.secondary_view.TabStop = false;
            // 
            // list_status
            // 
            this.list_status.Location = new System.Drawing.Point(1120, 52);
            this.list_status.Name = "list_status";
            this.list_status.Size = new System.Drawing.Size(228, 571);
            this.list_status.TabIndex = 2;
            this.list_status.UseCompatibleStateImageBehavior = false;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 635);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.app_console);
            this.Controls.Add(this.list_connections);
            this.Controls.Add(this.list_status);
            this.Controls.Add(this.secondary_view);
            this.Controls.Add(this.main_view);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.main_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondary_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox main_view;
        private System.Windows.Forms.PictureBox secondary_view;
        private System.Windows.Forms.ListView list_status;
        private System.Windows.Forms.ListView list_connections;
        private System.Windows.Forms.RichTextBox app_console;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}
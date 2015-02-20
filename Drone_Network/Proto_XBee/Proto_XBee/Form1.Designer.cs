namespace Proto_XBee
{
    partial class Prototype
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
            this._btnBlink = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnBlink
            // 
            this._btnBlink.Location = new System.Drawing.Point(99, 103);
            this._btnBlink.Name = "_btnBlink";
            this._btnBlink.Size = new System.Drawing.Size(75, 23);
            this._btnBlink.TabIndex = 0;
            this._btnBlink.Text = "Toggle";
            this._btnBlink.UseVisualStyleBackColor = true;
            // 
            // Prototype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._btnBlink);
            this.Name = "Prototype";
            this.Text = "XBee Prototype";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnBlink;
    }
}


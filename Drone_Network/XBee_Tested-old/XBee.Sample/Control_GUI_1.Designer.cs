namespace XBee.Sample
{
    partial class Control_GUI_1
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
            this._btnOn = new System.Windows.Forms.Button();
            this._btnOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnOn
            // 
            this._btnOn.Location = new System.Drawing.Point(44, 109);
            this._btnOn.Name = "_btnOn";
            this._btnOn.Size = new System.Drawing.Size(75, 23);
            this._btnOn.TabIndex = 0;
            this._btnOn.Text = "ON";
            this._btnOn.UseVisualStyleBackColor = true;
            this._btnOn.Click += new System.EventHandler(this._btnOn_Click);
            // 
            // _btnOff
            // 
            this._btnOff.Location = new System.Drawing.Point(136, 109);
            this._btnOff.Name = "_btnOff";
            this._btnOff.Size = new System.Drawing.Size(75, 23);
            this._btnOff.TabIndex = 1;
            this._btnOff.Text = "OFF";
            this._btnOff.UseVisualStyleBackColor = true;
            this._btnOff.Click += new System.EventHandler(this._btnOff_Click);
            // 
            // Control_GUI_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._btnOff);
            this.Controls.Add(this._btnOn);
            this.Name = "Control_GUI_1";
            this.Text = "Control_GUI_1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOn;
        private System.Windows.Forms.Button _btnOff;
    }
}
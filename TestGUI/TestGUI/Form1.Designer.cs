namespace TestGUI
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
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.StartStop = new System.Windows.Forms.Button();
            this.txtXYRadius = new System.Windows.Forms.TextBox();
            this.ibProcessed = new Emgu.CV.UI.ImageBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Blue = new System.Windows.Forms.TrackBar();
            this.Green = new System.Windows.Forms.TrackBar();
            this.Red = new System.Windows.Forms.TrackBar();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.RedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.Location = new System.Drawing.Point(12, 12);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(640, 480);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            this.ibOriginal.Click += new System.EventHandler(this.imageBox1_Click);
            // 
            // StartStop
            // 
            this.StartStop.Location = new System.Drawing.Point(67, 531);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(75, 23);
            this.StartStop.TabIndex = 3;
            this.StartStop.Text = "pause";
            this.StartStop.UseVisualStyleBackColor = true;
            this.StartStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXYRadius.Location = new System.Drawing.Point(171, 507);
            this.txtXYRadius.Multiline = true;
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.ReadOnly = true;
            this.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXYRadius.Size = new System.Drawing.Size(413, 94);
            this.txtXYRadius.TabIndex = 4;
            this.txtXYRadius.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ibProcessed
            // 
            this.ibProcessed.Location = new System.Drawing.Point(751, 12);
            this.ibProcessed.Name = "ibProcessed";
            this.ibProcessed.Size = new System.Drawing.Size(640, 480);
            this.ibProcessed.TabIndex = 5;
            this.ibProcessed.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 638);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 511);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Blue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(700, 542);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Green";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(701, 574);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Red";
            // 
            // Blue
            // 
            this.Blue.Location = new System.Drawing.Point(751, 507);
            this.Blue.Maximum = 255;
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(364, 45);
            this.Blue.TabIndex = 19;
            this.Blue.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Green
            // 
            this.Green.Location = new System.Drawing.Point(751, 542);
            this.Green.Maximum = 255;
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(364, 45);
            this.Green.TabIndex = 20;
            this.Green.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // Red
            // 
            this.Red.Location = new System.Drawing.Point(751, 574);
            this.Red.Maximum = 255;
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(364, 45);
            this.Red.TabIndex = 21;
            this.Red.Scroll += new System.EventHandler(this.Red_Scroll);
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(1135, 511);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(13, 13);
            this.BlueLabel.TabIndex = 22;
            this.BlueLabel.Text = "0";
            this.BlueLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(1135, 542);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(13, 13);
            this.GreenLabel.TabIndex = 23;
            this.GreenLabel.Text = "0";
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(1135, 574);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(13, 13);
            this.RedLabel.TabIndex = 24;
            this.RedLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 638);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ibProcessed);
            this.Controls.Add(this.txtXYRadius);
            this.Controls.Add(this.StartStop);
            this.Controls.Add(this.ibOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button StartStop;
        private System.Windows.Forms.TextBox txtXYRadius;
        private Emgu.CV.UI.ImageBox ibProcessed;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar Blue;
        private System.Windows.Forms.TrackBar Green;
        private System.Windows.Forms.TrackBar Red;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label RedLabel;
    }
}


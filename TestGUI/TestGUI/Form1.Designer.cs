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
            this.BlueHi = new System.Windows.Forms.TextBox();
            this.GreenHi = new System.Windows.Forms.TextBox();
            this.RedHi = new System.Windows.Forms.TextBox();
            this.BlueLo = new System.Windows.Forms.TextBox();
            this.GreenLo = new System.Windows.Forms.TextBox();
            this.RedLo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).BeginInit();
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
            // BlueHi
            // 
            this.BlueHi.Location = new System.Drawing.Point(794, 533);
            this.BlueHi.Name = "BlueHi";
            this.BlueHi.Size = new System.Drawing.Size(68, 20);
            this.BlueHi.TabIndex = 7;
            this.BlueHi.Text = "0";
            this.BlueHi.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // GreenHi
            // 
            this.GreenHi.Location = new System.Drawing.Point(892, 534);
            this.GreenHi.Name = "GreenHi";
            this.GreenHi.Size = new System.Drawing.Size(68, 20);
            this.GreenHi.TabIndex = 8;
            this.GreenHi.Text = "0";
            // 
            // RedHi
            // 
            this.RedHi.Location = new System.Drawing.Point(991, 533);
            this.RedHi.Name = "RedHi";
            this.RedHi.Size = new System.Drawing.Size(68, 20);
            this.RedHi.TabIndex = 9;
            this.RedHi.Text = "255";
            this.RedHi.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // BlueLo
            // 
            this.BlueLo.Location = new System.Drawing.Point(794, 581);
            this.BlueLo.Name = "BlueLo";
            this.BlueLo.Size = new System.Drawing.Size(68, 20);
            this.BlueLo.TabIndex = 10;
            this.BlueLo.Text = "0";
            // 
            // GreenLo
            // 
            this.GreenLo.Location = new System.Drawing.Point(892, 581);
            this.GreenLo.Name = "GreenLo";
            this.GreenLo.Size = new System.Drawing.Size(68, 20);
            this.GreenLo.TabIndex = 11;
            this.GreenLo.Text = "0";
            // 
            // RedLo
            // 
            this.RedLo.Location = new System.Drawing.Point(991, 581);
            this.RedLo.Name = "RedLo";
            this.RedLo.Size = new System.Drawing.Size(68, 20);
            this.RedLo.TabIndex = 12;
            this.RedLo.Text = "230";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Low(0-255)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(725, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "High(0-255)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(813, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Blue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(909, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Green";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1008, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Red";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1100, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Set BGR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 638);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RedLo);
            this.Controls.Add(this.GreenLo);
            this.Controls.Add(this.BlueLo);
            this.Controls.Add(this.RedHi);
            this.Controls.Add(this.GreenHi);
            this.Controls.Add(this.BlueHi);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button StartStop;
        private System.Windows.Forms.TextBox txtXYRadius;
        private Emgu.CV.UI.ImageBox ibProcessed;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox BlueHi;
        private System.Windows.Forms.TextBox GreenHi;
        private System.Windows.Forms.TextBox RedHi;
        private System.Windows.Forms.TextBox BlueLo;
        private System.Windows.Forms.TextBox GreenLo;
        private System.Windows.Forms.TextBox RedLo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}


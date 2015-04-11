using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;

namespace TestGUI
{
    public partial class Form1 : Form
    {
        Capture capwebcam = null;
        bool b1nCapturingInProcess = false;
        Image<Bgr,byte>imgOriginal;
        Image<Gray,byte> imgProcessed;
        int LoBlue = 0, LoGreen = 0, LoRed = 230, HiBlue = 0, HiGreen = 0, HiRed = 255;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(b1nCapturingInProcess == true){
                Application.Idle -= processFramAndUpdateGui;
                b1nCapturingInProcess = false;
                StartStop.Text = "Resume";
            }
            else{
                Application.Idle += processFramAndUpdateGui;
                b1nCapturingInProcess = true;
                StartStop.Text = "Pause";
            }
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try{
                capwebcam = new Capture(1); // default webcam
            }
            catch (NullReferenceException except) { 
                txtXYRadius.Text = except.Message;
                return;
            }
            Application.Idle += processFramAndUpdateGui; // add process image function to the application's list of task
            b1nCapturingInProcess = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e){
            if (capwebcam != null){
                capwebcam.Dispose();
            }
        }

        void processFramAndUpdateGui(object sender, EventArgs arg){
            imgOriginal = capwebcam.QueryFrame(); //Get frame from webcam
            if (imgOriginal == null) return;      //did not get frame

            imgProcessed = imgOriginal.InRange(new Bgr(LoBlue, LoGreen, LoRed), new Bgr(HiBlue, HiGreen, HiRed));
            //imgProcessed = imgOriginal.InRange(new Bgr(0,0,230), new Bgr(255,255,255));
            imgProcessed = imgProcessed.SmoothGaussian(9);
           // MCvMoments oMoments = imgProcessed.GetMoments(1);
            
           CircleF[] circles = imgProcessed.HoughCircles(new Gray(100), new Gray(50), 2, imgProcessed.Height / 4, 10, 400)[0];
           foreach (CircleF circle in circles){
               
               if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine);
               txtXYRadius.AppendText("ball position = x"+circle.Center.X.ToString().PadLeft(4)+
                                       ", y = " + circle.Center.Y.ToString().PadLeft(4)+
                                       ", radius =" + circle.Radius.ToString("###.000").PadLeft(7));
               
               txtXYRadius.ScrollToCaret();
                
               CvInvoke.cvCircle(imgOriginal, new Point((int)circle.Center.X,(int)circle.Center.Y),3,new MCvScalar(0,255,0),-1,LINE_TYPE.CV_AA,0);
               imgOriginal.Draw(circle, new Bgr(Color.Red),3);
           }
           
            
            ibOriginal.Image = imgOriginal;
            ibProcessed.Image = imgProcessed;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoBlue  = int.Parse(BlueLo.Text);
            LoGreen = int.Parse(GreenLo.Text);
            LoRed   = int.Parse(RedLo.Text);

            HiBlue  = int.Parse(BlueHi.Text);
            HiGreen = int.Parse(GreenHi.Text);
            HiRed   = int.Parse(RedHi.Text);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

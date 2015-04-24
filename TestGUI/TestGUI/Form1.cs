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
using Emgu.CV.VideoSurveillance;

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
            MCvMoments oMoments = imgProcessed.GetMoments(true);
            double dM01 = oMoments.m01;
            double dM10 = oMoments.m10;
            double dArea = oMoments.m00;
            int iLastX = 0, iLastY = 0;
            if (dArea > 10000)
            {
                //calculate the position of the ball
                int posX = (int)dM10 / (int)dArea;
                int posY = (int)dM01 / (int)dArea;
               
                if (iLastX >= 0 && iLastY >= 0 && posX >= 0 && posY >= 0)
                {
                    //Determine what side the object is on
                    if (posX < imgProcessed.Width / 3)
                        txtXYRadius.Text = "Left";
                    else if (posX > imgProcessed.Width / 3 * 2)
                        txtXYRadius.Text = "Right";
                    else
                        txtXYRadius.Text = "Center";
                    //make some temp x and y variables so we dont have to type out so much
                    int x = posX;
                    int y = posY;
                    //draw some crosshairs on the object
                    PointF center = new PointF(x,y);
                    Point xstart = new Point(x-50, y);
                    Point xend = new Point(x + 50, y);
                    Point ystart = new Point(x, y-50);
                    Point yend = new Point(x, y+50);
                    CircleF circle = new CircleF(center, 50);
                    LineSegment2D linex = new LineSegment2D(xstart, xend);
                    LineSegment2D liney = new LineSegment2D(ystart, yend);
                    imgOriginal.Draw(linex, new Bgr(Color.Blue), 4);
                    imgOriginal.Draw(liney, new Bgr(Color.Blue), 4);
                    imgOriginal.Draw(circle, new Bgr(Color.Red), 4);
                }

                iLastX = posX;
                iLastY = posY;
            }

            /*
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
             */ 
            
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
    
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            LoBlue = Blue.Value-10;
            HiBlue = Blue.Value+10;
            BlueLabel.Text = Blue.Value.ToString();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            LoGreen = Green.Value - 10;
            HiGreen = Green.Value + 10;
            GreenLabel.Text = Green.Value.ToString();
        }

        private void Red_Scroll(object sender, EventArgs e)
        {
            LoRed = Red.Value - 10;
            HiRed = Red.Value + 10;
            RedLabel.Text = Red.Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

using XBee;
using XBee_Interface;
using System.Threading;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;


namespace Drone_Gui
{
    
    public partial class MainWindow : Form
    {
        //Camera initialization 
        Capture capwebcam = null;
        Capture capwebcam2 = null;
        Image<Bgr, byte> imgOriginal;
        Image<Gray, byte> imgProcessed;
        Image<Bgr, byte> imgOriginal2;
        Image<Gray, byte> imgProcessed2;
        int LoBlue = 0, LoGreen = 0, LoRed = 230, HiBlue = 0, HiGreen = 0, HiRed = 255;
       
        //XBeeManager comms;
        ArrayList nodes;
        Thread recieveThread;

        //PUBLIC METHODS
        public MainWindow()
        {
            InitializeComponent();
            //comms = new XBeeManager();
            //comms.InitScan();
            //comms.NodeDiscover();
            //nodes = comms.nodes;
            
            
            
        }

        //EVENTS / DELEGATES
        private void MainWindow_Load(object sender, EventArgs e)
        {

            //read available nodes/connections and identify rovers/beacon
            //display in far left window
           // for (int i = 0; i < nodes.Count; i++)
            //{
            //    list_connections.Items.Add(new ListViewItem(((XBeeNode)nodes[i]).NodeIdentifier));
           // }

            //FOR LIZ:
            //tie 'console' stream to 'console_window'
           // recieveThread = new Thread(new ThreadStart(ReadConnection));
           // recieveThread.Start();
            //Color recognition
            try
            {
                capwebcam = new Capture(0); // default webcam
            }
            catch (NullReferenceException except)
            {
                list_status.Text = except.Message;
                return;
            }
            try
            {
                capwebcam2 = new Capture(1); // default webcam
            }
            catch (NullReferenceException except)
            {
                list_status.Text = except.Message;
                return;
            }
            Application.Idle += processFramAndUpdateGui; // add process image function to the application's list of task
        }

        private void ReadConnection()
        {
            while (true)
            {
                //String data = comms.ReceiveData();
                //app_console.Text = data;

                //alway send to app_console
                //based on data cases/format, perform other actions
                //will have to interact with class variables to store results
            }
        }

        private void main_view_Click(object sender, EventArgs e)
        {
            //if shift click, switch content
            if(Keyboard.IsKeyDown(Key.LeftShift))
            {                
                Switch();
            }

            //if map is present, place designated marker
        }


        //PRIVATE METHODS
        private void Switch()
        {
            //will have to add reformatting of streams and change state in data_controller.
            // have the format set by state in the data controller?
          //  var temp = main_view.Image;
        //    main_view.Image = secondary_view.Image;
         //   secondary_view.Image = temp;
        }
     

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capwebcam != null)
            {
                capwebcam.Dispose();
            }
            if (capwebcam2 != null)
            {
                capwebcam2.Dispose();
            }
        }

        void processFramAndUpdateGui(object sender, EventArgs arg)
        {
            imgOriginal = capwebcam.QueryFrame(); //Get frame from webcam
            imgOriginal2 = capwebcam2.QueryFrame(); //Get frame from second webcam
            if (imgOriginal == null || imgOriginal2 == null) return;      //did not get frame
            imgProcessed = imgOriginal.InRange(new Bgr(LoBlue, LoGreen, LoRed), new Bgr(HiBlue, HiGreen, HiRed));
            imgProcessed = imgProcessed.SmoothGaussian(9);
            imgProcessed2 = imgOriginal2.InRange(new Bgr(LoBlue, LoGreen, LoRed), new Bgr(HiBlue, HiGreen, HiRed));
            imgProcessed2 = imgProcessed2.SmoothGaussian(9);
            MCvMoments oMoments = imgProcessed.GetMoments(true);
            MCvMoments oMoments2 = imgProcessed2.GetMoments(true);
            double dM01 = oMoments.m01;
            double dM10 = oMoments.m10;
            double dArea = oMoments.m00;

            double d2M01 = oMoments.m01;
            double d2M10 = oMoments.m10;
            double d2Area = oMoments.m00;
 
            if (dArea > 10000)
            {
                //calculate the position of the object
                int posX = (int)dM10 / (int)dArea;
                int posY = (int)dM01 / (int)dArea;
               

                    //Determine what side the object is on
                    if (posX < imgProcessed.Width / 3)
                        list_status.Text = "Left on camera 1";
                    else if (posX > imgProcessed.Width / 3 * 2)
                        list_status.Text = "Right on camera 1";
                    else
                        list_status.Text = "Center on camera 1";

                   
                    //make some temp x and y variables 
                    int x = posX;
                    int y = posY;
                    //draw some crosshairs on the object
                    PointF center = new PointF(x, y);
                    Point xstart = new Point(x - 50, y);
                    Point xend = new Point(x + 50, y);
                    Point ystart = new Point(x, y - 50);
                    Point yend = new Point(x, y + 50);
                    CircleF circle = new CircleF(center, 50);
                    LineSegment2D linex = new LineSegment2D(xstart, xend);
                    LineSegment2D liney = new LineSegment2D(ystart, yend);
                    imgOriginal.Draw(linex, new Bgr(Color.Blue), 4);
                    imgOriginal.Draw(liney, new Bgr(Color.Blue), 4);
                    imgOriginal.Draw(circle, new Bgr(Color.Red), 4);
            }

            if (d2Area > 10000)
            {
                int pos2X = (int)d2M10 / (int)d2Area;
                int pos2Y = (int)d2M01 / (int)d2Area;
                if (pos2X < imgProcessed2.Width / 3)
                    list_status.Text = "Left on camera 2";
                else if (pos2X > imgProcessed2.Width / 3 * 2)
                    list_status.Text = "Right on camera 2";
                else
                    list_status.Text = "Center on camera 2";
                //make some temp x and y variables 
                int x = pos2X;
                int y = pos2Y;
                //draw some crosshairs on the object
                PointF center = new PointF(x, y);
                Point xstart = new Point(x - 50, y);
                Point xend = new Point(x + 50, y);
                Point ystart = new Point(x, y - 50);
                Point yend = new Point(x, y + 50);
                CircleF circle = new CircleF(center, 50);
                LineSegment2D linex = new LineSegment2D(xstart, xend);
                LineSegment2D liney = new LineSegment2D(ystart, yend);
                imgOriginal2.Draw(linex, new Bgr(Color.Blue), 4);
                imgOriginal2.Draw(liney, new Bgr(Color.Blue), 4);
                imgOriginal2.Draw(circle, new Bgr(Color.Red), 4);

            }

            camera1.Image = imgOriginal;
            camera2.Image = imgOriginal2;
     

        }

        private void list_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void camera1_Click(object sender, EventArgs e)
        {

        }


        

    }
}

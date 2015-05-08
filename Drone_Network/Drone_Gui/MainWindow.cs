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

using GMap.NET.CacheProviders;
using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.ObjectModel;
using GMap.NET.Projections;
using GMap.NET.Properties;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;


using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;


namespace MissionPlanner
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
        int LoHue = 0, LoSaturation = 0, LoValue = 230, HiHue = 0, HiSaturation = 0, HiValue = 255;
        

        //Map Layers and Points

        GMap.NET.PointLatLng start;
        GMap.NET.PointLatLng end;
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        GMapOverlay polyOverlay = new GMapOverlay("polygons");
        List<PointLatLng> route = new List<PointLatLng>();
        List<PointLatLng> area = new List<PointLatLng>();

        //XBeeManager comms;
        ArrayList nodes;
        Thread recieveThread;

        //PUBLIC METHODS
        public MainWindow()
        {
            InitializeComponent();
            SuspendLayout();
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
            /*
            try
            {
                capwebcam2 = new Capture(1); // default webcam
            }
            catch (NullReferenceException except)
            {
                list_status.Text = except.Message;
                return;
            }
             */
            capwebcam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 557);
            capwebcam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 389);
            Application.Idle += processFramAndUpdateGui; // add process image function to the application's list of task
        }

        private void mapControl_Load(object sender, EventArgs e)
        {
            mapControl.MapProvider = GMapProviders.BingHybridMap;

            //position will be defined by beacon init position, for initialization purposes.
            mapControl.Position = new GMap.NET.PointLatLng(33.7830, -118.1129);
            mapControl.MinZoom = 0;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 15;
            mapControl.DragButton = MouseButtons.Right;

            Controls.Add(mapControl);
            ResumeLayout(true);

            mapControl.Overlays.Add(routesOverlay);
            mapControl.Overlays.Add(polyOverlay);
        }

        private void generateRoute()
        {
            routesOverlay.Clear();
            GMapRoute r = new GMapRoute(route, "My route");
            r.Stroke.Width = 2;
            r.Stroke.Color = Color.Green;
            routesOverlay.Routes.Add(r);

            printPoints();
        }

        private void generateArea()
        {
            //draw polygon
            polyOverlay.Clear();
            GMapPolygon polygon = new GMapPolygon(area, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
        }

        private void mapControl_DoubleClick(object sender, EventArgs e)
        {
            if (mapModeSel.SelectedIndex == 0)
            {
                PointLatLng temp = mapControl.FromLocalToLatLng(((System.Windows.Forms.MouseEventArgs)e).Location.X, ((System.Windows.Forms.MouseEventArgs)e).Location.Y);
                route.Add(temp);
                generateRoute();
            }
            else if(mapModeSel.SelectedIndex == 1)
            {
                PointLatLng temp = mapControl.FromLocalToLatLng(((System.Windows.Forms.MouseEventArgs)e).Location.X, ((System.Windows.Forms.MouseEventArgs)e).Location.Y);
                area.Add(temp);
                generateArea();
            }
        }

        private void printPoints()
        {
            int j = 1;
            foreach (GMapRoute r in routesOverlay.Routes)
            {
                Console.WriteLine("Route #: " + j);
                for (int i = 0; i < r.Points.Count; i++)
                    Console.WriteLine("Route:" + r.Points[i]);
            }
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
            //Dispose of cameras
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
           // imgOriginal2 = capwebcam2.QueryFrame(); //Get frame from second webcam
            if (imgOriginal == null) return;      //did not get frame
            Image<Hsv, Byte> imgHSV = imgOriginal.Convert<Hsv, Byte>();
            imgProcessed = imgHSV.InRange(new Hsv(LoHue,LoSaturation,LoValue), new Hsv(HiHue,HiSaturation,HiValue));
            imgProcessed = imgProcessed.SmoothGaussian(9);
           // Image<Hsv, Byte> imgHSV2 = imgOriginal2.Convert<Hsv, Byte>();
            //imgProcessed2 = imgHSV2.InRange(new Hsv(LoHue, LoSaturation, LoValue), new Hsv(HiHue, HiSaturation, HiValue));
            //imgProcessed2 = imgProcessed2.SmoothGaussian(9);
            MCvMoments oMoments = imgProcessed.GetMoments(true);
            //MCvMoments oMoments2 = imgProcessed2.GetMoments(true);
            double dM01 = oMoments.m01;
            double dM10 = oMoments.m10;
            double dArea = oMoments.m00;

            //double d2M01 = oMoments.m01;
            //double d2M10 = oMoments.m10;
            //double d2Area = oMoments.m00;
 
            if (dArea > 3000)
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
            /*
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
            
            }*/

            camera1.Image = imgOriginal;
           
        }

        private void list_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void camera1_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '+')
            {
                mapControl.Zoom = mapControl.Zoom + 1;
            }

            if (e.KeyChar == '-')
            {
                mapControl.Zoom = mapControl.Zoom - 1;
            }
        }

        private void areaClear_Click(object sender, EventArgs e)
        {
            area.Clear();
            polyOverlay.Clear();
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void redButtonSelect_Click(object sender, EventArgs e)
        {
            LoHue = 0; 
            LoSaturation = 196; 
            LoValue = 74; 
            HiHue = 15; 
            HiSaturation = 138; 
            HiValue = 125;
            currentColorLabel.Text = "Color Selected: Red";
        }

        private void yellowButtonSelect_Click(object sender, EventArgs e)
        {
            LoHue = 29;
            LoSaturation = 86;
            LoValue = 102;
            HiHue = 63;
            HiSaturation = 165;
            HiValue = 181;
            currentColorLabel.Text = "Color Selected: Yellow";
        }

        private void blueButtonSelect_Click(object sender, EventArgs e)
        {
            LoHue = 140;
            LoSaturation = 86;
            LoValue = 97;
            HiHue = 165;
            HiSaturation = 190;
            HiValue = 170;
            currentColorLabel.Text = "Color Selected: Blue";
        }

       



        

    }
}

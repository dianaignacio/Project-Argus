using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET.CacheProviders;
using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.ObjectModel;
using GMap.NET.Projections;
using GMap.NET.Properties;
using GMap.NET.WindowsForms;
using System.Net;

namespace MapsTest
{
    public partial class Form1 : Form
    {
        GMapOverlay markerTest = new GMapOverlay("markers");
        GMap.NET.PointLatLng lastPoint, curPoint;
        Pen routeDraw;
        Graphics g;
        GMapMarkerRect wrapper;

        public Form1()
        {
            InitializeComponent();

            SuspendLayout();

            /* To be used if there is a proxy on the network            
            
            GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
            GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
            */
            //used to initialize map control, overlay, and markers
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void mapControl_Load(object sender, EventArgs e)
        {
            mapControl.MapProvider = GMapProviders.BingHybridMap;
            
            //position will be defined by beacon init position, for initialization purposes.
            mapControl.Position = new GMap.NET.PointLatLng(33.7830, -118.1129);
            mapControl.MinZoom = 0;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 15;
            mapControl.Dock = DockStyle.Fill;


            Controls.Add(mapControl);
            ResumeLayout(true);

           
            mapControl.Overlays.Add(markerTest);
        }

        private void mapControl_DoubleClick(object sender, EventArgs e)
        {
            
            GMapMarkerRect test = new GMapMarkerRect(mapControl.FromLocalToLatLng(((MouseEventArgs)e).Location.X,((MouseEventArgs)e).Location.Y));
            if (wrapper == null)
                wrapper = test;

            markerTest.Markers.Add(test);
            curPoint = mapControl.FromLocalToLatLng(((MouseEventArgs)e).Location.X, ((MouseEventArgs)e).Location.Y);

            if (lastPoint.Lat != 0 && lastPoint.Lng != 0)
            {
                routeDraw = new Pen(Brushes.Blue, 5);
                Point t1 = new Point(((int)(mapControl.FromLatLngToLocal(lastPoint)).X), ((int)(mapControl.FromLatLngToLocal(lastPoint)).Y));
                Point t2 = new Point(((int)(mapControl.FromLatLngToLocal(curPoint)).X), ((int)(mapControl.FromLatLngToLocal(curPoint)).Y));
                //wrapper.LineDraw(routeDraw,t1,t2);
                System.Windows.Forms.Control

            }
            lastPoint = curPoint;

        }

        //temporary method
        public void OnRender(Graphics g)
        {
            if (lastPoint.Lat != 0 && lastPoint.Lng != 0 )
            {
                routeDraw = new Pen(Brushes.Blue, 5);
                Point t1 = new Point(((int)(mapControl.FromLatLngToLocal(lastPoint)).X),((int)(mapControl.FromLatLngToLocal(lastPoint)).Y));
                Point t2 = new Point(((int)(mapControl.FromLatLngToLocal(curPoint)).X),((int)(mapControl.FromLatLngToLocal(curPoint)).Y));
                g.DrawLine(routeDraw, t1, t2);

            }
            lastPoint = curPoint;
        }
    }

    //THIS SHOULD BE IN A SEPERATE FILE
    //taken from: https://greatmaps.codeplex.com/wikipage?title=custom%20marker&referringTitle=GMap.NET.WindowsForms
    //template to generate custom marker
    //changed: pen width from 5 to 1; size from 55x55 to 5x5;
    public class GMapMarkerRect : GMapMarker
    {
        public Pen Pen;
        private Graphics temp;
        public GMapMarkerRect(GMap.NET.PointLatLng p)
            : base(p)
        {
            Pen = new Pen(Brushes.Red, 1);

            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new Size(5, 5);
        }

        public override void OnRender(Graphics g)
        {
            temp = g;
            g.DrawRectangle(Pen, new System.Drawing.Rectangle(LocalPosition.X - Size.Width / 2, LocalPosition.Y - Size.Height / 2, Size.Width, Size.Height));
        }

        public void LineDraw(Pen p, Point one, Point two)
        {
            Graphics.DrawLine(new Pen(Brushes.Blue), one, two);
        }

    }
}

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
        public Form1()
        {
            InitializeComponent();

            SuspendLayout();

            /* To be used if there is a proxy on the network            
            
            GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
            GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
            */
            //used to initialize map control, overlay, and markers
            


            //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(-25.966688, 32.580528),GMarkerGoogleType.green);
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
            //point will have to be determined by coordinates of mouse click
            //GMapMarker marker = new GMarkerGoogle(new GMap.NET.PointLatLng(-25.966688, 32.580528), GMarkerGoogleType.green);
            //markerTest.Markers.Add()

            GMapMarkerRect test = new GMapMarkerRect(new GMap.NET.PointLatLng(33.7830, -118.1129));
            markerTest.Markers.Add(test);
        }


    }

    //taken from: https://greatmaps.codeplex.com/wikipage?title=custom%20marker&referringTitle=GMap.NET.WindowsForms
    //template to generate custom marker
    //changed: pen width from 5 to 1; size from 55x55 to 5x5;
    public class GMapMarkerRect : GMapMarker
    {
        public Pen Pen;

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
            g.DrawRectangle(Pen, new System.Drawing.Rectangle(LocalPosition.X - Size.Width / 2, LocalPosition.Y - Size.Height / 2, Size.Width, Size.Height));
        }
    }
}

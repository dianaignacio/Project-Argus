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
using GMap.NET; 
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Net;

namespace MapsTest
{
    public partial class Form1 : Form
    {
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        GMapOverlay polyOverlay = new GMapOverlay("polygons");

        public Form1()
        {
            InitializeComponent(); 
            SuspendLayout();

            /* To be used if there is a proxy on the network            
            
            GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
            GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
            */
            //used to initialize map control, overlay, and markers

            //GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(33.7830, -118.1129), GMarkerGoogleType.green);

        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            //GMap.NET.MapProviders.GoogleMapProvider.Instance; 
            //mapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            //mapControl.Manager.Mode = AccessMode.ServerOnly;
            //GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.CacheOnly;   
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
            mapControl.DragButton = MouseButtons.Left;

            Controls.Add(mapControl);
            ResumeLayout(true);

            mapControl.Overlays.Add(routesOverlay);
            mapControl.Overlays.Add(polyOverlay);
        }

        private void printPoints()
        {
            int j = 1;
            foreach(GMapRoute r in routesOverlay.Routes)
            {
                Console.WriteLine("Route #: " + j);
                for (int i = 0; i < r.Points.Count; i++)
                    Console.WriteLine("Route:" + r.Points[i]);
            }
        }
 

        private void mapControl_DoubleClick(object sender, EventArgs e)
        {                          
            GMap.NET.PointLatLng start = new GMap.NET.PointLatLng(33.788399, -118.123112);   
            GMap.NET.PointLatLng end = new GMap.NET.PointLatLng(33.773846, -118.102684);
            
            /* the two booleans flags are:
                avoidHighways – If set, the mapping provider will try to avoid highways, instead taking the scenic route (if supported);
                walkingMode – If set, the mapping provider will assume that you’re going on foot and include footpaths (if supported). */
            GMap.NET.MapRoute route = GMap.NET.MapProviders.GMapProviders.GoogleMap.GetRoute(start, end, false, false, 15);

            GMapRoute r = new GMapRoute(route.Points, "My route");
            r.Stroke.Width = 2;
            r.Stroke.Color = Color.Green;
            routesOverlay.Routes.Add(r);
           
            printPoints();
            //mapControl.Overlays.Add(routesOverlay);
            //mapControl.ZoomAndCenterMarkers("My route");
            
        }

        private void mapControl_Click(object sender, EventArgs e)
        {
            /*
            // polygons 
            List<PointLatLng> points = new List<PointLatLng>(); ;
            points.Add(new PointLatLng(33.788399, -118.123112));
            points.Add(new PointLatLng(33.774416, -118.121052));
            points.Add(new PointLatLng(33.773846, -118.102684));
            points.Add(new PointLatLng(33.787686, -118.098907));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            */
        }
        
    }
}

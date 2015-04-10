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
       
        public Form1()
        {
            InitializeComponent();

            SuspendLayout();

            /* To be used if there is a proxy on the network            
            
            GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
            GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
            */
            //used to initialize map control, overlay, and markers
            

            Controls.Add(mapControl);
            ResumeLayout(true);

            GMapOverlay markerTest = new GMapOverlay("markers");
            mapControl.Overlays.Add(markerTest);

            //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(-25.966688, 32.580528),GMarkerGoogleType.green);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void mapControl_Load(object sender, EventArgs e)
        {
            mapControl.MapProvider = GMapProviders.BingHybridMap;
            mapControl.Position = new GMap.NET.PointLatLng(54.6961334816182, 25.2985095977783);
            mapControl.MinZoom = 0;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 9;
            mapControl.Dock = DockStyle.Fill;
            
        }


    }
}

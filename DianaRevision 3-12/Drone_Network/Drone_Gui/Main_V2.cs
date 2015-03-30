using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;

namespace Drone_Gui
{
    
    public partial class Main_V2 : Form
    {
        //constructor and load methods
         // layers
              readonly GMapOverlay top = new GMapOverlay();
              internal readonly GMapOverlay objects = new GMapOverlay("objects");
              internal readonly GMapOverlay routes = new GMapOverlay("routes");
              internal readonly GMapOverlay polygons = new GMapOverlay("polygons");

              // marker
              GMapMarker currentMarker;

              // polygons
              GMapPolygon polygon;

              // etc
              readonly Random rnd = new Random();
              readonly DescendingComparer ComparerIpStatus = new DescendingComparer();
              GMapMarkerRect CurentRectMarker = null;
              string mobileGpsLog = string.Empty;
              bool isMouseDown = false;
              PointLatLng start;
              PointLatLng end;
        
        public Main_V2()
        {
            InitializeComponent();
             


// map events
{
   MainMap.OnPositionChanged += new PositionChanged(MainMap_OnPositionChanged);

   MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
   MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);

   MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
   MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);

   MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
   MainMap.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
   MainMap.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

   MainMap.OnPolygonEnter += new PolygonEnter(MainMap_OnPolygonEnter);
   MainMap.OnPolygonLeave += new PolygonLeave(MainMap_OnPolygonLeave);

   MainMap.OnRouteEnter += new RouteEnter(MainMap_OnRouteEnter);
   MainMap.OnRouteLeave += new RouteLeave(MainMap_OnRouteLeave);

   MainMap.Manager.OnTileCacheComplete += new TileCacheComplete(OnTileCacheComplete);
   MainMap.Manager.OnTileCacheStart += new TileCacheStart(OnTileCacheStart);
   MainMap.Manager.OnTileCacheProgress += new TileCacheProgress(OnTileCacheProgress);
}   
}
                /// use to store all internal config
        /// </summary>
        public static Hashtable config = new Hashtable();

        public static string getConfig(string paramname)
        {
            if (config[paramname] != null)
                return config[paramname].ToString();
            return "";
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
        
        } 
        }

        //Events
        private void main_view_Click(object sender, EventArgs e)
        {
            //if shift click, switch content
            if(Keyboard.IsKeyDown(Key.LeftShift))
            {
                Switch();
            }

            //if map is present, place designated marker
        }

        //private methods
        private void Switch()
        {
            //will have to add reformatting of streams and change state in data_controller.
            // have the format set by state in the data controller?
            var temp = main_view.Image;
            main_view.Image = secondary_view.Image;
            secondary_view.Image = temp;
        }
      void OnTileCacheProgress(int left)
      {
         if(!IsDisposed)
         {
            MethodInvoker m = delegate
            {
               textBoxCacheStatus.Text = left + " tile to save...";
            };
            Invoke(m);
         }
      }
        static void CleanupFiles()
        {
            //cleanup bad file
            string file = Application.StartupPath + Path.DirectorySeparatorChar + @"LogAnalyzer\tests\TestUnderpowered.py";
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            //File.Delete("*.xaml");
        }
    // loader start loading tiles
      void MainMap_OnTileLoadStart()
      {
         MethodInvoker m = delegate()
         {
            panelMenu.Text = "Menu: loading tiles...";
         };
         try
         {
            BeginInvoke(m);
         }
         catch
         {
         }
      }

      // loader end loading tiles
      void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
      {
         MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

         MethodInvoker m = delegate()
         {
            panelMenu.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";

            textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00} MB of {1:0.00} MB", MainMap.Manager.MemoryCache.Size, MainMap.Manager.MemoryCache.Capacity);
         };
         try
         {
            BeginInvoke(m);
         }
         catch
         {
         }
      }
    }


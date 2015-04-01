using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MissionPlanner.Utilities;
using MissionPlanner;
using System.Net;
using log4net.Config;
using log4net;
using System.Diagnostics;

namespace Drone_Gui
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger("Program");
        public static string[] args = new string[] { };
        internal static Thread Thread;
        
        [STAThread]
        static void Main(string[] args)
        {
            Program.args = args;
            Console.WriteLine("If your error is about Microsoft.DirectX.DirectInput, please install the latest directx redist from here http://www.microsoft.com/en-us/download/details.aspx?id=35 \n\n");
            Console.WriteLine("Debug under mono    MONO_LOG_LEVEL=debug mono MissionPlanner.exe");

            Thread = Thread.CurrentThread;

            System.Windows.Forms.Application.EnableVisualStyles();
            XmlConfigurator.Configure();
            log.Info("******************* Logging Configured *******************");
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            ServicePointManager.DefaultConnectionLimit = 10;

            System.Windows.Forms.Application.ThreadException += Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // fix ssl on mono
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });

            if (args.Length > 0 && args[0] == "/update")
            {
                Utilities.Update.DoUpdate();
            }

            // setup theme provider
            CustomMessageBox.ApplyTheme += MissionPlanner.Utilities.ThemeManager.ApplyThemeTo;
            Controls.MainSwitcher.ApplyTheme += MissionPlanner.Utilities.ThemeManager.ApplyThemeTo;
            MissionPlanner.Controls.InputBox.ApplyTheme += MissionPlanner.Utilities.ThemeManager.ApplyThemeTo;

            // setup settings provider
            MissionPlanner.Comms.CommsBase.Settings += CommsBase_Settings;

            // set the cache provider to my custom version
            GMap.NET.GMaps.Instance.PrimaryCache = new Maps.MyImageCache();
            // add my custom map providers
            GMap.NET.MapProviders.GMapProviders.List.Add(Maps.WMSProvider.Instance);
            GMap.NET.MapProviders.GMapProviders.List.Add(Maps.Custom.Instance);
            GMap.NET.MapProviders.GMapProviders.List.Add(Maps.Earthbuilder.Instance);
            GMap.NET.MapProviders.GMapProviders.List.Add(Maps.Statkart_Topo2.Instance);
            GMap.NET.MapProviders.GMapProviders.List.Add(Maps.MapBox.Instance);
            GMap.NET.MapProviders.GMapProviders.List.Add(Maps.MapboxNoFly.Instance);

            // add proxy settings
            GMap.NET.MapProviders.GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;

            WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            string name = "Mission Planner";

            if (File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "logo.txt"))
                name = File.ReadAllText(Application.StartupPath + Path.DirectorySeparatorChar + "logo.txt", Encoding.UTF8);

            if (File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "logo.png"))
                Logo = new Bitmap(Application.StartupPath + Path.DirectorySeparatorChar + "logo.png");

            if (name == "VVVVZ")
            {
                vvvvz = true;
                // set pw
                Main_V2.config["password"] = "viDQSk/lmA2qEE8GA7SIHqu0RG2hpkH973MPpYO87CI=";
                Main_V2.config["password_protect"] = "True";
                // prevent wizard
                Main_V2.config["newuser"] = "11/02/2014";
                // invalidate update url
                System.Configuration.ConfigurationManager.AppSettings["UpdateLocationVersion"] = "";
            }

            CleanupFiles();
            
            Application.Run(new Main_V2());
        }
        static string CommsBase_Settings(string name, string value, bool set = false)
        {
            if (set)
            {
                Main_V2.config[name] = value;
                return value;
            }

            if (Main_V2.config.ContainsKey(name))
            {
                return Main_V2.config[name].ToString();
            }

            return "";
        }


    }
}

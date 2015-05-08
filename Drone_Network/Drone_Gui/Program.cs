using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner
{
    class Program
    {
        public static string[] args = new string[] { };

        [STAThread]
        static void Main(string[] args)
        {
            Form app = new MainWindow();
            Application.Run(app);
        }
    }
}

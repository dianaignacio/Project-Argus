using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drone_Gui
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form app = new MainWindow();
            Application.Run(app);
        }
    }
}

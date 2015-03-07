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
using XBee_Interface;


namespace Drone_Gui
{
    
    public partial class MainWindow : Form
    {

        XBeeManager comms;
        //PUBLIC METHODS
        public MainWindow()
        {
            InitializeComponent();
            comms = new XBeeManager();
            
        }

        //EVENTS / DELEGATES
        private void MainWindow_Load(object sender, EventArgs e)
        {
            comms.Scan();
            ReadConnection();
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
            var temp = main_view.Image;
            main_view.Image = secondary_view.Image;
            secondary_view.Image = temp;
        }

        
        //will be using it's own thread
        private void ReadConnection()
        {
            String data = comms.ReceiveData();
            app_console.Text = data;

            //alway send to app_console
            //based on data cases/format, perform other actions
        }

        

    }
}

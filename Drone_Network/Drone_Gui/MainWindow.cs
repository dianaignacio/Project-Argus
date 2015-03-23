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


namespace Drone_Gui
{
    
    public partial class MainWindow : Form
    {

        XBeeManager comms;
        ArrayList nodes;
        Thread recieveThread;

        //PUBLIC METHODS
        public MainWindow()
        {
            InitializeComponent();
            comms = new XBeeManager();
            comms.InitScan();
            comms.NodeDiscover();
            nodes = comms.nodes;
            
            
            
        }

        //EVENTS / DELEGATES
        private void MainWindow_Load(object sender, EventArgs e)
        {

            //read available nodes/connections and identify rovers/beacon
            //display in far left window
            for (int i = 0; i < nodes.Count; i++)
            {
                list_connections.Items.Add(new ListViewItem(((XBeeNode)nodes[i]).NodeIdentifier));
            }

            //FOR LIZ:
            //tie 'console' stream to 'console_window'
            recieveThread = new Thread(new ThreadStart(ReadConnection));
            recieveThread.Start();
           
        }

        private void ReadConnection()
        {
            while (true)
            {
                String data = comms.ReceiveData();
                app_console.Text = data;

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
            var temp = main_view.Image;
            main_view.Image = secondary_view.Image;
            secondary_view.Image = temp;
        }

        
        


        

    }
}

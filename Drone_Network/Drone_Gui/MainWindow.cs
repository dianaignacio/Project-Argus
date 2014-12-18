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

namespace Drone_Gui
{
    
    public partial class MainWindow : Form
    {
        //constructor and load methods
        
        public MainWindow()
        {
            InitializeComponent();
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

    }
}

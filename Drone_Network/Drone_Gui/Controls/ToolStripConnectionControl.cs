﻿using System.Windows.Forms;
namespace Drone_Gui.Controls
{
    public class ToolStripConnectionControl : ToolStripControlHost
    {
        // Call the base constructor passing in a MonthCalendar instance.     
        public ToolStripConnectionControl()
            : base(new ConnectionControl())
        {
        }

        public ConnectionControl ConnectionControl
        {
            get { return Control as ConnectionControl; }
        }
    }
}
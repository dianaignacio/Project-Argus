using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBee_Interface;
using XBee.Frames;
using XBee;

namespace AutoDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            //this is a test program
            XBeeManager coord = new XBeeManager();
            

            coord.InitScan();
            coord.NodeDiscover();
            

            //test getting information from individual nodes
                //run a node identification command on each node in coord.nodes
                //execute a node discover command with the node identifier to pull ONLY that nodes information

            //test changing parameters of individual nodes or the entire network
                //will need to be done for each remote node, then finially the coordinator node
            //will be moved to manager class, only here for pseudo code purposes
            foreach(XBeeNode n in coord.nodes)
            {
                //set parameter using 
            }
            //change network baud rate
            //change network parity
            //change network panID
            //set node identifier (for xbee, not arduino. xbee is too small for VIN)


            while (true) ;

        }
    }
}

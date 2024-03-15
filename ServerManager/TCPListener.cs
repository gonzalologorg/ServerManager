using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager
{
    class TCPListener
    {
        static String hostName = Dns.GetHostName();
        static IPAddress? ipAddress;
        static string port = "";
        static List<string> exclude = new List<string>();
        int result = 0;
        public TCPListener() {
        }

        public static async Task<bool> StartWorker(int port)
        {
            bool isOpen= checkPorts(port);
            return isOpen;
        }

        private static bool checkPorts(int port)
        {
            List<string> results = new List<string>();

            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            //Get a list of possible ip addresses
            IPAddress[] addr = ipEntry.AddressList;

            //The first one in the array is the ip address of the hostname
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = addr[i];
                    break;
                }
            }

            bool stat = false;
            TcpClient tc = new TcpClient();
            tc.NoDelay = true;
            tc.ReceiveTimeout = 10;
            tc.SendTimeout = 10;

            try
            {
                tc.Connect(ipAddress, port);
                stat = tc.Connected;

                if (stat)
                {
                    Debug.WriteLine("Success " + ipAddress.ToString() + ":" + port);
                    results.Add(port.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed " + ipAddress.ToString() + ":" + port);
            }

            tc.Close();

            return stat;
        }
    }
}

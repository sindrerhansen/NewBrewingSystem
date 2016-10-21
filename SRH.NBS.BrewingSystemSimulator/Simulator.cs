using Newtonsoft.Json;
using SRH.NBS.Commen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SRH.NBS.BrewingSystemSimulator
{
    
    public class Simulator
    {
        private const int port = 6000;
      
        static void Main(string[] args)
        {
            StartSimulating();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private static void StartSimulating()
        {
            Random rnd = new Random();
            bool done = false;
            var ip = GetLocalIPAddress();
            var testObject = new HotLiquidTank() { Name="HLT", Temperature=rnd.Next(0,100), Volume=(rnd.NextDouble()*60)};
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse("192.168.3.80"), port);
            var sender = new UdpClient();

            try
            {
                Console.WriteLine("Broadcasting");
                while (!done)
                {
                    //var sendString = "Is anybody there? At: " + DateTime.Now.Millisecond;
                    var sendObject = JsonConvert.SerializeObject(testObject);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(sendObject);
                    sender.Send(sendBytes, sendBytes.Length, groupEP);
                    Console.WriteLine(sendObject);
                    System.Threading.Thread.Sleep(1000);
                    testObject.Volume = rnd.NextDouble() * 60;
                    testObject.Temperature = rnd.NextDouble() * 100;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                sender.Close();
            }
        }
    }
}

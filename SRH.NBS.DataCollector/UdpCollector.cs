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

namespace SRH.NBS.DataCollector
{
    public class UdpCollector
    {
        private const int listenPort = 6000;
        private bool done = false;
        private UdpClient listener;
        private IPEndPoint groupEP;

        public UdpCollector()
        {
            listener = new UdpClient(listenPort);
            groupEP = new IPEndPoint(IPAddress.Any, listenPort);
        }
        public void Start(SignalrClient realtimeHub)
        {
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    var jsonObj = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    if (jsonObj != null)
                    {
                        var reciveObject = JsonConvert.DeserializeObject<HotLiquidTank>(jsonObj);
                        Console.WriteLine(reciveObject.Temperature);
                        Console.WriteLine(reciveObject.Volume);
                        if (realtimeHub.Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                        {
                            realtimeHub.Hub.Invoke("OnRealtimeBrewingData", jsonObj);
                    }
                    }

                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
    }
}

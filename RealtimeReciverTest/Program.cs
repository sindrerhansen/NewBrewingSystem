using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeReciverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectingUrl = @"http://" + "192.168.3.80" + ":9000/";
            var hubConnection = new HubConnection(connectingUrl);
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("RealtimeBrewingData");
            stockTickerHubProxy.On<string>("ReciveRealtimeBrewingData", msg =>  Console.WriteLine(msg));
            hubConnection.Start();
            Console.ReadLine();
        }
    }
}

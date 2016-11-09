using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SRH.NBS.Commen;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SRH.NBS.RealtimeDataProviderService
{
    [HubName("RealtimeBrewingData")]
    public class RealtimeBrewingDataHub : Hub
    {

        public override Task OnConnected()
        {
            Console.WriteLine("Some one is connecting");
            return base.OnConnected();
        }

        public void PublishRealtimeBrewingData(string message)
        {
            Debug.WriteLine(message);
            Clients.All.ReciveRealtimeBrewingData(message);
        }
        
        
        public void SendCommand(string command)
        {
            Console.WriteLine(string.Format("Writing command {0} ", command));
        }
        
    }
}

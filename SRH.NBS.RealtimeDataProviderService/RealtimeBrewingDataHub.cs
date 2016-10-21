using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SRH.NBS.Commen;
using System;
using System.Diagnostics;

namespace SRH.NBS.RealtimeDataProviderService
{
    [HubName("RealtimeBrewingData")]
    public class RealtimeBrewingDataHub : Hub
    {

        public void PublishRealtimeBrewingData(string message)
        {
            Debug.WriteLine(message);
            Clients.All.ReciveRealtimeBrewingData(message);
        }

        public void SendCommand(string command)
        {
            Console.WriteLine(string.Format("Writing command {0} ", command));
        }

        public TestClass Get()
        {
            return new TestClass { Age = 12, EtterNavn = "Hansen", ForNavn = "Sindre" };
        }
        
    }
}

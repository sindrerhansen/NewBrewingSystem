using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SRH.NBS.Commen;
using System;
using System.Diagnostics;

namespace DataHubService
{
    [HubName("RealtimeBrewingData")]
    public class RealtimeBrewingDataHub : Hub
    {

        public void OnRealtimeBrewingData(string message)
        {
            Debug.WriteLine(message);
            Clients.All.ReceiveMulticastBrewingData(message);
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

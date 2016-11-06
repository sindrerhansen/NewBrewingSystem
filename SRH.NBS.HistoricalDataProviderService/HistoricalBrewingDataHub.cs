using SRH.NBS.Commen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SRH.NBS.HistoricalDataProviderService
{
    [HubName("HistoricalBrewingData")]
    public class HistoricalBrewingDataHub : Hub
    {
        public void OnRealtimeBrewingData(string message)
        {
      
        }

        public void SendCommand(string command)
        {
            Console.WriteLine(string.Format("Writing command {0} ", command));
        }

    }
}

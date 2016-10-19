using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRH.NBS.DataProvider
{
    [HubName("RealtimeBrewingData")]
    public class HistoricalBrewingDataHub
    {
        public void MulticastBrewingData(string message)
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

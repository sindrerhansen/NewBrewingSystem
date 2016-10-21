using Microsoft.AspNet.SignalR.Client;
using System;
using System.Diagnostics;

namespace SRH.NBS.Commen
{
    public class SignalrClient
    {
        private IHubProxy _hub;
        public IHubProxy Hub
        {
            get { return _hub; }
            private set { _hub = value; }

        }

        private HubConnection connection;
        public HubConnection Connection
        {
            get { return connection; }
            private set { connection = value; }
        }

        public SignalrClient(string ip)
        {
            
            var connectingUrl = @"http://" + ip + ":8088/";
            // For testing
            connectingUrl = @"http://" + "192.168.3.80" + ":9000/";
            // For testing

            try
            {
                connection = new HubConnection(connectingUrl);
                _hub = connection.CreateHubProxy("RealtimeBrewingData");
                connection.Start().Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Hub error: {0}", e.Message.ToString());

            }


        }

    }
}

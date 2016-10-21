using Microsoft.Owin.Hosting;
using System;
using System.Configuration;



namespace SRH.NBS.RealtimeDataProviderService
{
    public class RealtimeDataService
    {
        public void Start()
        {
            var ip = ConfigurationManager.AppSettings["LocalIP"];
            string url = @"http://" + ip + ":9000/";
            WebApp.Start<HubStartup>(url);

            Console.WriteLine(string.Format("Server running at {0}", url));
            Console.ReadLine();
        }

        public void Stop()
        {

        }
    }
}

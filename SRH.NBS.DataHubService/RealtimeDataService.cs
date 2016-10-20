using Microsoft.Owin.Hosting;
using System;
using System.Configuration;



namespace DataHubService
{
    public class RealtimeDataService
    {
        public void Start()
        {
            var ip = ConfigurationManager.AppSettings["LocalIP"];
            string url = @"http://" + ip + ":8088/";
            WebApp.Start<HubStartup>(url);

            Console.WriteLine(string.Format("Server running at {0}", url));
            Console.ReadLine();
        }

        public void Stop()
        {

        }
    }
}

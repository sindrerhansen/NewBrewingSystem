using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DataHubService
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<DataHubService>(service =>
                {
                    service.ConstructUsing(s => new DataHubService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("SRH.NBS.DataHubService");
                configure.SetDisplayName("SRH.NBS.DataHubService");
                configure.SetDescription("Data reader and distrubuter for Sindre brewing system");
            });
        }
    }
}

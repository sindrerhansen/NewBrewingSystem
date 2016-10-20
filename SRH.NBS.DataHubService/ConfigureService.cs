using Topshelf;

namespace DataHubService
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                
                configure.Service<RealtimeDataService>(service =>
                {
                    service.ConstructUsing(s => new RealtimeDataService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("SRH.NBS.DataHubService");
                configure.SetDisplayName("SRH.NBS.DataHubService");
                configure.SetDescription("Data reader and distributer for Sindre brewing system");
            });
           
        }
    }
}

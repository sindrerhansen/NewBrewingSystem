using Microsoft.Owin.Cors;
using Owin;

namespace SRH.NBS.RealtimeDataProviderService
{
    class HubStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var x = app.MapSignalR();
        }
    }
}

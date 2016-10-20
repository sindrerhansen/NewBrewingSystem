using Microsoft.Owin.Cors;
using Owin;

namespace DataHubService
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

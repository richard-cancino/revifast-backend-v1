using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Revifast.Areas.Identity.IdentityHostingStartup))]
namespace Revifast.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
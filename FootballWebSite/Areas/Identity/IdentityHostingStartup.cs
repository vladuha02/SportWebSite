using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SportWebSite.Areas.Identity.IdentityHostingStartup))]
namespace SportWebSite.Areas.Identity
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
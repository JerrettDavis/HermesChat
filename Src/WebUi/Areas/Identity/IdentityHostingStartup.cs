using Microsoft.AspNetCore.Hosting;
using WebUi.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace WebUi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((_, _) => { });
        }
    }
}
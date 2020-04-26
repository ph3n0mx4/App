using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CarSalesApp.Web.Areas.Identity.IdentityHostingStartup))]
namespace CarSalesApp.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
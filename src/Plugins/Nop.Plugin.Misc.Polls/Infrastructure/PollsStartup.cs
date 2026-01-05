using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Nop.Plugin.Misc.Polls.Services;

namespace Nop.Plugin.Misc.Polls.Infrastructure
{
    public class PollsStartup : IStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPollService, PollService>();
        }

        public void Configure(IApplicationBuilder application)
        {
            
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        public int Order => 1000;
    }
}

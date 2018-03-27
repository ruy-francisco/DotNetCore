using DoubleRound.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DoubleRound
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DoubleRoundApiContext>(opt => opt.UseInMemoryDatabase("DoubleRounds"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseMvc();
        }
    }
}
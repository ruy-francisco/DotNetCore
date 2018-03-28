using DoubleRound.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DoubleRound
{
    public class Startup
    {
        private static string _connectionString = @"Server=localhost;Database=DoubleRound;Trusted_Connection=True;";

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DoubleRoundApiContext>(opt => opt.UseSqlServer(_connectionString));
            //services.AddDbContext<DoubleRoundApiContext>(opt => opt.UseInMemoryDatabase("DoubleRounds"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseMvc();
        }
    }
}
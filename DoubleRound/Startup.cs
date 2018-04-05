using DoubleRound.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace DoubleRound
{
    public class Startup
    {
        private static string _connectionString = @"Server=wabhzpc217\sqlexpress;Database=DoubleRound;Trusted_Connection=True;";

        public void ConfigureServices(IServiceCollection services) {
            services.AddCors();
            services.AddDbContext<DoubleRoundApiContext>(opt => opt.UseSqlServer(_connectionString));
            //services.AddDbContext<DoubleRoundApiContext>(opt => opt.UseInMemoryDatabase("DoubleRounds"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseCors(
                options => options.AllowAnyOrigin()
            );

            app.UseMvc();
        }
    }
}
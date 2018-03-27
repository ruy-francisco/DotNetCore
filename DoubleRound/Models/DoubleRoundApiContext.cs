using Microsoft.EntityFrameworkCore;
using DoubleRound.Models.Contracts;

namespace DoubleRound.Models
{
    public class DoubleRoundApiContext: DbContext
    {
        public DoubleRoundApiContext(DbContextOptions<DoubleRoundApiContext> options)
            :base(options){}

        public DbSet<DoubleRound> DoubleRounds { get; set; }
        public DbSet<IProvider> Providers { get; set; }
    }
}
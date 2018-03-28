using Microsoft.EntityFrameworkCore;

namespace DoubleRound.Models
{
    public class DoubleRoundApiContext: DbContext
    {
        public DoubleRoundApiContext(DbContextOptions<DoubleRoundApiContext> options)
            :base(options){}

        public DbSet<DoubleRound> DoubleRounds { get; set; }
    }
}
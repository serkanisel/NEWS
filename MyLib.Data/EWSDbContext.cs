using Microsoft.EntityFrameworkCore;

namespace WordStudy.Data
{
    public class EWSDbContext : DbContext
    {
        public EWSDbContext(DbContextOptions<EWSDbContext> options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Usr> Users { get; set; }
        public DbSet<WrdList> WrdLists { get; set; }
        public DbSet<WordOfList> WordOfLists { get; set; }

    }
}

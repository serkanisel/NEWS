using Microsoft.EntityFrameworkCore;
using WordStudy.Data.Model;
using System;

namespace WordStudy.Data
{
    public class EWSDbContext : DbContext
    {
        public EWSDbContext(DbContextOptions<EWSDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Word> Word { get; set; }
        public DbSet<Usr> User { get; set; }
        public DbSet<WrdList> WrdList { get; set; }
        public DbSet<WordOfList> WordOfList { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public DbSet<Sentence> Sentences { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using WordStudy.Data.Model;
using System;

namespace WordStudy.Data
{
    public class EWSDbContext : DbContext
    {
        public EWSDbContext(DbContextOptions<EWSDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().HasData(
                 new Word()
                 {
                     AddType = 1,
                     Body = "Calf",
                     Mean = "Dana",
                     CreatedDate = DateTime.Now,
                     IsDeleted = false,
                     Id=1
                 },
                 new Word()
                 {
                     AddType = 1,
                     Body = "Cat",
                     Mean = "Kedi",
                     CreatedDate = DateTime.Now,
                     IsDeleted = false,
                     Id=2
                 });
        }

        public DbSet<Word> Word { get; set; }
        public DbSet<Usr> User { get; set; }
        public DbSet<WrdList> WrdList { get; set; }
        public DbSet<WordOfList> WordOfList { get; set; }

    }
}

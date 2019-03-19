using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data.Model;

namespace WordStudy.Data
{
    public static class EWSDbContextExtension
    {
        public static void EnsureSeedDataForContext(this EWSDbContext context)
        {
            if (context.Word.Any())
            {
                return;
            }

            #region Sozluk Seed
            List<Word> words = new List<Word>()
            {
                new Word()
            {
                AddType = 1,
                Body = "Calf",
                Mean = "Dana",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
                 new Word()
            {
                AddType = 1,
                Body = "Cat",
                Mean = "Kedi",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
        };



            context.Word.AddRange(words);

            #endregion

            context.SaveChanges();
        }
    }
}

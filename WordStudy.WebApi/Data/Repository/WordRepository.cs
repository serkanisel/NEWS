using System;
using System.Collections.Generic;
using System.Text;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Repository
{
    public class WordRepository : Repository<Word>,IWordRepository
    {
        public WordRepository(EWSDbContext context) : base(context)
        {

        }
    }
}

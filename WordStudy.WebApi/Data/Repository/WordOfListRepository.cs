using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Repository
{
    public class WordOfListRepository : Repository<WordOfList> , IWordOfListRepository
    {
        public WordOfListRepository(EWSDbContext context) : base(context)
        {

        }

        public IEnumerable<WordOfList> GetAllWithWordAndList()
        {
            return _context.WordOfList.Include(p => p.WrdList).Include(p => p.Word);
        }

        public WordOfList GetWithWordAndList(int id)
        {
            return _context.WordOfList.Where(p => p.Id == id).Include(p => p.Word).Include(p => p.WrdList).FirstOrDefault();
        }
    }
}

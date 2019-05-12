using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data.Model;
using WordStudy.WebApi.Interfaces;

namespace WordStudy.WebApi.Interfaces
{
    public interface IListsRepository : IRepository<WrdList>
    {
        Task<IEnumerable<WrdList>> GetAllListsWithWordsAsync ();

        Task<IEnumerable<WrdList>> GetAllWrdListsWithWordCount();

        Task<IEnumerable<WrdList>> GetWrdListsWithWordsByID(int ID);

        Task<WrdList> AddWrdList(WrdList wrdList);
    }
}

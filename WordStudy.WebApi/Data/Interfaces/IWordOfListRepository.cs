using System;
using System.Collections.Generic;
using System.Text;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Interfaces
{
    public interface IWordOfListRepository : IRepository<WordOfList>
    {
        IEnumerable<WordOfList> GetAllWithWordAndList();

        WordOfList GetWithWordAndList(int id);

    }
}

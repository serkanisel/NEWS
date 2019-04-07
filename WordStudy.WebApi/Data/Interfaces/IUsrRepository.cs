using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Interfaces
{
    public interface IUsrRepository : IRepository<Usr>
    {
        Task<IEnumerable<Usr>> GetAllUsersWithPhotos();

        Task<Usr> GetUserWithPhotos(int id);
    }


}

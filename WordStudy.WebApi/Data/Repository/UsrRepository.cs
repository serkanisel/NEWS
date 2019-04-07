using System;
using System.Collections.Generic;
using System.Text;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data;
using WordStudy.Data.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WordStudy.WebApi.Repository
{
    public class UsrRepository : Repository<Usr>,IUsrRepository
    {
        public UsrRepository(EWSDbContext context) : base(context)
        {
           
        }
        public async Task<Usr> GetUserWithPhotos(int id)
        {
            return await _context.User.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Usr>> GetAllUsersWithPhotos()
        {
            return await _context.User.Include(p => p.Photos).ToListAsync();
        }
    }
}
 
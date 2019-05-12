using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data;
using WordStudy.Data.Model;
using WordStudy.WebApi.Interfaces;

namespace WordStudy.WebApi.Repository
{
    public class ListsRepository : Repository<WrdList> , IListsRepository
    {
        public ListsRepository(EWSDbContext context) : base(context)
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

        public async Task<IEnumerable<WrdList>> GetAllListsWithWordsAsync()
        {
            return  await _context.WrdList.Include(p => p.WordOfLists).ToListAsync();
        }

        public async Task<IEnumerable<WrdList>> GetAllWrdListsWithWordCount()
        {
            throw new NotImplementedException();
        }

        public async Task<WrdList> GetWrdListsWithWordsByID(int ID)
        {
            return await _context.WrdList.Include(p => p.WordOfLists).FirstOrDefaultAsync(p => p.Id==ID);
        }

        public async Task<WrdList> AddWrdList(WrdList wrdList)
        {
            try
            {
                WrdList w = new WrdList()
                {
                    ListName = wrdList.ListName
                };
                await _context.AddAsync(w);
                await _context.SaveChangesAsync();

                return w;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Task<IEnumerable<WrdList>> IListsRepository.GetWrdListsWithWordsByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}

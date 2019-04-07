using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data;
using WordStudy.Data.Model;
using WordStudy.WebApi.Helpers;

namespace WordStudy.WebApi.Data
{
    public class Seed
    {
        private readonly EWSDbContext _context;

        public Seed(EWSDbContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            if (_context.User.Any())
                return;

            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");

            List<Usr> users = JsonConvert.DeserializeObject<List<Usr>>(userData);

            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;

                GlobalHelper.CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Name = user.UserName;
                user.SurName = user.UserName;
                user.UserName = user.UserName.ToLower();

                Photo pho = new Photo();
                pho.DateAdded = DateTime.Now;

                _context.User.Add(user);

            }

            _context.SaveChanges();
        }


    }
}

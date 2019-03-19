using System;
using System.Collections.Generic;
using System.Text;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Repository
{
    public class UsrRepository : Repository<Usr>,IUsrRepository
    {
        public UsrRepository(EWSDbContext context) : base(context)
        {

        }
    }
}

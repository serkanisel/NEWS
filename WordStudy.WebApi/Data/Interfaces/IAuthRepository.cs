using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Interfaces
{
    public interface IAuthRepository 
    {
        Task<Usr> Register(Usr user, string password);
        Task<Usr> Login(string username,string password);
        Task<bool> UserExists(string username);
    }
}

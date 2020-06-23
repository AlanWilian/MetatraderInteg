using MetatraderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Repository
{
    interface IAuthRepository
    {
        Task<User> Login(string username);
    }
}

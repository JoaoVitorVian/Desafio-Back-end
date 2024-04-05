using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> CheckLogin(string email, string password);
        Task<List<User>>SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
    }
}

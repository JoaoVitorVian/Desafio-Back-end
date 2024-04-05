using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Delete(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> GetAll();
        Task<List<UserDTO>> SearchByName(string name);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail (string email);
        Task<UserDTO> CheckLogin(string email, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Models.DTO.Users;

namespace UsersMS.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> All();

        Task<UserDTO> Create(UserCreateDTO newUserDTO);

        Task<UserDTO> ByID(int userID);
        Task<UserDTO> Update(UserUpdateDTO userUpdateDTO);
        Task<bool> DeleteByID(int userId);
        Task<bool> PasswordUpdate(UserPasswordChangeDTO passwordChangeDTO);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Mapper;
using UsersMS.Models.Entities;
using UsersMS.Models.DTO.Users;
using AutoMapper;
using UsersMS.DAL;
using UsersMS.MessageBus;

namespace UsersMS.Services
{
    public class UserService:IUserService
    {
        private IMapper _mapper;
        private IPasswordService _passwordService;
        private IDAL _iDAL;
        public UserService(IPasswordService passwordService, IDAL iDAL)
        {
            _iDAL = iDAL;
            _mapper= AutoMapperConfig.Configure().CreateMapper();
            _passwordService = passwordService;
        }
        
        public  async Task<List<UserDTO>> All()
        {
            List<User> allUsers =await _iDAL.All();
            return _mapper.Map<List<UserDTO>>(allUsers);

        }
        
        public  async Task<UserDTO> Create(UserCreateDTO newUserDTO)
        {
            User userToAdd = _mapper.Map<User>(newUserDTO);
            userToAdd.RegisterdAt = DateTime.Now;
            userToAdd.PasswordHash = _passwordService.CreateSHA256Hash(newUserDTO.Password);         
            User addedUser =await _iDAL.Add(userToAdd);
            UserDTO addedUserDTO = _mapper.Map<UserDTO>(addedUser);
         //   LogsService.AddLog(DateTime.Now, addedUser);
            return addedUserDTO;
        }
        public  async Task<UserDTO> ByID(int userID)
        {
            User userByID =await _iDAL.ByID(userID);
            if (userByID != null)
            {
                return _mapper.Map<UserDTO>(userByID);
            }
            else
            {
                return new UserDTO();
            }
        }
        public  async Task<UserDTO> Update(UserUpdateDTO userUpdateDTO)
        {
            User userToUpdate = _mapper.Map<User>(userUpdateDTO);    
            User userToTakeOldHash=await _iDAL.ByID(userUpdateDTO.UserID);
            string existingPasswordHash = userToTakeOldHash.PasswordHash;
            userToUpdate.PasswordHash = existingPasswordHash;
            User updatedUser = await _iDAL.Edit(userToUpdate);
            UserDTO updatedUserDTO = _mapper.Map<UserDTO>(updatedUser);
          //  LogsService.AddLog(DateTime.Now, updatedUser);
            return updatedUserDTO;
            
           
        }
        public async Task<bool> DeleteByID(int userId)
        {
            bool isUserDeleted = await _iDAL.DeleteById(userId);
            if (isUserDeleted)
            {
                Producer.UserDeleted(userId);
            }
            //  LogsService.AddLog(DateTime.Now,await _DAL.Users.ByID(userId));
            //  return await _DAL.Users.DeleteById(userId);
            return isUserDeleted;
        }
        public  async Task<bool> PasswordUpdate(UserPasswordChangeDTO passwordChangeDTO)
        {
           
            User userToUpdatePassword =await _iDAL.ByID(passwordChangeDTO.UserID);
            userToUpdatePassword.PasswordHash = _passwordService.CreateSHA256Hash(passwordChangeDTO.NewPassword);
            User updatedUser =await _iDAL.Edit(userToUpdatePassword);
          //  LogsService.AddLog(DateTime.Now, updatedUser);
            return updatedUser.PasswordHash == userToUpdatePassword.PasswordHash;
        }
    }
}

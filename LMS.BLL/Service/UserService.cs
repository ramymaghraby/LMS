using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Service
{
    public class UserService : IUserService
    {
        UserRepository _userRepo = new UserRepository();
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepo.GetAll(u => u.IsActive);
            var usersDTO = new List<UserDTO>();
            if (users == null)
                return usersDTO;
            foreach (var user in users)
            {
                var userDTO = new UserDTO()
                {
                    IsActive = user.IsActive,
                    CreatedOn = user.CreatedOn,
                    Email = user.Email,
                    Id = user.Id,
                    Password = user.Password,
                    Username = user.Username
                };
                usersDTO.Add(userDTO);
            }
            ;
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _userRepo.GetBy(u => u.Id == userId);
            
                var userDTO = new UserDTO()
                {
                    IsActive = user.IsActive,
                    CreatedOn = user.CreatedOn,
                    Email = user.Email,
                    Id = user.Id,
                    Password = user.Password,
                    Username = user.Username
                };
            
            
            
            return userDTO;
        }
        public async Task CreateUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Id = userDTO.Id,
                IsActive = userDTO.IsActive,
                CreatedOn = userDTO.CreatedOn,
                Email = userDTO.Email,
                Username= userDTO.Username,
                Password = userDTO.Password
                
            };
            await _userRepo.CreateAsync(user);
        }
        public async Task UpdateUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Id = userDTO.Id,
                IsActive = userDTO.IsActive,
                CreatedOn = userDTO.CreatedOn,
                Email = userDTO.Email,
                Username = userDTO.Username,
                Password = userDTO.Password

            };
            await _userRepo.UpdateAsync(user);
        }
        public async Task DeleteUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Id = userDTO.Id,
                IsActive = userDTO.IsActive,
                CreatedOn = userDTO.CreatedOn,
                Email = userDTO.Email,
                Username = userDTO.Username,
                Password = userDTO.Password

            };
            await _userRepo.DeleteAsync(user);
        }

        public async Task<bool> DeReActivateUser(int userId)
        {
            await _userRepo.DeReActivateUser(userId);
            return true;
        }

        
    }
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int userId);
        Task<bool> DeReActivateUser(int userId);
        Task CreateUser(UserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(UserDTO userDTO);
    }
}

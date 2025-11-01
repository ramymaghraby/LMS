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
    public class RoleService : IRoleService
    {
        GenericRepository<Role> _roleRepo = new GenericRepository<Role>();

        public async Task<List<RoleDTO>> GetAllRoles()
        {
            var roles = await _roleRepo.GetAll(r => r.IsActive);
            var rolesDTO = new List<RoleDTO>();
            if (roles == null) 
                return rolesDTO;
            foreach (var role in roles) {
                var roleDTO = new RoleDTO()
                {
                    Name = role.Name,
                    Id = role.Id,
                    IsActive = role.IsActive,
                    CreatedOn = role.CreatedOn,
                    Description = role.Description
                    
                };
                rolesDTO.Add(roleDTO);
            };
            return rolesDTO;
        }

        public async Task<RoleDTO> GetRoleById(int roleId)
        {
            var role = await _roleRepo.GetBy(c => c.Id == roleId);
            var roleDTO = new RoleDTO()
            {
                Name = role.Name,
                Id = role.Id,
                IsActive = role.IsActive,
                CreatedOn = role.CreatedOn,
                Description = role.Description
                

            };
            return roleDTO;

        }
        public async Task CreateRole(RoleDTO roleDTO)
        {
            var role = new Role() 
            {
                Name = roleDTO.Name,
                Id = roleDTO.Id,
                IsActive = roleDTO.IsActive,
                CreatedOn = roleDTO.CreatedOn,
                Description = roleDTO.Description
            };
            await _roleRepo.CreateAsync(role);
        }
        public async Task UpdateRole(RoleDTO roleDTO)
        {
            var role = new Role()
            {
                Name = roleDTO.Name,
                Id = roleDTO.Id,
                IsActive = roleDTO.IsActive,
                CreatedOn = roleDTO.CreatedOn,
                Description = roleDTO.Description
            };
            await _roleRepo.UpdateAsync(role);
        }
        public async Task DeleteRole(RoleDTO roleDTO)
        {
            var role = new Role()
            {
                Name = roleDTO.Name,
                Id = roleDTO.Id,
                IsActive = roleDTO.IsActive,
                CreatedOn = roleDTO.CreatedOn,
                Description = roleDTO.Description,
            };
            await _roleRepo.DeleteAsync(role);

        }
    }
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetAllRoles();
        Task<RoleDTO> GetRoleById(int RoleId);
        Task CreateRole(RoleDTO roleDTO);
        Task UpdateRole(RoleDTO roleDTO);
        Task DeleteRole(RoleDTO roleDTO);
    }
}

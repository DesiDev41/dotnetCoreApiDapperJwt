using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.DataAccess.userRole;
using ApiProject.Domain;

namespace ApiProject.Services.userRole
{
    public class UserRoleServices : IUserRoleServices
    {
        public readonly IUserRoleRepository _userRoleRepository;

        public UserRoleServices(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public void AddUserRole(UserRole userRole)
        {
            _userRoleRepository.AddUserRole(userRole);
        }

        public void DeleteUserRole(int Id)
        {
            _userRoleRepository.DeleteUserRole(Id);
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoleAsync()
        {
            return await _userRoleRepository.GetAllUserRoleAsync();
        }

        public async Task<UserRole> GetUserRoleByIdAsync(int Id)
        {
            return await _userRoleRepository.GetUserRoleByIdAsync(Id);
        }

        public void UpdateUserRole(UserRole userRole)
        {
            _userRoleRepository.UpdateUserRole(userRole);
        }
    }
}
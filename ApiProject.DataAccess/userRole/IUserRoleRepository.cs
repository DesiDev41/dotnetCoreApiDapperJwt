using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.Domain;

namespace ApiProject.DataAccess.userRole
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllUserRoleAsync();

        Task<UserRole> GetUserRoleByIdAsync(int Id);

        void AddUserRole(UserRole userRole);
        void UpdateUserRole(UserRole userRole);
        void DeleteUserRole(int Id);
    }
}
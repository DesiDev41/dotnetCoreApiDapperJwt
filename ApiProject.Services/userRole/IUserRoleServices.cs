using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.Domain;

namespace ApiProject.Services.userRole
{
    public interface IUserRoleServices
    {
        Task<IEnumerable<UserRole>> GetAllUserRoleAsync();

        Task<UserRole> GetUserRoleByIdAsync(int Id);

        void AddUserRole(UserRole userRole);
        void UpdateUserRole(UserRole userRole);
        void DeleteUserRole(int Id);

    }
}
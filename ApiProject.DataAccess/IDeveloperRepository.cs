using ApiProject.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProject.DataAccess
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllDeveloperAsync();

        Task<Developer> GetDeveloperByIdAsync(int Id);
        Task<Developer> GetDeveloperByEmailAsync(string Email);


        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int Id);

    }
}
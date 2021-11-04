using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.Domain;

namespace ApiProject.Services
{
    public interface IDeveloperServices
    {
        Task<IEnumerable<Developer>> GetAllDeveloperAsync();

        Task<Developer> GetDeveloperByIdAsync(int Id);
        Task<Developer> GetDeveloperByEmailAsync(string Email);


        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int Id);

    }
}
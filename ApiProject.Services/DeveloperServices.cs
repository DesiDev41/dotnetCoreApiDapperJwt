using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.DataAccess;
using ApiProject.Domain;

namespace ApiProject.Services
{
    public class DeveloperServices : IDeveloperServices
    {

        public readonly IDeveloperRepository _developerRepository;

        public DeveloperServices(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public void AddDeveloper(Developer developer)
        {
            _developerRepository.AddDeveloper(developer);
        }

        public void DeleteDeveloper(int Id)
        {
            _developerRepository.DeleteDeveloper(Id);
        }

        public async Task<IEnumerable<Developer>> GetAllDeveloperAsync()
        {
            return await _developerRepository.GetAllDeveloperAsync();
        }

        public async Task<Developer> GetDeveloperByEmailAsync(string Email)
        {
            return await _developerRepository.GetDeveloperByEmailAsync(Email);
        }

        public async Task<Developer> GetDeveloperByIdAsync(int Id)
        {
            return await _developerRepository.GetDeveloperByIdAsync(Id);

        }

        public void UpdateDeveloper(Developer developer)
        {
            _developerRepository.UpdateDeveloper(developer);
        }
    }
}
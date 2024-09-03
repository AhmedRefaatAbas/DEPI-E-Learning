using DEPI_E_Learning.Models;
using System.Reflection;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<ModuleModel> GetByIdAsync(int moduleId);
        Task<IEnumerable<ModuleModel>> GetBySessionIdAsync(int sessionId);
        Task<IEnumerable<ModuleModel>> GetAllAsync();
        Task AddAsync(ModuleModel module);
        Task UpdateAsync(ModuleModel module);
        Task DeleteAsync(int moduleId);
    }

}

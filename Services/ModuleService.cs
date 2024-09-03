using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class ModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ModuleModel?> GetModuleByIdAsync(int moduleId)
        {
            return await _unitOfWork.Modules.GetByIdAsync(moduleId);
        }

        public async Task<IEnumerable<ModuleModel>> GetModulesBySessionIdAsync(int sessionId)
        {
            return await _unitOfWork.Modules.GetBySessionIdAsync(sessionId);
        }

        public async Task<IEnumerable<ModuleModel>> GetAllModulesAsync()
        {
            return await _unitOfWork.Modules.GetAllAsync();
        }

        public async Task AddModuleAsync(ModuleModel module)
        {
            await _unitOfWork.Modules.AddAsync(module);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateModuleAsync(ModuleModel module)
        {
            _unitOfWork.Modules.UpdateAsync(module);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteModuleAsync(int moduleId)
        {
            await _unitOfWork.Modules.DeleteAsync(moduleId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

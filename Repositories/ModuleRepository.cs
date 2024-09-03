using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace DEPI_E_Learning.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ModuleModel?> GetByIdAsync(int moduleId)
        {
            return await _context.Modules.FirstOrDefaultAsync(m => m.ModuleId == moduleId);
        }

        public async Task<IEnumerable<ModuleModel>> GetBySessionIdAsync(int sessionId)
        {
            return await _context.Modules.Where(m => m.SessionId == sessionId).ToListAsync();
        }
        // Implementing GetAllAsync method
        public async Task<IEnumerable<ModuleModel>> GetAllAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task AddAsync(ModuleModel module)
        {
            await _context.Modules.AddAsync(module);
        }

        public async Task UpdateAsync(ModuleModel module)
        {
            _context.Modules.Update(module);
        }

        public async Task DeleteAsync(int moduleId)
        {
            var module = await GetByIdAsync(moduleId);
            if (module != null)
            {
                _context.Modules.Remove(module);
            }
        }
    }

}

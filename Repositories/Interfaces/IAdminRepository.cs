using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<AdminModel?> GetByIdAsync(int adminId);
        Task<AdminModel?> GetByEmailAsync(string email);
        Task<IEnumerable<AdminModel>> GetAllAsync();
        Task AddAsync(AdminModel admin);
        Task UpdateAsync(AdminModel admin);
        Task DeleteAsync(int adminId);
    }
}

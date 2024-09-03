using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<InstructorModel?> GetByIdAsync(int instructorId);
        Task<InstructorModel?> GetByEmailAsync(string email);
        Task<IEnumerable<InstructorModel>> GetAllAsync();
        Task AddAsync(InstructorModel instructor);
        Task UpdateAsync(InstructorModel instructor);
        Task DeleteAsync(int instructorId);
    }
}

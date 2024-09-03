using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentModel?> GetByIdAsync(int studentId);
        Task<StudentModel?> GetByEmailAsync(string email);
        Task<IEnumerable<StudentModel>> GetAllAsync();
        Task AddAsync(StudentModel student);
        Task UpdateAsync(StudentModel student);
        Task DeleteAsync(int studentId);
    }
}

using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<CourseModel> GetByIdAsync(int courseId);
        Task<IEnumerable<CourseModel>> GetAllAsync();
        Task AddAsync(CourseModel course);
        Task UpdateAsync(CourseModel course);
        Task DeleteAsync(int courseId);
    }
}

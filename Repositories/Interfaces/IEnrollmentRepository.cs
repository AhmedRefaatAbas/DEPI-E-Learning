using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<EnrollmentModel> GetByIdAsync(int enrollmentId);
        Task<IEnumerable<EnrollmentModel>> GetByUserIdAsync(int userId);
        Task<IEnumerable<EnrollmentModel>> GetAllEnrollmentsAsync();
        Task<IEnumerable<EnrollmentModel>> GetByCourseIdAsync(int courseId);
        Task AddAsync(EnrollmentModel enrollment);
        Task DeleteAsync(int enrollmentId);
        Task UpdateEnrollmentAsync(EnrollmentModel enrollment);
    }

}

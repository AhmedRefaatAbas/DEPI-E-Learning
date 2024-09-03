using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class EnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EnrollmentModel?> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return await _unitOfWork.Enrollments.GetByIdAsync(enrollmentId);
        }

        public async Task<IEnumerable<EnrollmentModel>> GetEnrollmentsByUserIdAsync(int userId)
        {
            return await _unitOfWork.Enrollments.GetByUserIdAsync(userId);
        }
        public async Task<IEnumerable<EnrollmentModel>> GetAllEnrollmentsAsync()
        {
            return await _unitOfWork.Enrollments.GetAllEnrollmentsAsync();
        }

        public async Task<IEnumerable<EnrollmentModel>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            return await _unitOfWork.Enrollments.GetByCourseIdAsync(courseId);
        }

        public async Task AddEnrollmentAsync(EnrollmentModel enrollment)
        {
            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteEnrollmentAsync(int enrollmentId)
        {
            await _unitOfWork.Enrollments.DeleteAsync(enrollmentId);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateEnrollmentAsync(EnrollmentModel enrollment)
        {
            await _unitOfWork.Enrollments.UpdateEnrollmentAsync(enrollment); // Update the enrollment in the repository
            await _unitOfWork.CompleteAsync(); // Commit changes
        }
    }
}

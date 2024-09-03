using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 
namespace DEPI_E_Learning.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EnrollmentModel?> GetByIdAsync(int enrollmentId)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId);
        }

        public async Task<IEnumerable<EnrollmentModel>> GetByUserIdAsync(int userId)
        {
            return await _context.Enrollments.Where(e => e.StudentId == userId).ToListAsync();
        }
        public async Task<IEnumerable<EnrollmentModel>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<IEnumerable<EnrollmentModel>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments.Where(e => e.CourseId == courseId).ToListAsync();
        }

        public async Task AddAsync(EnrollmentModel enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
        }

        public async Task DeleteAsync(int enrollmentId)
        {
            var enrollment = await GetByIdAsync(enrollmentId);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }
        }
        public async Task UpdateEnrollmentAsync(EnrollmentModel enrollment)
        {
             _context.Enrollments.Update(enrollment);
           
        }
    }

}

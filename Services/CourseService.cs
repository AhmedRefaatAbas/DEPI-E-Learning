using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class CourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseModel?> GetCourseByIdAsync(int courseId)
        {
            return await _unitOfWork.Courses.GetByIdAsync(courseId);
        }

        public async Task<IEnumerable<CourseModel>> GetAllCoursesAsync()
        {
            return await _unitOfWork.Courses.GetAllAsync();
        }

        public async Task AddCourseAsync(CourseModel course)
        {
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCourseAsync(CourseModel course)
        {
            _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _unitOfWork.Courses.DeleteAsync(courseId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

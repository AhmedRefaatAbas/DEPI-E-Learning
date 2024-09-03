using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CourseModel?> GetByIdAsync(int courseId)
        {
            return await _context.Courses                          
                                 .FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task<IEnumerable<CourseModel>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task AddAsync(CourseModel course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task UpdateAsync(CourseModel course)
        {
            _context.Courses.Update(course);
        }

        public async Task DeleteAsync(int courseId)
        {
            var course = await GetByIdAsync(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
        }
    }
}

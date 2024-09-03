using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _context;

        public InstructorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InstructorModel?> GetByIdAsync(int instructorId)
        {
            return await _context.Instructors.FirstOrDefaultAsync(i => i.InstructorId == instructorId);
        }

        public async Task<InstructorModel?> GetByEmailAsync(string email)
        {
            return await _context.Instructors.FirstOrDefaultAsync(i => i.Email == email);
        }

        public async Task<IEnumerable<InstructorModel>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task AddAsync(InstructorModel instructor)
        {
            await _context.Instructors.AddAsync(instructor);
        }

        public async Task UpdateAsync(InstructorModel instructor)
        {
            _context.Instructors.Update(instructor);
        }

        public async Task DeleteAsync(int instructorId)
        {
            var instructor = await GetByIdAsync(instructorId);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
            }
        }
    }
}

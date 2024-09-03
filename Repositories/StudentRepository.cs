using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentModel?> GetByIdAsync(int studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<StudentModel?> GetByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(StudentModel student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateAsync(StudentModel student)
        {
            _context.Students.Update(student);
        }

        public async Task DeleteAsync(int studentId)
        {
            var student = await GetByIdAsync(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }
    }
}

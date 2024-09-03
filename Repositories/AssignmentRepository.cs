using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace DEPI_E_Learning.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentModel?> GetByIdAsync(int assignmentId)
        {
            return await _context.Assignments.FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
        }

        public async Task<IEnumerable<AssignmentModel>> GetByModuleIdAsync(int moduleId)
        {
            return await _context.Assignments.Where(a => a.ModuleId == moduleId).ToListAsync();
        }
        // Implementing GetAllAsync method
        public async Task<IEnumerable<AssignmentModel>> GetAllAsync()
        {
            return await _context.Assignments.ToListAsync();
        }
        public async Task AddAsync(AssignmentModel assignment)
        {
            await _context.Assignments.AddAsync(assignment);
        }

        public async Task UpdateAsync(AssignmentModel assignment)
        {
            _context.Assignments.Update(assignment);
        }

        public async Task DeleteAsync(int assignmentId)
        {
            var assignment = await GetByIdAsync(assignmentId);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
            }
        }
    }

}

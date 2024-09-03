using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace DEPI_E_Learning.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SessionModel?> GetByIdAsync(int sessionId)
        {
            return await _context.Sessions
                                 .Include(s => s.Modules)
                                 .FirstOrDefaultAsync(s => s.SessionId == sessionId);
        }

        public async Task<IEnumerable<SessionModel>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Sessions.Where(s => s.CourseId == courseId).ToListAsync();
        }

        public async Task AddAsync(SessionModel session)
        {
            await _context.Sessions.AddAsync(session);
        }

        public async Task UpdateAsync(SessionModel session)
        {
            _context.Sessions.Update(session);
        }

        public async Task DeleteAsync(int sessionId)
        {
            var session = await GetByIdAsync(sessionId);
            if (session != null)
            {
                _context.Sessions.Remove(session);
            }
        }
    }

}

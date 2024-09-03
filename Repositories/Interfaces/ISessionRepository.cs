using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<SessionModel> GetByIdAsync(int sessionId);
        Task<IEnumerable<SessionModel>> GetByCourseIdAsync(int courseId);
        Task AddAsync(SessionModel session);
        Task UpdateAsync(SessionModel session);
        Task DeleteAsync(int sessionId);
    }

}

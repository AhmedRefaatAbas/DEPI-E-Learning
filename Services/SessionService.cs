using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class SessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SessionModel?> GetSessionByIdAsync(int sessionId)
        {
            return await _unitOfWork.Sessions.GetByIdAsync(sessionId);
        }

        public async Task<IEnumerable<SessionModel>> GetSessionsByCourseIdAsync(int courseId)
        {
            return await _unitOfWork.Sessions.GetByCourseIdAsync(courseId);
        }

        public async Task AddSessionAsync(SessionModel session)
        {
            await _unitOfWork.Sessions.AddAsync(session);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateSessionAsync(SessionModel session)
        {
            _unitOfWork.Sessions.UpdateAsync(session);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteSessionAsync(int sessionId)
        {
            await _unitOfWork.Sessions.DeleteAsync(sessionId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

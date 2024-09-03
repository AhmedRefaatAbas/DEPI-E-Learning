using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminModel?> GetUserByIdAsync(int userId)
        {
            return await _unitOfWork.Admins.GetByIdAsync(userId);
        }

        public async Task<AdminModel?> GetUserByEmailAsync(string email)
        {
            return await _unitOfWork.Admins.GetByEmailAsync(email);
        }

        public async Task AddUserAsync(AdminModel user)
        {
            await _unitOfWork.Admins.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUserAsync(AdminModel user)
        {
            _unitOfWork.Admins.UpdateAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _unitOfWork.Admins.DeleteAsync(userId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class InstructorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstructorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InstructorModel?> GetInstructorByIdAsync(int instructorId)
        {
            return await _unitOfWork.Instructors.GetByIdAsync(instructorId);
        }

        public async Task<InstructorModel?> GetInstructorByEmailAsync(string email)
        {
            return await _unitOfWork.Instructors.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<InstructorModel>> GetAllInstructorsAsync()
        {
            return await _unitOfWork.Instructors.GetAllAsync();
        }

        public async Task AddInstructorAsync(InstructorModel instructor)
        {
            await _unitOfWork.Instructors.AddAsync(instructor);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateInstructorAsync(InstructorModel instructor)
        {
            _unitOfWork.Instructors.UpdateAsync(instructor);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteInstructorAsync(int instructorId)
        {
            await _unitOfWork.Instructors.DeleteAsync(instructorId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

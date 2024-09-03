using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class AssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssignmentModel?> GetAssignmentByIdAsync(int assignmentId)
        {
            return await _unitOfWork.Assignments.GetByIdAsync(assignmentId);
        }

        public async Task<IEnumerable<AssignmentModel>> GetAssignmentsByModuleIdAsync(int moduleId)
        {
            return await _unitOfWork.Assignments.GetByModuleIdAsync(moduleId);
        }

        public async Task<IEnumerable<AssignmentModel>> GetAllAssignmentsAsync()
        {
            return await _unitOfWork.Assignments.GetAllAsync();
        }

        public async Task AddAssignmentAsync(AssignmentModel assignment)
        {
            await _unitOfWork.Assignments.AddAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAssignmentAsync(AssignmentModel assignment)
        {
            _unitOfWork.Assignments.UpdateAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAssignmentAsync(int assignmentId)
        {
            await _unitOfWork.Assignments.DeleteAsync(assignmentId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<AssignmentModel> GetByIdAsync(int assignmentId);
        Task<IEnumerable<AssignmentModel>> GetByModuleIdAsync(int moduleId);
        Task<IEnumerable<AssignmentModel>> GetAllAsync();
        Task AddAsync(AssignmentModel assignment);
        Task UpdateAsync(AssignmentModel assignment);
        Task DeleteAsync(int assignmentId);
    }

}

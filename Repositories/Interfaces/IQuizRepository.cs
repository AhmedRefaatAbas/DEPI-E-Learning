using DEPI_E_Learning.Models;

namespace DEPI_E_Learning.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<QuizModel> GetByIdAsync(int quizId);
        Task<IEnumerable<QuizModel>> GetByModuleIdAsync(int moduleId);
        Task AddAsync(QuizModel quiz);
        Task UpdateAsync(QuizModel quiz);
        Task DeleteAsync(int quizId);
    }

}

using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Services
{
    public class QuizService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<QuizModel?> GetQuizByIdAsync(int quizId)
        {
            return await _unitOfWork.Quizzes.GetByIdAsync(quizId);
        }

        public async Task<IEnumerable<QuizModel>> GetQuizzesByModuleIdAsync(int moduleId)
        {
            return await _unitOfWork.Quizzes.GetByModuleIdAsync(moduleId);
        }

        public async Task AddQuizAsync(QuizModel quiz)
        {
            await _unitOfWork.Quizzes.AddAsync(quiz);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateQuizAsync(QuizModel quiz)
        {
            _unitOfWork.Quizzes.UpdateAsync(quiz);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteQuizAsync(int quizId)
        {
            await _unitOfWork.Quizzes.DeleteAsync(quizId);
            await _unitOfWork.CompleteAsync();
        }
    }
}

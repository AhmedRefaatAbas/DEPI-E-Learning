using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace DEPI_E_Learning.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QuizModel?> GetByIdAsync(int quizId)
        {
            return await _context.Quizzes
                                 .Include(q => q.Questions)
                                 .FirstOrDefaultAsync(q => q.QuizId == quizId);
        }

        public async Task<IEnumerable<QuizModel>> GetByModuleIdAsync(int moduleId)
        {
            return await _context.Quizzes.Where(q => q.ModuleId == moduleId).ToListAsync();
        }

        public async Task AddAsync(QuizModel quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
        }

        public async Task UpdateAsync(QuizModel quiz)
        {
            _context.Quizzes.Update(quiz);
        }

        public async Task DeleteAsync(int quizId)
        {
            var quiz = await GetByIdAsync(quizId);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
            }
        }
    }

}

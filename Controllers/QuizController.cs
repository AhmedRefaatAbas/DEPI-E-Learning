using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;

        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizModel>> GetQuiz(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpGet("module/{moduleId}")]
        public async Task<ActionResult<IEnumerable<QuizModel>>> GetQuizzesByModuleId(int moduleId)
        {
            var quizzes = await _quizService.GetQuizzesByModuleIdAsync(moduleId);
            return Ok(quizzes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(QuizModel quiz)
        {
            await _quizService.AddQuizAsync(quiz);
            return CreatedAtAction(nameof(GetQuiz), new { id = quiz.QuizId }, quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(int id, QuizModel quiz)
        {
            if (id != quiz.QuizId)
            {
                return BadRequest();
            }

            await _quizService.UpdateQuizAsync(quiz);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            await _quizService.DeleteQuizAsync(id);
            return NoContent();
        }
    }
}

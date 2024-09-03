using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionModel>> GetSession(int id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<SessionModel>>> GetSessionsByCourseId(int courseId)
        {
            var sessions = await _sessionService.GetSessionsByCourseIdAsync(courseId);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession(SessionModel session)
        {
            await _sessionService.AddSessionAsync(session);
            return CreatedAtAction(nameof(GetSession), new { id = session.SessionId }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, SessionModel session)
        {
            if (id != session.SessionId)
            {
                return BadRequest();
            }

            await _sessionService.UpdateSessionAsync(session);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            await _sessionService.DeleteSessionAsync(id);
            return NoContent();
        }
    }
}

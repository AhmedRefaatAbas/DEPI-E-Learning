using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _instructorService;

        public InstructorController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorModel>> GetInstructor(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<InstructorModel>> GetInstructorByEmail(string email)
        {
            var instructor = await _instructorService.GetInstructorByEmailAsync(email);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorModel>>> GetAllInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor(InstructorModel instructor)
        {
            await _instructorService.AddInstructorAsync(instructor);
            return CreatedAtAction(nameof(GetInstructor), new { id = instructor.InstructorId }, instructor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, InstructorModel instructor)
        {
            if (id != instructor.InstructorId)
            {
                return BadRequest();
            }

            await _instructorService.UpdateInstructorAsync(instructor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            await _instructorService.DeleteInstructorAsync(id);
            return NoContent();
        }
    }
}

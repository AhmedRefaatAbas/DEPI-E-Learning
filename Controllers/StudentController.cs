using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<StudentModel>> GetStudentByEmail(string email)
        {
            var student = await _studentService.GetStudentByEmailAsync(email);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentModel student)
        {
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentModel student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            await _studentService.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}

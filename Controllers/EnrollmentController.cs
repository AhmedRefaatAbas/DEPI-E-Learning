using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly EnrollmentService _enrollmentService;
        private readonly CourseService _courseService; // Assuming you need to fetch courses for enrollments
        private readonly StudentService _studentService; // Assuming you need to fetch students for enrollments

        public EnrollmentController(EnrollmentService enrollmentService, CourseService courseService, StudentService studentService)
        {
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _studentService = studentService;
        }

        // GET: Enrollment/Index
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return View(enrollments);
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseId", "CourseName");
            ViewBag.Students = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentId", "StudentName");
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId, CourseId, EnrolledOn, CompletionDate")] EnrollmentModel enrollment)
        {
            if (ModelState.IsValid)
            {
                await _enrollmentService.AddEnrollmentAsync(enrollment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Courses = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseId", "CourseName", enrollment.CourseId);
            ViewBag.Students = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentId", "StudentName", enrollment.StudentId);
            return View(enrollment);
        }
        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            ViewBag.Courses = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseId", "CourseName", enrollment.CourseId);
            ViewBag.Students = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentId", "StudentName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId, StudentId, CourseId, EnrolledOn, CompletionDate")] EnrollmentModel enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _enrollmentService.UpdateEnrollmentAsync(enrollment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Courses = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseId", "CourseName", enrollment.CourseId);
            ViewBag.Students = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentId", "StudentName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _enrollmentService.DeleteEnrollmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

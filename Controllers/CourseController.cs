using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly InstructorService _instructorService; // Assuming you need to fetch Instructors

        public CourseController(CourseService courseService, InstructorService instructorService)
        {
            _courseService = courseService;
            _instructorService = instructorService;
        }

        // GET: Course/Index
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public async Task<IActionResult> Create()
        {
            // Populate Instructors for dropdown
            ViewBag.Instructors = new SelectList(await _instructorService.GetAllInstructorsAsync(), "InstructorId", "Name");
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName, InstructorId")] CourseModel course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Instructors = new SelectList(await _instructorService.GetAllInstructorsAsync(), "InstructorId", "Name", course.InstructorId);
            return View(course);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Instructors = new SelectList(await _instructorService.GetAllInstructorsAsync(), "InstructorId", "Name", course.InstructorId);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId, CourseName, InstructorId")] CourseModel course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _courseService.UpdateCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Instructors = new SelectList(await _instructorService.GetAllInstructorsAsync(), "InstructorId", "Name", course.InstructorId);
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

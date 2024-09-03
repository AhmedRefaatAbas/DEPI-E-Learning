using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : Controller
    {
        private readonly AssignmentService _assignmentService;
        private readonly ModuleService _moduleService; // Assuming you need to fetch modules for assignments

        public AssignmentController(AssignmentService assignmentService, ModuleService moduleService)
        {
            _assignmentService = assignmentService;
            _moduleService = moduleService;
        }

        // GET: Assignment/Index
        public async Task<IActionResult> Index()
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();
            return View(assignments);
        }

        // GET: Assignment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // GET: Assignment/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Modules = new SelectList(await _moduleService.GetAllModulesAsync(), "ModuleId", "ModuleName");
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentName, ModuleId, Description, DueDate")] AssignmentModel assignment)
        {
            if (ModelState.IsValid)
            {
                await _assignmentService.AddAssignmentAsync(assignment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Modules = new SelectList(await _moduleService.GetAllModulesAsync(), "ModuleId", "ModuleName", assignment.ModuleId);
            return View(assignment);
        }

        // GET: Assignment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewBag.Modules = new SelectList(await _moduleService.GetAllModulesAsync(), "ModuleId", "ModuleName", assignment.ModuleId);
            return View(assignment);
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId, AssignmentName, ModuleId, Description, DueDate")] AssignmentModel assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _assignmentService.UpdateAssignmentAsync(assignment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Modules = new SelectList(await _moduleService.GetAllModulesAsync(), "ModuleId", "ModuleName", assignment.ModuleId);
            return View(assignment);
        }

        // GET: Assignment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

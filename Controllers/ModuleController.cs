using DEPI_E_Learning.Models;
using DEPI_E_Learning.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly ModuleService _moduleService;

        public ModuleController(ModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleModel>> GetModule(int id)
        {
            var module = await _moduleService.GetModuleByIdAsync(id);
            if (module == null)
            {
                return NotFound();
            }
            return Ok(module);
        }

        [HttpGet("session/{sessionId}")]
        public async Task<ActionResult<IEnumerable<ModuleModel>>> GetModulesBySessionId(int sessionId)
        {
            var modules = await _moduleService.GetModulesBySessionIdAsync(sessionId);
            return Ok(modules);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule(ModuleModel module)
        {
            await _moduleService.AddModuleAsync(module);
            return CreatedAtAction(nameof(GetModule), new { id = module.ModuleId }, module);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, ModuleModel module)
        {
            if (id != module.ModuleId)
            {
                return BadRequest();
            }

            await _moduleService.UpdateModuleAsync(module);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            await _moduleService.DeleteModuleAsync(id);
            return NoContent();
        }
    }
}

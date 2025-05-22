using JobApplicationTrackerApi.Models;
using JobApplicationTrackerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _service;

        public JobApplicationsController(IJobApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
        {
            var allApplications = await _service.GetAllAsync();
            return Ok(allApplications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetById(int id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null)
                return NotFound();

            return Ok(app);
        }

        [HttpPost]
        public async Task<ActionResult<JobApplication>> Create(JobApplication application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddAsync(application);
            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JobApplication application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.Id)
                return BadRequest();

            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.UpdateAsync(application);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

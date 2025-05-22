using JobApplicationTrackerApi.Models;
using JobApplicationTrackerApi.Repositories;
using JobApplicationTrackerApi.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<JobApplication>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<JobApplication> GetById(int id)
        {
            var app = _service.GetById(id);
            if (app == null)
                return NotFound();

            return Ok(app);
        }

        [HttpPost]
        public ActionResult<JobApplication> Create(JobApplication application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Add(application);
            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, JobApplication application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.Id)
                return BadRequest();

            var existing = _service.GetById(id);
            if (existing == null)
                return NotFound();

            _service.Update(application);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetById(id);
            if (existing == null)
                return NotFound();

            _service.Delete(id);
            return NoContent();
        }
    }
}

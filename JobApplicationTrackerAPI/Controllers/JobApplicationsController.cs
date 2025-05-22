using JobApplicationTrackerApi.Models;
using JobApplicationTrackerApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationsController(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobApplication>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<JobApplication> GetById(int id)
        {
            var app = _repository.GetById(id);
            if (app == null)
                return NotFound();

            return Ok(app);
        }

        [HttpPost]
        public ActionResult<JobApplication> Create(JobApplication application)
        {
            _repository.Add(application);
            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, JobApplication application)
        {
            if (id != application.Id)
                return BadRequest();

            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            _repository.Update(application);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            _repository.Delete(id);
            return NoContent();
        }
    }
}

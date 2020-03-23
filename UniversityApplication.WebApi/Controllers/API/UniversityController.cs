using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UniversityApplication.Data.DTOs;
using UniversityApplication.Service.Service;

namespace UniversityApplication.WebApi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly ILogger<UniversityController> _logger;
        private readonly IUniversityService _service;

        public UniversityController(ILogger<UniversityController> logger, IUniversityService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<StudentDTO> GetStudents()
        {
            return _service.GetStudents();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<StudentDTO> GetStudent(int id)
        {
            return await _service.GetStudent(id);
        }

        [HttpPost]
        [Route("NewStudent")]
        public IActionResult NewStudent([FromBody]StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                var response = _service.SaveStudent(student);
                return Created("Student successfully created", response);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("UpdateStudent/{id:int}")]
        public IActionResult UpdateStudent(int id, [FromBody]StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                var response = _service.PutStudent(id, student);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("RemoveStudent/{id:int}")]
        public IActionResult RemoveStudent(int id)
        {
            return Ok(_service.DeleteStudent(id));
        }

    }
}
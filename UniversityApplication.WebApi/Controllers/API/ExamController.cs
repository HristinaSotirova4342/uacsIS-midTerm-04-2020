using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UniversityApplication.Data.DTOs;
using UniversityApplication.Service.Service;

namespace UniversityApplication.WebApi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ILogger<ExamController> _logger;
        private readonly IExamsService _service;

        public ExamController(ILogger<ExamController> logger, IExamsService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Route("Get")]
        public IEnumerable<ExamsDTO> GetExams()
        {
            return _service.GetExams();
        }

        //[HttpGet]
        //[Route("Get/{studentId:int}")]
        //public AddressDTO Get([FromRoute]int studentId)
        //{
        //    return _service.GetAddress(studentId);
        //}


        [HttpPost]
        [Route("NewExams")]
        public IActionResult NewExams([FromBody]ExamsDTO exams)
        {
            if (ModelState.IsValid)
            {
                var response = _service.SaveExams(exams);
                return Created("Exam successfully created", response);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("UpdateExams/{id:int}")]
        public IActionResult UpdateExams(int id, [FromBody]ExamsDTO exams)
        {
            if (ModelState.IsValid)
            {
                var response = _service.PutExams(id, exams);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("RemoveExams/{id:int}")]
        public IActionResult RemoveExams(int id)
        {
            return Ok(_service.DeleteExams(id));
        }

    }

}

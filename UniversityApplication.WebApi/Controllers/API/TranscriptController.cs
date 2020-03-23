using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UniversityApplication.Data.DTOs;
using UniversityApplication.Service.Service;

namespace UniversityApplication.WebApi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : ControllerBase
    {
        private readonly ILogger<TranscriptController> _logger;
        private readonly ITranscriptService _service;

        public TranscriptController(ILogger<TranscriptController> logger, ITranscriptService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<TranscriptDTO> Get()
        {
            return _service.GetTranscripts();
        }

        [HttpGet]
        [Route("Get/{studentId:int}/{examId:int}")]
        public TranscriptDTO Get([FromRoute]int studentId, [FromRoute]int examId)
        {
            return _service.GetTranscript(studentId, examId);
        }
        
        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody]TranscriptDTO transcript)
        {
            if (ModelState.IsValid)
            {
                var result = _service.SaveTranscript(transcript);
                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Put/{id:int}")]
        public TranscriptDTO PutPoints([FromRoute]int id, [FromBody]TranscriptDTO transcriptObject)
        {
            return _service.PutPoints(id, transcriptObject);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteTranscript(id);
            if (deleted)
            {
                return Ok("Transcript successfully deleted");
            }

            return BadRequest("There isn't any transcript with that id");
        }
    }
}
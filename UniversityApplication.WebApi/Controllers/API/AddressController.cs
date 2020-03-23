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
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _service;

        public AddressController(ILogger<AddressController> logger, IAddressService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Route("Get")]
        public IEnumerable<AddressDTO> GetAddress()
        {
            return _service.GetAddress();
        }

        //[HttpGet]
        //[Route("Get/{studentId:int}")]
        //public AddressDTO Get([FromRoute]int studentId)
        //{
        //    return _service.GetAddress(studentId);
        //}


        [HttpPost]
        [Route("NewAddress")]
        public IActionResult NewAddress([FromBody]AddressDTO address)
        {
            if (ModelState.IsValid)
            {
                var response = _service.SaveAddress(address);
                return Created("Address successfully created", response);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("UpdateAddress/{id:int}")]
        public IActionResult UpdateAddress(int id, [FromBody]AddressDTO address)
        {
            if (ModelState.IsValid)
            {
                var response = _service.PutAddress(id, address);
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("RemoveAddress/{id:int}")]
        public IActionResult RemoveAddress(int id)
        {
            return Ok(_service.DeleteAddress(id));
        }

    }
}

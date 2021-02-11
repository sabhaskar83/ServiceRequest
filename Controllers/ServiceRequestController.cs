using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequest.Dtos;
using ServiceRequest.Models;
using ServiceRequest.Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequest _servicerequest;
        public ServiceRequestController(IServiceRequest servicerequest)
        {
            this._servicerequest = servicerequest;
        }
        // GET: api/<ServiceRequestController>
        [HttpGet]
        public ActionResult<List<ServiceRequestDto>> Get()
        {
            var response= _servicerequest.GetAllRecords();
            if (response.Count == 0)
                return NoContent();
            else
                return Ok(response);
        }

        // GET api/<ServiceRequestController>/5
        [HttpGet("{id}")]
        public ActionResult<ServiceRequestDto> Get(Guid id)
        {
            var record= _servicerequest.GetRecordById(id);
            if (record == null)
                return NotFound();
            else
                return Ok(record);
        }

        // POST api/<ServiceRequestController>
        [HttpPost]
        public ActionResult Post(ServiceRequestModel request)
        {
            if (request.id == null || request.id == Guid.Empty || request == null)
                return BadRequest();
            _servicerequest.CreateRecord(request);
              return  StatusCode(201);
        }

        // PUT api/<ServiceRequestController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ServiceRequestModel request)
        {
            if (request.id == null || request.id == Guid.Empty || request == null)
                return BadRequest();
           int result= _servicerequest.UpdateRecord( id, request);
            if (result == 0)
                return StatusCode(404);
            else
               return Ok();
        }

        // DELETE api/<ServiceRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

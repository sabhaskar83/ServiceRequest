﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequest.Dtos;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServiceRequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceRequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

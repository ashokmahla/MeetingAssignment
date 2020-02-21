using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Models.Meetings;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MeetingsController : ControllerBase
    {
        private IMeetingService _meetingService;
        
        private IMapper _mapper;
        
        public MeetingsController(
         IMeetingService meetingService,
         
         IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var meetings = _meetingService.GetAll();
            return Ok(meetings);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var meeting = _meetingService.GetById(id);
            return Ok(meeting);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var status = _meetingService.Delete(id);
            return Ok(status);
        }

        [HttpPost()]
        public IActionResult Update([FromBody]Meetings model)
        {
            // map model to entity and set id
            var meetings = _mapper.Map<Meetings>(model);
            int status = 0;
            try
            {
                if(model.Id == 0)
                {
                    // update user 
                    status = _meetingService.Add(meetings);
                }
                else
                {
                    // update user 
                    status = _meetingService.Update(meetings);
                }
               
                return Ok(status);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
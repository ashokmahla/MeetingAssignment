using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
            var model = _mapper.Map<IList<Meetings>>(meetings);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var meeting = _meetingService.GetById(id);
            var model = _mapper.Map<Meetings>(meeting);
            return Ok(model);
        }

        [HttpPost()]
        public IActionResult Update([FromBody]Meetings model)
        {
            // map model to entity and set id
            var meetings = _mapper.Map<Meetings>(model);
            
            try
            {
                if(model.Id == 0)
                {
                    // update user 
                    _meetingService.Add(meetings);
                }
                else
                {
                    // update user 
                    _meetingService.Update(meetings);
                }
               
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
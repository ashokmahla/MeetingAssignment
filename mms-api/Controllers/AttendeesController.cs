using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Meetings;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AttendeesController : ControllerBase
    {
        private IAttendeesService _attendeesService;
        private IMapper _mapper;

        public AttendeesController(
         IAttendeesService attendeesService,
         IMapper mapper)
        {
            _attendeesService = attendeesService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var attendees = _attendeesService.GetAll();
            var model = _mapper.Map<IList<Attendees>>(attendees);
            return Ok(model);
        }

    }
}
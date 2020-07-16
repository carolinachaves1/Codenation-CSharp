using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
           
            if (accelerationName != null && !companyId.HasValue)
            {
                var response = _mapper.Map<List<UserDTO>>(_userService.FindByAccelerationName(accelerationName));
                return Ok(response);
            }
            else if (accelerationName == null && companyId != null)
            {
                var response = _mapper.Map<List<UserDTO>>(_userService.FindByCompanyId(companyId.Value));
                return Ok(response);
            }

            return NoContent();
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var response = _mapper.Map<List<UserDTO>>(_userService.FindById(id));
            return Ok(response);
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(value);
            _userService.Save(user);

            var response = _mapper.Map<UserDTO>(user);
            return Ok(response);
        }   
    }
}

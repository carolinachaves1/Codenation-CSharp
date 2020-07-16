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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _accelerationService;
        private readonly IMapper _mapper;

        public AccelerationController(IAccelerationService accelerationService, IMapper mapper)
        {
            _accelerationService = accelerationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var response = _mapper.Map<AccelerationDTO>(_accelerationService.FindById(id));
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if(companyId == null)
            {
                return NoContent();
            }

            var response = _mapper.Map<List<AccelerationDTO>>(_accelerationService.FindByCompanyId(companyId.Value));
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var acceleration = _mapper.Map<Acceleration>(value);
            _accelerationService.Save(acceleration);

            var response = _mapper.Map<AccelerationDTO>(acceleration);
            return Ok(response);
        }
    }
}

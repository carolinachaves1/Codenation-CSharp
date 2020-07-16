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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            var response = _mapper.Map<CandidateDTO>(_candidateService.FindById(userId, accelerationId, companyId));
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if(companyId.HasValue && accelerationId == null)
            {
                var response = _mapper.Map<List<CandidateDTO>>(_candidateService.FindByCompanyId(companyId.Value));
                return Ok(response);
            }
            else if(companyId == null && accelerationId.HasValue)
            {
                var response = _mapper.Map<List<CandidateDTO>>(_candidateService.FindByAccelerationId(accelerationId.Value));
                return Ok(response);
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var candidate = _mapper.Map<Candidate>(value);
            _candidateService.Save(candidate);

            var response = _mapper.Map<CandidateDTO>(candidate);
            return Ok(response);
        }
    }
}

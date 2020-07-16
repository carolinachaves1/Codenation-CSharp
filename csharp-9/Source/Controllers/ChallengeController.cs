using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;
        private readonly IMapper _mapper;

        public ChallengeController(IChallengeService challengeService, IMapper mapper)
        {
            _challengeService = challengeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if(accelerationId == null && User == null)
            {
                return NoContent();
            }

            var response = _mapper.Map<List<ChallengeDTO>>(_challengeService.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value));
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var challenge = _mapper.Map<Models.Challenge>(value);
            _challengeService.Save(challenge);

            var response = _mapper.Map<ChallengeDTO>(challenge);
            return Ok(response);
        }
    }
}

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
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService submissionService, IMapper mapper)
        {
            _submissionService = submissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            
            if(challengeId == null && accelerationId == null)
            {
                return NoContent();
            }

            var response = _mapper.Map<List<SubmissionDTO>>(_submissionService.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value));
            return Ok(response);
        }

        [HttpGet("higherScore")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if(challengeId == null)
            {
                return NoContent();
            }

            var response = _submissionService.FindHigherScoreByChallengeId(challengeId.Value);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submission = _mapper.Map<Submission>(value);
            _submissionService.Save(submission);

            var response = _mapper.Map<SubmissionDTO>(submission);

            return Ok(response);
        }



    }
}
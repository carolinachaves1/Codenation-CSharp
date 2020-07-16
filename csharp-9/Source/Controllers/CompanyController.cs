﻿using System;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("id")]
        public ActionResult<CompanyDTO> GetCompanyById(int id)
        {
            var response = _mapper.Map<CompanyDTO>(_companyService.FindById(id));
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<List<CompanyDTO>> GetCompany(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId.HasValue && userId == null)
            {
                var response = _mapper.Map<CompanyDTO>(_companyService.FindByAccelerationId(accelerationId.Value));
                return Ok(response);
            }
            else if(accelerationId == null && userId.HasValue)
            {
                var response = _mapper.Map<CompanyDTO>(_companyService.FindById(userId.Value));
                return Ok(response);
            }

            return NoContent();
        }
    }
}

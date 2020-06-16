using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            var response = _context.Candidates.Where(x => x.AccelerationId == accelerationId).ToList();

            if (!response.Any())
            {
                throw new System.Exception();
            }

            return response;
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            var response = _context.Candidates.Where(x => x.CompanyId == companyId).ToList();

            if (!response.Any())
            {
                throw new System.Exception();
            }

            return response;
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            var response = _context.Candidates.Where(x => x.UserId == userId && x.AccelerationId == accelerationId && x.CompanyId == companyId).FirstOrDefault(); ;

            if (response == null)
            {
                throw new System.Exception();
            }

            return response;
        }
        public Candidate Save(Candidate candidate)
        {
            try
            {
                var findCandidate = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

                return findCandidate;
            }
            catch (Exception)
            {
                _context.Add(candidate);
                _context.SaveChanges();

                return candidate;
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            var response = _context.Candidates.Where(x => x.AccelerationId == accelerationId)
                .Select(x => x.Company).ToList();

            return response;
        }
        public Company FindById(int id)
        {
           return  _context.Companies.Where(x => x.Id == id).FirstOrDefault();
  
        }

        public IList<Company> FindByUserId(int userId)
        {
            var search = from candidate in _context.Candidates
                         join company in _context.Companies
                         on candidate.CompanyId equals company.Id
                         where candidate.UserId == userId
                         select company;


            return search.Distinct().ToList();
        }

        public Company Save(Company company)
        {
            if(company.Id == 0)
            {
                _context.Add(company);
                _context.SaveChanges();
            }
            else
            {
                _context.Update(company);
            }

            return company;
        }
    }
}
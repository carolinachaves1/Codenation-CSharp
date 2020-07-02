using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            var response = _context.Accelerations.Where(x => x.Id == companyId);

            if (!response.Any())
            {
                throw new System.Exception();
            }

            return response.ToList();
        }

        public Acceleration FindById(int id)
        {
            var response = _context.Accelerations.Where(x => x.Id == id).FirstOrDefault();

            if (response == null)
            {
                throw new System.Exception();
            }

            return response;
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if(acceleration.Id == 0)
            {
                _context.Add(acceleration);
                _context.SaveChanges();
            }

            return acceleration;
        }
    }
}

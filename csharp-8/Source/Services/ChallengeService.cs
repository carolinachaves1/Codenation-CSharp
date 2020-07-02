using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            var search = from candidate in _context.Candidates
                         join acceleration in _context.Accelerations
                         on candidate.AccelerationId equals acceleration.Id
                         join challenge in _context.Challenges
                         on acceleration.ChallengeId equals challenge.Id
                         where candidate.AccelerationId == accelerationId
                         where candidate.UserId == userId
                         select challenge;


            return search.Distinct().ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if(challenge.Id == 0)
            {
                _context.Add(challenge);
                _context.SaveChanges();
            }
            else
            {
                _context.Update(challenge);
            }

            return challenge;
        }
    }
}
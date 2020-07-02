using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;
        
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            var search = _context.Candidates.Where(candidate => candidate.AccelerationId == accelerationId)
                .Join(_context.Users, candidate => candidate.UserId, user => user.Id, (candidate, user) => user)
                .Join(_context.Submissions, user => user.Id, submission => submission.UserId, (user, submission) => submission)
                .Where(submission => submission.ChallengeId == challengeId).Distinct().ToList();

            return search;
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            var search = _context.Challenges.Where(challenge => challenge.Id == challengeId)
                .Join(_context.Submissions, challenge => challenge.Id, submission => submission.ChallengeId, (challenge, submission) => submission)
                .Select(x => x.Score).Distinct().Max();

            return search;
        }

        public Submission Save(Submission submission)
        {
            var search = _context.Submissions.Where(x => x.UserId == submission.UserId && x.ChallengeId == submission.ChallengeId).FirstOrDefault();

            if(search == null)
            {
                _context.Add(submission);
                _context.SaveChanges();
            }
            else
            {
                _context.Update(submission);
            }

            return submission;
        }
    }
}

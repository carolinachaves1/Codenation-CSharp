using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            var search = from candidate in _context.Candidates
                         join acceleration in _context.Accelerations
                         on candidate.AccelerationId equals acceleration.Id
                         join user in _context.Users
                         on candidate.UserId equals user.Id
                         where acceleration.Name == name
                         select user;


            return search.ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            var search = from candidate in _context.Candidates
                         join company in _context.Companies
                         on candidate.AccelerationId equals company.Id
                         join user in _context.Users
                         on candidate.UserId equals user.Id
                         where company.Id == companyId
                         select user;


            return search.ToList();
        }

        public User FindById(int id)
        {
            var search = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            return search;
        }

        public User Save(User user)
        {
            if(user.Id == 0)
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            else
            {
                _context.Update(user);
            }

            return user;
        }
    }
}

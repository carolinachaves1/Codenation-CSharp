using CentralDeErros.DataLayer.Interfaces;
using System;
using System.Linq;

namespace CentralDeErros.DataLayer.Repository
{
    public class EnvironmentRepository : IEnvironmentRepository
    {
        private readonly CentralDeErrosContext _context;

        public EnvironmentRepository(CentralDeErrosContext context)
        {
            _context = context;
        }

        public Models.Environment EnvironmentByName(string name)
        {
            return _context.Environments.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}


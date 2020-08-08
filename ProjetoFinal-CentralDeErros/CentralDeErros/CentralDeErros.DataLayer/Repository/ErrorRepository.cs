using CentralDeErros.DataLayer.Interfaces;
using CentralDeErros.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.DataLayer.Repository
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly CentralDeErrosContext _context;

        public ErrorRepository(CentralDeErrosContext context)
        {
            _context = context;
        }

        public IEnumerable<Error> GetAll()
        {
            return _context.Errors.Include(x => x.Environment)
                .Include(x => x.Level).ToList();
        }

        public IEnumerable<Error> GetByEnvironment(string environment)
        {
            return _context.Errors.Include(x => x.Environment)
                .Include(x => x.Level)
                .Where(x => x.Environment.Name == environment).ToList();
        }

        public Error GetById(int id)
        {
            return _context.Errors.Include(x => x.Environment)
                .Include(x => x.Level)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Error> GetByLevel(string level)
        {
            return _context.Errors.Include(x => x.Environment)
                .Include(x => x.Level)
                .Where(x => x.Level.Name == level).ToList();
        }

        public int Save(Error error)
        {
            _context.Errors.Add(error);
            return _context.SaveChanges();
        }
    }
}

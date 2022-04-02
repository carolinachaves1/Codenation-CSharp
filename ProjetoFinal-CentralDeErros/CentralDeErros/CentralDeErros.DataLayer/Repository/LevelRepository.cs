using CentralDeErros.DataLayer.Interfaces;
using CentralDeErros.DataLayer.Models;
using System.Linq;


namespace CentralDeErros.DataLayer.Repository
{
    public class LevelRepository : ILevelRepository
    {
        private readonly CentralDeErrosContext _context;

        public LevelRepository(CentralDeErrosContext context)
        {
            _context = context;
        }

        Level ILevelRepository.LevelByName(string name)
        {
            return _context.Levels.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}

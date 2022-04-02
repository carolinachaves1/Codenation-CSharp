using CentralDeErros.DataLayer.Models;

namespace CentralDeErros.DataLayer.Interfaces
{
    public interface ILevelRepository
    {
        Level LevelByName(string name);
    }
}

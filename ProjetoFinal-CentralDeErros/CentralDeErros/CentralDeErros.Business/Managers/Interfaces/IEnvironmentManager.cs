using Model = CentralDeErros.DataLayer.Models;

namespace CentralDeErros.Business.Managers.Interfaces
{
    public interface IEnvironmentManager
    {
        Model.Environment EnvironmentByName(string name);
    }
}

using CentralDeErros.Business.Managers.Interfaces;
using CentralDeErros.DataLayer.Interfaces;
using Model = CentralDeErros.DataLayer.Models;
using CentralDeErros.Business.Exceptions;

namespace CentralDeErros.Business.Managers
{
    public class EnvironmentManager : IEnvironmentManager
    {
        private readonly IEnvironmentRepository _environmentRepository;

        public EnvironmentManager(IEnvironmentRepository environmentRepository)
        {
            _environmentRepository = environmentRepository;
        }

        public Model.Environment EnvironmentByName(string name)
        {
            var environment = _environmentRepository.EnvironmentByName(name);

            if (environment == null)
            {
                throw new EnvironmentNotFoundException();
            }

            return environment;
        }
    }
}

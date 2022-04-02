using AutoMapper;
using CentralDeErros.Business.Exceptions;
using CentralDeErros.Business.Managers.Interfaces;
using CentralDeErros.Business.Models;
using CentralDeErros.DataLayer.Interfaces;
using CentralDeErros.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeErros.Business.Managers
{
    public class ErrorManager : IErrorManager
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IEnvironmentManager _environmentManager;
        private readonly ILevelManager _levelManager;
        private IMapper _mapper;

        public ErrorManager(IErrorRepository errorRepository, IEnvironmentManager environmentManager, ILevelManager levelManager, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _environmentManager = environmentManager;
            _levelManager = levelManager;
            _mapper = mapper;
        }

        public IEnumerable<ErrorDTO> GetAll()
        {
            var response = _errorRepository.GetAll();

            if (response == null || !response.Any())
            {
                throw new NoContentException();
            }

            return response.Select(x => _mapper.Map<ErrorDTO>(x)).ToList();
        }

        public ErrorDTO GetById(int id)
        {
            var response = _errorRepository.GetById(id);

            if (response == null)
            {
                throw new ErrorNotFoundException();
            }

            return _mapper.Map<ErrorDTO>(response);
        }

        public Error Save(ErrorDTO errorDTO)
        {
            var model = _mapper.Map<Error>(errorDTO);

            var category = _environmentManager.EnvironmentByName(errorDTO.Category);
            var level = _levelManager.LevelByName(errorDTO.Level);

            model.Environment = category;
            model.Level = level;

            _errorRepository.Save(model);

            return model;
        }
    }
}

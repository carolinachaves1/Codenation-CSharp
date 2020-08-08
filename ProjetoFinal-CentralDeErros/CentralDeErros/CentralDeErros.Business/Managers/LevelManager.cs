using CentralDeErros.Business.Managers.Interfaces;
using CentralDeErros.DataLayer.Interfaces;
using CentralDeErros.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Managers
{
    public class LevelManager : ILevelMananger
    {
        private readonly ILevelRepository _levelRepository;

        public LevelManager(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public Level LevelByName(string name)
        {
            var level = _levelRepository.LevelByName(name);

            if (level == null)
            {
                throw new LevelNotFoundException();
            }

            return level;
        }
    }
}

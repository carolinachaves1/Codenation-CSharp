using CentralDeErros.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Managers.Interfaces
{
    public interface ILevelMananger
    {
        Level LevelByName(string name);
    }
}

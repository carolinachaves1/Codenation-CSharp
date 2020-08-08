using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.DataLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Environment EnvironmentByName(string name);
    }
}

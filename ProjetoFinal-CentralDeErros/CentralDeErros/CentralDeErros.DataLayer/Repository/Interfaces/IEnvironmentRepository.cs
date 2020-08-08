using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.DataLayer.Interfaces
{
    public interface IEnvironmentRepository
    {
        Models.Environment EnvironmentByName(string name);
    }
}

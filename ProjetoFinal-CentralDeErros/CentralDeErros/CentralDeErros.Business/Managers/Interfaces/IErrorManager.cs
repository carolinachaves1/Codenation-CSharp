using CentralDeErros.Business.Models;
using CentralDeErros.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Managers.Interfaces
{
    public interface IErrorManager
    {
        IEnumerable<ErrorDTO> GetAll();
        ErrorDTO GetById(int id);
        Error Save(ErrorDTO error);
    }
}

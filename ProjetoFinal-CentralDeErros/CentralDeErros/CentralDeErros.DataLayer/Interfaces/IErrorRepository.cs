using CentralDeErros.DataLayer.Models;
using System.Collections.Generic;

namespace CentralDeErros.DataLayer.Interfaces
{
    public interface IErrorRepository
    {
        IEnumerable<Error> GetAll();
        Error GetById(int id);
        IEnumerable<Error> GetByLevel(string level);
        IEnumerable<Error> GetByCategory(string category);
        int Save(Error error);
    }
}

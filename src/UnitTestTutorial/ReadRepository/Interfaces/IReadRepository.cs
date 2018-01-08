using System.Collections.Generic;
using UnitTestTutorial.Model;

namespace UnitTestTutorial.ReadRepository.Interfaces
{
    public interface IReadRepository<T> where T : Entity
    {
         IList<T> GetAll();

         T GetById(int id);
    }
}
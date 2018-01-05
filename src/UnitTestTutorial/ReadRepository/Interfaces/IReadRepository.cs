using System.Collections.Generic;
using UnitTestTutorial.Model;

namespace UnitTestTutorial.ReadRepository.Interfaces
{
    public interface IReadRepository<T> where T : Entity
    {
         T GetAll();

         IList<T> GetById(int id);
    }
}
using System.Collections.Generic;
using UnitTestTutorial.Model;

namespace UnitTestTutorial.Services.Interfaces
{
    public interface IUserService
    {
         IList<User> GetUsersByType(int type);

         void AddUser(User user);
    }
}
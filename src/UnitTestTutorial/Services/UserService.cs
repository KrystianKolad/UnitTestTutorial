using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestTutorial.Model;
using UnitTestTutorial.ReadRepository.Interfaces;
using UnitTestTutorial.Services.Interfaces;
using UnitTestTutorial.WriteRepository.Interfaces;

namespace UnitTestTutorial.Services
{
    public class UserService : IUserService
    {
        private IWriteRepository<User> _userWriteRepository;
        private IReadRepository<User> _userReadRepository;
        public UserService(IWriteRepository<User> userWriteRepository, IReadRepository<User> userReadRepository)
        {
            _userWriteRepository = userWriteRepository ?? throw new System.ArgumentNullException(nameof(userWriteRepository));
            _userReadRepository = userReadRepository ?? throw new System.ArgumentNullException(nameof(userReadRepository));
        }

        public void AddUser(User user)
        {
            try
            {
                _userWriteRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<User> GetUsersByType(int type)
        {
            return _userReadRepository.GetAll().Where(x=>x.UserType == type).ToList();
        }
    }
}
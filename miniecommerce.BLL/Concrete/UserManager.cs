using miniecommerce.BLL.Abstract;
using miniecommerce.DAL.Abstract;
using miniecommerce.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userRepository.GetList(filter);
        }

        public User GetById(int id)
        {
            return _userRepository.Get(c => c.Id == id);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}

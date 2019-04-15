using miniecommerce.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.BLL.Abstract
{
    public interface IUserService
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User GetById(int id);
        User Add(User user);
        User Update(User user);
    }
}

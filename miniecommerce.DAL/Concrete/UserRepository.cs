using miniecommerce.DAL.Abstract;
using miniecommerce.ENTITIES.Concrete;

namespace miniecommerce.DAL.Concrete
{
    public class UserRepository : Repository<User, DatabaseContext>, IUserRepository
    {
        
    }
}

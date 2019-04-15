using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.DAL.Abstract
{
    public interface IBasketRepository : IRepository<Basket>
    {
        List<BasketViewModel> GetBasketListByUserID(Expression<Func<BasketViewModel,bool>> filter );
    }
}

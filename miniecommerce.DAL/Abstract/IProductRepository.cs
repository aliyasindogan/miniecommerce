using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.DAL.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ProductBasketViewModel> GetListProductViewModel(Expression<Func<ProductBasketViewModel, bool>> filter);
        ProductBasketViewModel GetProductViewModel(Expression<Func<ProductBasketViewModel, bool>> filter);
    }
}

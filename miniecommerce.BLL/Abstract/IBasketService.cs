using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace miniecommerce.BLL.Abstract
{
    public interface IBasketService
    {
        List<Basket> GetAll(Expression<Func<Basket, bool>> filter = null);
        Basket GetById(int id);
        Basket Add(Basket basket);
        Basket Update(Basket basket);

        int Max(Expression<Func<Basket, int>> filter);
        int Sum(Expression<Func<Basket, bool>> filterWhere, Func<Basket, int> filterSum);
        decimal Sum(Expression<Func<Basket, bool>> filterWhere, Func<Basket, decimal> filterSum);

        List<BasketViewModel> GetBasketListByUserID(Expression<Func<BasketViewModel, bool>> filter);
    }
}
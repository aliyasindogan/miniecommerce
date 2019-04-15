using miniecommerce.BLL.Abstract;
using miniecommerce.DAL.Abstract;
using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.BLL.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketRepository _basketRepository;

        public BasketManager(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Basket Add(Basket basket)
        {
            return _basketRepository.Add(basket);
        }

        public List<Basket> GetAll(Expression<Func<Basket, bool>> filter = null)
        {
            return _basketRepository.GetList(filter);
        }

        public List<BasketViewModel> GetBasketListByUserID(Expression<Func<BasketViewModel, bool>> filter)
        {
            return _basketRepository.GetBasketListByUserID(filter);
        }

        public Basket GetById(int id)
        {
            return _basketRepository.Get(x => x.Id == id);
        }

        public int Max(Expression<Func<Basket, int>> filter)
        {
            return _basketRepository.Max(filter);
        }

        public int Sum(Expression<Func<Basket, bool>> filterWhere, Func<Basket, int> filterSum)
        {
            return _basketRepository.Sum(filterWhere, filterSum);
        }
        public decimal Sum(Expression<Func<Basket, bool>> filterWhere, Func<Basket, decimal> filterSum)
        {
            return _basketRepository.Sum(filterWhere, filterSum);
        }
        public Basket Update(Basket basket)
        {
            return _basketRepository.Update(basket);
        }

        
    }
}

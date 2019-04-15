using miniecommerce.BLL.Abstract;
using miniecommerce.DAL.Abstract;
using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductBasketViewModel> GetListProductViewModel(Expression<Func<ProductBasketViewModel, bool>> filter)
        {
            return _productRepository.GetListProductViewModel(filter);
        }

        public Product Add(Product user)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productRepository.GetList(filter);
        }

        public Product GetById(int id)
        {
            return _productRepository.Get(u => u.Id == id);
        }

      

        public Product Update(Product user)
        {
            throw new System.NotImplementedException();
        }

        public ProductBasketViewModel GetProductViewModel(Expression<Func<ProductBasketViewModel, bool>> filter)
        {
            return _productRepository.GetProductViewModel(filter);
        }

        public int Max(Expression<Func<Product, int>> filter)
        {
            return _productRepository.Max(filter);
        }
    }
}

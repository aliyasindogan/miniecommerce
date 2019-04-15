using miniecommerce.DAL.Abstract;
using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace miniecommerce.DAL.Concrete
{
    public class ProductRepository : Repository<Product, DatabaseContext>, IProductRepository
    {
        public List<ProductBasketViewModel> GetListProductViewModel(Expression<Func<ProductBasketViewModel, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from p in context.Products
                             join b in context.Baskets on p.Id equals b.ProductID into pb
                             from b in pb.DefaultIfEmpty()
                             select new ProductBasketViewModel
                             {
                                 Id = p.Id,
                                 ProductID = p.Id,
                                 ProductName = p.ProductName,
                                 ProductCode = p.ProductCode,
                                 ProductImageUrl = p.ProductImageUrl,
                                 ProductDescripton = p.ProductDescripton,
                                 ProductPrice = p.ProductPrice,
                                 UserID = b.UserID,
                                 Quantity = b.Quantity

                             };
                return result.Where(filter).ToList();
            }
        }
        public ProductBasketViewModel GetProductViewModel(Expression<Func<ProductBasketViewModel, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = (from p in context.Products
                              join b in context.Baskets on p.Id equals b.ProductID 
                              into pb
                              from b in pb.DefaultIfEmpty()
                              select new ProductBasketViewModel
                              {
                                  Id = p.Id,
                                  ProductID = p.Id,
                                  ProductName = p.ProductName,
                                  ProductCode = p.ProductCode,
                                  ProductImageUrl = p.ProductImageUrl,
                                  ProductDescripton = p.ProductDescripton,
                                  ProductPrice = p.ProductPrice,
                                  Quantity = (int?)b.Quantity ?? 0
                              }).FirstOrDefault(filter);
                return result;
            }
        }

    }
}

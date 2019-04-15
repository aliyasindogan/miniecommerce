using miniecommerce.DAL.Abstract;
using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace miniecommerce.DAL.Concrete
{
    public class BasketRespository : Repository<Basket, DatabaseContext>, IBasketRepository
    {
        public List<BasketViewModel> GetBasketListByUserID(Expression<Func<BasketViewModel, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from b in context.Baskets
                             join p in context.Products on b.ProductID equals p.Id into pb
                             from p in pb.DefaultIfEmpty()
                             select new BasketViewModel
                             {
                                 Id = b.Id,
                                 ProductName = p.ProductName,
                                 Quantity = b.Quantity,
                                 ProductPrice = b.ProductPrice,
                                 ProductPriceTotal = b.ProductPriceTotal,
                                 IsSales = b.IsSales,
                                 UserID = b.UserID,
                                 SortNumber = b.SortNumber,
                                 ProductImageUrl = p.ProductImageUrl
                             };
                return result.Where(filter).OrderByDescending(x => x.Id).ToList();
            }
        }
    }
}

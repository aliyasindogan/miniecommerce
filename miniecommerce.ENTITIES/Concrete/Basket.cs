using miniecommerce.ENTITIES.Abstract;
using System.ComponentModel.DataAnnotations;

namespace miniecommerce.ENTITIES.Concrete
{
    public class Basket : BaseEntity, IEntity
    {
        [Display(Name = "Kullanıcı")]
        public int UserID { get; set; }

        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Ürün Fiyat Toplamı")]
        public decimal ProductPriceTotal { get; set; }

        [Display(Name = "Satış Mı?")]
        public bool IsSales { get; set; }
    }
}

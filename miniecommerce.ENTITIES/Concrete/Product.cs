using miniecommerce.ENTITIES.Abstract;
using System.ComponentModel.DataAnnotations;

namespace miniecommerce.ENTITIES.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        public string ProductDescripton { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal ProductPrice { get; set; }
        [Display(Name = "Ürün Resim URL")]
        public string ProductImageUrl { get; set; }
    }
}

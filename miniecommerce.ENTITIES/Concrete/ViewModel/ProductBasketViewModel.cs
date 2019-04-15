using System.ComponentModel.DataAnnotations;

namespace miniecommerce.ENTITIES.Concrete.ViewModel
{
    public class ProductBasketViewModel:BaseEntity
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

        [Display(Name = "Kullanıcı")]
        public int? UserID { get; set; }

        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Ürün Fiyat Toplamı")]
        public decimal? ProductPriceTotal { get; set; }

        [Display(Name = "Satış Mı?")]
        public bool? IsSales { get; set; }
    }
}

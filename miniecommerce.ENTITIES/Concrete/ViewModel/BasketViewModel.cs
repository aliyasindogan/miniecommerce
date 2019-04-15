using miniecommerce.ENTITIES.Abstract;
using System.ComponentModel.DataAnnotations;

namespace miniecommerce.ENTITIES.Concrete.ViewModel
{
    public class BasketViewModel
    {
        //BasketID
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Ürün Resim URL")]
        public string ProductImageUrl { get; set; }

        [Display(Name = "Kaydeden")]
        public string CreatedUser { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Ürün Fiyat Toplamı")]
        public decimal? ProductPriceTotal { get; set; }

        [Display(Name = "Satış Mı?")]
        public bool? IsSales { get; set; }

        public int SortNumber { get; set; } //Sıra No
    }
}

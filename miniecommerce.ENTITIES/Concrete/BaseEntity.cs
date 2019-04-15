using System;
using System.ComponentModel.DataAnnotations;

namespace miniecommerce.ENTITIES.Concrete
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int SortNumber { get; set; } //Sıra No
        public DateTime CreatedDate { get; set; } //Kayıt Tarihi
        public int CreatedUserID { get; set; } //Kaydeden Kullanıcı ID
        public Nullable<DateTime> UpdatedDate { get; set; } //Güncelleme Tarihi
        public Nullable<int> UpdatedUserID { get; set; } // Güncelleyen Kullanıcı ID
        public bool IsActive { get; set; } //Aktif Mi
    }
}

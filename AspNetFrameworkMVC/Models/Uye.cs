using System;
using System.ComponentModel.DataAnnotations; // Validation işlemleri için gerekli kütüphane

namespace AspNetFrameworkMVC.Models
{
    public class Uye
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Ad { get; set; }
        [Required, StringLength(50)]
        public string Soyad { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telefon { get; set; }
        [Display(Name = "Tc Kimlik Numarası")]
        [MinLength(11, ErrorMessage = "Tc Kimlik Numarası 11 Karakter Olmalıdır!")]
        [MaxLength(11, ErrorMessage = "{0} 11 Karakter Olmalıdır!")]
        public string TcKimlikNo { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password)]
        [Required, StringLength(50, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 3)]
        public string Sifre { get; set; }
        [Display(Name = "Şifre Tekrar"), DataType(DataType.Password)]
        [Compare("Sifre")]
        public string SifreTekrar { get; set; }
    }
}
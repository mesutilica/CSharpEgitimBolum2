using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Kategoriler")] // Entity framework ün veritabanı tablosunu Kategoris ismi yerine Kategoriler olarak oluşturması için bu attribute ü yazıyoruz
    public class Kategori
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
    }
}

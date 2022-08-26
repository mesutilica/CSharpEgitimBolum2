using System;
using System.Collections.Generic;
using System.Data; // Veritabanı işlemleri için gerekli
using System.Data.SqlClient; // Adonet kütüphaneleri

namespace WindowsFormsAppAdoNet
{
    public class KategoriDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet; integrated security=true");

        void ConnectionKontrol() // void = tek
        {
            if (connection.State == ConnectionState.Closed) // Eğer yukarda tanımladığımız veritabanı bağlantısı kapalıysa
            {
                connection.Open();// bağlantıyı aç
            }
        }
        public DataTable GetAllDataTable()
        {
            ConnectionKontrol(); // bağlantıyı kontrol et
            DataTable dt = new DataTable(); // Boş bir datatable nesnesi oluştur
            SqlCommand command = new SqlCommand("select * from Kategoriler", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); // sql komut nesnesini kapat
            connection.Close();// veritabanı bağlantısını kapat
            return dt; // metodun çağırıldığı yere dt(data tablosunu) gönder.
        }

        public int Add(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Kategoriler (KategoriAdi, Durum) values (@KategoriAdi, @Durum)", connection); // Sql komutu olarak bu sefer insert komutu yazdık
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);

            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // sql komut nesnesini kapat
            connection.Close();// veritabanı bağlantısını kapat
            return islemSonucu; // Metodumuz geriye int döndüğü için islemSonucu değişkenini geri gönüyoruz
        }


    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkDbFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Entity Framework
        /*
         * Entity Framework ORM(Object Relational Mapping) araçlarından biridir. Veritabanı CRUD işlemlerini Sql sorgusu yazmadan Linq dili ile hazır metotları kullanarak yapabilmemizi sağlar.
         * Entity Framework ile 4 farklı yöntem kullanarak proje geliştirebilirsiniz.
         * 
         * Model First (Model oluşturup bu modele göre db oluşturarak)
         * Database First (Var Olan Veritabanını Kullanma)
         * Code First (Önce Entity class larımızı oluşturup sonra Veritabanı oluşturarak)
         * Code First (Var Olan Veritabanını Kullanarak Entity class larını oluşturarak)
         */
        // Entity Framework projelere dahili olarak ado.net gibi gelmez!
        // Sonradan projeye sağ tıklayıp açılan menüden nuget package manager i açıp buradan browse menüsüne tıklayıp arama çubuğundan entityframework yazarak paketi bulup install diyerek açılan onay penceresinde I Accept butonuna basarak yüklememiz gerekir.

        UrunYonetimiAdoNetEntities context = new UrunYonetimiAdoNetEntities(); // Entity framework ile veritabanı crud işlemlerini yapabilmek için bu sınıftan bir nesne tanımlıyoruz.

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Products.ToList(); // EF ile contex nesnesi üzerindeki Products dbset ine ulaşıp veritabanındaki ürünleri listeledik
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Products.Add(new Products
                {
                    StokMiktari = Convert.ToInt32(txtStokMiktari.Text),
                    UrunAdi = txtUrunAdi.Text,
                    UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text)
                });// yukarda dbset üzerine yeni bir ürün kaydı ekledik
                context.SaveChanges(); // burada ise context üzerinde yapılan bu değişikliği veritabanına kaydettik
                dgvUrunler.DataSource = context.Products.ToList();
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

            var kayit = context.Products.Find(secilenKayitId); // Entity framework Find metodu kendisine parametreyle gönderilen id ile eşleşen kaydı veritabanından getirir.

            txtUrunAdi.Text = kayit.UrunAdi;
            txtStokMiktari.Text = kayit.StokMiktari.ToString();
            txtUrunFiyati.Text = kayit.UrunFiyati.ToString();

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

                var kayit = context.Products.Find(secilenKayitId);

                kayit.UrunAdi = txtUrunAdi.Text;

                kayit.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);

                kayit.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Products.ToList();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

                Products kayit = context.Products.Find(secilenKayitId);

                context.Products.Remove(kayit); // context üzerindeki Products tablosundan kayit içindeki ürünü silinecek olarak işaretle!

                var sonuc = context.SaveChanges(); // context üzerindeki değişiklikleri (Burada silme işlemine karşılık geliyor değişiklik) veritabanına işle..
                // Entity framework de tracking denilen bir kavram var ve bu tracking ef context üzerindeki değişiklikleri izler, takip eder, savechanges i çalıştırdığımızda db ye işler.

                if (sonuc > 0) // context.SaveChanges() metodu geriye veritabanında etkilenen kayıt sayısını int olarak bize döndürür. sonuc değişkenine bu değeri atadık ve if ile bu değer 0 dan büyük mü diye kontrol ettik. Eğer silme başarılıysa sonuc değeri 1 olacaktır, başarısız olursa 0 olacaktır.
                {
                    dgvUrunler.DataSource = context.Products.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
                else MessageBox.Show("Kayıt Silinemedi!");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }
    }
}

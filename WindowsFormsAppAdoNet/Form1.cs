using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDAL productDAL = new ProductDAL(); // Veritabanı işlemlerinin olduğu sınıfı tanımladık
        private void Form1_Load(object sender, EventArgs e)
        {
            //dgvUrunler.DataSource = productDAL.GetAll(); // Form ön yüzdeki dgvUrunler nesnesine productDAL içindeki GetAll metodu ile ürünleri yüklettik
            dgvUrunler.DataSource = productDAL.GetAllDataTable(); // data table ile yaptığımız veri çekme metodu
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product(); // Boş bir product nesnesi oluşturduk
                product.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);
                product.UrunAdi = txtUrunAdi.Text;
                product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                var islemSonucu = productDAL.Add(product); // Add metoduna product ı eklemesi için gönderdik

                if (islemSonucu > 0)
                {
                    dgvUrunler.DataSource = productDAL.GetAllDataTable(); // Data grid view da eklenen son kaydı da görebilmek için
                    MessageBox.Show("Kayıt Başarılı");
                }
                else MessageBox.Show("Kayıt Başarısız!");
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Hata Oluştu!\nGeçersiz Değer Girdiniz!");
                MessageBox.Show(hata.Message);
            }
        }

        // Ekleme işleminden sonraki işlemimiz gridview dan kayıt seçip, seçilen kaydın bilgilerini textboxlara doldurmak. Bunun için gridview ın events (olaylar) kısmında cell click olayını etkinleştirmemiz lazım. Gride sağ klik yapıp properties e tıklayıp açılan pencereden şimşek ikonuna tıklayıp oradan secc click kutucuğuna mouse ile çift tıklayarak bu olayı aktifleştirebiliyoruz.

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtStokMiktari.Text = dgvUrunler.CurrentRow.Cells[3].Value.ToString();
            //txtUrunAdi.Text = dgvUrunler.CurrentRow.Cells[1].Value.ToString();
            //txtUrunFiyati.Text = dgvUrunler.CurrentRow.Cells[2].Value.ToString();

            string id = dgvUrunler.CurrentRow.Cells[0].Value.ToString(); // seçili satırda ilk sütundaki id değerini elde ettik

            Product product = productDAL.GetProduct(id); // Boş bir product nesnesi oluşturup productDAL sınıfımızdaki GetProduct metoduna üstteli id değerini göndererek bu id ye ait kaydı veritabanından çekmesini sağladık

            // veritabanından gelen product nesnesindeki verileri aşağıda textbox lara doldurduk
            txtStokMiktari.Text = product.StokMiktari.ToString();
            txtUrunAdi.Text = product.UrunAdi.ToString();
            txtUrunFiyati.Text = product.UrunFiyati.ToString();
            btnGuncelle.Enabled = true; // Listeden kayıt seçildiğinde güncelle butonunu aktif et
            btnSil.Enabled = true; // Sil butonunu aktif et
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product(); // Boş bir product nesnesi oluşturduk
                product.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);
                product.UrunAdi = txtUrunAdi.Text;
                product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                product.Id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var islemSonucu = productDAL.Update(product); // Add metoduna product ı eklemesi için gönderdik

                if (islemSonucu > 0)
                {
                    dgvUrunler.DataSource = productDAL.GetAllDataTable(); // Data grid view da eklenen son kaydı da görebilmek için
                    MessageBox.Show("Kayıt Başarılı");
                }
                else MessageBox.Show("Kayıt Başarısız!");
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Hata Oluştu!\nGeçersiz Değer Girdiniz!");
                MessageBox.Show(hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var islemSonucu = productDAL.Delete(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
                if (islemSonucu > 0)
                {
                    dgvUrunler.DataSource = productDAL.GetAllDataTable();
                    MessageBox.Show("Silme Başarılı");
                }
                else MessageBox.Show("Silme Başarısız!");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}

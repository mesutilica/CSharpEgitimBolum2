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
    }
}

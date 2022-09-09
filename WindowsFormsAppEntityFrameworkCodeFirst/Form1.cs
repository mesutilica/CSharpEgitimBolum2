using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;
using WindowsFormsAppEntityFrameworkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext(); // Ef code first ü kullanabilmek için DatabaseContext sınıfımızdan bu şekilde bir nesne oluşturmalıyız.
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Urunler.ToList(); // context nesnemiz üzerindeki urunler isimli dbset üzerinden veritabanındaki kayıtları listeletiyoruz
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Urunler.Add(
                    new Urun
                    {
                        Adi = txtUrunAdi.Text,
                        Fiyati = Convert.ToDecimal(txtUrunFiyati.Text),
                        Stok = Convert.ToInt32(txtStokMiktari.Text)
                    }
                    );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu! " + hata.Message);
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var kayit = context.Urunler.Find(id);

                txtUrunAdi.Text = kayit.Adi;
                txtStokMiktari.Text = kayit.Stok.ToString();
                txtUrunFiyati.Text = kayit.Fiyati.ToString();

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu! " + hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var kayit = context.Urunler.Find(id);

                kayit.Adi = txtUrunAdi.Text;
                kayit.Fiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                kayit.Stok = Convert.ToInt32(txtStokMiktari.Text);

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu! " + hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var kayit = context.Urunler.Find(id);

                context.Urunler.Remove(kayit);

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu! " + hata.Message);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Urunler.Where(u => u.Adi.Contains(txtAra.Text)).ToList();
        }
    }
}

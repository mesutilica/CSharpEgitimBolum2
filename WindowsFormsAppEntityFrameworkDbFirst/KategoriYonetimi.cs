using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkDbFirst
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }

        UrunYonetimiAdoNetEntities context = new UrunYonetimiAdoNetEntities();

        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = context.Kategoriler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez!");
                return;
            }
            try
            {
                context.Kategoriler.Add(
                    new Kategoriler
                    {
                        KategoriAdi = txtKategoriAdi.Text,
                        Durum = cbDurum.Checked
                    });
                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);

            var kayit = context.Kategoriler.Find(secilenKayitId);

            txtKategoriAdi.Text = kayit.KategoriAdi;
            cbDurum.Checked = kayit.Durum;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez!");
                return;
            }
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);

                var kayit = context.Kategoriler.Find(secilenKayitId);

                kayit.Durum = cbDurum.Checked;

                kayit.KategoriAdi = txtKategoriAdi.Text;

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);

                var kayit = context.Kategoriler.Find(secilenKayitId);

                context.Kategoriler.Remove(kayit);

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}

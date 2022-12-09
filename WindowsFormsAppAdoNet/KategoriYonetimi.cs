using System;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        KategoriDAL kategoriDAL = new KategoriDAL();
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = kategoriDAL.GetAllDataTable();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int sonuc = kategoriDAL.Add(new Kategori
                {
                    KategoriAdi = txtKategoriAdi.Text,
                    Durum = cbDurum.Checked
                });
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = kategoriDAL.GetAllDataTable();
                    MessageBox.Show("Kayıt Başarılı!");
                }
                else MessageBox.Show("Kayıt Başarısız!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvKategoriler.CurrentRow.Cells[0].Value.ToString();

            var kategori = kategoriDAL.Get(id); // kategoriDAL içine yazdığımız get metoduna seçili satırdan aldığımız id değerini yolladık, o da bize bu id ye ait kategori bilgilerini veritabanından çekip getirecek.

            txtKategoriAdi.Text = kategori.KategoriAdi; // Ön yüzdeki txtKategoriAdi adlı textbox a veritabanından gelen kategorinin kategori adı bilgisini yükledik.

            cbDurum.Checked = kategori.Durum; // Aynı şekilde ön yüzdeki cbdurum isimli checkbox ın değerini de kategoriden gelen değere göre işaretledik.
            btnGuncelle.Enabled = true; // Satır seçildiğinde Güncelle butonunu aktif et
            btnSil.Enabled = true; // Satır seçildiğinde Sil butonunu aktif et
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int sonuc = kategoriDAL.Update(new Kategori
                {
                    KategoriAdi = txtKategoriAdi.Text,
                    Durum = cbDurum.Checked,
                    Id = (int)dgvKategoriler.CurrentRow.Cells[0].Value
                });
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = kategoriDAL.GetAllDataTable();
                    MessageBox.Show("Kayıt Başarılı!");
                }
                else MessageBox.Show("Kayıt Başarısız!");
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
                var islemSonucu = kategoriDAL.Delete(dgvKategoriler.CurrentRow.Cells[0].Value.ToString());
                if (islemSonucu > 0)
                {
                    dgvKategoriler.DataSource = kategoriDAL.GetAllDataTable();
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

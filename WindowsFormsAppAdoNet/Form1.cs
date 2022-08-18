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
            dgvUrunler.DataSource = productDAL.GetAll(); // Form ön yüzdeki dgvUrunler nesnesine productDAL içindeki GetAll metodu ile ürünleri yüklettik
        }
    }
}

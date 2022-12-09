using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class MarkaYonetimi : Form
    {
        public MarkaYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void MarkaYonetimi_Load(object sender, EventArgs e)
        {
            dgvMarkalar.DataSource = context.Markalar.ToList();
        }
    }
}

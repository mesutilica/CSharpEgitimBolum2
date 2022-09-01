using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

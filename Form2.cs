using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lop.Mod;

namespace Lop
{
    public partial class Form2 : Form
    {
        public Model1 db { get; set; }
        public Product pr { get; set; }
        public List<string> stringList = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pr == null)
            {
                pr = (Product)productBindingSource.Current;
                db.Product.Add(pr);
            }
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        string FileName = "";

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото";
            ofd.InitialDirectory = @"...\...\...\...\...\Lopushok\products";
            ofd.Filter = "Файлы JPEG,JPG,GIF,PNG|*.jpeg;*.jpg;*.gif;*.png|Все файлы(*.*)|*.*";
            DialogResult rc = ofd.ShowDialog();
            if (rc == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                FileName = ofd.FileName;
            }
        }
    }
}

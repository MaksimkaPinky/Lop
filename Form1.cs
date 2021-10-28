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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        List<string> stringList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productBindingSource.DataSource = db.Product.ToList();
            productTypeBindingSource.DataSource = db.ProductType.ToList();
            comboBox2.Items.Add("Все элементы");
            foreach (ProductType p in db.ProductType)
            {
                stringList.Add(p.Title);
            }
            stringList.Sort();
            comboBox2.Items.AddRange(stringList.Select(n => n.ToString()).ToArray());
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            productBindingSource.DataSource = db.Product.Where(p => p.Title.Contains(searchBox.Text) || p.Description.Contains(searchBox.Text)).ToList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                productBindingSource.DataSource = db.Product.ToList();
            }
            else 
            {
                string n = (string)comboBox2.SelectedItem;
                productBindingSource.DataSource = db.Product.Where(x => x.ProductType.Title == n).ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Product pr = (Product)productBindingSource.Current;
            //if (pr.Image == "" || pr.Image == null)
            //{
            //    pictureBox1.Image = Image.FromFile(@"..\..\picture.png");
            //}
            //else
            //{
            //    pictureBox1.Image = Image.FromFile($@"..\..\{pr.Image}");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Addrm = new Form2();
            Addrm.pr = null;
            Addrm.db = db;
            DialogResult dr = Addrm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                productBindingSource.DataSource = db.Product.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product pr = (Product)productBindingSource.Current;
            Form2 Addrm = new Form2();
            Addrm.pr = null;
            Addrm.db = db;
            DialogResult dr = Addrm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                productBindingSource.DataSource = db.Product.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

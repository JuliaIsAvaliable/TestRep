using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace дэнахууй
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int filterDiscount, filterCategory; 
        private void Form1_Load(object sender, EventArgs e)
        {
            using (Classes.Model1 DB = new Classes.Model1())
            {

                var category = Helper.DB.test1.Select(x => x.IDName).ToList();
                category.Insert(0, "Все категории");//Добавить первой «Все категории»
                comboBox1.DataSource = category;
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            var products = Helper.DB.test1.ToList();
            products = products.Where(x => x.ID >= 2 &&
                                            x.ID <= 3).ToList();
            dataGridView1.DataSource = products;

            int countFilter;
            countFilter = products.Count();
            label2.Text = countFilter.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Classes.Model1 DB = new Classes.Model1())
            {

                if (filterCategory == 0)
                {

                    var users = DB.test1.Select(x => new { x.ID, x.IDName }).ToList();
                    dataGridView1.DataSource = users;

                    int countAll;

                    countAll = Helper.DB.test1.Count();
                    label1.Text = countAll.ToString();

                }
                else
                {
                    string cat;
                    cat = comboBox1.Text;

                    var products = Helper.DB.test1.ToList();
                    products = products.Where(x => x.IDName = cat).ToList();
                    dataGridView1.DataSource = products;
                }



            }

        }
    }
}

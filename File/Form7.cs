using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File
{
    public partial class Form7 : Form
    {
        int q = 0;
        bool Q;
        string[] tmp;
        string ch;
        List<Product> _Products = new List<Product>();
        string temp, tmpp;
        public Form7(List<Product> Products , string [] IN , string choose)
        {
            _Products = Products;
            tmp=IN;
            ch = choose;
            InitializeComponent();  
        }
        public Form7(List<Product> Products,string cho,string tmp,string text,bool ok)
        {
            _Products = Products;
            temp = tmp;
            q = 1;
            ch = cho;
            Q = ok;
            tmpp = text;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (q == 0)
            {
                List<Product> Pro = new List<Product>();
                if (ch == "price")
                {
                    Pro.Clear();
                    foreach (string num in tmp)
                    {
                        int D = int.Parse(num);

                        for (int i = 0; i < _Products.Count; i++)
                        {

                            if (D == _Products[i].price)
                            {
                                Pro.Add(_Products[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = Pro;
                }

                else
                {
                    Pro.Clear();
                    foreach (string num in tmp)
                    {
                        int D = int.Parse(num);

                        for (int i = 0; i < _Products.Count; i++)
                        {

                            if (D == _Products[i].quantity)
                            {
                                Pro.Add(_Products[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = Pro;

                }
            }
            else if (Q == true)
            {
                List<Product> pro = new List<Product>();
                if (ch == "price")
                {
                    pro.Clear();
                    if (temp == ">")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d < _Products[i].price)
                                pro.Add(_Products[i]);
                        }
                        dataGridView1.DataSource = pro;
                    }
                    if (temp == "<")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d > _Products[i].price)
                                pro.Add(_Products[i]);
                        }
                        dataGridView1.DataSource = pro;
                    }
                    if (temp == "=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d == _Products[i].price)
                                pro.Add(_Products[i]);

                        }
                        dataGridView1.DataSource =pro;
                    }
                    if (temp == "!=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d != _Products[i].price)
                                pro.Add(_Products[i]);

                        }
                        dataGridView1.DataSource = pro;
                    }
                }
                else if (ch == "quantity")
                {
                    pro.Clear();
                    if (temp == ">")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d < _Products[i].quantity)
                                pro.Add(_Products[i]);

                        }
                        dataGridView1.DataSource = pro;
                    }
                    if (temp == "<")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d > _Products[i].quantity)
                                pro.Add(_Products[i]);

                        }
                        dataGridView1.DataSource = pro;
                    }
                    if (temp == "=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d == _Products[i].quantity)
                                pro.Add(_Products[i]);

                        }
                        dataGridView1.DataSource = pro;
                    }
                    if (temp == "!=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Products.Count; i++)
                        {
                            if (d != _Products[i].quantity)
                                pro.Add(_Products[i]);

                        }
                        dataGridView1.DataSource = pro;
                    }
                }
            }
            else
                dataGridView1.DataSource = _Products; 
        }
        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Form6 : Form
    {
       
        double minprice = 10e10, maxprice = -1;
        int minquantity = 200, maxquantity = 0;
        double sum = 0;
        public string choose;
        DataSet Ds = new DataSet();
        List<Product> _Products,_Tmp = new List<Product>();
        List<Tuple<string, string>> cond = new List<Tuple<string, string>>();
        List<Tuple<string, string>> cond2 = new List<Tuple<string, string>>();
        public Form6()
        {
            InitializeComponent();
        }
        public Form6(List<Product>Products)
        {
            _Products = Products;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            choose = comboBox1.SelectedItem.ToString();
            sum = 0;
            if (choose == "price")
            {
                for (int i = 0; i < _Products.Count; i++)
                {
                    sum += _Products[i].price;
                    minprice = Math.Min(minprice, _Products[i].price);
                    maxprice = Math.Max(maxprice, _Products[i].price);
                }
            }
            else
            {
                for (int i = 0; i < _Products.Count; i++)
                {
                    sum += _Products[i].quantity;
                    minquantity = Math.Min(minquantity,_Products[i].quantity);
                    maxquantity = Math.Max(maxquantity, _Products[i].quantity);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = (sum / _Products.Count).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (choose == "price")
            {
                textBox4.Text = maxprice.ToString();
            }
            
            else
            {
                textBox4.Text = maxquantity.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (choose == "price")
            {
                textBox3.Text = minprice.ToString();
            }
            else
            {
                textBox3.Text = minquantity.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tmp = textBox8.Text;
            string[] IN = tmp.Split('/');
            Form7 f7 = new Form7(_Products, IN, choose);
            f7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = sum.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string tmp = textBox5.Text;
            List<string> N = new List<string>();
            List<Product> _Star = new List<Product>();
            string[] Command = tmp.Split(' ');
            
            if (Command[0].ToLower() == "select" && (Command[1].ToLower() == "name" || Command[1].ToLower() == "quantity" || Command[1].ToLower() == "price" || Command[1] == "*") && Command[2].ToLower() == "from" && Command[3].ToLower() == "product" && Command[4].ToLower() == "where" && (Command[5].ToLower() == "name" || Command[5].ToLower() == "price" || Command[5].ToLower() == "quantity") && (Command[6] == "<" || Command[6] == ">" || Command[6] == "=" || Command[6] == "!="))
            {
                N.Clear();
                _Star.Clear();
                for (int i = 0; i < _Products.Count; i++)
                {
                    if (Command[5].ToLower() == "price")
                    {
                        if (Command[6] == "<")
                        {
                            if (int.Parse(Command[7]) > _Products[i].price)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                        else if (Command[6] == ">")
                        {
                            if (int.Parse(Command[7]) < _Products[i].price)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                        else if (Command[6] == "=")
                        {
                            if (int.Parse(Command[7]) == _Products[i].price)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                        else
                        {
                            if (int.Parse(Command[7]) != _Products[i].price)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }

                    }
                    else if (Command[5].ToLower() == "quantity")
                    {
                        if (Command[6] == "<")
                        {
                            if (int.Parse(Command[7]) > _Products[i].quantity)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);

                            }
                        }
                        else if (Command[6] == ">")
                        {
                            if (int.Parse(Command[7]) < _Products[i].quantity)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                        else if (Command[6] == "=")
                        {
                            if (int.Parse(Command[7]) == _Products[i].quantity)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                        else
                        {
                            if (int.Parse(Command[7]) != _Products[i].quantity)
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                    }
                    else if (Command[5].ToLower() == "name")
                    {

                        if (Command[6] == "=")
                        {
                            if (Command[7].ToLower() == _Products[i].name.ToLower())
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                        else
                        {
                            if (Command[7].ToLower() != _Products[i].name.ToLower())
                            {
                                if (Command[1].ToLower() == "price") N.Add(_Products[i].price.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Products[i].name.ToString());
                                if (Command[1].ToLower() == "quantity") N.Add(_Products[i].quantity.ToString());
                                if (Command[1] == "*") _Star.Add(_Products[i]);
                            }
                        }
                    }
                }
                Form10 f10 = new Form10(N,_Star);
                f10.Show();
            }
            else MessageBox.Show("Syntax Error !");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (cond2.Count != 0 && cond.Count == 0)
            {
                _Tmp.Clear();
                for (int i = 0; i < _Products.Count; i++)  // OR
                {
                    bool Take = false;
                    for (int j = 0; j < cond2.Count; j++)
                    {
                        int D = int.Parse(cond2[j].Item1);
                        if (choose == "price")
                        {
                            if (cond2[j].Item2 == ">")
                            {
                                if (D < _Products[i].price)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "<")
                            {
                                if (D > _Products[i].price)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "=")
                            {
                                if (D == _Products[i].price)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "!=")
                            {
                                if (D != _Products[i].price)
                                    Take = true;
                            }
                        }
                        else if (choose == "quantity")
                        {
                            if (cond2[j].Item2 == ">")
                            {
                                if (D < _Products[i].quantity)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "<")
                            {
                                if (D > _Products[i].quantity)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "=")
                            {
                                if (D == _Products[i].quantity)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "!=")
                            {
                                if (D != _Products[i].quantity)
                                    Take = true;
                            }
                        }
                    }
                    if (Take)
                        _Tmp.Add(_Products[i]);
                }
            }
            if (cond2.Count == 0 && cond.Count != 0)
            {
                _Tmp.Clear();
                for (int i = 0; i < _Products.Count; i++)    //And
                {
                    bool Take = true;
                    for (int j = 0; j < cond.Count; j++)
                    {
                        int D = int.Parse(cond[j].Item1);
                        if (choose == "price")
                        {
                            if (cond[j].Item2 == ">")
                            {
                                if (D > _Products[i].price)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "<")
                            {
                                if (D < _Products[i].price)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "=")
                            {
                                if (D != _Products[i].price)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "!=")
                            {
                                if (D == _Products[i].price)
                                    Take = false;
                            }
                        }
                        else if (choose == "quantity")
                        {
                            if (cond[j].Item2 == ">")
                            {
                                if (D > _Products[i].quantity)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "<")
                            {
                                if (D < _Products[i].quantity)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "=")
                            {
                                if (D != _Products[i].quantity)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "!=")
                            {
                                if (D == _Products[i].quantity)
                                    Take = false;
                            }
                        }
                    }
                    if (Take)
                        _Tmp.Add(_Products[i]);
                }
            }
            bool Q = false;
            if (cond.Count == 0 && cond2.Count == 0)
            {
                _Tmp = _Products;
                Q = true;
            }
            cond.Clear();
            cond2.Clear();
            Form7 f7 = new Form7(_Tmp, choose, comboBox2.SelectedItem.ToString(), textBox6.Text, Q);
            f7.Show();
        }

        private void button9_Click(object sender, EventArgs e) // or
        {
            cond2.Add(new Tuple<string, string>(textBox6.Text, comboBox2.SelectedItem.ToString()));
            textBox6.Clear();
        }

        private void button10_Click(object sender, EventArgs e) // and
        {
            cond.Add(new Tuple<string, string>(textBox6.Text, comboBox2.SelectedItem.ToString()));
            textBox6.Clear();
        }
    }
}

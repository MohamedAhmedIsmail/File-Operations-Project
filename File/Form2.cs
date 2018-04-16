using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using System.IO;
namespace File
{
    public partial class Form2: Form
    {
        double minSalary = 10e10, maxSalary = -1;
        int minAge = 200, maxAge = 0, minH = 500000, maxH = 0;
        double sum = 0;
       public string choose;
        DataSet Ds = new DataSet();
        List<Employee> _Employees , _Tmp = new List<Employee>();
        List<Tuple<string, string>> cond = new List<Tuple<string, string>>();
        List<Tuple<string, string>> cond2 = new List<Tuple<string, string>>();
        public Form2(List<Employee> Employees)
        {
            _Employees = Employees;
            InitializeComponent();  
        }
        public Form2()
        {
            InitializeComponent();
        }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choose = comboBox1.SelectedItem.ToString();
            sum = 0;
            if (choose == "Salary")
            {
                for (int i = 0; i < _Employees.Count; i++)
                {
                    sum += _Employees[i].salary;
                    minSalary = Math.Min(minSalary, _Employees[i].salary);
                    maxSalary = Math.Max(maxSalary, _Employees[i].salary);
                }
            }
            else if (choose == "Age")
            {
                for (int i = 0; i < _Employees.Count; i++)
                {
                    sum += _Employees[i].age;
                    minAge = Math.Min(minAge, _Employees[i].age);
                    maxAge = Math.Max(maxAge, _Employees[i].age);
                }
            }
            else
            {
                for (int i = 0; i < _Employees.Count; i++)
                {
                    sum += _Employees[i].hourswork;
                    minH = Math.Min(minH, _Employees[i].hourswork);
                    maxH = Math.Max(maxH, _Employees[i].hourswork);
                }
            }
        }
       // string selected = listBox1.GetItemText(listBox1.SelectedItem);

       

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = (sum / _Employees.Count).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (choose == "Salary")
            {
                textBox3.Text = minSalary.ToString();
            }
            else if (choose == "Age")
            {
                textBox3.Text = minAge.ToString();
            }
            else
            {
                textBox3.Text = minH.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (choose == "Salary")
            {
                textBox4.Text = maxSalary.ToString();
            }
            else if (choose == "Age")
            {
                textBox4.Text = maxAge.ToString();
            }
            else
            {
                textBox4.Text = maxH.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tmp=textBox8.Text;
            string []IN = tmp.Split('/');
            Form3 f3 = new Form3(_Employees,IN,choose);
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = sum.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (cond2.Count != 0 && cond.Count == 0)
            {
                _Tmp.Clear();
                for (int i = 0; i < _Employees.Count; i++)  // OR
                {
                    bool Take = false;
                    for (int j = 0; j < cond2.Count; j++)
                    {
                        int D = int.Parse(cond2[j].Item1);
                        if (choose == "Salary")
                        {
                            if (cond2[j].Item2 == ">")
                            {
                                if (D < _Employees[i].salary)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "<")
                            {
                                if (D > _Employees[i].salary)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "=")
                            {
                                if (D == _Employees[i].salary)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "!=")
                            {
                                if (D != _Employees[i].salary)
                                    Take = true;
                            }
                        }
                        else if (choose == "Age")
                        {
                            if (cond2[j].Item2 == ">")
                            {
                                if (D < _Employees[i].salary)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "<")
                            {
                                if (D > _Employees[i].salary)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "=")
                            {
                                if (D == _Employees[i].salary)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "!=")
                            {
                                if (D != _Employees[i].salary)
                                    Take = true;
                            }
                        }
                    }
                    if (Take)
                        _Tmp.Add(_Employees[i]);
                }
            }
            if (cond2.Count == 0&&cond.Count!=0)
            {
                _Tmp.Clear();
                for (int i = 0; i < _Employees.Count; i++)    //And
                {
                    bool Take = true;
                    for (int j = 0; j < cond.Count; j++)
                    {
                        int D = int.Parse(cond[j].Item1);
                        if (choose == "Salary")
                        {
                            if (cond[j].Item2 == ">")
                            {
                                if (D > _Employees[i].salary)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "<")
                            {
                                if (D < _Employees[i].salary)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "=")
                            {
                                if (D != _Employees[i].salary)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "!=")
                            {
                                if (D == _Employees[i].salary)
                                    Take = false;
                            }
                        }
                        else if (choose == "Age")
                        {
                            if (cond[j].Item2 == ">")
                            {
                                if (D > _Employees[i].age)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "<")
                            {
                                if (D < _Employees[i].age)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "=")
                            {
                                if (D != _Employees[i].age)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "!=")
                            {
                                if (D == _Employees[i].age)
                                    Take = false;
                            }
                        }
                    }
                    if (Take)
                        _Tmp.Add(_Employees[i]);
                }
            }
            bool Q = false;
            if (cond.Count == 0 && cond2.Count == 0)
            {
                _Tmp = _Employees; 
                Q=true; 
            }
            cond.Clear();
            cond2.Clear();
            Form3 f3 = new Form3(_Tmp,choose,comboBox2.SelectedItem.ToString(),textBox6.Text ,Q );
            f3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cond.Add(new Tuple<string, string>(textBox6.Text, comboBox2.SelectedItem.ToString()));
            textBox6.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cond2.Add(new Tuple<string, string>(textBox6.Text, comboBox2.SelectedItem.ToString()));
            textBox6.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string tmp = textBox7.Text;
            List<string> N=new List<string>();
            List<Employee> _Star = new List<Employee>();
            string[] Command = tmp.Split(' ');
            if (Command[0].ToLower() == "select" && (Command[1].ToLower() == "age" || Command[1].ToLower() == "salary" || Command[1].ToLower() == "hourswork" || Command[1].ToLower() == "name" || Command[1] == "*") && Command[2].ToLower() == "from" && Command[3].ToLower() == "employee" && Command[4].ToLower() == "where" && (Command[5].ToLower() == "age" || Command[5].ToLower() == "salary" || Command[5].ToLower() == "hourswork" || Command[5].ToLower() == "name") && (Command[6] == "<" || Command[6] == ">" || Command[6] == "=" || Command[6] == "!="))
            {
                N.Clear();
                _Star.Clear();
                for (int i = 0; i < _Employees.Count; i++)
                {
                    if (Command[5].ToLower() == "salary")
                    {
                        if (Command[6] == "<")
                        {
                            if (int.Parse(Command[7]) > _Employees[i].salary)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else if (Command[6] == ">")
                        {
                            if (int.Parse(Command[7]) < _Employees[i].salary)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else  if (Command[6] == "=")
                        {
                            if (int.Parse(Command[7]) == _Employees[i].salary)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else 
                        {
                            if (int.Parse(Command[7]) != _Employees[i].salary)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }

                    }
                    else if (Command[5].ToLower() == "age")
                    {
                        if (Command[6] == "<")
                        {
                            if (int.Parse(Command[7]) > _Employees[i].age)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else if (Command[6] == ">")
                        {
                            if (int.Parse(Command[7]) < _Employees[i].age)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else if (Command[6] == "=")
                        {
                            if (int.Parse(Command[7]) == _Employees[i].age)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else
                        {
                            if (int.Parse(Command[7]) != _Employees[i].age)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }

                    }
                    else if (Command[5].ToLower() == "name")
                    {
                        
                         if (Command[6] == "=")
                        {
                            if (Command[7] == _Employees[i].name)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else
                        {
                            if (Command[7] != _Employees[i].name)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }

                    }
                    if (Command[5].ToLower() == "hourswork")
                    {
                        if (Command[6] == "<")
                        {
                            if (int.Parse(Command[7]) > _Employees[i].hourswork)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else if (Command[6] == ">")
                        {

                            if (int.Parse(Command[7]) < _Employees[i].hourswork)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else if (Command[6] == "=")
                        {
                            if (int.Parse(Command[7]) == _Employees[i].hourswork)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                        else
                        {
                            if (int.Parse(Command[7]) != _Employees[i].hourswork)
                            {
                                if (Command[1].ToLower() == "age") N.Add(_Employees[i].age.ToString());
                                if (Command[1].ToLower() == "salary") N.Add(_Employees[i].salary.ToString());
                                if (Command[1].ToLower() == "hourswork") N.Add(_Employees[i].hourswork.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_Employees[i].name.ToString());
                                if (Command[1] == "*") _Star.Add(_Employees[i]);
                            }
                        }
                    }
                }
                Form8 f8 = new Form8(N,_Star);
                f8.Show();
            }
            else MessageBox.Show("Syntax Error !");

        }
        }

    }


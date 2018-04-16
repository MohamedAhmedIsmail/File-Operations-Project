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
    public partial class Form3 : Form
    {
        int q = 0;
        bool Q;
        string[] tmp;
        string ch;
        List<Employee> _Employees = new List<Employee>();
        string temp,tmpp;
        public Form3(List<Employee> Employees , string [] IN , string choose)
        {
            _Employees = Employees;
            tmp=IN;
            ch = choose;
            q=0;
            InitializeComponent();  
        }
        public Form3(List<Employee> Employees, string cho , string tmp ,string text , bool ok)
        {
            _Employees = Employees;
           temp=tmp;
            q=1;
            ch=cho;
            Q = ok;
            tmpp = text;
            InitializeComponent();  
        }
        public Form3()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (q == 0)
            {
                List<Employee> Emp = new List<Employee>();
                if (ch == "Salary")
                {
                    Emp.Clear();
                    foreach (string num in tmp)
                    {
                        double D = double.Parse(num);

                        for (int i = 0; i < _Employees.Count; i++)
                        {

                            if (D == _Employees[i].salary)
                            {
                                Emp.Add(_Employees[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = Emp;
                }
                else if (ch == "Age")
                {
                    Emp.Clear();
                    foreach (string num in tmp)
                    {
                        double D = double.Parse(num);

                        for (int i = 0; i < _Employees.Count; i++)
                        {

                            if (D == _Employees[i].age)
                            {
                                Emp.Add(_Employees[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = Emp;
                }
                else if (ch == "Hours Work")
                {
                    Emp.Clear();
                    foreach (string num in tmp)
                    {
                        double D = double.Parse(num);

                        for (int i = 0; i < _Employees.Count; i++)
                        {

                            if (D == _Employees[i].hourswork)
                            {
                                Emp.Add(_Employees[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = Emp;
                }
                else
                {
                    Emp.Clear();
                    foreach (string num in tmp)
                    {
                        string D = num;

                        for (int i = 0; i < _Employees.Count; i++)
                        {

                            if (D == _Employees[i].name)
                            {
                                Emp.Add(_Employees[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = Emp;

                }
            }
            else if(Q==true)
            {    
                List<Employee> Emp = new List<Employee>();
                if (ch == "Salary")
                {
                    if (temp == ">")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d < _Employees[i].salary)
                                Emp.Add(_Employees[i]);
                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "<")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d > _Employees[i].salary)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d == _Employees[i].salary)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "!=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d != _Employees[i].salary)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                }
                else if (ch == "Age")
                {
                    Emp.Clear();
                    if (temp == ">")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d < _Employees[i].age)
                                Emp.Add(_Employees[i]);
                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "<")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d > _Employees[i].age)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d == _Employees[i].age)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "!=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d != _Employees[i].age)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                }
                else
                {
                    Emp.Clear();
                    if (temp == ">")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d < _Employees[i].hourswork)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "<")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d > _Employees[i].hourswork)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d == _Employees[i].hourswork)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                    if (temp == "!=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Employees.Count; i++)
                        {
                            if (d != _Employees[i].hourswork)
                                Emp.Add(_Employees[i]);

                        }
                        dataGridView1.DataSource = Emp;
                    }
                }
            }
            else
            dataGridView1.DataSource = _Employees;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

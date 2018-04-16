// FILE

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

namespace File
{
    public partial class Form1 : Form
    {
        DataSet Ds = new DataSet();
        int E_row = 0;
        List<Employee> Employees = new List<Employee>();
        List<Student> std = new List<Student>();
        List<Product> pro = new List<Product>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string choose;
            choose = comboBox1.SelectedItem.ToString();
            Ds.Clear();
            Ds.ReadXml("Tables.xml");
            
            
           
            if(choose=="Employee Table")
            {
                if (Ds.Tables[0].Rows[0][0].ToString() == "") { Ds.Clear();
                Ds.ReadXml("Tables.xml");
                }
                dataGridView1.DataSource = Ds.Tables[0];
            }
            else if (choose == "Student Table")
            {
                if (Ds.Tables[1].Rows[0][0].ToString() == "")
                {
                    Ds.Clear();
                    Ds.ReadXml("Tables.xml");
                }
                dataGridView1.DataSource = Ds.Tables[1];
            }
            else
            {
                if (Ds.Tables[2].Rows[0][0].ToString() == "")
                {
                    Ds.Clear();
                    Ds.ReadXml("Tables.xml");
                }
                dataGridView1.DataSource = Ds.Tables[2];
            }            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            
            string choose;
            choose = comboBox1.SelectedItem.ToString();
            if (choose == "Employee Table")
            {
                Employees.Clear();
                for (int i = 0; i < Ds.Tables[0].Rows.Count -1; i++)
                {
                    Employee em = new Employee();
                    em.Id = Ds.Tables[0].Rows[i][0].ToString();
                    em.name = Ds.Tables[0].Rows[i][1].ToString();
                    em.age = int.Parse(Ds.Tables[0].Rows[i][2].ToString());
                    em.salary = double.Parse(Ds.Tables[0].Rows[i][3].ToString());
                    em.hourswork = int.Parse(Ds.Tables[0].Rows[i][4].ToString());
                    Employees.Add(em);
                }
                 Form2 f2 = new Form2(Employees);
                f2.Show();
            }
            else if (choose == "Student Table")
            {
                std.Clear();
                for (int i = 0; i < Ds.Tables[1].Rows.Count-1 ; i++)
                {
                    Student S = new Student();
                    S.name = Ds.Tables[1].Rows[i][0].ToString();
                    S.Gender = Ds.Tables[1].Rows[i][2].ToString();
                    S.grades = double.Parse(Ds.Tables[1].Rows[i][1].ToString());
                   
                    std.Add(S);
                }
                Form4 f4 = new Form4(std);
                f4.Show();
            }
            else
            {
                pro.Clear();
                for (int i = 0; i < Ds.Tables[2].Rows.Count-1; i++)
                {
                    Product pr = new Product();
                    pr.name = Ds.Tables[2].Rows[i][0].ToString();
                    pr.price =int.Parse( Ds.Tables[2].Rows[i][1].ToString());
                    pr.quantity =int.Parse(Ds.Tables[2].Rows[i][2].ToString());

                    pro.Add(pr);
                }
                Form6 f6 = new Form6(pro);
                f6.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

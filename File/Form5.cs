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
    public partial class Form5 : Form
    {
        int q = 0;
        bool Q;
        string temp, tmpp;
        string[] tmp;
        string ch;
        List<Student> _Student = new List<Student>();
        public Form5(List<Student> std , string [] IN , string choose)
        {
            _Student = std;
            q = 0;
            tmp=IN;
            ch = choose;
            InitializeComponent();  
        }
        public Form5(List<Student> stundent, string cho, string tmp, string text, bool ok)
        {
            _Student = stundent;
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
                List<Student> std = new List<Student>();
                if (ch == "Grades")
                {
                    std.Clear();
                    foreach (string num in tmp)
                    {
                        double D = double.Parse(num);

                        for (int i = 0; i < _Student.Count; i++)
                        {

                            if (D == _Student[i].grades)
                            {
                                std.Add(_Student[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = std;
                }
                else if (ch == "Name")
                {
                    std.Clear();
                    foreach (string num in tmp)
                    {
                        string D = (num);

                        for (int i = 0; i < _Student.Count; i++)
                        {

                            if (D == _Student[i].name)
                            {
                                std.Add(_Student[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = std;
                }
                else if (ch == "Gender")
                {
                    std.Clear();
                    foreach (string num in tmp)
                    {
                        string D = num;

                        for (int i = 0; i < _Student.Count; i++)
                        {

                            if (D == _Student[i].Gender)
                            {
                                std.Add(_Student[i]);
                            }
                        }
                    }
                    dataGridView1.DataSource = std;
                }
            }
            else if (Q == true)
            {
                List<Student> stdn = new List<Student>();
                if (ch == "Grades")
                {
                    if (temp == ">")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Student.Count; i++)
                        {
                            if (d < _Student[i].grades)
                            {
                                stdn.Add(_Student[i]);
                            }
                        }
                        dataGridView1.DataSource = stdn;
                    }
                    if (temp == "<")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Student.Count; i++)
                        {
                            if (d > _Student[i].grades)
                                stdn.Add(_Student[i]);

                        }
                        dataGridView1.DataSource = stdn;
                    }
                    if (temp == "=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Student.Count; i++)
                        {
                            if (d == _Student[i].grades)
                                stdn.Add(_Student[i]);
                        }
                        dataGridView1.DataSource = stdn;
                    }
                    if (temp == "!=")
                    {
                        int d = int.Parse(tmpp);
                        for (int i = 0; i < _Student.Count; i++)
                        {
                            if (d != _Student[i].grades)
                                stdn.Add(_Student[i]);
                        }
                        dataGridView1.DataSource = stdn;
                    }
                }
            }
                else
                 dataGridView1.DataSource = _Student;
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

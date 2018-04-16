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
    public partial class Form4 : Form
    {

        double minGrade = 10e10, maxGrade = -1;
        double sum = 0;
        public string choose;
        List<Student> _student,_Tmp = new List<Student>();
        List<Tuple<string, string>> cond = new List<Tuple<string, string>>();
        List<Tuple<string, string>> cond2 = new List<Tuple<string, string>>();
        public Form4(List<Student> std)
        {
            _student = std;
            InitializeComponent();  
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sum = 0;
            choose = comboBox1.SelectedItem.ToString();
            if (choose == "Grades")
            {
                for (int i = 0; i < _student.Count; i++)
                {
                
                    sum += _student[i].grades;
                    minGrade = Math.Min(minGrade, _student[i].grades);
                    maxGrade = Math.Max(maxGrade, _student[i].grades);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = (sum / _student.Count).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = minGrade.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = maxGrade.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tmp = textBox5.Text;
            string[] IN = tmp.Split('/');
            Form5 f5 = new Form5(_student, IN, choose);
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
             string tmp = textBox6.Text;
            List<string> N=new List<string>();
            string[] Command = tmp.Split(' ');
            List<Student> _Star = new List<Student>();
            if (Command[0].ToLower() == "select" && (Command[1].ToLower() == "name" || Command[1].ToLower() == "gender" || Command[1].ToLower() == "grade" || Command[1] == "*") && Command[2].ToLower() == "from" && Command[3].ToLower() == "student" && Command[4].ToLower() == "where" && (Command[5].ToLower() == "name" || Command[5].ToLower() == "gender" || Command[5].ToLower() == "grade") && (Command[6] == "<" || Command[6] == ">" || Command[6] == "=" || Command[6] == "!="))
            {
                N.Clear();
                _Star.Clear();
                for (int i = 0; i < _student.Count; i++)
                {
                    if (Command[5].ToLower() == "grade")
                    {
                        if (Command[6] == "<")
                        {
                            if (int.Parse(Command[7]) > _student[i].grades)
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                        else if (Command[6] == ">")
                        {
                            if (int.Parse(Command[7]) < _student[i].grades)
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                        else  if (Command[6] == "=")
                        {
                            if (int.Parse(Command[7]) == _student[i].grades)
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                        else 
                        {
                            if (int.Parse(Command[7]) != _student[i].grades)
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }

                    }
                    else if (Command[5].ToLower() == "gender")
                    {  
                         if (Command[6] == "=")
                        {
                            if (Command[7].ToLower() == _student[i].Gender.ToLower())
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                        else
                        {
                            if (Command[7].ToLower() != _student[i].Gender.ToLower())
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                    }
                    else if (Command[5].ToLower() == "name")
                    {
                        
                         if (Command[6] == "=")
                        {
                            if (Command[7].ToLower() == _student[i].name.ToLower())
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                        else
                        {
                            if (Command[7].ToLower() != _student[i].name.ToLower())
                            {
                                if (Command[1].ToLower() == "grade") N.Add(_student[i].grades.ToString());
                                if (Command[1].ToLower() == "name") N.Add(_student[i].name.ToString());
                                if (Command[1].ToLower() == "gender") N.Add(_student[i].Gender.ToString());
                                if (Command[1] == "*") _Star.Add(_student[i]);
                            }
                        }
                    }
                }
                Form9 f9 = new Form9(N,_Star);
                f9.Show();
            }
            else MessageBox.Show("Syntax Error !");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (cond2.Count != 0 && cond.Count == 0)
            {
                _Tmp.Clear();
                for (int i = 0; i < _student.Count; i++)  // OR
                {
                    bool Take = false;
                    for (int j = 0; j < cond2.Count; j++)
                    {
                        int D = int.Parse(cond2[j].Item1);
                        if (choose == "Grades")
                        {
                            if (cond2[j].Item2 == ">")
                            {
                                if (D < _student[i].grades)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "<")
                            {
                                if (D > _student[i].grades)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "=")
                            {
                                if (D == _student[i].grades)
                                    Take = true;
                            }
                            else if (cond2[j].Item2 == "!=")
                            {
                                if (D != _student[i].grades)
                                    Take = true;
                            }
                        }

                    }
                    if (Take)
                        _Tmp.Add(_student[i]);
                }
            }
            if (cond2.Count == 0 && cond.Count != 0)
            {
                _Tmp.Clear();
                for (int i = 0; i < _student.Count; i++)    //And
                {
                    bool Take = true;
                    for (int j = 0; j < cond.Count; j++)
                    {
                        int D = int.Parse(cond[j].Item1);
                        if (choose == "Grades")
                        {
                            if (cond[j].Item2 == ">")
                            {
                                if (D > _student[i].grades)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "<")
                            {
                                if (D < _student[i].grades)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "=")
                            {
                                if (D != _student[i].grades)
                                    Take = false;
                            }
                            else if (cond[j].Item2 == "!=")
                            {
                                if (D == _student[i].grades)
                                    Take = false;
                            }
                        }
                       
                    }
                    if (Take)
                        _Tmp.Add(_student[i]);
                }
            }
            bool Q = false;
            if (cond.Count == 0 && cond2.Count == 0)
            {
                _Tmp = _student;
                Q = true;
            }
            cond.Clear();
            cond2.Clear();
            Form5 f5 = new Form5(_Tmp, choose, comboBox2.SelectedItem.ToString(), textBox7.Text, Q);
            f5.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cond2.Add(new Tuple<string, string>(textBox7.Text, comboBox2.SelectedItem.ToString()));
            textBox7.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cond.Add(new Tuple<string, string>(textBox7.Text, comboBox2.SelectedItem.ToString()));
            textBox7.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

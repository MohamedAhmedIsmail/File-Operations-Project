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
    public partial class Form8 : Form
    {
        public class MyOutput
        {
            public string output { get; set; }
            public MyOutput()
            {
                output = " ";
            }
        };
        List<MyOutput> tmp=new List<MyOutput>();
        List<Employee> _s = new List<Employee>();
        public Form8(List<string> t, List<Employee> _S)
        {
            for (int i = 0; i < t.Count; i++)
            {
                MyOutput inn=new MyOutput();
                inn.output = t[i];
                tmp.Add(inn);
            }
            _s = _S;
            InitializeComponent();
        }
        public Form8()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_s.Count == 0)
                dataGridView1.DataSource = tmp;
            else
                dataGridView1.DataSource = _s;
        }
    }
}

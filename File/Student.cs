using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    public class Student
    {
        public string name { get; set; }
        public double grades { get; set; }
        public string Gender { get; set; }
  
       public Student()
        {
            name = "";
            grades = 0;
            Gender = "Male";
        }
       public Student(string n, double gr, string ge)
       {
           name = n;
           grades = gr;
           Gender = ge;
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    public class Employee
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public double salary { get; set; }
        public int hourswork { get; set; }
  
       public Employee()
        {
            Id = name = "";
            salary=hourswork = 0;
        }
       public Employee(string i, string n, double s, int h)
        {
            Id = i;
            name = n;
            salary = s;
            hourswork = h;
        }
    }
}

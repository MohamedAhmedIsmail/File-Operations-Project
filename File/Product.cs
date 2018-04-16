using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
  public  class Product
    {
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public Product()
        {
            name = "";
            price = quantity = 0;
        }
        public Product(string n, int p, int q)
        {
            name = n;
            price = p;
            quantity = q;
        }

    }
}

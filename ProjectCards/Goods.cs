using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
    internal class Goods
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public Goods(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}
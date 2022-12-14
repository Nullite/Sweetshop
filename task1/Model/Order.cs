using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Model
{
    internal class Order
    {
        public int ID;
        public DateTime Date;
        public string Client;
        public List<Product> Products;
        public decimal Price { get => Products.Sum(p => p.Price); }
    }
}

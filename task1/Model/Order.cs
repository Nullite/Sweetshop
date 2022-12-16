using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Model
{
    internal class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public ObservableCollection<OrderProduct> Products;
        public decimal Price { get => Products.Sum(p => p.product.Price * p.Quantity); }
        public decimal Quantity => Products.Count;
    }
}

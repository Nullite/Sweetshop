using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Model
{
    public class OrderProduct : NotifyClass
    {
        private int _quantity;
        public Product Product { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged("Price");
            }
        }
        public decimal Price => Product.Price * Quantity;
    }
}

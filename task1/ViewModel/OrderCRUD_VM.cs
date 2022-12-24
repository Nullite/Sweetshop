using SweetShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.ViewModel
{
    internal class OrderCRUD_VM : NotifyClass
    {
        private OrderProduct _selectProduct;
        private Order _current;
        public OrderCRUD_VM(Order order = null)
        {
            _current = new Order();
            if (order != null)
            {
                _current.Products = new ObservableCollection<OrderProduct>(order.Products);
                _current.Client = order.Client;
                _current.Date = order.Date;
                _current.ID = order.ID;
            }
        }
        public Order Current 
        { 
            get => _current;
            private set => _current = value;
        }

        public int id
        {
            get => _current.ID;
            set
            {
                _current.ID = value;
                OnPropertyChanged();
            }
        }
        public string Client
        {
            get => _current.Client;
            set
            {
                _current.Client = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get => _current.Date;
            set
            {
                _current.Date = value;
                OnPropertyChanged();
            }
        }
        public decimal Price => _current.Price;
        public ObservableCollection<OrderProduct> Products
        {
            get => _current.Products;
            set
            {
                _current.Products = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public OrderProduct SelectProduct
        {
            get => _selectProduct;
            set
            {
                _selectProduct = value;
                OnPropertyChanged();
            }
        }
        public void Add(Product p)
        {
            var s = Products.FirstOrDefault(x => x.Product.ID == p.ID);
            if (s != null) ++s.Quantity;
            else Products.Add(new OrderProduct { Product = p, Quantity = 1});
            OnPropertyChanged("Price");
        }
        public void Delete()
        {
            Products.Remove(SelectProduct);
            OnPropertyChanged("Price");
        }
    }
}

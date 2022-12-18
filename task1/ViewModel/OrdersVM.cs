using SweetShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.ViewModel
{
    internal class OrdersVM: NotifyClass
    {
        private string _serachText;
        private List<Order> SearchOrdersByPruductName(ObservableCollection<Order> orders, string value)
        {
            List<Order> found = new List<Order>();
            if (value.Length == 0) return found;
            foreach (var order in orders)
            {
                List<OrderProduct> products = order.Products.ToList();
                for (int i = 0; i < products.Count; ++i)
                {
                    if (products[i].product.Name.ToLower().Contains(value.ToLower()))
                    {
                        found.Add(order);
                        break;
                    }
                }
            }
            return found;
        }
        public OrdersVM()
        {
            Orders = UsersDB.Context.Orders.ToList();
        }
        public List<Order> Orders { get; set; }
        public string SearchText
        {
            get => _serachText;
            set
            {
                _serachText = value;
                Orders = UsersDB.Context.Orders.Where(o => (int.TryParse(_serachText, out int ID) && o.ID == ID) 
                    || o.Client.ToLower().Contains(value.ToLower()) || (DateTime.TryParse(_serachText, out DateTime dt) && o.Date == dt) 
                    || _serachText == string.Empty).ToList();
                Orders.AddRange(SearchOrdersByPruductName(UsersDB.Context.Orders, value));
                OnPropertyChanged("Orders");
                OnPropertyChanged();
            }
        }
    }
}

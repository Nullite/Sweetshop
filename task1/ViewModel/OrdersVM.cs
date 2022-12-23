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
        public OrdersVM()
        {
            Orders = UsersDB.Context.Orders.ToList();
        }
        public List<Order> Orders { get; set; }
        public List<Order> SelectedOrders { get; set; }
        public string SearchText
        {
            get => _serachText;
            set
            {
                    _serachText = value;
                    OnPropertyChanged();             
            }
        }
        public void UpdateOrders()
        {
            Orders = UsersDB.Context.Orders.Where(o => SearchText == null
                    || (int.TryParse(SearchText, out int ID) && o.ID == ID)
                    || o.Client.ToLower().Contains(SearchText.ToLower())
                    || (DateTime.TryParse(SearchText, out DateTime dt) && o.Date == dt)
                    || o.Products.FirstOrDefault(p => p.Product.Name.ToLower().Contains(SearchText.ToLower()))!=null).ToList();
            OnPropertyChanged("Orders");
        }
        public void DeleteOrders()
        {
            foreach(var o in SelectedOrders)
            {
                UsersDB.Context.Orders.Remove(o);
            }           
            Orders = UsersDB.Context.Orders.ToList();
            SelectedOrders.Clear();
            OnPropertyChanged("Orders");
        }
    }
}

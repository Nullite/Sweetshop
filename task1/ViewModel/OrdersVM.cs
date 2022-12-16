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
        public OrdersVM ()
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
                Orders = UsersDB.Context.Orders.Where(o => (int.TryParse(_serachText, out int ID) && o.ID == ID) || _serachText == string.Empty).ToList();
                OnPropertyChanged("Orders");
                OnPropertyChanged();
            }
        }
    }
}

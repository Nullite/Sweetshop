using SweetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.ViewModel
{
    internal class OrderCRUD_VM : NotifyClass
    {
        private Order _current;
        public OrderCRUD_VM(Order order = null)
        {
            if (order == null) Current = new Order();
            else Current = order;
        }
        public Order Current 
        { 
            get => _current;
            private set => _current = value;
        }
    }
}

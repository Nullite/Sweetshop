using SweetShop.Model;
using SweetShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SweetShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersCRUD.xaml
    /// </summary>
    public partial class OrdersCRUD : UserControl
    {
        private OrderCRUD_VM _vm;
        public OrdersCRUD(Order order = null)
        {
            InitializeComponent();
            _vm = new OrderCRUD_VM(order);
            DataContext = _vm;
        }
    }
}

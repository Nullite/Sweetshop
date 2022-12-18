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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : UserControl
    {
        private OrdersVM _vm;
        public OrdersPage()
        {
            InitializeComponent();
            _vm = new OrdersVM();
            DataContext = _vm;
        }

        private void FindOrders(object sender, RoutedEventArgs e)
        {
            _vm.SearchText = SearchOrdersTextBox.Text;
        }
    }
}

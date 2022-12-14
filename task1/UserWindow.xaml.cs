using SweetShop.Pages;
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
using System.Windows.Shapes;

namespace SweetShop
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private PageContext _pageContext;
        public UserWindow()
        {
            InitializeComponent();
            _pageContext = new PageContext();
            DataContext = _pageContext;
            _pageContext.Add(new MainPage());
        }

        private void GetMainPage(object sender, RoutedEventArgs e)
        {
            _pageContext.ChangeRoot(new MainPage());
        }

        private void GetOrdersPage(object sender, RoutedEventArgs e)
        {
            _pageContext.ChangeRoot(new OrdersPage());
        }
    }
}

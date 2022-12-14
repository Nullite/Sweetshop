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
using SweetShop.ViewModel;

namespace SweetShop
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private AuthVM vm;
        public AuthWindow()
        {
            InitializeComponent();
            vm = new AuthVM();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           if ( vm.Auth(passBox.Password))
            {
                new UserWindow().Show();
                Owner.Close();
                Close();
            }
        }
    }
}

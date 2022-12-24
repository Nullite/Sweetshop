using SweetShop.Model;
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
    /// Логика взаимодействия для SelectProductWindow.xaml
    /// </summary>
    public partial class SelectProductWindow : Window
    {
        private List<INode> _nodes;
        private Product _selectProduct;
        public SelectProductWindow()
        {
            InitializeComponent();
            _nodes = new List<INode>(UsersDB.Context.Folders);
            ProductsTree.ItemsSource= _nodes;
        }
        public Product SelectProduct { get => _selectProduct; }

        private void Select(object sender, RoutedEventArgs e)
        {
            ProductNode Product = ProductsTree.SelectedItem as ProductNode;
            if (Product != null) _selectProduct = Product.Product;
            Close();
        }
    }
}

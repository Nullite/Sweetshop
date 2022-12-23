using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SweetShop
{
    internal class PageContext : NotifyClass
    {
        private static PageContext _currentPageContext = new PageContext();
        private Stack<UserControl> _pages = new Stack<UserControl> ();
        public UserControl Current { get; private set; }
        public void Add(UserControl page)
        {
            _pages.Push (page);
            Current = page;
            OnPropertyChanged("Current");
        }
        public static PageContext CurrentPageContext
        {
            get => _currentPageContext;
            set
            {
                if (_currentPageContext == null) _currentPageContext = value;
            }
        }
        public void Drop()
        {
            _pages.Pop();
            Current = _pages.Peek();
            OnPropertyChanged("Current");
        }
        public void Next(UserControl page)
        {
            Drop();
            Add(page);
        }
        public void Refresh(params object[] parameters)
        {
            Type pageType = Current.GetType();
            Current = Activator.CreateInstance(pageType, parameters) as UserControl;
        }
        public void ChangeRoot(UserControl page)
        {
            _pages.Clear();
            Add(page);
        }
    }
}

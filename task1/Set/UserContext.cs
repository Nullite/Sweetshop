using SweetShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    internal class UserContext
    {
        public User User { get; private set; }
        public static event PropertyChangedEventHandler PropertyChanged;
        private UserContext(User user)
        {
            User = user;
            CurrentUserContext = this;
            OnPropertyChanged("CurrentUserContext");
        }
        public static  UserContext CurrentUserContext { get; private set; }
        public void Clear()
        {
            CurrentUserContext = null;
        }
        public static void Create(User user)
        {
            if (CurrentUserContext != null)
            {
                new UserContext(user);
            }
        }
        public static void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(CurrentUserContext, new PropertyChangedEventArgs(property));
        }
    }
}

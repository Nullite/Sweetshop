using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetShop.Model;

namespace SweetShop
{
    internal class GLOBAL
    {
        private static User _user;
        public static User User
        {
            get { return _user; }
            set { if (value != null) _user = value; }
        }
    }
}

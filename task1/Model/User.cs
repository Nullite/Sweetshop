using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Model
{
    internal class User
    {
        public User (string name, string password, string login)
        {
            Name = name;
            Password = password;
            Login = login;
        }
        string Password { get; set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public bool IsAuth(string pass) => pass == Password;

    }
}

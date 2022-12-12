using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Model
{
    internal class UsersDB
    {
        public List<User> Users { get; set; } = new List<User>()
        {
            new User ("Anonimus","12345","anon"),
            new User ("User","uSeR","user"),
            new User ("Null","password","login"),
            new User ("Human","102030","hum"),
            new User ("Vasja","gop","stop"),
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SweetShop.Model;

namespace SweetShop.ViewModel
{
    internal class AuthVM : NotifyClass
    {
        const int FAIL_COUNT = 3;
        const int PAUSE = 10;
        private int _fail_Count;
        private string _message;
        private bool _isEnabledAuth;
        private string _userName { get; set; }
        public AuthVM()
        {
            Message = "";
            FailCount = FAIL_COUNT;
            IsEnabledAuth = true;
        }
        public string UserLogin { get; set; }
        public int FailCount
        {
            get => _fail_Count;
            set
            {
                if (value > 0)
                {
                    _fail_Count = value;
                    Message = $"Auth tries: {_fail_Count}";
                }
                else
                {
                    FailCount = FAIL_COUNT;
                    var t = StartPause();
                }
                
            }
        }
        public string UserName
        {
            get => _userName;
            set 
            { 
                _userName = value; 
                OnPropertyChanged(); 
            }
        }
        public string Message
        {
            get => _message;
            set 
            {   _message = value;
                OnPropertyChanged();
            }
        }
        private async Task StartPause()
        {
            IsEnabledAuth = false;
            for (int i = PAUSE; i >= 0; --i)
            {
                Message = $"Athorization blocked on {i} seconds";
                await Task.Delay(1000);
            }
            Message = $"Auth tries: {_fail_Count}";
            IsEnabledAuth = true;
        }
        public bool IsEnabledAuth
        {
            get => _isEnabledAuth;
            set
            {
                _isEnabledAuth = value;
                OnPropertyChanged();
            }
        }
        public bool Auth(string pass)
        {
            --FailCount;
            if (UserLogin == null || pass == null) return false;

            UsersDB context = new UsersDB();
            User access = context.Users.Where(user => user.Login == UserLogin).FirstOrDefault();

            if (access != null && access.IsAuth(pass))
            {
                GLOBAL.User = access;
                UserName = access.Name;
                return true;
            }
            return false;
        }
    }
}

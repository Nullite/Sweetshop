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
        //счетчик неудачных попыток входа
        const int FAIL_COUNT = 3;
        //Количесво секунд блокировки кнопки "Войти"
        const int PAUSE = 10;
        private int _fail_Count;
        private string _message;
        private bool _isEnabledAuth;
        private string _userName { get; set; }
        public AuthVM()
        {
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
                //при достижении счетчиком нуля сбасываем счетчик и запускаем асинхронный
                //метод блокироки кнопки входа.
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
            //при изменении UserName (привязан к textBlock.Text на форме AuthWindow) запускаем метод перерисовки компонентов на форме.
            set 
            { 
                _userName = value; 
                //Метод перерисовки унаследован от класса NotifyClass
                OnPropertyChanged(); 
            }
        }
        public string Message
        {
            get => _message;
            //при изменении Message (привязан к textBlock.Text на форме AuthWindow) запускаем метод перерисовки компонентов на форме.
            set
            {   _message = value;
                OnPropertyChanged();
            }
        }
        //Асинхронный метод блокировки кнопки входа на заданное количество секунд.
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
            //при изменении IsEnabledAuth (привязана к свойству Button.isEnabled на форме AuthWindow) запускаем метод перерисовки компонентов на форме.
            set
            {
                _isEnabledAuth = value;
                OnPropertyChanged();
            }
        }
        //Метод авторизации юзера в системе.
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

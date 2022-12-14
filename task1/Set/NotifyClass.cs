using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    internal class NotifyClass : INotifyPropertyChanged
    {
        //событие интерфейса INotifyPropertyChanged, информирующее систему о том, что какое-либо свойство было изменено.
        public event PropertyChangedEventHandler PropertyChanged;
        //метод, ответственный за перерисовку окна.
        protected virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

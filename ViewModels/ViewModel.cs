using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armandaa.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _textValue;
        public string TextValue
        {
            get { return _textValue; }
            set
            {
                _textValue = value;
                OnPropertyChanged("TextValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

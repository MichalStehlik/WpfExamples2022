using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf03Convertors.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _number;
        private string _text;

        public MainViewModel()
        {
            Number = 2;
        }

        public int Number 
        { 
            get 
            { 
                return _number; 
            } 
            set 
            { 
                _number = value;
                switch (_number)
                {
                    case 0: Text = "Nula"; break;
                    case 1: Text = "Jedna"; break;
                    case 2: Text = "Dva"; break;
                    case 3: Text = "Tři"; break;
                    case 4: Text = "Čtyři"; break;
                    default: Text = "Moc"; break;
                }
                NotifyPropertyChanged();
                NotifyPropertyChanged("Text2");
            } 
        }
        public string Text { get { return _text; } set { _text = value; NotifyPropertyChanged(); } }
        public string Text2 { get { return "XXXXX" + _number.ToString(); }  }
    }
}

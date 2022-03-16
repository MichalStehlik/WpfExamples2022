using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf04Commands.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Random _random = new Random();
        private int _number;

        public RelayCommand RollCommand { get; set; }

        public MainViewModel()
        {
            RollCommand = new RelayCommand(
                () =>
                {
                    Number = _random.Next(100);
                },
                () => { return true; }
                );
            Number = _random.Next(100);
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
                NotifyPropertyChanged();
            }
        }
    }
}

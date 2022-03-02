using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf02Binding.ViewModels
{
    internal class PanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _text;
        private double _size;

        public PanelViewModel()
        {
            TextValue = "Text";
            SizeValue = 12;
        }

        public string TextValue
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged(); }
        }

        public double SizeValue
        {
            get { return _size; }
            set { _size = value; NotifyPropertyChanged(); }
        }
    }
}

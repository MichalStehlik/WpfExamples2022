using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf05Collection.Models
{
    public class Student : INotifyPropertyChanged
    {
        private string _firstname;
        private string _lastname;
        private bool _examined;
        private Gender _gender;
        private double _average;
        public string Firstname { get { return _firstname; } set { _firstname = value; NotifyPropertyChanged(); } }
        public string Lastname { get { return _lastname; } set { _lastname = value; NotifyPropertyChanged(); } }
        public Gender Gender { get { return _gender; } set { _gender = value; NotifyPropertyChanged(); } }
        public double Average { get { return _average; } set { _average = value; NotifyPropertyChanged(); } }
        public bool Examined { get { return _examined; } set { _examined = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

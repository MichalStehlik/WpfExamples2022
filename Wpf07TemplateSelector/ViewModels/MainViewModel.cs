using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf07TemplateSelector.Models;

namespace Wpf07TemplateSelector.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Human> _people = new ObservableCollection<Human>();
        private int? _selectedIndex;
        private Human _selectedHuman;
        public ObservableCollection<Human> People { get { return _people; } set { _people = value; NotifyPropertyChanged(); } }

        public MainViewModel()
        {
            _people.Add(new Student { Firstname = "Adam", Lastname = "Novák", Classname = "P3" });
            _people.Add(new Student { Firstname = "Beáta", Lastname = "Pokorná", Classname = "P2" });
            _people.Add(new Teacher { Firstname = "Cyril", Lastname = "Vomáčka" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

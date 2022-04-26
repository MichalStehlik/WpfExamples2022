using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf08EntityFramework.Data;
using Wpf08EntityFramework.Models;

namespace Wpf08EntityFramework.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationDbContext Db { get; set; }
        private ObservableCollection<Book> _books;
        public MainViewModel()
        {

        }
        public ObservableCollection<Book> Books {
            get { return _books; }
            set { _books = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

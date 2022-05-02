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
        private Book _selectedBook;
        public RelayCommand ReloadCommand { get; set; }
        public ParametrizedRelayCommand<int> DeleteCommand { get; set; }
        public MainViewModel()
        {
            ReloadCommand = new RelayCommand(
                () => {
                    if (Db != null)
                    {
                        Books = new ObservableCollection<Book>(Db.Books.ToList());
                    }
                }
                );
            DeleteCommand = new ParametrizedRelayCommand<int>(
                (id) => {
                    if (Db != null)
                    {
                        Book b = Db.Books.Where(x => x.BookId == id).SingleOrDefault();
                        Db.Books.Remove(b);
                        Db.SaveChanges();
                        Books = new ObservableCollection<Book>(Db.Books.ToList());
                    }
                }
                );
        }
        public ObservableCollection<Book> Books {
            get { return _books; }
            set { _books = value; NotifyPropertyChanged(); }
        }
        public Book SelectedBook {
            get { return _selectedBook; }
            set { _selectedBook = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

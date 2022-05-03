using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Wpf08EntityFramework.Data;
using Wpf08EntityFramework.Models;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Wpf08EntityFramework.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationDbContext Db { get; set; }
        private ObservableCollection<Book> _books;
        private Book _selectedBook;
        public RelayCommand ReloadCommand { get; set; }
        public ParametrizedRelayCommand<int> DeleteCommand { get; set; }
        public ParametrizedRelayCommand<string> ExportCommand { get; set; }
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
            ExportCommand = new ParametrizedRelayCommand<string>(
                (filename) => {
                    if (Db != null)
                    {
                        // https://docs.microsoft.com/cs-cz/dotnet/csharp/programming-guide/interop/how-to-access-office-onterop-objects
                        // Syncfusion.XlsIO
                        /*
                        Excel.Application excel = new Excel.Application();
                        excel.Workbooks.Add();
                        Excel._Worksheet workSheet = (Excel.Worksheet)excel.ActiveSheet;
                        workSheet.Cells[1, "A"] = "ID";
                        workSheet.Cells[1, "B"] = "Název";
                        workSheet.Cells[1, "C"] = "Počet stran";
                        var books = Db.Books.ToList();
                        */
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

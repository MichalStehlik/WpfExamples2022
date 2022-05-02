using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf08EntityFramework.Data;
using Wpf08EntityFramework.Models;
using Wpf08EntityFramework.ViewModels;

namespace Wpf08EntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        internal MainWindow(ApplicationDbContext db)
        {          
            InitializeComponent();
            vm = (MainViewModel)DataContext;
            vm.Db = db;
            vm.ReloadCommand.Execute(null);
        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            Book newItem = (Book)e.NewItem;
            vm.Db.Books.Add(newItem);
            vm.Db.SaveChanges();
            vm.ReloadCommand.Execute(null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
                     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedBook != null)
            {
                EditWindow editWindow = new EditWindow();
                editWindow.DataContext = vm;
                editWindow.ShowDialog();
            }
        }
    }
}

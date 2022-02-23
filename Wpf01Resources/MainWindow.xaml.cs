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

namespace Wpf01Resources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnSecond.Content = this.FindResource("btnText");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //imgMain.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/02.jpg"));
            //imgMain.Source = new BitmapImage(new Uri("file:///C:/Images/02.jpg"));
            //imgMain.Source = new BitmapImage(new Uri("Images/02.jpg",UriKind.Relative));
            //imgMain.Source = (BitmapImage)this.FindResource("pic2");
            imgMain.Source = ((BitmapImage[])this.FindResource("pics"))[1];
        }
    }
}

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

namespace Wpf02Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 1. zpusob
        private void txtInput1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                var text = (sender as TextBox).Text;
                lblResult1.Content = text;
            }
        }

        private void sliSize1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider)
            {
                var size = (sender as Slider).Value;
                lblResult1.FontSize = size;
            }
        }
    }
}

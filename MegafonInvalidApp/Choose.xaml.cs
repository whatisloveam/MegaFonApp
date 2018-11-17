using MegafonInvalidApp.NavigationHelper;
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

namespace MegafonInvalidApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Choose : Page
    {
        public Choose()
        {
            InitializeComponent();
            
        }
        void OnClick1(object sender, RoutedEventArgs e)
        {
            //btn1.Background = Brushes.Pink;
        }
        void OnClick2(object sender, RoutedEventArgs e)
        {
            //btn2.Background = Brushes.Pink;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Service.Navigate(new Autorization());
        }
    }
}

using MegafonInvalidApp.NavigationHelper;
using MegafonInvalidApp.ViewModels;
using MegafonInvalidApp.ViewModels.Resolver;
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
using System.Windows.Shapes;

namespace MegafonInvalidApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Storage.WebClient = new System.Net.WebClient();
            this.Closing += (ev, csender) => Storage.WebClient.Dispose();
            Navigator.Service = MainFrame.NavigationService;
            DataContext = new MainViewModel(new ViewModelsResolver());
        }
    }
}

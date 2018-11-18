using MegafonInvalidApp.NavigationHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    /// 
    

    public partial class General : Page
    {
        ObservableCollection<OfferTask> items = new ObservableCollection<OfferTask>();
        string s;
        public General()
        {
            InitializeComponent();

            this.Loaded += (e, sender) =>
            {
                var x = Storage.SendPost("http://192.168.43.31/task.php", new Id { Identificator = Storage.CurrentProblemUser.Id });
                if (x.Contains("Data not exist"))
                    return;
                var deserialize = JsonConvert.DeserializeObject<List<OfferTask>>(x);
                deserialize.ForEach(items.Add);
            };
            //items.Add(new Work() { Title = "John Doe", Description = "GOD", Price = "100 $", DateDiff = "32 дня" });
            //items.Add(new Work() { Title = "Jane Doe", Description = "GOG", Price = "200$", DateDiff = "32 дня" });
            //items.Add(new Work() { Title = "Sammy Doe", Description = "SHOCK", Price = "300 $", DateDiff = "32 дня" });
            lvDataBinding.ItemsSource = items;
            lvDataBinding.MouseDoubleClick += (sender, ev) =>
            {
                var listItem = ev.Source;
                if(listItem is ListView item)
                {
                    Offers.Items.Add(item.SelectedItem as OfferTask);
                    var res = Storage.SendPost("http://192.168.43.31/delete.php", new Id { Identificator = (item.SelectedItem as OfferTask).Id });
                    items.Remove(item.SelectedItem as OfferTask);                  
                }
            };
        }

        private void LastName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LastName.Text == "Фамилия") LastName.Text = "";
        }

        private void FirstName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FirstName.Text == "Имя") FirstName.Text = "";
        }

        private void Otchestvo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Otchestvo.Text == "Отчество") Otchestvo.Text = "";
        }

        private void Refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            items.Clear();
            var x = Storage.SendPost("http://192.168.43.31/task.php", new Id { Identificator = Storage.CurrentProblemUser.Id });
            var deserialize = JsonConvert.DeserializeObject<List<OfferTask>>(x);
            deserialize.ForEach(items.Add);
        }
    }
}

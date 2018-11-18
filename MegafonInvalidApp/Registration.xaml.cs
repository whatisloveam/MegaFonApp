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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
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

        private void Email_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Email.Text == "Email") Email.Text = "";
        }

        private void Password_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RepeatPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Invite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Invite.Text == "Инвайт код") Invite.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((LastName.Text != "Фамилия") && (LastName.Text != "") && (FirstName.Text != "Имя") && (FirstName.Text != "") &&
               (Otchestvo.Text != "Отчество") && (Otchestvo.Text != "") && (Email.Text != "Email") && (Email.Text != "") &&
               (Password.Password != "Пароль") && (Password.Password != "") && (RepeatPassword.Password != "Пароль") && (RepeatPassword.Password != ""))
            {
                Navigator.Service.Navigate(new Registration2());
            }
                
        }
    }
}


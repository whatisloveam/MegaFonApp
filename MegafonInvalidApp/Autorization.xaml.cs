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
using System.Net;
using System.Collections.Specialized;
using System.IO;
using InvalidAppHttpClient.Example;
using InvalidAppHttpClient;
using InvalidAppHttpClient.Serializer;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;

namespace MegafonInvalidApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        string status;
        public static string path = @"C:\Users\Public\WriteLines2.txt";
        public Autorization()
        {
            InitializeComponent();
            DateTime startTime;

            string s;
            
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(System.DateTime.Now.ToString());
                tw.Close();
            }
            else
            {
                TextReader tr = new StreamReader(path);
                s = tr.ReadLine();
                startTime = DateTime.Parse(s);
                if (s == "") // empty file
                {
                    tr.Close();                    
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(System.DateTime.Now.ToShortTimeString());
                    tw.Close();
                }
                else
                {
                    TimeSpan span = System.DateTime.Now.Subtract(startTime);
                    if (span.Minutes >= 2)  // if timeout
                    {
                        tr.Close();
                        TextWriter tw = new StreamWriter(path);

                        tw.WriteLine(System.DateTime.Now.ToShortTimeString());//System.DateTime.Now.Minute.ToString());
                        tw.Close();
                    }
                    else  // autorized
                    {
                        tr.Close();
                        //grid.Visibility = Visibility.Hidden;
                        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                        dispatcherTimer.Tick += dispatcherTimer_Tick;
                        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                        //dispatcherTimer.Start();
                        
                    }

                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Navigator.Service.Navigate(new StartTest());
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Login_Box.Text == "") || (Password_Box.Text == ""))
            {
            }
            else
            {
                var user = new AuthUser { Mail = Login_Box.Text, Password = CreateMD5(Password_Box.Text).ToLower() };
                status = Storage.SendPost("http://192.168.43.31", user);
                if (status.Contains("wrong password or login")) // lox
                {
                    MessageBox.Show("Wrong password or username");
                }
                else // victory
                {
                    var results = JsonConvert.DeserializeObject<User>(status.ToString());
                    Login_Text.Text = results.Id + " " + results.Name + " __ " + results.Surname;

                    Storage.CurrentProblemUser = results;
                    Navigator.Service.Navigate(new General());
                }
            }
            
        }
    }
}

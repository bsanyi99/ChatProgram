using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();

            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = new List<Users>();
            string userName = textBox1.Text.ToString();
            string password = textBox2.Password.ToString();


            if (userName.Equals(""))
            {
                MessageBox.Show("Felhasználónév kötelező!");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Jelszó kötelező!");
            }
            else
            {
                login login1 = new login();
                Users akt_felhasznalo = new Users(userName, password);

                string filepath = @"D:\Egyetem\Távközlő\alapverzió\Client\Client\data.txt";         //adat olvasása a filebol

                List<string> lines = File.ReadAllLines(filepath).ToList();
                foreach (var line in lines)
                {
                    string[] tokenek = line.Split(',');
                    users.Add(new Users(tokenek[0], tokenek[1]));
                }
                if (users.Contains(akt_felhasznalo))
                {
                    MainWindow sw = new MainWindow();
                    sw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("SIKERTELEN BEJELENTKEZÉS!");
                    login1.Show();
                    this.Close();
                }
            }

        }
        public string getLoginName()
        {
            return this.textBox1.Text;
        }

        public string getPassword()
        {
            return this.textBox2.Password.ToString();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Registration sw2 = new Registration();
            sw2.Show();
            this.Close();
        }
    }
}

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
using Newtonsoft.Json;


namespace Client
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseButtonHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = new List<Users>();
            string userName = textBox1.Text.ToString();
            string password = textBox2.Password.ToString();
            string password2 = textBox3.Password.ToString();


            if (userName.Equals(""))
            {
                MessageBox.Show("Felhasználónév kötelező!");
            }
            else if (password.Equals("") || password2.Equals(""))
            {
                MessageBox.Show("Jelszó kötelező!");
            }

            else if (!password.Equals(password2))
            {
                MessageBox.Show("A jelszó nem egyezik!");
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
                    MessageBox.Show("Már létezik ilyen felhasználó");
                }
                else
                {
                    users.Add(akt_felhasznalo);     //új felhasználó hozzá adása a már meglévő listához
                    File.AppendAllText("../../data.txt", userName + "," + password+"\n");   //a lista írása a file-ba

                    MessageBox.Show("Sikeres regisztráció!");
                    login1.Show();
                    this.Close();
                }
            }
        }
    }

}

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
using Linkedlistsstory.Pages;
using BCrypt.Net;

namespace Linkedlistsstory.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            using var db = new UserDetails.AppStorage.APPDbContext();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            using var db = new UserDetails.AppStorage.APPDbContext();
            var user = db.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) 
            {
                MessageBlock.Foreground = new SolidColorBrush(Colors.Green);
                MessageBlock.Text = $"Welcome {username}!";


            }
            else
            {
                MessageBlock.Foreground = new SolidColorBrush(Colors.Red);
                MessageBlock.Text = "Invalid username or password.";
            }
        }

        private void RegisterButton_click(object sender, RoutedEventArgs e)
        {
            Content = new Register();
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

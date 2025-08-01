using Linkedlistsstory.UserDetails.AppStorage;
using Microsoft.EntityFrameworkCore;
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
using BCrypt.Net;

namespace Linkedlistsstory.Pages
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
            //using var db = new Linkedlistsstory.AppStorage.AppDbContext();
            //db.Database.Migrate(); // Ensure database is created and migrations are applied
        }
        private void RegisterButton_click(object sender, RoutedEventArgs e)
        {
            // TODO: Add registration logic here
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            using var db = new Linkedlistsstory.UserDetails.AppStorage.APPDbContext();

            if (db.Accounts.Any(a => a.Username == username))
            {
                MessageBlock.Foreground = new SolidColorBrush(Colors.Red);
                MessageBlock.Text = "Username already exists.";
                return;
            }
            var newUser = new AccountData 
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password) // In a real application, hash the password!
            };
            db.Accounts.Add(newUser);
            db.SaveChanges();
            MessageBlock.Foreground = new SolidColorBrush(Colors.Green);
            MessageBlock.Text = "Registration successful! You can now log in.";




        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: Add username changed logic here
           //string username = UsernameBox.Text;

        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string password = PasswordBox.Text;
        }
    }
}

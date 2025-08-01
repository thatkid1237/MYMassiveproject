using Linkedlistsstory.Filemanagment;
using Linkedlistsstory.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Linkedlistsstory.UserDetails.AppStorage; 
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Linkedlistsstory.Pages;


namespace Linkedlistsstory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            //MainWindow MainWindow = new MainWindow();
            //MainWindow.Show();
            MainFrame.Content = new Pages.Login();
            MessageBox.Show("MainWindow constructor called");

            System.Diagnostics.Debug.WriteLine("MainWindow constructor called");


        }
        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }



        // Navigation button click handler
        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
             
            var button = sender as Button;
            switch (button.Tag)
            {
                case "StoryPage":
                    MainFrame.Content = new Adventure();
                    break;
                case "AccountPage":
                    MainFrame.Content = new Account();
                    break;
            }

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
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

namespace Практическаяработа2.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Task1Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task1Page());
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task2Page());
        }
        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task4Page());
        }
        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task5Page());
        }
        private void Task5Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task3Page());
        }
    }
}

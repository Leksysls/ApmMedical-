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

namespace ApmMedical.Views
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

        private void OtdelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OtdelPage());
        }

       

        private void BolnieButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BolniePage());
        }

        private void MedicButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MedicPage());
        }


    }
}

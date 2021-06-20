using ApmMedical.Controllers;
using ApmMedical.Models;
using ApmMedical.Views.AdminPages;
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
    /// Логика взаимодействия для WardPage.xaml
    /// </summary>
    public partial class WardPage : Page
    {
        Core db = new Core();
        readonly WardController wardObj = new WardController();
        public WardPage()
        {
            InitializeComponent();
            WardsDataGrid.ItemsSource = wardObj.GetWards().ToList();
        }

       

        private void AddWardsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddWardsPage());
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}

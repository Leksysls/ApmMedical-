using ApmMedical.Controllers;
using ApmMedical.Models;
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

namespace ApmMedical.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для Temperature_sheetPage.xaml
    /// </summary>
    public partial class Temperature_sheetPage : Page
    {
        Core db = new Core();
        readonly TemperaturController tempObj= new TemperaturController();
        readonly DoctorController docObj = new DoctorController();
        public Temperature_sheetPage()
        {
            InitializeComponent();

            TemperatureDataGrid.ItemsSource = tempObj.GetTemperature();
        }

        private void AddTemperaturButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TemperatureDeliteButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            Card_patiet item = button.DataContext as Card_patiet;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Card_patiet currentUsers = db.context.Card_patiet.Where(x => x.id_card == item.id_card).FirstOrDefault();
                db.context.Card_patiet.Remove(currentUsers);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }

            //обновление DataGrid
            TemperatureDataGrid.ItemsSource = db.context.Card_patiet.ToList();


        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

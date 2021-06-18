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
    /// Логика взаимодействия для BolniePage.xaml
    /// </summary>
    public partial class BolniePage : Page
    {
        readonly Core db = new Core();
        readonly PacientClass runObj = new PacientClass();
        public BolniePage()
        {
            InitializeComponent();
            PacientDataGrid.ItemsSource = runObj.GetPacient().ToList();


        }



        /// <summary>
        /// Нажатие на кнопку изменения волонтёра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminEditBolniePage((sender as Button).DataContext as Models.Info_patient));
        }
        /// <summary>
        /// Нажатие на кнопку добавления нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPacientButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddPacientPage());
        }
        private void PacientDeliteButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            Info_patient item = button.DataContext as Info_patient;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Info_patient curentPacient = db.context.Info_patient.Where(x => x.id_patient == item.id_patient).FirstOrDefault();
                db.context.Info_patient.Remove(curentPacient);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }
            //обновление DataGrid
            PacientDataGrid.ItemsSource = db.context.Info_patient.ToList();


        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

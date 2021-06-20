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
    /// Логика взаимодействия для DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page
    {
        readonly Core db = new Core();
        readonly DepartmentsController departObj = new DepartmentsController();
        public DepartmentPage()
        {
            InitializeComponent();
            
            DepartmentsDataGrid.ItemsSource = departObj.GetDepartments().ToList();
        }

        private void WardsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WardPage());
        }
        private void DepartmentsDeliteButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            Departments item = button.DataContext as Departments;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Departments currentDepartments = db.context.Departments.Where(x => x.id_department == item.id_department).FirstOrDefault();
                db.context.Departments.Remove(currentDepartments);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }

            //обновление DataGrid
            DepartmentsDataGrid.ItemsSource = db.context.Departments.ToList();


        }

        private void AddDepartmentsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddDepartmentPage());
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepartmentsDataGrid.ItemsSource = db.context.Departments.Where(x => x.name_department.Contains(SearchBox.Text)).ToList();
        }
    }
}

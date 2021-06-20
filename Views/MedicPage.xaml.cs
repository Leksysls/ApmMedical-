using ApmMedical.Controllers;
using ApmMedical.Models;
using ApmMedical.Views.AdminPages;
using StringCheckLib;
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
    /// Логика взаимодействия для MedicPage.xaml
    /// </summary>
    public partial class MedicPage : Page
    {
        Core db = new Core();
        readonly RolesController roleObj = new RolesController();
        UsersController userObj = new UsersController();
        readonly DoctorController runObj = new DoctorController();
        readonly FileManagerClass fileObj = new FileManagerClass();
        List<Models.Users> currentUsers;
        public MedicPage()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = roleObj.GetRoles().Where(x => x.id_role != 4);
            RoleComboBox.SelectedValuePath = "id_role";
            RoleComboBox.DisplayMemberPath = "name_role";
            RoleComboBox.SelectedIndex = 0;
            userObj = new UsersController();
            UsersDataGrid.ItemsSource = runObj.GetDoctors().ToList();
            
        }

        /// <summary>
        /// Нажатие на кнопку изменения  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Models.Users currentUser = button.DataContext as Models.Users;
            //if (currentUser.id_role == 2)
            //{
            this.NavigationService.Navigate(new AdminEditGlavVrachPage(currentUser));
            //}
            //else
            //{
            //    this.NavigationService.Navigate(new AdminRabotnikPage(currentUser));
            //}
        }

        /// <summary>
        /// Действие на изменение значения RoleComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userObj = new UsersController();
            currentUsers = userObj.GetUsersByRole(Convert.ToInt32(RoleComboBox.SelectedValue));
            UsersDataGrid.ItemsSource = currentUsers;
        }

        /// <summary>
        /// Нажатие на кнопку добавления нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }

        private void DoctorDeliteButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            Users item = button.DataContext as Users;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Users currentUsers = db.context.Users.Where(x => x.id_user == item.id_user).FirstOrDefault();
                db.context.Users.Remove(currentUsers);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }

            //обновление DataGrid
            UsersDataGrid.ItemsSource = db.context.Users.ToList();


        }


        private void DownloadUsersButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Dictionary<string, List<string>> currentLoadableData = new Dictionary<string, List<string>>();
                currentLoadableData.Add("Email", new List<string>());
                currentLoadableData.Add("Пароль", new List<string>());
                currentLoadableData.Add("Фамилия", new List<string>());
                currentLoadableData.Add("Имя", new List<string>());
                currentLoadableData.Add("Отчество", new List<string>());
                currentLoadableData.Add("Роль", new List<string>());
                foreach (var item in currentUsers)
                {
                    currentLoadableData["Email"].Add(item.login);
                    currentLoadableData["Пароль"].Add(item.password);
                    currentLoadableData["Фамилия"].Add(item.user_lastname);
                    currentLoadableData["Имя"].Add(item.user_firstname);
                    currentLoadableData["Отчество"].Add(item.user_othername);
                    currentLoadableData["Роль"].Add(item.role.name_role);
                }
                if (fileObj.DownLoadToCsvFile(currentLoadableData))
                {
                    MessageBox.Show("Сохранение прошло успешно!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}

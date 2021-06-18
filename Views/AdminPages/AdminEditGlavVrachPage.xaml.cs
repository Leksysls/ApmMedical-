using ApmMedical.Controllers;
using ApmMedical.Models;
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

namespace ApmMedical.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminGlavVrachPage.xaml
    /// </summary>
    public partial class AdminEditGlavVrachPage : Page
    {
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly UsersController userObj = new UsersController();
        string pass;
        public AdminEditGlavVrachPage(Users currentUser)
        {

            InitializeComponent();
            EmailTextBox.Text = currentUser.login;
            FirstNameTextBox.Text = currentUser.user_firstname;
            LastNameTextBox.Text = currentUser.user_lastname;
            OtherNameTextBox.Text = currentUser.user_othername;
            pass = currentUser.password;
        }

        /// <summary>
        /// Обновление границ заполняемых элементов 
        /// </summary>
        /// <returns>
        /// Возвращает строку с информацией о незаполненных полях
        /// </returns>
        private string SetBorders()
        {
            FirstNameTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(2);
            LastNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(2);
            OtherNameTextBox.BorderBrush = Brushes.Black;
            OtherNameTextBox.BorderThickness = new Thickness(2);

            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(FirstNameTextBox.Text)
                || !strObj.NameCheck(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = Brushes.Red;
                FirstNameTextBox.BorderThickness = new Thickness(2);
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(LastNameTextBox.Text)
                || !strObj.NameCheck(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = Brushes.Red;
                LastNameTextBox.BorderThickness = new Thickness(2);
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            if (String.IsNullOrWhiteSpace(OtherNameTextBox.Text)
                || !strObj.NameCheck(OtherNameTextBox.Text))
            {
                OtherNameTextBox.BorderBrush = Brushes.Red;
                OtherNameTextBox.BorderThickness = new Thickness(2);
                errorString += "Проверьте правильность написания Отчества\n";
            }
            
            return errorString;
        }


        

        /// <summary>
        /// Нажатие на кнопку сохранения данных о пользователе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if (errors == String.Empty)
            {
                UpdateRunnerInfo();
                
                
            }
            else
            {
                MessageBox.Show(errors);
            }
        }

        /// <summary>
        /// Обновление данных о бегуне
        /// </summary>
        private void UpdateRunnerInfo()
        {

            try
            {
                if(userObj.UpdateUserInfo(EmailTextBox.Text,FirstNameTextBox.Text, LastNameTextBox.Text, OtherNameTextBox.Text,pass))
                    {
                        MessageBox.Show("Профиль успешно отредактирован!");  
                        this.NavigationService.Navigate(new MedicPage());
                    }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
    }
}

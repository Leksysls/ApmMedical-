using ApmMedical.Controllers;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        readonly RolesController roleObj = new RolesController();
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly UsersController userObj = new UsersController();
        public RegistrationPage()
        {
            InitializeComponent();

            RoleComboBox.ItemsSource = roleObj.GetRoles();
            RoleComboBox.DisplayMemberPath = "name_role";
            RoleComboBox.SelectedValuePath = "id_role";
            RoleComboBox.SelectedIndex = 0;

        }


        /// <summary>
        /// Действие на изменении выбранного значения в RoleComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (RoleComboBox.SelectedValue.ToString() == "3")
            //{
            //    RunnerInfoStackPanel.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    RunnerInfoStackPanel.Visibility = Visibility.Collapsed;
            //}
        }

        private string SetBorders()
        {
            EmailTextBox.BorderBrush = Brushes.Black;
            EmailTextBox.BorderThickness = new Thickness(1);
            PasswordPasswordBox.BorderBrush = Brushes.Black;
            PasswordPasswordBox.BorderThickness = new Thickness(1);
            RepeatPasswordBox.BorderBrush = Brushes.Black;
            RepeatPasswordBox.BorderThickness = new Thickness(1);
            FirstNameTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(1);
            LastNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(1);
            OtherNameTextBox.BorderBrush = Brushes.Black;
            OtherNameTextBox.BorderThickness = new Thickness(1);

            string errorString = String.Empty;
            if (String.IsNullOrWhiteSpace(EmailTextBox.Text)
                || !strObj.EmailCheck(EmailTextBox.Text))
            {
                EmailTextBox.BorderBrush = Brushes.Red;
                EmailTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Email\n";
            }
            if (!userObj.CheckEmailDuplication(EmailTextBox.Text))
            {
                EmailTextBox.BorderBrush = Brushes.Red;
                EmailTextBox.BorderThickness = new Thickness(3);
                errorString += "Пользователь с таким Email уже существует\n";
            }
            if (String.IsNullOrWhiteSpace(PasswordPasswordBox.Password)
                || !strObj.PasswordCheck(PasswordPasswordBox.Password))
            {
                PasswordPasswordBox.BorderBrush = Brushes.Red;
                PasswordPasswordBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания пароля\n";
            }
            if (String.IsNullOrWhiteSpace(RepeatPasswordBox.Password)
                || !strObj.PasswordCheck(RepeatPasswordBox.Password))
            {
                RepeatPasswordBox.BorderBrush = Brushes.Red;
                RepeatPasswordBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания пароля\n";
            }
            if (PasswordPasswordBox.Password != RepeatPasswordBox.Password)
            {
                PasswordPasswordBox.BorderBrush = Brushes.Red;
                PasswordPasswordBox.BorderThickness = new Thickness(3);
                RepeatPasswordBox.BorderBrush = Brushes.Red;
                RepeatPasswordBox.BorderThickness = new Thickness(3);
                errorString += "Пароли не совпадают\n";
            }
            if (String.IsNullOrWhiteSpace(FirstNameTextBox.Text)
                || !strObj.NameCheck(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = Brushes.Red;
                FirstNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(LastNameTextBox.Text)
                || !strObj.NameCheck(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = Brushes.Red;
                LastNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            if (String.IsNullOrWhiteSpace(OtherNameTextBox.Text)
                || !strObj.NameCheck(OtherNameTextBox.Text))
            {
                OtherNameTextBox.BorderBrush = Brushes.Red;
                OtherNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Отчества\n";
            }
            return errorString;
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Registration())
            {
                MessageBox.Show("Добавление прошло успешно!");
            }
        }
        /// <summary>
        /// Осуществление добавления нового пользователя
        /// </summary>
        /// <returns>
        /// Возвращает:
        /// true - если все данные были введены корректно
        /// false - если произошла ошибка или данные введены некорректно  
        /// </returns>
        private bool Registration()
        {
            string errorString = SetBorders();
            if (String.IsNullOrEmpty(errorString))
            {
                if (RoleComboBox.SelectedValue.ToString() == "1" || RoleComboBox.SelectedValue.ToString() == "2" || RoleComboBox.SelectedValue.ToString() == "3")
                {
                    try
                    {
                        int result = userObj.AddUser(
                            EmailTextBox.Text,
                            FirstNameTextBox.Text,
                            LastNameTextBox.Text,
                            OtherNameTextBox.Text,
                            Convert.ToInt32(RoleComboBox.SelectedValue),
                            PasswordPasswordBox.Password);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(errorString);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(errorString);
                return false;
            }
        }


    }
}


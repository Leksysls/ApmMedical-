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

namespace ApmMedical.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminAddPacientPage.xaml
    /// </summary>
    public partial class AdminAddPacientPage : Page
    {
        readonly SexController genObj = new SexController();
        readonly BloodController bloyObj = new BloodController();
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly PacientClass paciObj = new PacientClass();
        public AdminAddPacientPage()
        {
            InitializeComponent();

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.SelectedValuePath = "id_sex";
            GenderComboBox.DisplayMemberPath = "name_sex";
            GenderComboBox.SelectedIndex = 0;

            BloodComboBox.ItemsSource = bloyObj.GetBloods();
            BloodComboBox.SelectedValuePath = "id_blood";
            BloodComboBox.DisplayMemberPath = "name_blood";
            BloodComboBox.SelectedIndex = 0;
        }

        private string SetBorders()
        {
            
            FirstNameTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(1);
            LastNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(1);
            OtherNameTextBox.BorderBrush = Brushes.Black;
            OtherNameTextBox.BorderThickness = new Thickness(1);

            string errorString = String.Empty;
           
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
                
                    try
                    {
                        bool result = paciObj.AddPacient(
                            FirstNameTextBox.Text,
                            LastNameTextBox.Text,
                            OtherNameTextBox.Text,
                            Convert.ToDateTime(BirthDatePicker.SelectedDate), 
                            Convert.ToInt32(GenderComboBox.SelectedValue),
                            Convert.ToInt32(BloodComboBox.SelectedValue)
                            );

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
    }
}

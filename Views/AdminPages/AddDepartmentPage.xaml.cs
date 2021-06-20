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
    /// Логика взаимодействия для AddDepartmentPage.xaml
    /// </summary>
    public partial class AddDepartmentPage : Page
    {
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly DepartmentsController departObj = new DepartmentsController();
        public AddDepartmentPage()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Registration())
            {
                MessageBox.Show("Добавление прошло успешно!");
            }
        }
        private string SetBorders()
        {

            DepartmentsTextBox.BorderBrush = Brushes.Black;
            DepartmentsTextBox.BorderThickness = new Thickness(1);


            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(DepartmentsTextBox.Text)
                || !strObj.NameCheck(DepartmentsTextBox.Text))
            {
                DepartmentsTextBox.BorderBrush = Brushes.Red;
                DepartmentsTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Имени\n";
            }

            return errorString;
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
                    bool result = departObj.AddDepartments(
                        DepartmentsTextBox.Text
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

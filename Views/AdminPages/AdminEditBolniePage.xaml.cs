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
    /// Логика взаимодействия для AdminEditBolniePage.xaml
    /// </summary>
    public partial class AdminEditBolniePage : Page
    {
        Info_patient patient;
        readonly SexController genObj = new SexController();
        readonly BloodController bloyObj = new BloodController();
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly PacientClass paciObj = new PacientClass();
        
        public AdminEditBolniePage(Info_patient currentPacient)
        {
            InitializeComponent();

            patient = currentPacient;

            

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.SelectedValuePath = "id_sex";
            GenderComboBox.DisplayMemberPath = "name_sex";
            GenderComboBox.SelectedValue = currentPacient.id_sex;

            BloodComboBox.ItemsSource = bloyObj.GetBloods();
            BloodComboBox.SelectedValuePath = "id_blood";
            BloodComboBox.DisplayMemberPath = "name_blood";
            BloodComboBox.SelectedValue = currentPacient.id_blood;


            FirstNameTextBox.Text = currentPacient.fitstname_patient;
            LastNameTextBox.Text = currentPacient.surname_patient;
            OtherNameTextBox.Text = currentPacient.lastname_patient;

            BirthDatePicker.SelectedDate = currentPacient.year_patient;


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
        /// Нажатие на кнопку сохранить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if (errors == String.Empty)
            {
                UpdateMedicInfo();
            }
            else
            {
                MessageBox.Show(errors);
            }
        }


        /// <summary>
        /// Обновление данных о Враче
        /// </summary>
        private void UpdateMedicInfo()
        {

            try
            {
                if (paciObj.UpdatePacientInfo( FirstNameTextBox.Text, LastNameTextBox.Text, OtherNameTextBox.Text, Convert.ToDateTime(BirthDatePicker.SelectedDate), Convert.ToInt32(GenderComboBox.SelectedValue), Convert.ToInt32(BloodComboBox.SelectedValue), patient))
                {
                    MessageBox.Show("Профиль успешно отредактирован!");
                    this.NavigationService.Navigate(new BolniePage());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}



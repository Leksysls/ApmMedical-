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
    /// Логика взаимодействия для AddWardsPage.xaml
    /// </summary>
    public partial class AddWardsPage : Page
    {
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly WardController wardObj = new WardController();
        public AddWardsPage()
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
            

                try
                {
                    bool result = wardObj.AddWards(
                        Convert.ToInt32(WardTextBox.Text)
                        );

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            
        }
    }
}

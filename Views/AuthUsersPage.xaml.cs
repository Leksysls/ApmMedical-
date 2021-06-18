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


namespace ApmMedical.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthUsersPage.xaml
    /// </summary>
    public partial class AuthUsersPage : Page
    {

        public AuthUsersPage()
        {
            InitializeComponent();


        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            UsersController obj = new UsersController();
            if (obj.Auth(LoginTextBox.Text, TextPasswordBox.Password) == true)
            {
                RolesController objrole = new RolesController();
                
                switch (objrole.GetRole(LoginTextBox.Text))
                {
                    case 1:
                        this.NavigationService.Navigate(new RabotnikiPage());
                        break;
                    case 2:
                        this.NavigationService.Navigate(new GlavVrachPage());
                        break;
                    case 3:
                        this.NavigationService.Navigate(new MainPage());
                        break;

                }

            }

        }


    }
}



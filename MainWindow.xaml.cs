using ApmMedical.Views;
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

namespace ApmMedical
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthUsersPage());
        }

        /// <summary>
        /// событие, которое выполняет переход на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)

            { MainFrame.GoBack(); }
        }
        /// <summary>
        /// событие, которое происходит при навигации (то есть при помещении страниц во фрейм)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content;
            if (MainFrame.CanGoBack && page is MainPage)
            {
                MainFrame.RemoveBackEntry();
            }

        }
        /// <summary>
        /// может влиять на отображение любых элементов на странице . 
        /// Например, в описанном ниже примере, кнопка становится невидимой, если нет возможности перейти на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)

        {
            if (!MainFrame.CanGoBack)

            { BackButton.Visibility = Visibility.Collapsed; }

            else

            { BackButton.Visibility = Visibility.Visible; }

        }
    }
}

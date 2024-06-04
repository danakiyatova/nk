using NailsApp.ViewModel;
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
using System.Windows.Shapes;

namespace NailsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            this.DataContext = new AuthorizationViewModel();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (this.DataContext as AuthorizationViewModel).Password = pbPassword.Password;

                // Вызываем Auth() один раз и сохраняем результат
                int roleId = (this.DataContext as AuthorizationViewModel).Auth();

                if (roleId == 2)
                {
                    new MasterMainWindow().Show();
                    Close();
                }
                else if (roleId == 3)
                {
                    new AdminWindow().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

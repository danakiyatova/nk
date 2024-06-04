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
    /// Логика взаимодействия для AddMasterWindow.xaml
    /// </summary>
    public partial class AddMasterWindow : Window
    {
        public AddMasterWindow()
        {
            InitializeComponent();
            this.DataContext = new AddPersonViewModel();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AddPersonViewModel).Add();
        }
    }
}

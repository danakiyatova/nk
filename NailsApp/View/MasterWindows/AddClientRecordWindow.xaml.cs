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
    /// Логика взаимодействия для AddClientRecord.xaml
    /// </summary>
    public partial class AddClientRecordWindow : Window
    {
        public AddClientRecordWindow()
        {
            InitializeComponent();
            this.DataContext = new AddRecordViewModel();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            new AddClientWindow().ShowDialog();
            Close();
        }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AddRecordViewModel).Add();
        }
    }
}

using ClosedXML.Excel;
using NailsApp.Model.Database;
using NailsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NailsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddMasterWindow().ShowDialog();
            
        }

        

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgUser.SelectedItem != null)
            {
                EditPerson.Id = (dgUser.SelectedItem as User).Id;
                new EditPerson().ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AdminViewModel();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.Control control = new System.Windows.Forms.Control();
            Help.ShowHelp(control, "HelpSys.chm");
        }
    }
}

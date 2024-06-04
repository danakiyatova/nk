using NailsApp.Model.Database;
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

namespace NailsApp.View.MasterWindows
{
    /// <summary>
    /// Логика взаимодействия для EditClientRecordWindow.xaml
    /// </summary>
    public partial class EditClientRecordWindow : Window
    {
        public static int RecordId;
        public EditClientRecordWindow()
        {
            InitializeComponent();
            this.DataContext = new EditRecordViewModel();
        }


        private void btnEditRecord_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as EditRecordViewModel).Edit();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите ужалить запись?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (NailDBEntities db = new NailDBEntities())
                {
                    var client = db.MasterHasClient.FirstOrDefault(c => c.Id == RecordId);
                    db.MasterHasClient.Remove(client);
                    db.SaveChanges();
                    MessageBox.Show("Удалено");
                    Close();
                }
            }
        }
    }
}

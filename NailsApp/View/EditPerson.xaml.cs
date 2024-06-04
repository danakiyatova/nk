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

namespace NailsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditPerson.xaml
    /// </summary>
    public partial class EditPerson : Window
    {
        public static int Id { get; set; }
        public EditPerson()
        {
            InitializeComponent();
            this.DataContext = new EditUserViewModel();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as EditUserViewModel).EditUser();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var userId = Id;
            using (NailDBEntities db = new NailDBEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Id == userId);
                db.User.Remove(user);
                db.SaveChanges();
                MessageBox.Show("Удалено");
                Close();
            }
        }
    }
}

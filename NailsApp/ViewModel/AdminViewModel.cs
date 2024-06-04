using NailsApp.Model.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NailsApp.ViewModel
{
    class AdminViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public AdminViewModel()
        {
            try
            {
                _users = new ObservableCollection<User>();
                using (NailDBEntities db = new NailDBEntities())
                {
                    var users = db.User.ToList();
                    foreach (var user in users)
                    {
                        var master = db.Master.FirstOrDefault(m => m.UserId == user.Id);
                        if(master != null)
                        {
                            _users.Add(user);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка базы данных");
            }

        }
    }
}

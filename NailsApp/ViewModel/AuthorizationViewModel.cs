
using NailsApp.Model.Database;
using NailsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NailsApp.ViewModel
{
    class AuthorizationViewModel : BaseViewModel
    {
        private string _login;
        private string _password;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public int Auth()
        {
            try
            {
                using (NailDBEntities db = new NailDBEntities())
                {
                    var account = db.Account.FirstOrDefault(d => d.Login == Login && d.Password == Password);
                    if (account != null)
                    {
                        var master = db.Master.FirstOrDefault(d => d.AccountId == account.Id);
                        var user = db.User.FirstOrDefault(d => d.Id == master.UserId);

                        if (user.RoleId == 2)
                        {
                            MasterMainWindow.MasterId = db.Master.FirstOrDefault(m => m.UserId == user.Id).Id;
                        }
                       
                        return user.RoleId;
                    }
                    else
                        return 0;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка базы данных");
                return 0;
            }
        }
    }
}

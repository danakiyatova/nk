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
    class AddPersonViewModel : BaseViewModel
    {
        private string _firstname;
        private string _lastname;
        private string _middlename;
        private string _login;
        private string _password;
        private string _role;
        private DateTime _bornDate = DateTime.Now;
        private string _phone;

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string MiddleName
        {
            get { return _middlename; }
            set
            {
                _middlename = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
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
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public DateTime BornDate
        {
            get { return _bornDate; }
            set
            {

                _bornDate = value;
                OnPropertyChanged(nameof(BornDate));
            }
        }
        public AddPersonViewModel()
        {
        }

        public void Add()
        {
            if (FirstName == null || LastName == null || Login == null || Password == null || Phone == null || BornDate == null)
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                using (NailDBEntities db = new NailDBEntities())
                {
                    var role = db.Role.FirstOrDefault(r => r.Value == _role);
                    var user = db.User.Add(new User()
                    {
                        FirstName = _firstname,
                        LastName = _lastname,
                        MiddleName = _middlename,
                        RoleId = 2,
                        Phone = _phone,
                        BornDate = _bornDate
                    }) ;
                    db.SaveChanges();

                    var account = db.Account.Add(new Account()
                    {
                        Login = _login,
                        Password = _password
                    });
                    db.SaveChanges();
                    db.Master.Add(new Master()
                    {
                        UserId = user.Id,
                        AccountId = account.Id
                    });
                    
                    db.SaveChanges();
                    MessageBox.Show("Пользователь добавлен");
                }
            }
        }
    }
}

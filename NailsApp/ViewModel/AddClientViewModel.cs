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
    internal class AddClientViewModel : BaseViewModel
    {
        private string _firstname;
        private string _lastname;
        private string _middlename;
        private DateTime _bornDate = DateTime.Now;
        private string _phone;

        
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
        public AddClientViewModel()
        {
           
           
        }

        public void Add()
        {
            if (_firstname == null || _lastname == null || _phone == null)
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
               
                using (NailDBEntities db = new NailDBEntities())
                {
                    var user = db.User.Add(new User()
                    {
                        FirstName = _firstname,
                        LastName = _lastname,
                        MiddleName = _middlename,
                        Phone = _phone,
                        BornDate = _bornDate,
                        RoleId = 1

                    });
                    db.SaveChanges();
                    db.Client.Add(new Client()
                    {
                        UserId = user.Id
                    });
                    
                    db.SaveChanges();
                    MessageBox.Show("Пользователь добавлен");
                }
            }
        }
    }
}

using NailsApp.Model.Database;
using NailsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NailsApp.ViewModel
{
    class EditUserViewModel : BaseViewModel
    {
        private string _firstname;
        private string _lastname;
        private string _middlename;
        private DateTime _bornDate;
        private string _phone;

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(FirstName);
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(LastName);
            }
        }
        public string MiddleName
        {
            get { return _middlename; }
            set
            {
                _middlename = value;
                OnPropertyChanged(MiddleName);
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
        public EditUserViewModel()
        {
            try
            {
                using (NailDBEntities db = new NailDBEntities())
                {

                    var user = db.User.FirstOrDefault(u => u.Id == EditPerson.Id);
                    if(user != null)
                    {
                        _firstname = user.FirstName;
                        _lastname = user.LastName;
                        _middlename = user.MiddleName;
                        _phone = user.Phone;
                        _bornDate = user.BornDate;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка базы данных");
            }
        }
        public void EditUser()
        {
            try
            {
                if (FirstName == "" || LastName == "" || Phone == "" || BornDate == null)
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
                else
                {
                    using (NailDBEntities db = new NailDBEntities())
                    {
                        var user = db.User.FirstOrDefault(u => u.Id == EditPerson.Id);
                        db.User.AddOrUpdate(new User()
                        {
                            Id = EditPerson.Id,
                            FirstName = _firstname,
                            LastName = _lastname,
                            MiddleName = _middlename,
                            RoleId = user.RoleId,
                            Phone = _phone,
                            BornDate = _bornDate,
                        }) ;
                        db.SaveChanges();
                        MessageBox.Show("Пользователь обновлен");
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

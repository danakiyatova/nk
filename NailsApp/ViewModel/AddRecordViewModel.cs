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
    internal class AddRecordViewModel : BaseViewModel
    {
        private string _client;
        private ObservableCollection<string> _clients;
        private ObservableCollection<string> _services;
        private DateTime _date = DateTime.Now;
        private string _service;
        private string _timeHour;
        private string _timeMin;

        public string Client
        {
            get { return _client; }
            set { _client = value; OnPropertyChanged(nameof(Client)); }
        }
        public ObservableCollection<string> Clients
        {
            get { return _clients; }
            set { _clients = value; OnPropertyChanged(nameof(Clients)); }
        }
        public string Service
        {
            get { return _service; }
            set { _service = value; OnPropertyChanged(nameof(Service)); }
        }
        public string TimeHour
        {
            get { return _timeHour; }
            set { _timeHour = value; OnPropertyChanged(nameof(TimeHour)); }
        }
        public string TimeMin
        {
            get { return _timeMin; }
            set { _timeMin = value; OnPropertyChanged(nameof(TimeMin)); }
        }
        public ObservableCollection<string> Services
        {
            get { return _services; }
            set { _services = value; OnPropertyChanged(nameof(Services)); }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        public AddRecordViewModel() 
        {
            _clients = new ObservableCollection<string>();
            _services = new ObservableCollection<string>();

            using(NailDBEntities db = new NailDBEntities())
            {
                foreach(var client in db.Client)
                {
                    foreach(var user in db.User)
                    {
                        if(user.Id == client.UserId)
                        {
                            _clients.Add(client.Id + " " + user.FirstName + " " + user.LastName + " " + user.MiddleName);
                        }
                    } 
                }
                foreach(var service in db.Service)
                {
                    _services.Add(service.Value);
                }
            }
        }
        public void Add()
        {
            try
            {
                if (Client == null || Service == null || Date == null || TimeHour == null || TimeMin == null)
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
                else
                {
                    var timeH = Convert.ToInt32(TimeHour);
                    var timeM = Convert.ToInt32(TimeMin);
                    if (timeH < 0 || timeH >= 60 || timeM < 0 || timeM >= 60)
                    {
                        MessageBox.Show("Неверное время");
                    }
                    else
                    {
                        var cl = Client.Split(' ');
                        using (NailDBEntities db = new NailDBEntities())
                        {
                            var id = Convert.ToInt32(cl[0]);
                            //var user = db.User.FirstOrDefault(u => u.Id == id);
                            var client = db.Client.FirstOrDefault(c => c.Id == id);
                            var service = db.Service.FirstOrDefault(s => s.Value == Service);
                            var date = new DateTime(Date.Year, Date.Month, Date.Day, timeH, timeM, 0);
                            var record = db.MasterHasClient.FirstOrDefault(r => r.Date == date);
                            if(record != null)
                            {
                                MessageBox.Show("На это время уже есть запись!");
                            }
                            else
                            {
                                db.MasterHasClient.Add(new MasterHasClient()
                                {
                                    ClientId = client.Id,
                                    MasterId = MasterMainWindow.MasterId,
                                    Date = date,
                                    ServiceId = service.Id
                                });
                                var res = db.SaveChanges();
                                if (res > 0)
                                    MessageBox.Show("Добавлено");
                                else
                                {
                                    MessageBox.Show("Ошибка");
                                }
                                //MasterMainWindow.MasterId;
                            }

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}

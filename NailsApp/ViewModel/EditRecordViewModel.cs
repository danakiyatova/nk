using NailsApp.Model.Database;
using NailsApp.View;
using NailsApp.View.MasterWindows;
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
    internal class EditRecordViewModel : BaseViewModel
    {
        private string _client;
        private ObservableCollection<string> _services;
        private DateTime _date;
        private string _service;
        private string _timeHour;
        private string _timeMin;

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
        public string Client
        {
            get { return _client; }
            set { _client = value; OnPropertyChanged(nameof(Client)); }
        }
        public string Service
        {
            get { return _service; }
            set { _service = value; OnPropertyChanged(nameof(Service)); }
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

        public EditRecordViewModel()
        {
            _services = new ObservableCollection<string>();

            using (NailDBEntities db = new NailDBEntities())
            {
                //var record = db.MasterHasClient.FirstOrDefault(m => m.Id == EditClientRecordWindow.RecordId);
                var client = db.ClientList.FirstOrDefault(c => c.Id == EditClientRecordWindow.RecordId);
                _service = client.Service.ToString();
                _client = client.ClientId + " " + client.FirstName + ' ' + client.LastName + ' ' + client.MiddleName;
                foreach (var service in db.Service)
                {
                    _services.Add(service.Value);
                }
                _date = client.Date;
                _timeHour = client.Date.Hour.ToString();
                _timeMin = client.Date.Minute.ToString();
            }
        }
        public void Edit()
        {
            try
            {
                if (Client == "" || Service == "" || Date == null || TimeHour == null || TimeMin == null)
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
                            if (record != null)
                            {
                                MessageBox.Show("На это время уже есть запись!");
                            }
                            else
                            {
                                db.MasterHasClient.AddOrUpdate(new MasterHasClient()
                                {
                                    Id = EditClientRecordWindow.RecordId,
                                    ClientId = client.Id,
                                    MasterId = MasterMainWindow.MasterId,
                                    Date = date,
                                    ServiceId = service.Id
                                });
                                var res = db.SaveChanges();
                                if (res > 0)
                                    MessageBox.Show("Отредактировано");
                                else
                                {
                                    MessageBox.Show("Ошибка");
                                }
                            }
                            //MasterMainWindow.MasterId;
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

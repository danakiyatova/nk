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
    class MasterMainViewModel : BaseViewModel
    {
        private ObservableCollection<ClientList> _clients;
        public ObservableCollection<ClientList> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
        public MasterMainViewModel()
        {
            try
            {
                _clients = new ObservableCollection<ClientList>();
                using(NailDBEntities db = new NailDBEntities())
                {
                    var clients = db.ClientList.ToList();
                    foreach(var client in clients)
                    {
                        if (client.MasterId == MasterMainWindow.MasterId)
                            _clients.Add(client);
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

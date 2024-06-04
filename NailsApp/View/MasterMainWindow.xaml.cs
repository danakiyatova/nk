using ClosedXML.Excel;
using NailsApp.Model.Database;
using NailsApp.View.MasterWindows;
using NailsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace NailsApp.View
{
    /// <summary>
    /// Логика взаимодействия для MasterMainWindow.xaml
    /// </summary>
    public partial class MasterMainWindow : Window
    {
        public static int MasterId { get; set; }
        public MasterMainWindow()
        {
            InitializeComponent();
            this.DataContext = new MasterMainViewModel();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddClientRecordWindow().ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MasterMainViewModel();
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClients.SelectedItem != null)
            {
                var client = dgClients.SelectedItem as ClientList;
                EditClientRecordWindow.RecordId = client.Id;

                new EditClientRecordWindow().ShowDialog();
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            var classes = new ObservableCollection<ClientList>();
            using (NailDBEntities db = new NailDBEntities())
            {
                var classe = db.ClientList.ToList();
                foreach (var ev in classe)
                {
                    classes.Add(ev);
                }
                var file = $"Отчет мастера Id {MasterId} от {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} " +
                $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}";
                SaveExcelData(classes, file);
                System.Windows.MessageBox.Show("Выгружено по пути C:/Данные в Excel/Отчеты/" + file + ".xlsx");
            }
            
            
        }

        public void SaveExcelData(IEnumerable<ClientList> Data, string FileName)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Журнал");

            //Заголовки у столбцов
            worksheet.Cell("A" + 1).Value = "Ф.И.О. клиента";
            worksheet.Cell("B" + 1).Value = "Дата";
            worksheet.Cell("C" + 1).Value = "Услуга";
            worksheet.Cell("D" + 1).Value = "Цена";
            int row = 2;

            //Запись данных 
            foreach (var data in Data)
            {
                worksheet.Cell("A" + row).Value = data.LastName + " " + data.FirstName + " " + data.MiddleName;
                worksheet.Cell("B" + row).Value = data.Date.ToString();
                worksheet.Cell("C" + row).Value = data.Service;
                worksheet.Cell("D" + row).Value = data.Price;
                row++;
            }

            worksheet.Columns().AdjustToContents(); //ширина столбца по содержимому

            workbook.SaveAs($"C:/Данные в Excel/Отчеты/{FileName}.xlsx");
        }


        private void btnSpravka_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Control control = new System.Windows.Forms.Control();
            Help.ShowHelp(control, "HelpSys.chm");
        }
    }
}


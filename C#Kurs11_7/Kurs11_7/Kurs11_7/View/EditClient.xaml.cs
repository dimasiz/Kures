using Kurs11_7.Model;
using Kurs11_7.ViewModel;
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

namespace Kurs11_7.View
{
    /// <summary>
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        public EditClient(Client Client)
        {
            InitializeComponent();
            DataContext = new DataManager();
            DataManager.SelectionClient = Client;
            DataManager.ClientName = Client.Name;
            DataManager.ClientSecondName = Client.SecondName;
            DataManager.ClientLastName = Client.LastName;
            DataManager.ClientNumber = Client.Number;
            DataManager.ClientPassportData = Client.PassportData;
            DataManager.ClientDepartmentID = Client.DepartmentID;

        }
    }
}

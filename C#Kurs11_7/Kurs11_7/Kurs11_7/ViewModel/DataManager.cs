using Kurs11_7.Model;
using Kurs11_7.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs11_7.Model;
using System.Windows;
using Kurs11_7.View;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net;
using System.Windows.Media.Animation;
using System.Net.Sockets;

namespace Kurs11_7.ViewModel
{
    public class DataManager : INotifyPropertyChanged
    {

       

        private List<Deportament> allDeportments;
        public List<Deportament> AllDepartments
        {
            get
            {
                return allDeportments = AllDeportament();
            }

            set
            {
                allDeportments = value;
                NotifyPropertyChanged("Все депортаменты");
            }
        }


        private List<Client> allClients;
        public List<Client> AllClients
        {
            get { return allClients = AllClie(); }
            set
            {
                allClients = value;
                NotifyPropertyChanged("Все депортаменты");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Deportament> AllDeportament()
        {
            return allDeportments = Data.DataDepartment;
        }
        public List<Client> AllClie()
        {
            return allClients = Data.GetAllClients();
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #region COMANDLIST
        public string DepartmentName { get; set; }

        private RellayComand addNewDepartment;
        public RellayComand AddNewDepartment
        {
            get
            {
                return addNewDepartment ?? new RellayComand(obj =>
                {
                    Window wind = obj as Window;
                    string resultStr = "";

                    if (DepartmentName == null)
                    {
                        SetRedBlockContol(wind, "NameBlock");
                    }
                    else
                    {
                        resultStr = Data.CreateDepartment(DepartmentName, 0);
                        ShowMasageToUser(resultStr);
                        UpdateAll();
                        wind.Close();
                    }
                }
                );
            }
        }

        

        private RellayComand addNewClient;
        public RellayComand AddNewClient
        {
            get
            {
                return addNewClient ?? new RellayComand(obj =>
                {
                    Window wind = obj as Window;
                    string resultStr = "";
                    

                    if (ClientName == null)
                    {
                        SetRedBlockContol(wind, "NameBox");
                    }
                    if (ClientSecondName == null)
                    {
                        SetRedBlockContol(wind, "SecondNameBox");
                    }
                    if (ClientLastName == null)
                    {
                        SetRedBlockContol(wind, "LastNameBox");
                    }
                    if (ClientNumber == null)
                    {
                        SetRedBlockContol(wind, "NumberBox");
                    }
                    if (ClientPassportData == null)
                    {
                        SetRedBlockContol(wind, "PassportBox");
                    }
                  
                    else
                    {
                        resultStr = Data.CreateClient(ClientName, ClientSecondName, ClientLastName, ClientNumber, ClientPassportData, Selecteditem.ID);
                        ShowMasageToUser(resultStr);
                        UpdateAll();
                        wind.Close();
                    }
                }
                );
            }
        }
        private RellayComand deleteClient;
        public RellayComand DeleteClient
        {
            get
            {

                return deleteClient ?? new RellayComand(obj =>
                {
                    if (SelectionClient != null)
                    {
                        Data.DeleteClient(SelectionClient, SelectionClient.DepartmentID);
                        UpdateAll();
                    }
                });
            }
        }

        public static Client SelectionClient { get; set; }

        private RellayComand openEditClientOnNew;

        public RellayComand OpenEditClientOnNew
        {
            get
            {
                return openEditClientOnNew ?? new RellayComand(obj =>
                {
                    if (SelectionClient != null)
                    {
                        OpenEditClintWindow(SelectionClient);
                    }
                });
            }
        }

        private RellayComand editClientOnNew;

        public RellayComand EditClientOnNew
        {
            get
            {
                string result = "Ошибка";
                return editClientOnNew ?? new RellayComand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectionClient != null)
                    {
                        result = Data.EditClient(SelectionClient, ClientDepartmentID, ClientName, ClientSecondName, ClientLastName, ClientNumber, ClientPassportData, Selecteditem.ID, Accses);
                        UpdateAll();
                        ShowMasageToUser(result);
                        window.Close();
                    }
                    else
                    {
                        ShowMasageToUser(result);
                    }
                })
                {

                };
            }
        }
        #endregion
        #region PROPERTYS
        public static string ClientName { get; set; }
        public static string ClientSecondName { get; set; }
        public static string ClientLastName { get; set; }
        public static string ClientNumber { get; set; }
        public static string ClientPassportData { get; set; }
        public static int ClientDepartmentID { get; set; }
        public static bool Accses { get; set; }
        public static Deportament Selecteditem { get; set; }
        #endregion
        #region UPDATE

        private void UpdateAll()
        {
            UpdateAllDepartment();
            UpdateAllClient();
        }
        private void UpdateAllDepartment()
        {

            allDeportments = Data.GetAllDeportment();

            MainWindow.AllDepartmentsView.ItemsSource = allDeportments;
            MainWindow.AllDepartmentsView.Items.Refresh();
        }
        
        private void UpdateAllClient()
        {

            AllClients = Data.GetAllClients();

            MainWindow.AllClientView.ItemsSource = AllClients;
            MainWindow.AllClientView.Items.Refresh();
        }
        #endregion

        private void SetRedBlockContol(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void ShowMasageToUser(string message)
        {
            Massage massageView = new Massage(message);
            SetCenterPositionAndOpen(massageView);
        }

        private bool ManagerInWeb()
        {
            return true;
        }

        private bool ConsultantInWeb()
        {
            return false;
        }
       
        #region COMAND OPEN
        private void OpenAddDeparmentWindow()
        {
            AddNewDepartment newDepartmentWindow = new AddNewDepartment();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void OpenAddClintWindow()
        {
            AddClient editClient = new AddClient();
            SetCenterPositionAndOpen(editClient);
        }


        private void OpenEditClintWindow(Client selectedClient)
        {
            EditClient editClient = new EditClient(selectedClient);
            SetCenterPositionAndOpen(editClient);
        }

        #endregion
        #region ACTIVATION COMAND
        private RellayComand openAddNewDepartmentWind;

        public RellayComand OpenAddNewDepartmentWind
        {
            get
            {
                return openAddNewDepartmentWind ?? new RellayComand(obj =>
            {
                OpenAddDeparmentWindow();
            }
            );
            }
        }


      
        private RellayComand openAddNewClientWind;
        public RellayComand OpenAddNewClientWind
        {
            get
            {
                return openAddNewClientWind ?? new RellayComand(obj =>
                {
                    OpenAddClintWindow();
                }
            );
            }
        }

        private RellayComand openEditNewClientWind;
        public RellayComand OpenEditNewClientWind
        {
            get
            {
                return openEditNewClientWind ?? new RellayComand(obj =>
                {
                    OpenEditClintWindow(SelectionClient);
                }
            );
            }
        }
        #endregion

        #region SORT COMMAND
        public List<Deportament> SortListDepartment()
        {
            var list = allDeportments.OrderBy(item => item.Name).ToList();
            return list;
        }

        private RellayComand sortDepartment;
        public RellayComand SortDepartment
        {
            get
            {
                return sortDepartment ?? new RellayComand(obj =>
                {

                    MainWindow.AllDepartmentsView.ItemsSource = SortListDepartment();
                    MainWindow.AllDepartmentsView.Items.Refresh();

                });
            }
        }


        public List<Client> SortListClient()
        {
            var list = AllClients.OrderBy(item => item.Name).ToList();
            return list;
        }

        private RellayComand sortClient;
        public RellayComand SortClient
        {
            get
            {
                return sortClient ?? new RellayComand(obj =>
                {

                    MainWindow.AllClientView.ItemsSource = SortListClient();
                    MainWindow.AllClientView.Items.Refresh();

                });
            }
        }
        #endregion

        private RellayComand choseManager;
        public RellayComand ChoseManager
        {
            get
            {
                return choseManager ?? new RellayComand(obj =>
                {
                    Accses = true;
                    MainWindow newDepartmentWindow = new MainWindow();
                    SetCenterPositionAndOpen(newDepartmentWindow);
                });
            }
        }

        private RellayComand choseConsultant;
        public RellayComand ChoseConsultant
        {
            get
            {
                return choseConsultant ?? new RellayComand(obj =>
                {
                    Accses = false;
                    MainWindow newDepartmentWindow = new MainWindow();
                    newDepartmentWindow.AddButton.Visibility = Visibility.Collapsed;
                    SetCenterPositionAndOpen(newDepartmentWindow);
                });
            }
        }
    }
}

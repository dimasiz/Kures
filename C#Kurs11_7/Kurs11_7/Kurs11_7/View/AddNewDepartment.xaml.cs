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
    /// Логика взаимодействия для AddNewDepartment.xaml
    /// </summary>
    public partial class AddNewDepartment : Window
    {
        public AddNewDepartment()
        {
            InitializeComponent();
            DataContext = new DataManager();
        }
    }
}

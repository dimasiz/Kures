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
    /// Логика взаимодействия для Massage.xaml
    /// </summary>
    public partial class Massage : Window
    {
        public Massage(string text)
        {
            InitializeComponent();
            MassageText.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

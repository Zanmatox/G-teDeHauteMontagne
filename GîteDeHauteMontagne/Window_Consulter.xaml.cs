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

namespace GîteDeHauteMontagne
{
    /// <summary>
    /// Logique d'interaction pour Window_Consulter.xaml
    /// </summary>
    public partial class Window_Consulter : Window
    {
        public Window_Consulter()
        {
            InitializeComponent();
        }

        private void btn_annulerConsul_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

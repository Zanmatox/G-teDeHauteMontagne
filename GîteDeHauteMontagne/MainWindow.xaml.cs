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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GîteDeHauteMontagne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Réserver_Click(object sender, RoutedEventArgs e)
        {
            Window_Réserver win_réserver = new Window_Réserver();
            win_réserver.Show();
        }

        private void btn_Consulter_Click(object sender, RoutedEventArgs e)
        {
            Window_Consulter win_consulter = new Window_Consulter();
            win_consulter.Show();
        }

        private void btn_Modifier_Click(object sender, RoutedEventArgs e)
        {
            Window_Modifier win_modifier = new Window_Modifier();
            win_modifier.Show();
        }

        private void btn_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Window_Supprimer win_supprimer = new Window_Supprimer();
            win_supprimer.Show();

        }
    }
}

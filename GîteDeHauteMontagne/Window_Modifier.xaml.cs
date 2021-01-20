using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour Window_Modifier.xaml
    /// </summary>
    public partial class Window_Modifier : Window
    {
        public Window_Modifier()
        {
            InitializeComponent();
        }

        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            Window_Réserver win_réserver = new Window_Réserver();
            win_réserver.Show();
        }

        private void btn_annulerModif_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            // 1. Instantiate the connection 
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AFPA\CHEUNG\DESKTOP\WPF\MINI_PROJET\GÎTEDEHAUTEMONTAGNE\GÎTEDEHAUTEMONTAGNEBDD.MDF;Integrated Security=True;Connect Timeout=30");
            SqlDataReader rdr = null;
            listBoxAfficher.Items.Clear();
            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object
                string adding = @"select* from Personne";
                //string adding = @"select* from Personne  where Nom ='" + textbox_Nom.Text.ToString() + '"';
                ;
                SqlCommand cmd = new SqlCommand(adding, conn);
                // 4. Use the connection   //
                // get query results
                rdr = cmd.ExecuteReader();
                // print the CustomerID of each record  
                while (rdr.Read())
                {
                    listBoxAfficher.Items.Add("Id :" + rdr[0] + "\r\nNom : " + rdr[1] + "\r\nPrénom : " + " " + rdr[2] + "\r\nNumero de telephone : " + " " + rdr[3] + "\r\nMail : " + " " + rdr[4]);
                }

            }
            finally
            {
                // close the reader 
                if (rdr != null)
                { rdr.Close(); }

                // 5. Close the connection       
                if (conn != null)
                {
                    conn.Close();
                }
            }
   
        }
    }
}

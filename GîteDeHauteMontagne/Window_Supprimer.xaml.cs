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
    /// Logique d'interaction pour Window_Supprimer.xaml
    /// </summary>
    public partial class Window_Supprimer : Window
    {
        public Window_Supprimer()
        {
            InitializeComponent();
            afficherList();
            textboxDelete.Text = "";
        }

        void afficherList()
        {
            // 1. Instantiate the connection 
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AFPA\CHEUNG\DESKTOP\WPF\MINI_PROJET\GÎTEDEHAUTEMONTAGNE\GÎTEDEHAUTEMONTAGNEBDD.MDF;Integrated Security=True;Connect Timeout=30");
            SqlDataReader rdr = null;
            ListReservation.Items.Clear();
            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object
                string adding = @"select* from Personne";
                ;
                SqlCommand cmd = new SqlCommand(adding, conn);
                // 4. Use the connection   //
                // get query results
                rdr = cmd.ExecuteReader();
                // print the CustomerID of each record  
                while (rdr.Read())
                {
                    ListReservation.Items.Add("Id :" + rdr[0] + "\r\nNom : " + rdr[1] + "\r\nPrénom : " + " " + rdr[2] + "\r\nNumero de telephone : " + " " + rdr[3] + "\r\nMail : " + " " + rdr[4]);
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
        private void btn_annulerSuppr_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            // 1. Instantiate the connection 
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AFPA\CHEUNG\DESKTOP\WPF\MINI_PROJET\GÎTEDEHAUTEMONTAGNE\GÎTEDEHAUTEMONTAGNEBDD.MDF;Integrated Security=True;Connect Timeout=30");
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object

                SqlCommand cmd = new SqlCommand(@" delete from Personne where Id = '" + textboxDelete.Text + "'", conn);
                // 4. Use the connection   //
                // get query results
                rdr = cmd.ExecuteReader();
                // print the CustomerID of each record  
                /*      while (rdr.Read())
                      {
                          lstCustomer.Items.Add(rdr[0]);
                      }*/

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
            afficherList();
        }
    }
}

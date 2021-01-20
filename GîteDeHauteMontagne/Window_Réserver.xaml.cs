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
    /// Logique d'interaction pour Window_Réserver.xaml
    /// </summary>
    public partial class Window_Réserver : Window
    {
        public Window_Réserver()
        {
            InitializeComponent();
            fill_comboBox();
        }

        void fill_comboBox()
        {

                // 1. Instantiate the connection 
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AFPA\CHEUNG\DESKTOP\WPF\MINI_PROJET\GÎTEDEHAUTEMONTAGNE\GÎTEDEHAUTEMONTAGNEBDD.MDF;Integrated Security=True;Connect Timeout=30");
                SqlDataReader rdr = null;
               
                try
                {
                    // 2. Open the connection
                    conn.Open();
                    // 3. Pass the connection to a command object
                    string adding = @"select* from Hebergement";
                    ;
                    SqlCommand cmd = new SqlCommand(adding, conn);
                    // 4. Use the connection   //
                    // get query results
                    rdr = cmd.ExecuteReader();
                    // print the CustomerID of each record  
                    while (rdr.Read())
                    {
                        comboBoxType.Items.Add(rdr[1]);
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
        
            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 1. Instantiate the connection 
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AFPA\CHEUNG\DESKTOP\WPF\MINI_PROJET\GÎTEDEHAUTEMONTAGNE\GÎTEDEHAUTEMONTAGNEBDD.MDF;Integrated Security=True;Connect Timeout=30");
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object

                SqlCommand cmd = new SqlCommand("insert into Personne(Nom, Prénom, Num, Mail) values ('" + textbox_Nom.Text + "', '" + textbox_Prénom.Text + "', '" + textbox_Numéro.Text + "', '" + textbox_Mail.Text + "')", conn);
                // 4. Use the connection   //
                if (textbox_Nom.Text == "" || textbox_Prénom.Text == "")
                {
                    MessageBox.Show("Veuilliez entrer un nom et un prénom ! ");
                }
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
            textbox_Nom.Text = "";
            textbox_Prénom.Text = "";
            textbox_Numéro.Text = "";
            textbox_Mail.Text = "";
        }

        private void btn_annulerReserv_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

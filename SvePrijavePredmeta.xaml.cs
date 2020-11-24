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
using MySql.Data.MySqlClient;

namespace SistemZaPrijavuIspita_27_6_2017
{
    /// <summary>
    /// Interaction logic for SvePrijavePredmeta.xaml
    /// </summary>
    public partial class SvePrijavePredmeta : Window
    {

        MySqlConnection connection;
        private int IDIspita;

        public SvePrijavePredmeta(string naziv_predmeta, int id_ispita)
        {
            InitializeComponent();
            tbNazivPredmeta.Content = naziv_predmeta;
            IDIspita = id_ispita;
            initializeStudents();
        }


        private void initializeStudents()
        {
            int brojac = 1;
            stPanelStudenti.Children.Clear();
            connection = new MySqlConnection(Properties.Settings.Default.connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM prijave WHERE ispiti_id=" + IDIspita + ";";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserControlPrijavaStudenta student = new UserControlPrijavaStudenta(reader["ime"].ToString(), reader["prezime"].ToString(), (brojac++), Convert.ToInt32(reader["br_ind"].ToString()), reader.GetDateTime(reader.GetOrdinal("datum_prijave")));
                    stPanelStudenti.Children.Add(student);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

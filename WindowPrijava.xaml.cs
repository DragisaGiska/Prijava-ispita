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
    /// Interaction logic for WindowPrijava.xaml
    /// </summary>
    public partial class WindowPrijava : Window
    {

        MySqlConnection connection;

        public delegate void MyEventHandler();
        public event MyEventHandler Prijavljeno;

        private int idIspita;
        public WindowPrijava(int id_ispita)
        {
            InitializeComponent();

            idIspita = id_ispita;
            tbIme.Focus();
        }

        private void btnPrijaviIspit_Click(object sender, RoutedEventArgs e)
        {
            if (checkInput())
            {
                connection = new MySqlConnection(Properties.Settings.Default.connectionString);
                try
                {
                    connection.Open();
                    string date=DateTime.Now.ToString("yyyy-MM-dd");
                    string query = "INSERT INTO prijave (ime, prezime, br_ind, datum_prijave, ispiti_id) VALUES ('" + tbIme.Text + "', '" + tbPrezime.Text + "', " + Convert.ToInt32(tbBrIndeksa.Text) + ", '" + date + "', " + idIspita + ");";

                    MySqlCommand command = new MySqlCommand(query,connection);
                    command.ExecuteNonQuery();
                    Prijavljeno();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Ispravno popunite sva polja.");
            }
        }

        private bool checkInput()
        {
            int br;
            if (int.TryParse(tbBrIndeksa.Text, out br) && (!string.IsNullOrWhiteSpace(tbIme.Text)) && (!string.IsNullOrWhiteSpace(tbPrezime.Text)))
                return true;
            return false;
        }
    }
}

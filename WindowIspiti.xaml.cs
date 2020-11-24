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
    /// Interaction logic for WindowIspiti.xaml
    /// </summary>
   
    public partial class WindowIspiti : Window
    {
        MySqlConnection connection;
        MySqlConnection connection2;
        private string godinaStudiranja="";
        private string smjerSt = "";
        public WindowIspiti(string godina,string smjer)
        {
            InitializeComponent();
            godinaStudiranja = godina;
            smjerSt = smjer;
            initializeInfoFromDB();
        }

        private void initializeInfoFromDB()
        {
            stPanelIspiti.Children.Clear();
            connection = new MySqlConnection(Properties.Settings.Default.connectionString);
            connection2 = new MySqlConnection(Properties.Settings.Default.connectionString);

            try
            {
                connection.Open();
                connection2.Open();
                
                string query = "SELECT * FROM ispiti WHERE godina="+Convert.ToInt32(godinaStudiranja)+" AND smjer LIKE '%"+smjerSt+"%' ;";
                MySqlCommand command = new MySqlCommand(query,connection);
               
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    string queryBrPrijava = "SELECT COUNT(*) FROM prijave WHERE ispiti_id="+reader["id"]+";";
                    MySqlCommand command2 = new MySqlCommand(queryBrPrijava, connection2);
                    Ispit ispit = new Ispit(reader["skraceni_naziv"].ToString(),reader["naziv"].ToString(),reader.GetDateTime(reader.GetOrdinal("datum")), int.Parse(command2.ExecuteScalar().ToString()),Convert.ToInt32(reader["id"].ToString()));
                    ispit.PromjeneUBazi +=()=>{ initializeInfoFromDB(); };
                    stPanelIspiti.Children.Add(ispit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection2.Close();
            }
        }

        

    }
}

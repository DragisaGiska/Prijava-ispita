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

namespace SistemZaPrijavuIspita_27_6_2017
{
    /// <summary>
    /// Interaction logic for UserControlPrijavaStudenta.xaml
    /// </summary>
    public partial class UserControlPrijavaStudenta : UserControl
    {
        public UserControlPrijavaStudenta(string ime, string prezime, int redni_broj, int br_indeksa, DateTime date)
        {
            InitializeComponent();
            lbRedniBroj.Content = redni_broj.ToString()+".";
            lbLicniPodaci.Content = ime + " " + prezime + "  " + br_indeksa;

            lbDatumPrijaveispita.Content = date.ToString("dd.MM.yyyy");
        }
    }
}

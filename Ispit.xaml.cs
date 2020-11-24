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
    /// Interaction logic for Ispit.xaml
    /// </summary>
    public partial class Ispit : UserControl
    {

        public delegate void MyEventHandler();
        public event MyEventHandler PromjeneUBazi;
        public int IDIspita {get; set;}
        private string NazivIspita;
        public Ispit(string skracenica,string naziv,DateTime datum, int brPrijava,int id)
        {
            InitializeComponent();
            lblSkraceniNaziv.Content = skracenica;
            lblNaziv.Content = naziv;
            lblDatum.Content = datum.ToString("dd.MM.yyyy");
            IDIspita = id;
            NazivIspita = naziv;
            if (brPrijava > 0)
            {
                rectPozadina.Fill = Brushes.White;
            }
            else
            {
                rectPozadina.Fill = Brushes.Gray;
            }
            
            this.MouseLeftButtonDown += clickMouseLeftButtonDown;
            this.listaPrijava.MouseLeftButtonDown+= listaPrijava_MouseLeftButtonDown;
        }

        private void clickMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if (listaPrijavaEventRaised == false)
            {
                Ispit ispt = (Ispit)sender;
                WindowPrijava wPrijava = new WindowPrijava(ispt.IDIspita);
                wPrijava.Prijavljeno += () => { PromjeneUBazi(); };
                wPrijava.ShowDialog();
            }
            listaPrijavaEventRaised = false;

        }

        private bool listaPrijavaEventRaised = false;
        private void listaPrijava_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            listaPrijavaEventRaised = true;
            SvePrijavePredmeta ispPrijava = new SvePrijavePredmeta(NazivIspita, IDIspita);
            ispPrijava.ShowDialog();
        }
    }
}

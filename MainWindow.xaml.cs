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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btngod_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            WindowIspiti winIspt=null;
            switch (btn.Content)
            {
                case "I":
                    winIspt = new WindowIspiti("1",getSmjer());
                    break;
                case "II":
                   winIspt = new WindowIspiti("2", getSmjer());
                    break;
                case "III":
                    winIspt = new WindowIspiti("3", getSmjer());
                    break;
                case "IV":
                    winIspt = new WindowIspiti("4", getSmjer());
                    break;
            }
            this.Hide();
            winIspt.ShowDialog();
            this.Show();
        }

        private string getSmjer()
        {
            if (rbAiE.IsChecked == true)
                return "AiE";
            if (rbEE.IsChecked == true)
                return "EE";
            return "RiI";
        }
    }
}

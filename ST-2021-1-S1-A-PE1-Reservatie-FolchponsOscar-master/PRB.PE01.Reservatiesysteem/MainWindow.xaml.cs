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

namespace PRB.PE01.Reservatiesysteem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        const int KostPrijs = 7;
        int Beginuur = 0;
        int Einduur = 0;
        string Naam;
        decimal Korting = 0;
        string LijstElement;
        decimal Uurprijs = 0;
        public MainWindow()


        {
            InitializeComponent();
        }

        private void BeginLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       
        private void ResBtn_Click(object sender, RoutedEventArgs e)
        {
            Beginuur = Convert.ToInt32(BeginLst.Text);
            Einduur = Convert.ToInt32(EindLst.Text);
            Naam = NaamTxt.Text;
            Korting = Convert.ToDecimal(KortingTxt.Text);
            Uurprijs = ((Einduur - Beginuur) * KostPrijs) - Korting;
           
            LijstElement = "Reservatie van " + Naam + " van " + Beginuur + " tot " + Einduur + " met €" + Korting + " korting voor €" + Uurprijs;
            Lijst.Items.Add(LijstElement);

            WachtLbl.Content = Convert.ToInt32(Lijst.Items.Count);
            
        }

        private void AanvaardBtn_Click(object sender, RoutedEventArgs e)
        {
            AanvaardLbl.Content = Convert.ToInt32(AanvaardLbl.Content) + 1;
            Lijst.Items.Remove(Lijst.SelectedItem);
            TotaalLbl.Content = Convert.ToDecimal(TotaalLbl.Content) + Uurprijs;

            WachtLbl.Content = Convert.ToInt32(Lijst.Items.Count);
            Uurprijs = 0;
        }

        private void WeigerBtn_Click(object sender, RoutedEventArgs e)
        {
            WeigerLbl.Content = Convert.ToInt32(WeigerLbl.Content) + 1;
            Lijst.Items.Remove(Lijst.SelectedItem);

            WachtLbl.Content = Convert.ToInt32(Lijst.Items.Count);
            Uurprijs = 0;
        }
    }
}

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
using System.IO;

namespace WPF_Panel_logowania
{
    /// <summary>
    /// Logika interakcji dla klasy Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
		

		}

		private void btnZapisz_Click(object sender, RoutedEventArgs e)
		{
		    panelUsera panelUsera = null;
			string[] line = new string[7];
			line[0] = txbRejImie.Text;
			line[1] = txbRejNazwisko.Text;
			line[2] = txbRejLogin.Text;
			line[3] = txbRejHaslo.Text;
			line[4] = txbRejDataUr.Text;
			line[5] = txbRejAdres.Text;
			line[6] = txbRejEmail.Text;
			
			if ((txbRejImie.Text == "") ||
				(txbRejNazwisko.Text == "") ||
				(txbRejLogin.Text == "") ||
				(txbRejHaslo.Text == "") ||
				(txbRejDataUr.Text == "") ||
				(txbRejAdres.Text == "") ||
				(txbRejEmail.Text == ""))
			{
				MessageBox.Show("Wszystkie pola muszą być wypełnione");
				
			}

			while ((txbRejImie.Text != "") &&
				(txbRejNazwisko.Text != "") &&
				(txbRejLogin.Text != "") &&
				(txbRejHaslo.Text != "") &&
				(txbRejDataUr.Text != "") &&
				(txbRejAdres.Text != "") &&
				(txbRejEmail.Text != ""))
			{
				FileStream plik = new FileStream("PlikTekstowy.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
				plik.Close();
				var userFormat = "{0};{1};{2};{3};{4};{5};{6}";
				var dane = string.Format(userFormat, line[0], line[1], line[2], line[3], line[4], line[5], line[6]);
				StreamWriter file = new StreamWriter("PlikTekstowy.txt", true);
				file.WriteLine(dane);
				file.Close();

				MessageBox.Show("Dane zostały poprawnie zapisane");
				this.Close();

				panelLogowania PanelLogowania = new panelLogowania();
				PanelLogowania.NowyUser(line[0], line[1], line[2], line[3], line[4], line[5], line[6]);
				panelUsera = PanelLogowania.Logowanie(line[2], line[3]);
				break;
			}

		}
	}
}

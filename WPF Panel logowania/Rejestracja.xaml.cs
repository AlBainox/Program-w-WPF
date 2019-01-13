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
		private List<User> ListOfUsers = new List<User>
		{

		};

		public void PobieranieUserow()
		{
			foreach (var line in File.ReadAllLines("PlikTekstowy.txt"))
			{
				var userData = line.Split(';');
				var im = userData[0];
				var nazw = userData[1];
				var login = userData[2];
				var haslo = userData[3];
				var dataUro = userData[4];
				var adres = userData[5];
				var email = userData[6];

				var userFromFile = new User(im, nazw, login, haslo, dataUro, adres, email);

				ListOfUsers.Add(userFromFile);
			}
		}


		private void btnZapisz_Click(object sender, RoutedEventArgs e)
		{
			PobieranieUserow();
			foreach (User user in ListOfUsers)
			{
				if (txbRejLogin.Text == user.Login)
				{
					MessageBox.Show("Podany login istnieje już w bazie");
				}
			}


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

				break;
			}

			

		}
	}
}

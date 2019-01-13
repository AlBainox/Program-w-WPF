using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPF_Panel_logowania
{
	/// <summary>
	/// Logika interakcji dla klasy MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			PobieranieUserow();
		}

		private panelUsera PanelUsera = null;
		private bool wylogowanie = false;

		public void MetodaWylogowujaca()
		{
			wylogowanie = true;
		}

		private void btnZaloguj_Click(object sender, RoutedEventArgs e)
		{

			if (PanelUsera == null)
			{
				if ((txbLogin.Text == "") || (txbHaslo.Text == ""))
				{
					MessageBox.Show("Pola nie mogą być puste");
				}
				string Login = txbLogin.Text;
				string Haslo = txbHaslo.Text;
				PanelUsera = Logowanie(Login, Haslo);

			}
			txbLogin.Clear();
			txbHaslo.Clear();

		}
		// Przycisk Rejestracja
		private void btnWyjscie_Click(object sender, RoutedEventArgs e)
		{
			Rejestracja wdwRej = new Rejestracja();
			wdwRej.ShowDialog();

		}


		public List<User> PobieranieUserow()
		{
			List<User> ListOfUsers = new List<User>();

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
			return ListOfUsers;
		}

		public panelUsera Logowanie(string log, string has)
		{

			foreach (User user in PobieranieUserow())
			{
				if ((log == user.Login && has == user.Haslo))
				{					
					if (wylogowanie == false)
					{
						PanelUsera = new panelUsera(user);
						MessageBox.Show("Udało Ci się pomyślnie zalogować!");
						PanelUzytkownika panel = new PanelUzytkownika();

						panel.ShowDialog();

					}
				}
			}
			return null;
		}

	}
}

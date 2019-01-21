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
using System.Windows.Shapes;
using System.IO;

namespace WPF_Panel_logowania
{
	/// <summary>
	/// Logika interakcji dla klasy PanelUzytkownika.xaml
	/// </summary>
	public partial class PanelUzytkownika : Window
	{
		private User user = UserManager.GetUser();

		public PanelUzytkownika()
		{
			InitializeComponent();
			lblImie.Content = user.Imie;
			lblNazwisko.Content = user.Nazwisko;
			lblLogin.Content = user.Login;
			lblHaslo.Content = user.Haslo;
			lblDataUr.Content = user.DataUrodzenia;
			lblAdres.Content = user.Adres;
			lblEmail.Content = user.Email;

			txbImie.Text = user.Imie;
			txbNazwisko.Text = user.Nazwisko;
			txbLogin.Text = user.Login;
			txbHaslo.Text = user.Haslo;
			txbDataUr.Text = user.DataUrodzenia;
			txbAdres.Text = user.Adres;
			txbEmail.Text = user.Email;
		}


		private void btnWyloguj_Click(object sender, RoutedEventArgs e)
		{
			UserManager.LogOut();
			MessageBox.Show("Użytkownik został poprawnie wylogowany");
			this.Close();
		}

		private void btnZapisz_Click(object sender, RoutedEventArgs e)
		{
						
			var userFormat = "{0};{1};{2};{3};{4};{5};{6}";
			var newData = string.Format(
				userFormat,
				txbImie.Text,
				txbNazwisko.Text,
				txbLogin.Text,
				txbHaslo.Text,
				txbDataUr.Text,
				txbAdres.Text,
				txbEmail.Text);


			var oldData = string.Format(
				userFormat,
				user.Imie,
				user.Nazwisko,
				user.Login,
				user.Haslo,
				user.DataUrodzenia,
				user.Adres,
				user.Email);

			string text = File.ReadAllText("PlikTekstowy.txt");
			text = text.Replace(oldData, newData);
			File.WriteAllText("PlikTekstowy.txt", text);

			lblImie.Content = user.Imie;
			lblNazwisko.Content = user.Nazwisko;
			lblLogin.Content = user.Login;
			lblHaslo.Content = user.Haslo;
			lblDataUr.Content = user.DataUrodzenia;
			lblAdres.Content = user.Adres;
			lblEmail.Content = user.Email;

			MessageBox.Show("Dane zostały poprawnie zapisane");
			



		}
	}
}

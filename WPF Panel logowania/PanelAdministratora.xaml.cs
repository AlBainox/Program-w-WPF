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
    /// Logika interakcji dla klasy PanelAdministratora.xaml
    /// </summary>
    public partial class PanelAdministratora : Window
    {
        public PanelAdministratora()
        {
            InitializeComponent();
        }

		private User user = UserManager.GetUser();

		private void btnWyloguj_Click(object sender, RoutedEventArgs e)
		{
			UserManager.LogOut();
			MessageBox.Show("Użytkownik został poprawnie wylogowany", "", MessageBoxButton.OK, MessageBoxImage.Warning);

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
				txbNrTel.Text,
				txbAdres.Text,
				txbEmail.Text);


			var oldData = string.Format(
				userFormat,
				user.Imie,
				user.Nazwisko,
				user.Login,
				user.Haslo,
				user.NrTelefonu,
				user.Adres,
				user.Email);

			string text = File.ReadAllText("PlikTekstowy.txt");
			text = text.Replace(oldData, newData);
			File.WriteAllText("PlikTekstowy.txt", text);

			lblImie.Content = user.Imie;
			lblNazwisko.Content = user.Nazwisko;
			lblLogin.Content = user.Login;
			lblHaslo.Content = user.Haslo;
			lblNrTel.Content = user.NrTelefonu;
			lblAdres.Content = user.Adres;
			lblEmail.Content = user.Email;

			MessageBox.Show("Dane zostały poprawnie zapisane", "Zapis danych", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}

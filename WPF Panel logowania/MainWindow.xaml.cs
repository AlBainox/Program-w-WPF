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
using MySql.Data.MySqlClient;
using System.Data;

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
			btnWyswietl.IsEnabled = false;
		}

		ConnectionDB conn = new ConnectionDB();

		public bool DisplaybtnWyswietl()
		{
			var result = UserManager.GetUser();
			while (result == null)
			{
				return false;
			}
			return true;
		}
		public bool DisplayRestOfControls()
		{
			var result = UserManager.GetUser();
			if (result == null)
			{
				return false;
			}
			return true;
		}
		public bool _DisplayRestOfControls()
		{
			var result = UserManager.GetUser();
			if (result == null)
			{
				return true;
			}
			return false;
		}

		private void btnLogining_Click(object sender, RoutedEventArgs e)
		{
			if ((txbLogin.Text == "") || (txbHaslo.Password == ""))
			{
				MessageBox.Show("Pola nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			string Login = txbLogin.Text;
			string Haslo = txbHaslo.Password;

			Logining(Login, Haslo);

			btnWyswietl.IsEnabled = DisplaybtnWyswietl();
			btnZaloguj.IsEnabled = _DisplayRestOfControls();
			btnRejestracja.IsEnabled = _DisplayRestOfControls();

			txbLogin.Clear();
			txbHaslo.Clear();

		}

		private void btnRegistration_Click(object sender, RoutedEventArgs e)
		{
			Rejestracja wdwRej = new Rejestracja();
			wdwRej.ShowDialog();

		}


		public void Logining(string log, string has)
		{

			foreach (User user in conn.DownloadingUsers())
			{

				if ((log == user.Login && has == user.Haslo))
				{
					btnZaloguj.IsEnabled = DisplayRestOfControls();
					btnRejestracja.IsEnabled = DisplayRestOfControls();
					UserManager.SignIn(user);
					MessageBox.Show("Udało Ci się pomyślnie zalogować!", "", MessageBoxButton.OK, MessageBoxImage.Information);
					btnWyswietl.IsEnabled = !btnWyswietl.IsEnabled;
					if (user.Role == UserRole.user)
					{
						PanelUzytkownika panelUzytkownika = new PanelUzytkownika();
						panelUzytkownika.ShowDialog();
					}
					if (user.Role == UserRole.admin)
					{
						PanelAdministratora adminPanel = new PanelAdministratora();
						adminPanel.ShowDialog();
					}
				}
			}
		}

		private void btnWyswietl_Click(object sender, RoutedEventArgs e)
		{
			PanelUzytkownika panelUzytkownika = new PanelUzytkownika();

			if (UserManager.GetUser().Role == UserRole.admin)
			{
				PanelAdministratora administrator = new PanelAdministratora();
				administrator.ShowDialog();
			}
			else
			{
				panelUzytkownika.ShowDialog();
			}
		}


	}
}

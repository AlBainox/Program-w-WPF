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
			btnWyswietl.IsEnabled = false;
		}

		bool adminChecked = false;

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
			if ((txbLogin.Text == "") || (txbHaslo.Text == ""))
			{
				MessageBox.Show("Pola nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			string Login = txbLogin.Text;
			string Haslo = txbHaslo.Text;
					
			Logining(Login, Haslo, adminChecked);

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


		public List<User> DownloadingUsers(bool admin)
		{
			List<User> ListOfUsers = new List<User>();

			if (admin == false)
			{
				foreach (var line in File.ReadAllLines("PlikTekstowy.txt"))
				{
					var userData = line.Split(';');
					var im = userData[0];
					var nazw = userData[1];
					var login = userData[2];
					var haslo = userData[3];
					var nrTel = userData[4];
					var adres = userData[5];
					var email = userData[6];

					var userFromFile = new User(im, nazw, login, haslo, nrTel, adres, email);

					ListOfUsers.Add(userFromFile);
				}
			}
			if (admin == true)
			{

				var adminAccount = new User("admin", "admin", "admin", "admin", "admin", "admin", "admin");

				ListOfUsers.Add(adminAccount);

			}
			return ListOfUsers;
		}

		public void Logining(string log, string has, bool adminChecked)
		{

			foreach (User user in DownloadingUsers(adminChecked))
			{
				if ((log == user.Login && has == user.Haslo))
				{
					btnZaloguj.IsEnabled = DisplayRestOfControls();
					btnRejestracja.IsEnabled = DisplayRestOfControls();
					UserManager.SignIn(user);
					MessageBox.Show("Udało Ci się pomyślnie zalogować!", "", MessageBoxButton.OK, MessageBoxImage.Information);
					btnWyswietl.IsEnabled = !btnWyswietl.IsEnabled;
					if (adminChecked == false)
					{
						PanelUzytkownika panelUzytkownika = new PanelUzytkownika();
						panelUzytkownika.ShowDialog();
					}
					if (adminChecked == true)
					{
						PanelAdministratora adminPanel = new PanelAdministratora();
						adminPanel.ShowDialog();
					}

				}
			}
		}

		private void chbAdmin_Checked(object sender, RoutedEventArgs e)
		{
			adminChecked = true;
		}

		private void btnWyswietl_Click(object sender, RoutedEventArgs e)
		{
			PanelUzytkownika panelUzytkownika = new PanelUzytkownika();
			panelUzytkownika.ShowDialog();
		}

		
	}
}

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


		public List<User> DownloadingUsers()
		{
			List<User> ListOfUsers = new List<User>();


			foreach (var line in File.ReadAllLines("PlikTekstowy.txt"))
			{
				var userData = line.Split(';');
				var result = userData[0];
				var user = "user";
				if (result == user)
				{
					userData[0] = 0.ToString();
				}
				var role = (UserRole)int.Parse(userData[0]);				
				var im = userData[1];
				var nazw = userData[2];
				var login = userData[3];
				var haslo = userData[4];
				var nrTel = userData[5];
				var adres = userData[6];
				var email = userData[7];

				var userFromFile = new User(role,im, nazw, login, haslo, nrTel, adres, email);

				ListOfUsers.Add(userFromFile);
			}
						
			return ListOfUsers;
		}
		

		public void Logining(string log, string has)
		{

			foreach (User user in DownloadingUsers())
			{
				if ((log == user.Login && has == user.Haslo))
				{
					btnZaloguj.IsEnabled = DisplayRestOfControls();
					btnRejestracja.IsEnabled = DisplayRestOfControls();
					UserManager.SignIn(user);
					MessageBox.Show("Udało Ci się pomyślnie zalogować!", "", MessageBoxButton.OK, MessageBoxImage.Information);
					btnWyswietl.IsEnabled = !btnWyswietl.IsEnabled;
					if (user.Role==UserRole.user)
					{
						PanelUzytkownika panelUzytkownika = new PanelUzytkownika();
						panelUzytkownika.ShowDialog();
					}
					if (user.Role==UserRole.admin)
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

			if (UserManager.GetUser().Role== UserRole.admin)
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

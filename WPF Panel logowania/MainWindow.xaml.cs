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
		}

		
		private void btnLogining_Click(object sender, RoutedEventArgs e)
		{
			if ((txbLogin.Text == "") || (txbHaslo.Text == ""))
			{
				MessageBox.Show("Pola nie mogą być puste");
			}
			string Login = txbLogin.Text;
			string Haslo = txbHaslo.Text;
			Logining(Login, Haslo);

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

		public void Logining(string log, string has)
		{

			foreach (User user in DownloadingUsers())
			{
				if ((log == user.Login && has == user.Haslo))
				{
					UserManager.SignIn(user);
					MessageBox.Show("Udało Ci się pomyślnie zalogować!");
					PanelUzytkownika panel = new PanelUzytkownika(user);
					panel.ShowDialog();

				}
			}
			
		}

	}
}

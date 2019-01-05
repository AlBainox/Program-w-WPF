using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Panel_logowania
{
    class panelLogowania
    {
		private static List<User> ListOfUsers = new List<User>
		{
			
		};

		public static void PobieranieUserow()
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
				
				var userFromFile = new User(im, nazw, login, haslo,dataUro,adres,email);

				ListOfUsers.Add(userFromFile);

			}
		}


		public panelUsera Logowanie(string log, string has)
		{
			PobieranieUserow();
			foreach (User user in ListOfUsers)
			{
				if ((log == user.Login && has == user.Haslo))
				{
					PanelUzytkownika panel = new PanelUzytkownika();
					MessageBox.Show("Udało Ci się pomyślnie zalogować!");

					panel.ShowDialog();
					return new panelUsera(user);

				}								
			}
			
			return null;
		}


		public void NowyUser(string noweImie, string noweNazwisko, string nowyLogin, string noweHaslo, string dataUrodzenia, string adres, string email)
		{
			ListOfUsers.Add(new User(noweImie, noweNazwisko, nowyLogin, noweNazwisko, dataUrodzenia,adres,email));

		}
	}
}

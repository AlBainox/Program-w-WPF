using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WPF_Panel_logowania
{
    class panelUsera
    {
		private User LoggedUser;

		public panelUsera(User loggedUser)
		{
			LoggedUser = loggedUser;
		}
		public void WriteOptions()
		{
			Console.Clear();
			Console.WriteLine($"Witaj {LoggedUser.Imie}, Poniżej znajdują się Twoje dostępne opcje");
			Console.WriteLine("Wybierz opcje:");
			Console.WriteLine("1 - Zmien imie");
			Console.WriteLine("2 - Zmien nazwisko");
			Console.WriteLine("3 - Zmien login");
			Console.WriteLine("4 - Zmien haslo");
			Console.WriteLine("5 - Dadaj dane szczegółowe");
			Console.WriteLine("6 - Wyloguj sie");
			Console.SetCursorPosition(15, 1);
		}

	public void ZmienImie(string noweImie)
		{
			LoggedUser.Imie = noweImie;

			Console.WriteLine("Zmieniono imie");
			Thread.Sleep(2000);
			Console.Clear();
			//Program.panelUzytkownika();
		}

		public void ZmienNazwisko(string noweNazwisko)
		{
			LoggedUser.Nazwisko = noweNazwisko;
			Console.WriteLine("Zmieniono nazwisko");
			Thread.Sleep(2000);
			Console.Clear();
			//Program.panelUzytkownika();
		}

		public void ZmienLogin(string nowyLogin)
		{
			LoggedUser.Login = nowyLogin;
			Console.WriteLine("Zmieniono login");
			Thread.Sleep(2000);
			Console.Clear();
			//Program.panelUzytkownika();
		}

		public void ZmienHaslo(string noweHaslo)
		{
			LoggedUser.Haslo = noweHaslo;
			Console.WriteLine("Zmieniono haslo");
			Thread.Sleep(2000);
			Console.Clear();
			//Program.panelUzytkownika();
		}

		public void DodatkoweDane()
		{
			Console.Clear();
			Console.WriteLine("Wybierz opcje: ");
			Console.WriteLine("1. Data urodzenia");
			Console.WriteLine("2. Adres");
			Console.WriteLine("3. Data aktualizacji");
			Console.WriteLine("4. Powrót do poprzedniego menu");
			Console.SetCursorPosition(15, 0);
			string wybor = Console.ReadLine();
			switch (wybor)
			{
				case "1":
					Console.Clear();
					DataUrodzenia();
					break;
				case "2":
					Console.Clear();
					Adres();
					break;
				case "3":
					Console.Clear();
					DataAktualizacji();
					break;
				case "4":
					Console.Clear();
					//Program.panelUzytkownika();
					break;

			}
		}

		private void DataAktualizacji()
		{
			Console.WriteLine("Wybierz opcje: ");
			Console.WriteLine("1. Podaj/Zmien date aktualizacji danych");
			Console.WriteLine("2. Powrót do poprzedniego menu");
			Console.WriteLine(LoggedUser.Email);
			Console.SetCursorPosition(15, 0);
			string wybor2 = Console.ReadLine();
			switch (wybor2)
			{
				case "1":
					Console.SetCursorPosition(0, 3);
					LoggedUser.Email = Console.ReadLine();
					Console.Clear();
					DataAktualizacji();
					break;
				case "2":
					DodatkoweDane();
					break;
			}
		}

		private void Adres()
		{
			Console.WriteLine("Wybierz opcje: ");
			Console.WriteLine("1. Podaj/Zmien adres");
			Console.WriteLine("2. Powrót do poprzedniego menu");
			Console.WriteLine(LoggedUser.Adres);
			Console.SetCursorPosition(15, 0);
			string wybor3 = Console.ReadLine();
			switch (wybor3)
			{
				case "1":
					Console.SetCursorPosition(0, 3);
					LoggedUser.Adres = Console.ReadLine();
					Console.Clear();
					Adres();
					break;
				case "2":
					DodatkoweDane();
					break;
			}
		}

		private void DataUrodzenia()
		{
			Console.WriteLine("Wybierz opcje: ");
			Console.WriteLine("1. Podaj/Zmien date urodzenia");
			Console.WriteLine("2. Powrót do poprzedniego menu");
			Console.WriteLine(LoggedUser.DataUrodzenia);
			Console.SetCursorPosition(15, 0);
			string wybor4 = Console.ReadLine();
			switch (wybor4)
			{
				case "1":
					Console.SetCursorPosition(0, 3);
					LoggedUser.DataUrodzenia = Console.ReadLine();
					Console.Clear();
					DataUrodzenia();
					break;

				case "2":

					DodatkoweDane();
					break;

			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Panel_logowania
{
    public class User
    {
		string imie, nazwisko, login, haslo, dataUrodzenia, adres, email;

		public string Imie
		{
			get { return imie; }
			set { imie = value; }
		}
		public string Nazwisko
		{
			get { return nazwisko; }
			set { nazwisko = value; }
		}
		public string Login
		{
			get { return login; }
			set { login = value; }
		}
		public string Haslo
		{
			get { return haslo; }
			set { haslo = value; }
		}
		public string DataUrodzenia
		{
			get { return dataUrodzenia; }
			set { dataUrodzenia = value; }
		}
		public string Adres
		{
			get { return adres; }
			set { adres = value; }
		}
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public User(string imie, string nazwisko, string login, string haslo, string dataUrodzenia, string adres, string email)
		{
			this.imie = imie;
			this.nazwisko = nazwisko;
			this.login = login;
			this.haslo = haslo;
			this.dataUrodzenia = dataUrodzenia;
			this.adres = adres;
			this.email = email;
		}
	}
}


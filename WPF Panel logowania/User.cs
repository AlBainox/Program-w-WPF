using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Panel_logowania
{
	public enum UserRole
	{
		user,
		admin
	}
	public class User
	{
		string  imie, nazwisko, login, haslo, nrTel, adres, email;
		int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public UserRole Role { get; set; }

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
		public string NrTelefonu
		{
			get { return nrTel; }
			set { nrTel = value; }
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

		public User(UserRole role, string imie, string nazwisko, string login, string haslo, string nrTel, string adres, string email)
		{
			this.Role = role;
			this.imie = imie;
			this.nazwisko = nazwisko;
			this.login = login;
			this.haslo = haslo;
			this.nrTel = nrTel;
			this.adres = adres;
			this.email = email;
		}
		public User(int id, UserRole role, string imie, string nazwisko, string login, string haslo, string nrTel, string adres, string email)
		{
			this.id = id;
			this.Role = role;
			this.imie = imie;
			this.nazwisko = nazwisko;
			this.login = login;
			this.haslo = haslo;
			this.nrTel = nrTel;
			this.adres = adres;
			this.email = email;
		}
	}
}


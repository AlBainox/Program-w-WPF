using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WPF_Panel_logowania
{
	[TestFixture]
	class TestLoginPanel
	{
		[TestCase]
		public void SignInNameEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.Imie, result.Imie);

		}
		[TestCase]
		public void SignInSurnameEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.Nazwisko, result.Nazwisko);
		}
		[TestCase]
		public void SignInLoginEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.Login, result.Login);
		}
		[TestCase]
		public void SignInPasswordEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.Haslo, result.Haslo);
		}
		[TestCase]
		public void SignInDtOfBrthEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.NrTelefonu, result.NrTelefonu);
		}
		[TestCase]
		public void SignInAdresEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.Adres, result.Adres);
		}
		[TestCase]
		public void SignInEmailEqualResult()
		{
			string dane = "xxx";
			UserRole role = UserRole.user;
			var SampleUser = new User(role, dane, dane, dane, dane, dane, dane, dane);

			UserManager.SignIn(SampleUser);
			var result = UserManager.GetUser();
			Assert.AreEqual(SampleUser.Email, result.Email);
		}

	}
}

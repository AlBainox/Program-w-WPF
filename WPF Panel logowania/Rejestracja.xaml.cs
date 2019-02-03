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
using MySql.Data.MySqlClient;
using System.Data;

namespace WPF_Panel_logowania
{
	/// <summary>
	/// Logika interakcji dla klasy Rejestracja.xaml
	/// </summary>
	public partial class Rejestracja : Window
	{
		public Rejestracja()
		{
			InitializeComponent();


		}
		private List<User> ListOfUsers = new List<User>
		{

		};
		ConnectionDB conn = new ConnectionDB();
		

		public void DownloadingUserToCheck()
		{
			List<User> ListOfUsers = new List<User>();
			conn.connect();
			MySqlDataAdapter daClient = new MySqlDataAdapter("select * from client",conn.connection);
			DataSet dsClient = new DataSet("Client");
			daClient.FillSchema(dsClient, SchemaType.Source, "Client");
			daClient.Fill(dsClient, "Client");
			DataTable tblClient = dsClient.Tables["Client"];


			foreach (DataRow line in tblClient.Rows)
			{
				DataRow drCurrent = line;
				var id = int.Parse(drCurrent["id"].ToString());

				var result = drCurrent["UserRole"].ToString();
				string admin = "admin";
				string user = "user";
				if (result == admin)
				{
					drCurrent["UserRole"] = 1.ToString();
				}
				else if (result == user)
				{
					drCurrent["UserRole"] = 0.ToString();
				}
				var role = (UserRole)int.Parse(drCurrent["UserRole"].ToString());
				var im = drCurrent["Imie"].ToString();
				var nazw = drCurrent["Nazwisko"].ToString();
				var login = drCurrent["Login"].ToString();
				var haslo = drCurrent["Haslo"].ToString();
				var nrTel = drCurrent["Telefon"].ToString();
				var adres = drCurrent["Adres"].ToString();
				var email = drCurrent["Email"].ToString();

				var userFromFile = new User(id, role, im, nazw, login, haslo, nrTel, adres, email);

				ListOfUsers.Add(userFromFile);
			}
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			DownloadingUserToCheck();
			foreach (User user in ListOfUsers)
			{
				if (txbRejLogin.Text == user.Login)
				{
					MessageBox.Show("Podany login istnieje już w bazie", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			string[] line = new string[8];
			line[0] = UserRole.user.ToString();
			line[1] = txbRejImie.Text;
			line[2] = txbRejNazwisko.Text;
			line[3] = txbRejLogin.Text;
			line[4] = txbRejHaslo.Text;
			line[5] = txbRejNrTel.Text;
			line[6] = txbRejAdres.Text;
			line[7] = txbRejEmail.Text;

			if ((txbRejImie.Text == "") ||
				(txbRejNazwisko.Text == "") ||
				(txbRejLogin.Text == "") ||
				(txbRejHaslo.Text == "") ||
				(txbRejNrTel.Text == "") ||
				(txbRejAdres.Text == "") ||
				(txbRejEmail.Text == ""))
			{
				MessageBox.Show("Wszystkie pola muszą być wypełnione", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

			}

			while ((txbRejImie.Text != "") &&
				(txbRejNazwisko.Text != "") &&
				(txbRejLogin.Text != "") &&
				(txbRejHaslo.Text != "") &&
				(txbRejNrTel.Text != "") &&
				(txbRejAdres.Text != "") &&
				(txbRejEmail.Text != ""))
			{
				FileStream createFile = new FileStream("PlikTekstowy.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
				createFile.Close();
				var userFormat = "{0};{1};{2};{3};{4};{5};{6};{7}";
				var data = string.Format(userFormat, line[0], line[1], line[2], line[3], line[4], line[5], line[6], line[7]);
				StreamWriter file = new StreamWriter("PlikTekstowy.txt", true);
				file.WriteLine(data);
				file.Close();

				MessageBox.Show("Dane zostały poprawnie zapisane", "Zapis danych", MessageBoxButton.OK, MessageBoxImage.Information);
				this.Close();

				try
				{
					
					conn.connect();
					
					conn.AddingRecord(line[0], line[1], line[2], line[3], line[4], line[5], line[6], line[7]);

					conn.disconnect();
				}
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{
					MessageBox.Show("Błąd połaczenia z bazą danych", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

				}
				
				break;
			}



		}
	}
}

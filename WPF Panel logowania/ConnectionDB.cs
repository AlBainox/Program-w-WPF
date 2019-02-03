using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.IO;

namespace WPF_Panel_logowania
{
	class ConnectionDB
	{
		protected static string myConnection = "server=127.0.0.1;uid=root;pwd=albertbrzakala;database=test";

		public MySqlConnection connection;

		public bool connect()
		{
			try
			{
				connection = new MySqlConnection(myConnection);
				connection.Open();
				return true;
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Błąd połaczenia z bazą danych", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
		}
		public bool disconnect()
		{
			try
			{
				connection.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool query(string query)
		{
			MySqlCommand xquery = new MySqlCommand(query);
			try
			{
				xquery.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				return false;
			}
			return true;
		}

		public DataSet select(string query)
		{
			MySqlCommand xquery = new MySqlCommand(query, connection);
			MySqlDataAdapter xdata = new MySqlDataAdapter(xquery);
			DataSet res = new DataSet();
			try
			{
				xdata.Fill(res);
			}
			catch
			{
				return null;
			}
			return res;
		}

		public void AddingRecord(string role, string imie, string nazwisko,string login, string haslo, string nrTel, string adres, string email)
		{
			MySqlDataAdapter daClient = new MySqlDataAdapter("SELECT * FROM client", connection);
			DataSet dsClient = new DataSet("Client");
			daClient.FillSchema(dsClient, SchemaType.Source, "Client");
			daClient.Fill(dsClient, "Client");
			DataTable tblClient = dsClient.Tables["Client"];
			DataRow drClient;
			drClient = tblClient.NewRow();

			drClient["UserRole"] = role;
			drClient["Imie"] = imie;
			drClient["Nazwisko"] = nazwisko;
			drClient["Login"] = login;
			drClient["Haslo"] = haslo;
			drClient["Telefon"] = nrTel;
			drClient["Adres"] = adres;
			drClient["Email"] = email;

			tblClient.Rows.Add(drClient);

			MySqlCommandBuilder objCommandBuilder = new MySqlCommandBuilder(daClient);
			daClient.ContinueUpdateOnError = true;
			daClient.Update(dsClient, "Client");

		}

		public void Modification(string idClient, string imie, string nazwisko, string haslo, string telefon, string adres, string email)
		{
			MySqlDataAdapter daClient = new MySqlDataAdapter("SELECT * FROM	client", connection);
			DataSet dsClient = new DataSet("Client");
			daClient.FillSchema(dsClient, SchemaType.Source, "Client");
			daClient.Fill(dsClient, "Client");
			DataTable tblClient = dsClient.Tables["Client"];
			DataRow drCurrent;
			
			drCurrent = tblClient.Rows.Find(idClient);
			drCurrent.BeginEdit();
			drCurrent["Imie"] = imie;
			drCurrent["Nazwisko"] = nazwisko;
			drCurrent["Haslo"] = haslo;
			drCurrent["Telefon"] = telefon;
			drCurrent["Adres"] = adres;
			drCurrent["Email"] = email;
			drCurrent.EndEdit();

			MySqlCommandBuilder objCommandBuilder = new MySqlCommandBuilder(daClient);
			daClient.ContinueUpdateOnError = true;
			daClient.Update(dsClient, "Client");
			disconnect();
		}

		public List<User> DownloadingUsers()
		{
			List<User> ListOfUsers = new List<User>();			
			connect();
			MySqlDataAdapter daClient = new MySqlDataAdapter("select * from client", connection);
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

			disconnect();
			return ListOfUsers;
		}


	}

}


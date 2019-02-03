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
using System.Windows.Shapes;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace WPF_Panel_logowania
{
	/// <summary>
	/// Logika interakcji dla klasy PanelUzytkownika.xaml
	/// </summary>
	public partial class PanelUzytkownika : Window
	{
		private User user = UserManager.GetUser();

		public PanelUzytkownika()
		{
			InitializeComponent();
			DisplayProductTable();
			displayCurrentUser();
		}

		protected static string myConnection = "server=127.0.0.1;uid=root;pwd=albertbrzakala;database=test";

		private void btnWyloguj_Click(object sender, RoutedEventArgs e)
		{			
			UserManager.LogOut();
			MessageBox.Show("Użytkownik został poprawnie wylogowany", "", MessageBoxButton.OK,MessageBoxImage.Warning);
			
			this.Close();
		}

		private void btnZapisz_Click(object sender, RoutedEventArgs e)
		{
			string idClient = user.Id.ToString();
			ConnectionDB conn = new ConnectionDB();
			conn.connect();
			conn.Modification(idClient, txbImie.Text, txbNazwisko.Text, txbHaslo.Text, txbTelefon.Text, txbAdres.Text, txbEmail.Text);
			conn.disconnect();	
			MessageBox.Show("Dane zostały poprawnie zapisane","Zapis danych",MessageBoxButton.OK,MessageBoxImage.Information);
			
		}

		public void DisplayProductTable()
		{
			string sql = "SELECT * FROM shop";

			MySqlConnection connection = new MySqlConnection(myConnection);

			try
			{
				connection.Open();

				using (MySqlCommand cmdSl = new MySqlCommand(sql, connection))
				{
					DataTable dt = new DataTable();
					MySqlDataAdapter da = new MySqlDataAdapter(cmdSl);
					da.Fill(dt);

					dgProdukty.ItemsSource = dt.DefaultView;
				}
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Błąd połaczenia z bazą danych", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			connection.Close();
		}
		private void displayCurrentUser()
		{
			using (MySqlConnection connection = new MySqlConnection(myConnection))
			{
				using (MySqlCommand cmd = new MySqlCommand())
				{
					string id = UserManager.GetUser().Id.ToString(); ;
					cmd.Connection = connection;
					cmd.CommandText = "SELECT * FROM	client WHERE ID=" + id;
					cmd.Parameters.AddWithValue("id", id);
					using (MySqlDataAdapter ad = new MySqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();
						ad.Fill(dt);
						dgDaneUsera.ItemsSource = dt.DefaultView;
					}
				}
			}

		}
	}
}

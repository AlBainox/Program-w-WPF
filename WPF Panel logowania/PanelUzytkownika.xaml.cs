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

namespace WPF_Panel_logowania
{
	/// <summary>
	/// Logika interakcji dla klasy PanelUzytkownika.xaml
	/// </summary>
	public partial class PanelUzytkownika : Window
	{
		public PanelUzytkownika()
		{
			InitializeComponent();
			MainWindow mainWindow = new MainWindow();
			//DataGridOfPeople.ItemsSource = mainWindow.listOfUsers;
			
		}

		

		private void btnWyloguj_Click(object sender, RoutedEventArgs e)
		{
			MainWindow main = new MainWindow();
			main.MetodaWylogowujaca();

			MessageBox.Show("Użytkownik został poprawnie wylogowany");
			this.Close();
		}

		
	}
}

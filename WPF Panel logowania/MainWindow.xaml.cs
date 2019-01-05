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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
		private static panelLogowania PanelLogowania = new panelLogowania();
		private static panelUsera PanelUsera = null;


		private void btnZaloguj_Click(object sender, RoutedEventArgs e)
		{
			if (PanelUsera == null)
			{
				string Login = txbLogin.Text;
				string Haslo = txbHaslo.Text;
				if ((txbLogin.Text == "") || (txbHaslo.Text == ""))
				{
					MessageBox.Show("Pola nie mogą być puste");
				}
				PanelUsera = PanelLogowania.Logowanie(Login, Haslo);
				if (PanelUsera == null)
				{
					MessageBox.Show("Błędny login / hasło");
					txbLogin.Clear();
					txbHaslo.Clear();
				}
			}


		}
		// Przycisk Rejestracja
		private void btnWyjscie_Click(object sender, RoutedEventArgs e)
		{
			Rejestracja wdwRej = new Rejestracja();
			wdwRej.ShowDialog();
			
		}
		
	}
}

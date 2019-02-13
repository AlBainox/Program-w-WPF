using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Panel_logowania
{
	public class Product
	{

		int id;
		double cena;
		string iloscSztuk, produkt;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public double Cena
		{
			get { return cena; }
			set { cena = value; }
		}
		public string IloscSztuk
		{
			get { return iloscSztuk; }
			set { iloscSztuk = value; }
		}
		public string Produkt
		{
			get { return produkt; }
			set { produkt = value; }
		}
		
	}
}

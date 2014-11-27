using System.Collections.Generic;
using System.IO;
using Simulateur.Data;

namespace Simulateur.Bussiness
{
	public static class BankBookManager
	{
		private static List<BankBook> __bankBooks;

		public static List<BankBook> BankBooks
		{
			get { return __bankBooks; }
		}

		public static void LoadAllDatas()
		{
			// TODO ; Complete this
			// fill __bankbook
		}


		public static void LoadAllDatas(string jsonFile)
		{
			
			

		}

	}
}
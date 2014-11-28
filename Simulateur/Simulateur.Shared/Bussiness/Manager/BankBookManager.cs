using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Simulateur.Data;
using Simulateur.Data.BLL;

namespace Simulateur.Bussiness
{
	public static class BankBookManager
	{
		private static List<BankBook> __bankBooks;

		public static List<BankBook> BankBooks
		{
			get { return __bankBooks; }
		}

		public async static Task LoadAllDatasAsync()
		{
			__bankBooks = await BLLBankBooks.GetAllAsync();
		}

	}
}
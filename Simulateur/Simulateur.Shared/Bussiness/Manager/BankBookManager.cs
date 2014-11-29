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

		#region Constantes
		private const decimal MAX_RATE_YOUNG = 1;
		#endregion

		#region Static Attributes
		private static List<BankBook> __bankBooks;
		#endregion

		#region Properties
		public static List<BankBook> BankBooks
		{
			get { return __bankBooks; }
		}
		#endregion


		#region Operations
		public async static Task LoadAllDatasAsync()
		{
			__bankBooks = await BLLBankBooks.GetAllAsync();
		}

		public static List<BankBook> GetListByFilter(Filter filter)
		{
			List<BankBook> res = new List<BankBook>();
			if (__bankBooks != null)
			{
				foreach (BankBook b in __bankBooks)
				{
					// Filtre
					if (b.Rate <= MAX_RATE_YOUNG)
					{
						res.Add(b);
					}

					// TODO : finir le filtre
				}

			}
			return res;
		}
		#endregion

	}
}
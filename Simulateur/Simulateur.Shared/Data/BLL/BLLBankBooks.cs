using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Simulateur.Data.Utils;

namespace Simulateur.Data.BLL
{
	/// <summary>
	/// Utilities to retrive datas from Windows Azure
	/// </summary>
	public static class BLLBankBooks
	{

		public static Task< List<BankBook> > GetAllAsync()
		{
			// TODO : Improve this function to get more accurate error management
			return AzureConnectionUtils.GetDatasAsync<BankBook>();
		}
	}
}

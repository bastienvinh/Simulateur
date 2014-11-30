using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Simulateur.Data.Utils
{
	/// <summary>
	/// Manage Custom Error provoqued by Azure
	/// </summary>
	public class AzureConnectionException : Exception
	{

		public AzureConnectionException()
			: base("Problem with Web Service")
		{
			
		}

		public AzureConnectionException(string message) : base(message)
		{
			
		}

		public AzureConnectionException(string message, Exception innerException) 
			: base(message, innerException)
		{
			
		}

	}



	public static class AzureConnectionUtils
	{
		#region Attributes

		// TODO : Don't forget ot change your configuration and add ID on another file and to fill it
		private readonly static MobileServiceClient __mobileService = new MobileServiceClient(
					 ""
		 );

		#endregion

		#region Operations

		public async static Task<List<T>> GetDatasAsync<T>()
			where T : class
		{
			List<T> res = null;

			try
			{
				res = await __mobileService.GetTable<T>().ToListAsync();

			}
			catch (Exception e)
			{
				string message = string.Format("Problem to retrive data of type {0} on Mobile Services Azure", typeof (T).Name);
				throw new AzureConnectionException(message, e);
			}
			return res;
		}

		public async static Task<ObservableCollection<T>> GetCollectionDatasAsync<T>()
			where T : class
		{
			ObservableCollection<T> res = null;

			try
			{
				res = await __mobileService.GetTable<T>().ToCollectionAsync();

			}
			catch (Exception e)
			{
				string message = string.Format("Problem to retrive data of type {0} on Mobile Services Azure", typeof(T).Name);
				throw new AzureConnectionException(message, e);
			}
			return res;
		}

		#endregion


	}


}

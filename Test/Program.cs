using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Microsoft.WindowsAzure.MobileServices;

namespace Test
{

	class Program
	{

//		public static MobileServiceClient MobileService = new MobileServiceClient(
//					"http://localhost:10547"
//);

		public static MobileServiceClient MobileService = new MobileServiceClient(
				 "",
				 ""
	 );

		public class BankBook
		{
			public string Id { get; set; }
			public string Name { get; set; }
			public string ShortName { get; set; }
			public string Description { get; set; }
			public decimal Rate { get; set; }
			public decimal MaxCeilling { get; set; }
			public bool HasTax { get; set; }
			public decimal MinimumMoney { get; set; }
			public decimal MinTransferPayment { get; set; }
			public bool IsIllimited { get; set; }
		}

		static void Main(string[] args)
		{
			
			Console.WriteLine("Its working !!!!");
			Console.ReadKey(true);
		}
	}
}

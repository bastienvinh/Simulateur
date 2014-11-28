using System;

namespace Simulateur.Data
{
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
}

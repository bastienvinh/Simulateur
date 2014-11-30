using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EpargneAzureService.DataObjects
{
	public class BankBook : EntityData
	{
		[MaxLength(75)]
		public string Name { get; set; }
		[MaxLength(15)]
		public string ShortName { get; set; }
		[MaxLength(400)]
		public string Description { get; set; }
		public decimal Rate { get; set; }
		public decimal MaxCeilling { get; set; }
		public bool HasTax { get; set; }
		[DefaultValue(0)]
		public decimal MinimumMoney { get; set; }
		[DefaultValue(0)]
		public decimal MinTransferPayment { get; set; }
		[DefaultValue(false)]
		public bool IsIllimited { get; set; }
	}
}
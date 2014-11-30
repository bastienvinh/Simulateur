using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using EpargneAzureService.DataObjects;
using EpargneAzureService.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EpargneAzureService
{
	public static class WebApiConfig
	{
		public static void Register()
		{
			// Use this class to set configuration options for your mobile service
			ConfigOptions options = new ConfigOptions();

			// Use this class to set WebAPI configuration options
			HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

			// To display errors in the browser during development, uncomment the following
			// line. Comment it out again when you deploy your service for production use.
			// config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

			Database.SetInitializer(new MobileServiceInitializer());
		}
	}

	public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
	{
		protected override void Seed(MobileServiceContext context)
		{

			if (!context.BankBooks.Any())
			{
				List<BankBook> bankBooks = new List<BankBook>
				{
					new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Livret Jeune",
						ShortName = "Jeune",
						MaxCeilling = 1600,
						HasTax = true,
						Rate = 2.75m,
						Description = "C'est un livret destine aux jeunes de 16 - 25 ans"
					},
					new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Axa Banque",
						ShortName = "AXAA",
						IsIllimited = true,
						HasTax = true,
						Rate = 4,
						Description = "Livret epargne special d'AXA"
					},
					new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Plan Epargne Logement",
						ShortName = "PEL",
						MaxCeilling = 61200,
						HasTax = true,
						Rate = 2.5m,
						Description = "Livret destine pour financer les demenagements ..."
					},
					new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Compte Epargne Logement",
						ShortName = "CEL",
						MaxCeilling = 15300,
						HasTax = true,
						Rate = 0.75m,
						Description = "Livret CEL"
					},
					new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Developpement Durable",
						ShortName = "Jeune",
						MaxCeilling = 12000,
						HasTax = true,
						Rate = 1,
						Description = "Un livret pour les financements lie a l'installation lie au equipements pour l'energie vert"
					}
				};

				context.BankBooks.AddRange(bankBooks);
				context.SaveChanges();
			}

			base.Seed(context);
		}
	}
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.ApplicationModel.Resources;
using Simulateur.Business;
using Simulateur.Data;

namespace Simulateur.ViewModels
{
	public class VMSimulatorEpargneResultat
	{

		#region Static Attributes
		private static readonly string __labelResult;
		private static readonly string __labelTitle;
		private static readonly string __labelSubtitle;
		#endregion


		#region Attributes
		private ObservableCollection<ResultFilter> _results;
		#endregion


		#region Properties
		public string LabelResult
		{
			get { return __labelResult; }
		}


		public string LabelTitle { get { return __labelTitle; } }

		public string LabelSubtitle { get { return __labelSubtitle; } }

		public ObservableCollection<ResultFilter> Results
		{
			get { return _results; }
		}
		#endregion


		#region Constructor
		static VMSimulatorEpargneResultat()
		{
			ResourceLoader loader = ResourceLoader.GetForCurrentView("Resources");
			__labelResult = loader.GetString("Result");
			__labelTitle = loader.GetString("ApplicationName");
			__labelSubtitle = loader.GetString("SubtitleApplicationName");
		}

		public VMSimulatorEpargneResultat()
		{
			// TODO : Remove these / Just for example
			#region Examples
			_results = new ObservableCollection<ResultFilter>
			{
				new ResultFilter
				{

					BankBook = new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Livret Jeune",
						ShortName = "Jeune",
						MaxCeilling = 1600,
						HasTax = true,
						Rate = 2.75m,
						Description = "C'est un livret destine aux jeunes de 16 - 25 ans"
					},
					Capital =  10000,
					PayperMonth = 120,
					Total = 180000,
					Year = 30
				},
				new ResultFilter
				{

					BankBook = new BankBook
					{
						Id = Guid.NewGuid().ToString(),
						Name = "Axa Banque",
						ShortName = "AXAA",
						IsIllimited = true,
						HasTax = true,
						Rate = 4,
						Description = "Livret epargne special d'AXA"
					},
					Capital =  1000,
					PayperMonth = 120,
					Total = 200000,
					Year = 30
				}
			};
			#endregion

			// This is for testing
		}
		#endregion

	}
}

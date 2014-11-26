using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Resources;
using Simulateur.Common;

namespace Simulateur.ViewModels
{
	public class VMSimulatorHelp : ViewModelBase
	{

		#region Constants

		private const string FILE_RESOURCE = "Resources";

		#endregion

		#region Properties

		private readonly string _textExplication;

		#endregion


		#region

		public string TextExplication { get { return _textExplication; } }

		#endregion

		#region Constructor

		public VMSimulatorHelp()
		{

			ResourceLoader resourceLanguage = ResourceLoader.GetForCurrentView(FILE_RESOURCE);
			_textExplication = resourceLanguage.GetString("AboutMessage");
		}

		#endregion

	}
}

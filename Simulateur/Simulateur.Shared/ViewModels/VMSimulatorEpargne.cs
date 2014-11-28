using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Resources;
using Simulateur.Common;

namespace Simulateur.ViewModels
{
	public class VMSimulatorEpargne : ViewModelBase
	{

		#region Static Attributes
		private static readonly string __nextButtonLabel;
		private static readonly string __labelSwitchOnStudentChoice;
		private static readonly string __labelSwitchOffOtherChoice;
		#endregion


		#region Attributes
		private bool _isAStudent;
		#endregion


		#region Properties

		public string NextButtonLabel
		{
			get { return __nextButtonLabel; }
		}


		public string LabelSwitchOnStudentChoice
		{
			get { return __labelSwitchOnStudentChoice; }
		}

		public string LabelSwitchOffOtherChoice
		{
			get { return __labelSwitchOffOtherChoice; }
		}

		public bool IsAStudent
		{
			get { return _isAStudent; }
			set { _isAStudent = value; RaisePropertyChanged("IsAStudent"); }
		}

		#endregion

		#region Constructor

		static VMSimulatorEpargne()
		{
			ResourceLoader ressourceManager = ResourceLoader.GetForCurrentView("Resources");
			__nextButtonLabel = ressourceManager.GetString("SimulatorEpargneButtonNext");
			__labelSwitchOnStudentChoice = ressourceManager.GetString("Student");
			__labelSwitchOffOtherChoice = ressourceManager.GetString("Others");
		}

		public VMSimulatorEpargne()
		{
			_isAStudent = false;
		}

		#endregion


	}
}

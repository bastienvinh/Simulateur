using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using Simulateur.Business;
using Simulateur.Business.Manager;
using Simulateur.Business.Utils;
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
		private readonly ObservableCollection<DegreeLevel> _degreeLevels;
		private readonly ObservableCollection<CustomInformation> _customInformations;
		private Filter _filterResponse;

		// Events
		private readonly ICommand _nextEventCommand;

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

		public int MaxChildren
		{
			get { return FilterInformationsManager.MAX_CHILDREN; }
		}

		public int MinChildren
		{
			get { return FilterInformationsManager.MIN_CHILDREN; }
		}

		public bool IsAStudent
		{
			get { return _isAStudent; }
			set { _isAStudent = value; RaisePropertyChanged("IsAStudent"); }
		}

		public ObservableCollection<DegreeLevel> DegreesLevels
		{
			get { return _degreeLevels; }
		}

		public ObservableCollection<CustomInformation> CustomInformations
		{
			get { return _customInformations; }
		}

		public Filter FilterResponse
		{
			get { return _filterResponse; }
			set { _filterResponse = value; RaisePropertyChanged("FilterResponse"); }
		}


		// Events Command Properties
		public ICommand NextEventCommand
		{
			get { return _nextEventCommand; }
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
			_isAStudent = true;
			_degreeLevels = new ObservableCollection<DegreeLevel>( FilterInformationsManager.GetDegrees() );
			_filterResponse = new Filter();


			// Events
			_nextEventCommand = new RelayCommand(NextEvent);
		}

		#endregion


		#region Operations
		public void NextEvent()
		{
			// TODO : verify that datas is computed correctly


			// We store datas to pass on another Page (View Model's Page)
			TrashData.Store( "FilterSimulator",  _filterResponse);
			NavigatorHelper.NavigateTo( typeof( Views.WSimulatorEpargneResult ) );
		}
		#endregion


	}
}

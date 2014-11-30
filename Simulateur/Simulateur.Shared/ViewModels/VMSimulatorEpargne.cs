using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
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


		private ushort _nbChilds;
		private decimal _capital;
		private int _duration;
		private decimal _monthPay;
		private decimal _deposit;
		private DegreeLevel _selectedDegree;
		private CustomInformation _selectedCustomInformation;

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

		public int MinDuration
		{
			get { return FilterInformationsManager.MIN_DURATION; }
		}

		public int MaxDuration
		{
			get { return FilterInformationsManager.MAX_DURATION; }
		}

		public int MinPayPerMonth
		{
			get { return (int) FilterInformationsManager.MIN_PER_MONTH; }
		}

		public int MaxPayPerMonth
		{
			get { return (int)FilterInformationsManager.MAX_PER_MONTH; }
		}

		public ObservableCollection<DegreeLevel> DegreesLevels
		{
			get { return _degreeLevels; }
		}

		public ObservableCollection<CustomInformation> CustomInformations
		{
			get { return _customInformations; }
		}

		#region Filter Binding Values
		public ushort NbChilds
		{
			get { return _nbChilds; }
			set { _nbChilds = value; RaisePropertyChanged("NbChilds"); }
		}

		public decimal Capital
		{
			get { return _capital; }
			set { _capital = value; RaisePropertyChanged("Capital"); }
		}

		public int Duration
		{
			get { return _duration; }
			set { _duration = value; RaisePropertyChanged("Duration"); }
		}

		public decimal MonthPay
		{
			get { return _monthPay; }
			set { _monthPay = value; RaisePropertyChanged("MonthPay"); }
		}

		public decimal Deposit
		{
			get { return _deposit; }
			set { _deposit = value; RaisePropertyChanged("Deposit"); }
		}

		public DegreeLevel SelectedDegree
		{
			get { return _selectedDegree; }
			set { _selectedDegree = value; RaisePropertyChanged("SelectedDegree"); }
		}

		public CustomInformation SelectedCustomInformation
		{
			get { return _selectedCustomInformation; }
			set { _selectedCustomInformation = value; RaisePropertyChanged("SelectedCustomInformation"); }
		}

		public bool IsAStudent
		{
			get { return _isAStudent; }
			set { _isAStudent = value; RaisePropertyChanged("IsAStudent"); }
		}

		#endregion


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


			// Filter information


			// Events
			_nextEventCommand = new RelayCommand(NextEvent);
		}

		#endregion

		#region Operations
		public void NextEvent()
		{
			// TODO : verify that datas is computed correctly
			Filter filter = new Filter();

			// We store datas to pass on another Page (View Model's Page)
			TrashData.Store( "FilterSimulator",  filter);
			NavigatorHelper.NavigateTo( typeof( Views.WSimulatorEpargneResult ) );
		}
		#endregion


	}
}

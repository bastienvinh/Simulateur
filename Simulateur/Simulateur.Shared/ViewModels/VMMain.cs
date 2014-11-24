using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using Simulateur.Common;
using Simulateur.Navigation;

namespace Simulateur.ViewModels
{
	public class VMMain : ViewModelBase
	{
		#region Constants

		private const string RESSOURCE_FILE = "Menus";

		#endregion

		#region Attributes

		private static readonly ObservableCollection<MenuNavigation> __navigationMenu;
		private MenuNavigation _selectedMenu;


		// Commands

		private ICommand _selectedMenuCommand;

		#endregion

		#region Properties

		public ObservableCollection<MenuNavigation> NavigationsMenu
		{
			get { return __navigationMenu; }
		}

		public MenuNavigation SelectedMenu
		{
			get { return _selectedMenu; }
			set { _selectedMenu = value; RaisePropertyChanged("SelectedMenu"); }
		}


		public ICommand SelectedMenuCommand { get { return _selectedMenuCommand; } }

		#endregion


		#region Constructors

		static VMMain()
		{
			__navigationMenu = new ObservableCollection<MenuNavigation>();


			// Create our menus
			ResourceLoader ressourceMenus = ResourceLoader.GetForCurrentView(RESSOURCE_FILE);

			__navigationMenu.Add(new MenuNavigation
			{
				Label = ressourceMenus.GetString("MenuSimulator"),
				Description = ressourceMenus.GetString("DescMenuSimulator"),
				Order =  1,
				View = Type.GetType("Simulateur.Views.WSimulatorEpargne")
			});

			__navigationMenu.Add(new MenuNavigation
			{
				Label = ressourceMenus.GetString("MenuHelp"),
				Description = ressourceMenus.GetString("DescMenuHelp"),
				Order = 2,
				View = Type.GetType("Simulateur.Views.WSimulatorHelp")
			});



		}


		public VMMain()
		{
			_selectedMenu = null;

			// Initialisation commands
			_selectedMenuCommand = new RelayCommand(SelectMenu);

		}

		#endregion

		#region Operations

		private static void ShowPage(MenuNavigation menu)
		{
			
		}

		#endregion


		#region Events

		private void SelectMenu()
		{
			ShowPage(SelectedMenu);
		}

		#endregion

	}
}

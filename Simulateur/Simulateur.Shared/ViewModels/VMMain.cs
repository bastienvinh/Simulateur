using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using Simulateur.Bussiness;
using Simulateur.Common;
using Simulateur.Data;
using Simulateur.Data.Utils;
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
		private ICommand _loadCommand;

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
		public ICommand LoadCommand { get { return _loadCommand; } }

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
			// Initialisation commands
			_selectedMenuCommand = new RelayCommand(SelectMenu);
			_loadCommand = new RelayCommand(Load);
		}

		#endregion

		#region Operations

		private static void ShowPage(MenuNavigation menu)
		{
			// We open Another on current frame
			NavigatorHelper.NavigateTo( menu.View );
		}

		#endregion


		#region Events


		private async void Load()
		{
			// we must have internet to do something
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				// We load all datas
				await BankBookManager.LoadAllDatasAsync();

				// Be careful at this point, we don't know when we execute this. 
				// TODO : Make a pending image for loading datas / If something happen use cache datas
			}
		}

		private void SelectMenu()
		{
			if (SelectedMenu != null)
				ShowPage(SelectedMenu);
		}

		#endregion

	}
}

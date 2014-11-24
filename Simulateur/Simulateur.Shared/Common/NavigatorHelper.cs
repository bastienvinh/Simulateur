using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Simulateur.Common
{
	public static class NavigatorHelper
	{


		public static void NavigateTo(Type page)
		{
			((Frame) Window.Current.Content).Navigate(page);
		}

	}
}

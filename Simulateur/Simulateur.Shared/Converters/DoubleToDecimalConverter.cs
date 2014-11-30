using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace Simulateur.Converters
{
	public class DoubleToDecimalConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			// TODO : Manage better errors

			return System.Convert.ToDouble(value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return System.Convert.ToDecimal(value);
		}
	}
}

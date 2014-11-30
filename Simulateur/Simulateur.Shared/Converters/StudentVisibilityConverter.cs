using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Simulateur.Converters
{
	public class StudentVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			
			if (value.GetType() != typeof(bool))
				throw new ArgumentException( "Must be boolean to convert to visiblity" );

			return (System.Convert.ToBoolean(value)) ? Visibility.Collapsed : Visibility.Visible;

		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}

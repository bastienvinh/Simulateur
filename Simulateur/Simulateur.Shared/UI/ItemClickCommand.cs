using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Simulateur.UI
{
	public static class ItemClickCommand
	{
		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.RegisterAttached("Command", typeof (ICommand),
				typeof (ItemClickCommand), new PropertyMetadata(null, OnCommandPropertyChanged));


		public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.RegisterAttached(
			"SelectedValue", typeof(object), typeof(ItemClickCommand), new PropertyMetadata(default(object)));


		public static void SetSelectedValue(DependencyObject d, object value)
		{
			d.SetValue(SelectedValueProperty, value);
		}

		public static object GetSelectedValue(DependencyObject d)
		{
			return d.GetValue(SelectedValueProperty);
		}

		public static void SetCommand(DependencyObject d, ICommand value)
		{
			d.SetValue(CommandProperty, value);
		}

		public static ICommand GetCommand(DependencyObject d)
		{
			return (ICommand) d.GetValue(CommandProperty);
		}

		private static void OnCommandPropertyChanged(DependencyObject d,
			DependencyPropertyChangedEventArgs e)
		{
			var control = d as ListViewBase;
			if (control != null)
				control.ItemClick += OnItemClick;
		}

		private static void OnItemClick(object sender, ItemClickEventArgs e)
		{
			var control = sender as ListViewBase;
			if (control != null)
			{
				var command = GetCommand(control);
				SetSelectedValue(control, e.ClickedItem );

				if (command != null && command.CanExecute(e.ClickedItem))
					command.Execute(e.ClickedItem);
			}
		}
	}
}

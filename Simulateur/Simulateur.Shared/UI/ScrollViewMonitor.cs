﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Simulateur.UI
{
	// Don't mind this class, just to create event for scrolling bot at end
	public class ScrollViewerMonitor
	{
		public static DependencyProperty AtEndCommandProperty
				= DependencyProperty.RegisterAttached(
						"AtEndCommand", typeof(ICommand),
						typeof(ScrollViewerMonitor),
						new PropertyMetadata( null , OnAtEndCommandChanged));

		public static ICommand GetAtEndCommand(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(AtEndCommandProperty);
		}

		public static void SetAtEndCommand(DependencyObject obj, ICommand value)
		{
			obj.SetValue(AtEndCommandProperty, value);
		}


		public static void OnAtEndCommandChanged(
				DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement element = (FrameworkElement)d;
			if (element != null)
			{
				element.Loaded -= element_Loaded;
				element.Loaded += element_Loaded;
			}
		}

		static void element_Loaded(object sender, RoutedEventArgs e)
		{
			FrameworkElement element = (FrameworkElement)sender;
			element.Loaded -= element_Loaded;
			ScrollViewer scrollViewer = FindChildOfType<ScrollViewer>(element);
			if (scrollViewer == null)
			{
				throw new InvalidOperationException("ScrollViewer not found.");
			}

			//var listener = new DependencyPropertyListener();
			//listener.Changed
			//		+= delegate
			//		{
			//			bool atBottom = scrollViewer.VerticalOffset
			//													>= scrollViewer.ScrollableHeight;

			//			if (atBottom)
			//			{
			//				var atEnd = GetAtEndCommand(element);
			//				if (atEnd != null)
			//				{
			//					atEnd.Execute(null);
			//				}
			//			}
			//		};
			//Binding binding = new Binding("VerticalOffset") { Source = scrollViewer };
			//listener.Attach(scrollViewer, binding);
		}

		static T FindChildOfType<T>(DependencyObject root) where T : class
		{
			var queue = new Queue<DependencyObject>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				DependencyObject current = queue.Dequeue();
				for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)
				{
					var child = VisualTreeHelper.GetChild(current, i);
					var typedChild = child as T;
					if (typedChild != null)
					{
						return typedChild;
					}
					queue.Enqueue(child);
				}
			}
			return null;
		}
	}
}

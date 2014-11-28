using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur.Navigation
{
	public class MenuNavigation
	{
		#region Attributes

		private Type _view;
		private Type _typeDataContext;
		private int _value;

		#endregion

		#region Properties

		public Type View
		{
			get { return _view; }
			set
			{
				// TODO : Verifiy that value descend from type Page
				_view = value;
			}
		}

		public Type TypeDataContext
		{
			get { return _typeDataContext; }
			set
			{
				// TODO : Verify that value descend from type ViewModelPage
				_typeDataContext = value;
			}
		}

		public int Value
		{
			get { return _value; }
			internal set { _value = value; }
		}

		public string Label { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }

		#endregion


		#region Construtors

		public MenuNavigation(string label, Type view, Type dataContext)
		{
			Label = label;
			_view = view;
			_typeDataContext = dataContext;
		}


		public MenuNavigation(string label, int value, Type view, Type dataContext)
			: this(label, view, dataContext)
		{
			_value = value;
		}

		internal MenuNavigation()
		{
			
		}

		#endregion
	}
}

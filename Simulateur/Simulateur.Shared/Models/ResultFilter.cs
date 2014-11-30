using System;
using System.Collections.Generic;
using System.Text;
using Simulateur.Data;

namespace Simulateur.Models
{
	public class ResultFilter
	{
		#region Attributes

		private decimal _capital;
		private decimal _payPerMonth;
		private int _year;

		#endregion


		#region Properties
		public BankBook BankBook { get; set; }
		public decimal Total { get; set; }

		public decimal Capital
		{
			get { return _capital; }
			internal set { _capital = value; }
		}

		public decimal PayperMonth
		{
			get { return _payPerMonth; }
			internal set { _payPerMonth = value; }
		}

		public int Year
		{
			get { return _year; }
			internal set { _year = value; }
		}
		#endregion


		#region Constructor

		internal ResultFilter()
		{

		}


		public ResultFilter( BankBook bank, decimal capital, decimal payPerMonth, int year )
		{
			BankBook = bank;
			_capital = capital;
			_payPerMonth = payPerMonth;
			_year = year;
		}

		#endregion

	}
}

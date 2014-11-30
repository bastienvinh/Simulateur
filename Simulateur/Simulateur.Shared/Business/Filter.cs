using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur.Business
{
	public class Filter
	{
		//public uint Graduation { get; set; }
		public bool IsAStudent { get; set; }
		public ushort NbChilds { get; set; }
		public decimal Capital { get; set; } 
		public int Duration { get; set; }
		public decimal MonthPay { get; set; } 
		public decimal Deposit { get; set; }
		public DegreeLevel Degree { get; set; }
		public CustomInformation CustomInformations { get; set; }


		public Filter()
		{
			NbChilds = 0;
		}
	}
}

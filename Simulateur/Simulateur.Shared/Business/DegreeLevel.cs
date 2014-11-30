using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur.Business
{

	// I don't know if it will be static datas or store on database
	// For now, it will be static
	public class DegreeLevel
	{
		public string Id { get; set; }
		public int LevelPoint { get; set; }
		public string Name { get; set; }
	}
}

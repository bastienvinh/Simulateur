using System;
using System.Collections.Generic;


namespace Simulateur.Business.Manager
{
	public static class FilterInformationsManager
	{
		public const int MAX_CHILDREN = 5;
		public const int MIN_CHILDREN = 0;



		private readonly static List<DegreeLevel> __degreeLevels = new List<DegreeLevel>
		{

			new DegreeLevel{ Id = Guid.NewGuid().ToString(), Name = "Post-Bac", LevelPoint = 50 },
			new DegreeLevel{ Id = Guid.NewGuid().ToString(), Name = "Master", LevelPoint = 100 },
			new DegreeLevel{ Id = Guid.NewGuid().ToString(), Name = "Baccalaureaut", LevelPoint = 40 },
			new DegreeLevel{ Id = Guid.NewGuid().ToString(), Name = "Doctorat", LevelPoint = 60 }

			// TODO : Finish this
		};


		private static readonly List<CustomInformation> __customInformations = new List<CustomInformation>
		{
			new CustomInformation { Id = Guid.NewGuid().ToString(), Label = "Cherche un nouvel emploi" },
			new CustomInformation { Id = Guid.NewGuid().ToString(), Label = "Financer mes etudes" },
			new CustomInformation { Id = Guid.NewGuid().ToString(), Label = "Financer un logement" },
			new CustomInformation { Id = Guid.NewGuid().ToString(), Label = "Creer une nouvel association" }
		};

		public static List<DegreeLevel> GetDegrees()
		{
			return __degreeLevels;
		}


		public static List<CustomInformation> GetInformations()
		{
			return __customInformations;
		}

	}
}

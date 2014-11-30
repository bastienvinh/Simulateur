using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Simulateur.Business.Utils;
using Xunit;
using Assert = Xunit.Assert;

namespace EpargneMobileUnitTest.Business.Utils
{
	[TestClass]
	public class TemporyDatasMangementUnitTest
	{
		[Fact]
		public void CountDatas()
		{
			TemporyDatasMangement.Store("lala", "lala");
			TemporyDatasMangement.Store("toto", "lala");
			TemporyDatasMangement.Store("pepe", "lala");
			TemporyDatasMangement.Store("jiji", "lala");
			TemporyDatasMangement.Store("toto", "meme");
			TemporyDatasMangement.Store("lala", "lala");
			TemporyDatasMangement.Store("toto", "lala");
			TemporyDatasMangement.Store("pepe", "lala");
			TemporyDatasMangement.Store("jiji", "lala");
			TemporyDatasMangement.Store("toto", "meme");
			TemporyDatasMangement.Store("lala", "lala");
			TemporyDatasMangement.Store("toto", "lala");
			TemporyDatasMangement.Store("pepe", "lala");
			TemporyDatasMangement.Store("jiji", "lala");
			TemporyDatasMangement.Store("toto", "meme");

			Assert.Equal( TemporyDatasMangement.Count, 4 );
		}

	}
}

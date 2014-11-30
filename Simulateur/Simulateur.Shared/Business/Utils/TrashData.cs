using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur.Business.Utils
{

	public class TrashDataException : Exception
	{

		public TrashDataException()
			: base("Problem Tempory Datas")
		{

		}


		public TrashDataException(string message)
			: base(message)
		{
			
		}


		public TrashDataException(string message, Exception innerException)
		: base(message, innerException)
		{
			
		}
	}


	/// <summary>
	/// This class was created because we have no time to create lib with datas local storing strategies 
	/// </summary>
	public static class TrashData
	{

		// We can store anything
		private static Dictionary<string, object> __datas = new Dictionary<string, object>(); 


		public static void Store(string key, object obj)
		{
			if (__datas.ContainsKey(key))
				__datas[key] = obj;
			else
				__datas.Add( key, obj );
		}


		public static void Clear()
		{
			__datas.Clear();
		}


		public static void Remove(string key)
		{
			__datas.Remove(key);
		}

		public static int Count
		{
			get { return __datas.Count; }
		}


		public static T Get<T>(string key)
		{
			if (!__datas.ContainsKey(key))
			{
				throw new TrashDataException("Key don't exists", new ArgumentException("False Key"));
			}

			return (T) Convert.ChangeType(__datas[key], typeof(T));
		}

	}
}

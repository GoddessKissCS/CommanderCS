using System;
using System.IO;

namespace StellarGKLibrary.BattleSimulator
{
	public class Logger
	{
		public static void Log(object msg)
		{
		}

		public static void LogToFile(object msg)
		{
			using (StreamWriter streamWriter = new StreamWriter("./debug.log", true))
			{
				streamWriter.WriteLine(msg);
				streamWriter.Flush();
			}
		}
	}
}

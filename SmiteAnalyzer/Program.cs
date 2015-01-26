using System;
using System.Configuration;
using System.IO;

namespace SmiteAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start Smite Analyzer");

			var path = ConfigurationManager.AppSettings.Get("SmitePath");

			Console.WriteLine("Checking for smite at \"{0}\"", path);

			if (Directory.Exists(path))
			{
				Console.WriteLine("Locations exists");
			}
			else
				Console.WriteLine("Smite not found");


			if (ConfigurationManager.AppSettings.Get("WaitOnDone") == "true")
			{
				Console.WriteLine("Done. Press any key to exit");
				Console.ReadKey();
			}
			else
			{
				Console.WriteLine("Done");
			}
		}
	}
}

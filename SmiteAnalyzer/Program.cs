using System;
using System.Configuration;
using System.IO;
using UELib;
using UELib.Core;

namespace SmiteAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().Run();
		}

		private void Run()
		{
			Console.WriteLine("Start Smite Analyzer");

			var path = ConfigurationManager.AppSettings.Get("SmitePath");

			Console.WriteLine("Checking for smite at \"{0}\"", path);

			if (Directory.Exists(path))
			{
				Console.WriteLine("Locations exists");

				Console.WriteLine("Checking for Potraits file");

				var potraitsPath = Path.Combine(ConfigurationManager.AppSettings.Get("SmitePath"), "BattleGame\\CookedPC\\GUI\\Icons\\Portraits.upk");

				if (File.Exists(potraitsPath))
					AnalyzePotraits(potraitsPath);
				else
					Console.WriteLine("Potraits file nont found at \"{0}\"", potraitsPath);
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

		private void AnalyzePotraits(string path)
		{
			var package = UnrealLoader.LoadFullPackage(path);

			foreach (var content in package.Objects)
			{
				Console.WriteLine("Name: {0}, Class: {1}, Outer: {2}", content.Name, content.Class.Name, content.Outer == null ? "null" : content.Outer.Name);
			}
		}
	}
}

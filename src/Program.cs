/// @file Program.cs
/// @author Ron Wilson

using System;
using RPW.Simple;

class Program
{
	static void Main(string[] args)
	{
		SimpleServiceInstaller.DisplayName = "my display name";
		SimpleServiceInstaller.ServiceName = "SimpleServiceExample";

		SimpleService.Worker = new SampleWorker();
		SimpleService.Start(args);
	}
}

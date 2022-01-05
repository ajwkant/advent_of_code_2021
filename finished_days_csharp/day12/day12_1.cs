using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day12
{
	public class PathMain
	{
		static void Main()
		{
			Paths.Paths paths = new Paths.Paths();

			paths.PathsReader("input_day12.txt");

			paths.FindAllPaths();

			paths.PrintFoundPaths();
		}
	}
}

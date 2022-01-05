using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day12
{
	public class Path2Main
	{
		static void Main()
		{
			Paths2.Paths2 paths = new Paths2.Paths2();

			paths.PathsReader("input_day12.txt");

			paths.FindAllPaths();

			paths.PrintFoundPaths();
		}
	}
}

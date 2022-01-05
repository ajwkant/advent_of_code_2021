using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day11
{
	public class DumboMain
	{
		static void Main()
		{
			int step = 0;
			Map.Map map = new Map.Map();

			map.MapReader("input_day11.txt");
			while (true)
			{
				step++;
				// map.Print();
				// Console.Write("{0}\n", i);
				map.NextStep();
				if (map.FlashedSimultaneously())
				{
					Console.WriteLine("Flashed simultaneously on step {0}", step);
					break;
				}
				if (step == 100)
					Console.WriteLine("Amount of flashes after 100 steps {0}", map.Flashes);
			}

		}
	}
}

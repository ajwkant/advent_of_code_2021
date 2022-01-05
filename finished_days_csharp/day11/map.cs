using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Day11.Map
{
	public class Map
	{
		private List<List<int>> mapList;
		private int flashes;

		public Map()
		{
			mapList = new List<List<int>>();
			flashes = 0;
		}

		public int Flashes
		{
			get { return flashes; }
		}

		public void MapReader(string path)
		{
			string[] lines = File.ReadAllLines(path);

			foreach (string line in lines)
			{
				List<int> mapRow = line.Select(c => c - '0').ToList();

				mapList.Add(mapRow);
			}
		}

		public void IncrementAll()
		{
			foreach (List<int> line in mapList)
			{
				for (int index = 0; index < line.Count; index++)
				{
					line[index]++;
				}
			}
		}

		public void Print()
		{
			for (int rowIndex = 0; rowIndex < mapList.Count; rowIndex++)
			{
				for (int colIndex = 0; colIndex < mapList[0].Count; colIndex++)
				{
					Console.Write(" " + mapList[rowIndex][colIndex]);
				}
				Console.Write("\n");
			}
		}

		public bool FlashedSimultaneously()
		{
			for (int row = 0; row < mapList.Count; row++)
			{
				for (int col = 0; col < mapList[0].Count; col++)
				{
					if (mapList[row][col] != 0)
						return (false);
				}
			}
			return (true);
		}

		public void RecursiveFlash(int rowIndex, int colIndex)
		{
			mapList[rowIndex][colIndex] = 0;
			flashes++;
			// Upper row
			if (rowIndex > 0)
			{
				// Upper left
				if (colIndex > 0)
				{
					if (mapList[rowIndex - 1][colIndex - 1] != 0)
						mapList[rowIndex - 1][colIndex - 1]++;

					if (mapList[rowIndex - 1][colIndex - 1] > 9)
						RecursiveFlash(rowIndex - 1, colIndex - 1);
				}

				// Upper middle
				if (mapList[rowIndex - 1][colIndex] != 0)
					mapList[rowIndex - 1][colIndex]++;

				if (mapList[rowIndex - 1][colIndex] > 9)
					RecursiveFlash(rowIndex - 1, colIndex);

				// Upper right
				if (colIndex + 1 < mapList[0].Count)
				{
					if (mapList[rowIndex - 1][colIndex + 1] != 0)
						mapList[rowIndex - 1][colIndex + 1]++;

					if (mapList[rowIndex - 1][colIndex + 1] > 9)
						RecursiveFlash(rowIndex - 1, colIndex + 1);
				}
			}

			// Middle left
			if (colIndex > 0 && mapList[rowIndex][colIndex - 1] != 0)
			{
				mapList[rowIndex][colIndex - 1]++;

				if (mapList[rowIndex][colIndex - 1] > 9)
					RecursiveFlash(rowIndex, colIndex - 1);
			}

			// Middle right
			if (colIndex + 1 < mapList[0].Count && mapList[rowIndex][colIndex + 1] != 0)
			{
				mapList[rowIndex][colIndex + 1]++;

				if (mapList[rowIndex][colIndex + 1] > 9)
					RecursiveFlash(rowIndex, colIndex + 1);
			}

			// Lower row
			if (rowIndex + 1 < mapList.Count)
			{
				// Lower left
				if (colIndex > 0)
				{
					if (mapList[rowIndex + 1][colIndex - 1] != 0)
						mapList[rowIndex + 1][colIndex - 1]++;

					if (mapList[rowIndex + 1][colIndex - 1] > 9)
						RecursiveFlash(rowIndex + 1, colIndex - 1);
				}

				// Lower middle
				if (mapList[rowIndex + 1][colIndex] != 0)
					mapList[rowIndex + 1][colIndex]++;

				if (mapList[rowIndex + 1][colIndex] > 9)
					RecursiveFlash(rowIndex + 1, colIndex);

				// Lower right
				if (colIndex + 1 < mapList[0].Count)
				{
					if (mapList[rowIndex + 1][colIndex + 1] != 0)
						mapList[rowIndex + 1][colIndex + 1]++;

					if (mapList[rowIndex + 1][colIndex + 1] > 9)
						RecursiveFlash(rowIndex + 1, colIndex + 1);
				}
			}
		}

		public void NextStep()
		{
			IncrementAll();
			for (int rowIndex = 0; rowIndex < mapList.Count; rowIndex++)
			{
				for (int colIndex = 0; colIndex < mapList.Count; colIndex++)
				{
					if (mapList[rowIndex][colIndex] > 9)
					{
						RecursiveFlash(rowIndex, colIndex);
					}
				}
			}
		}
	}
}

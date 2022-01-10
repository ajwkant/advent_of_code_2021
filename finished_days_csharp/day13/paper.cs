using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Day13.Paper
{
	public class Paper
	{
		private List<List<int>> map;
		private List<List<int>> dots;

		private int width;
		private int height;
		private List<string> folds;

		private int amountOfDots;

		public Paper()
		{
			map = new List<List<int>>();
			dots = new List<List<int>>();
			width = 0;
			height = 0;
			folds = new List<string>();
			amountOfDots = 0;
		}

		public void MakeBlankMap()
		{
			foreach (var dot in dots)
			{
				if (dot[0] > width)
					width = dot[0];
				if (dot[1] > height)
					height = dot[1];
			}
			width++;
			height++;

			for (int y = 0; y < height; y++)
			{
				map.Add(new List<int>(Enumerable.Repeat(0, width)));
			}
		}

		public void FillInDots()
		{
			foreach (var dot in dots)
			{
				map[dot[1]][dot[0]] = 1;
			}
		}

		public void PaperReader(string path)
		{
			string[] lines = File.ReadAllLines(path);

			int index;
			for (index = 0; index < lines.Length && lines[index] != "" ; index++)
			{
				string[] xyCoordinate = lines[index].Split(',');
				int[] toIntArray = new int[] {Int32.Parse(xyCoordinate[0]), Int32.Parse(xyCoordinate[1])};
				List<int> coordinate = new List<int>(toIntArray);

				dots.Add(coordinate);
			}
			for (index = index + 1; index < lines.Length; index++)
			{
				string[] foldLine = lines[index].Split(" ");
				folds.Add(foldLine[2]);
			}

			MakeBlankMap();
			FillInDots();
		}

		public void FoldPaper(int foldNumber)
		{
			// To do still: Divide this function into multiple smaller functions
			// It is already working but needs some cleaning up.

			string fold = folds[foldNumber];
			string[] foldSplitted = fold.Split("=");
			List<List<int>> foldedMap = new List<List<int>>();
			float half;
			int newWidth;
			int newHeight;
			int foldNo = Int32.Parse(foldSplitted[1]);

			if (foldSplitted[0] == "x")
			{
				half = (width - 1) / (float)2;
				newWidth = width - foldNo - 1;
				if (foldNo >= half)
					newWidth = width - (width - foldNo);

				for (int row = 0; row < height; row++)
				{
					List<int> newRow = new List<int>();

					int temp = 1;
					for (int col = 0; col < newWidth; col++)
					{
						if (foldNo >= half)
						{
							newRow.Add(map[row][col]);

							if (newWidth - col <= width - foldNo - 1)
							{
								if (newRow[col] == 0 && map[row][width - temp] == 1)
								newRow[col] = 1;
								temp++;
							}
						}
						else
						{
							newRow.Add(map[row][width - col - 1]);

							if (newWidth - col <= foldNo)
							{
								if (newRow[col] == 0 && map[row][temp - 1] == 1)
									newRow[col] = 1;
								temp++;
							}
						}
						if (newRow[col] > 0)
							amountOfDots++;
					}
					map[row] = newRow;
				}
				width = newWidth;
			}
			else
			{
				half = (height - 1) / (float)2;
				newHeight = height - foldNo - 1;
				if (foldNo >= half)
					newHeight = height - (height - foldNo);

				List<List<int>> newMap = new List<List<int>>();

				for (int row = 0; row < newHeight; row++)
				{
					List<int> newRow = new List<int>();
					newMap.Add(newRow);
				}

				for (int col = 0; col < width; col++)
				{
					int temp = 1;
					for (int row = 0; row < newHeight; row++)
					{
						if (foldNo >= half)
						{
							newMap[row].Add(map[row][col]);

							if (newHeight - row <= height - foldNo - 1)
							{
								if (newMap[row][col] == 0 && map[height - temp][col] == 1)
									newMap[row][col] = 1;
								temp++;
							}
						}
						else
						{
							newMap[row].Add(map[height - row - 1][col]);

							if (newHeight - row <= foldNo)
							{
								if (newMap[row][col] == 0 && map[temp - 1][col] == 1)
									newMap[row][col] = 1;
								temp++;
							}
						}
						if (newMap[row][col] > 0)
							amountOfDots++;
					}
				}
				height = newHeight;
				map = newMap;
			}
		}

		public void FoldFully()
		{
			for (int number = 0; number < folds.Count; number++)
			{
				FoldPaper(number);
			}
		}

		public void PrintPaper()
		{
			foreach (var row in map)
			{
				foreach (var col in row)
					Console.Write(col + " ");
				Console.WriteLine();
			}
		}

		public void PrintAmountOfDots()
		{
			Console.WriteLine("Amount of dots: {0}", amountOfDots);
		}
	}
}

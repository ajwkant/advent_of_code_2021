using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Day12.Paths
{
	public class Paths
	{
		private List<List<string>> paths;
		private List<List<string>> uniquePaths;

		public Paths()
		{
			paths = new List<List<string>>();
			uniquePaths = new List<List<string>>();
		}

		public void PathsReader(string path)
		{
			string[] linesRead;

			linesRead = File.ReadAllLines(path);

			foreach (string line in linesRead)
			{
				string[] substrings;
				List<string> newPath = new List<string>();

				substrings = line.Split('-');
				newPath.AddRange(substrings);
				paths.Add(newPath);
			}
		}

		public List<string> FindNextPaths(List<List<string>> availablePaths, string currentCave)
		{
			List<string> returnList = new List<string>();

			foreach(var path in availablePaths)
			{
				// Console.WriteLine(path[0]);
				if (path[0] == currentCave)
				{
					returnList.Add(path[1]);
				}
				else if (path[1] == currentCave)
				{
					returnList.Add(path[0]);
				}
			}
			Console.WriteLine("returnList in Findnextpaths:");
			foreach(var line in returnList)
				Console.WriteLine(line);
			return (returnList);
		}

		static public List<List<string>> RemovePathWithCave(List<List<string>> availablePaths, string cave)
		{
			List<List<string>> changedPaths = new List<List<string>>();

			for (int index = 0; index < availablePaths.Count; index++)
			{
				List<string> path = availablePaths[index];

				if (path[0] == cave || path[1] == cave)
				{
					continue;
				}
				else
				{
					changedPaths.Add(path);
				}
			}

			return (changedPaths);
		}

		static public List<List<string>> RemovePreviousCave(string previousCave, List<List<string>> availablePaths)
		{
			// Remove previouscave if it's a small one or the starting cave
			if (previousCave == "start")
			{
				availablePaths = RemovePathWithCave(availablePaths, previousCave);
			}
			else if (previousCave.Length == 1)
			{
				char cave = char.Parse(previousCave);
				if (Char.IsLower(cave))
				{
					availablePaths = RemovePathWithCave(availablePaths, previousCave);
				}
			}
			return (availablePaths);
		}

		public void ContinueDownThisPath(string previousCave, List<string> currentPath, List<List<string>> availablePaths, string currentCave)
		{
			// Add previouscave to current path
			currentPath.Add(previousCave);

			// Call Recursive path finder
			// Console.WriteLine("Just visited cave: {0}", previousCave);
			// Console.WriteLine("available paths left:");
			// foreach(var line in availablePaths)
			// {
			// 	Console.WriteLine();
			// 	Console.WriteLine(line[0]);
			// 	Console.WriteLine(line[1]);
			// }
			// Console.WriteLine("Currentcave: {0}", currentCave);
			RecursivePathFinder(currentCave, currentPath, availablePaths);
		}

		public void RecursivePathFinder(string currentCave, List<string> currentPath, List<List<string>> availablePaths)
		{
			// Console.WriteLine("Rec	Just visited cave: {0}", currentCave);
			// Console.WriteLine("Rec	Available paths left:");
			// foreach(var line in availablePaths)
			// {
			// 	Console.WriteLine();
			// 	Console.WriteLine(line[0]);
			// 	Console.WriteLine(line[1]);
			// }

			if (currentCave == "end")
			{
				Console.WriteLine("Found a path that works: ");
				foreach(var line in currentPath)
					Console.WriteLine(line);
				uniquePaths.Add(currentPath);
			}
			else
			{




				Console.WriteLine("Rec	Just visited cave: {0}", currentCave);
				List<string> nextPossibleCaves = FindNextPaths(availablePaths, currentCave);
				availablePaths = RemovePreviousCave(currentCave, availablePaths);
				Console.WriteLine("Rec	Available paths left:");
				foreach(var line in availablePaths)
				{
					Console.WriteLine();
					Console.WriteLine(line[0]);
					Console.WriteLine(line[1]);
				}

				Console.WriteLine("Rec	nextPossibleCaves:");
				foreach(var line in nextPossibleCaves)
				{
					Console.WriteLine();
					Console.WriteLine(line);
					// Console.WriteLine(line[1]);
				}
				foreach(var nextPossibleCave in nextPossibleCaves)
				{
					List<string> currentPathCopy = currentPath;
					ContinueDownThisPath(currentCave, currentPathCopy, availablePaths, nextPossibleCave);
				}
			}
		}

		public void FindAllPaths()
		{
			List<string> startList = new List<string>();
			RecursivePathFinder("start", startList, paths);
		}

		public void PrintFoundPaths()
		{
			foreach (var path in uniquePaths)
			{
				Console.WriteLine("Path found: \n");
				foreach (string cave in path)
				{
					Console.Write(cave);
					// break;
				}
				break;
			}
		}
	}
}

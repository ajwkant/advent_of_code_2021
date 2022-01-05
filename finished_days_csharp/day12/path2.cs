using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

// Recursive program to find all the possible paths through caves of different sizes.
namespace Day12.Paths2
{
	public class Paths2
	{
		private List<List<string>> paths;
		private List<List<string>> uniquePaths;

		public Paths2()
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
				if (path[0] == currentCave)
				{
					returnList.Add(path[1]);
				}
				else if (path[1] == currentCave)
				{
					returnList.Add(path[0]);
				}
			}
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
			else if (!previousCave.Any(char.IsUpper))
			{
				availablePaths = RemovePathWithCave(availablePaths, previousCave);
			}
			return (availablePaths);
		}

		static public bool IsAlreadyVisited(List<string> visited, string current)
		{
			foreach (var cave in visited)
			{
				if (cave == current)
					return (true);
			}
			return (false);
		}

		public void ContinueDownThisPath(string previousCave, List<string> currentPath, List<List<string>> availablePaths, string currentCave, bool doubleVisitHappened)
		{
			if (currentCave == "end")
			{
				currentPath.Add(currentCave);
				uniquePaths.Add(currentPath);
				return;
			}

			if (!doubleVisitHappened)
			{
				if (!currentCave.Any(char.IsUpper) && IsAlreadyVisited(currentPath, currentCave))
				{
					doubleVisitHappened = true;
				}
			}
			else if (!currentCave.Any(char.IsUpper) && IsAlreadyVisited(currentPath, currentCave))
			{
				return;
			}

			currentPath.Add(previousCave);
			RecursivePathFinder(currentCave, currentPath, availablePaths, doubleVisitHappened);
		}

		public void RecursivePathFinder(string currentCave, List<string> currentPath, List<List<string>> availablePaths, bool doubleVisitHappened)
		{
			List<string> nextPossibleCaves = FindNextPaths(availablePaths, currentCave);

			foreach(var nextPossibleCave in nextPossibleCaves)
			{
				if (nextPossibleCave == "start")
				{
					continue;
				}
				List<string> currentPathCopy = new List<string>();
				foreach (string item in currentPath)
				{
					currentPathCopy.Add(item);
				}
				ContinueDownThisPath(currentCave, currentPathCopy, availablePaths, nextPossibleCave, doubleVisitHappened);
			}
		}

		public void FindAllPaths()
		{
			List<string> startList = new List<string>();
			RecursivePathFinder("start", startList, paths, false);
		}

		public void PrintFoundPaths()
		{
			int pathNumber = 1;
			foreach (var path in uniquePaths)
			{
				Console.WriteLine("\nPath {0} found:", pathNumber);
				pathNumber++;
				foreach (string cave in path)
				{
					Console.Write(cave + " ");
				}
			}
		}
	}
}

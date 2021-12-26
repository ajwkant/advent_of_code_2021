using System;
class Hello
{
	static public bool Is_Lowest(string[] lines, int i, int j)
	{
		if (i > 0 && lines[i][j] - '0' >= lines[i - 1][j] - '0')
			return (false);
		if (j > 0 && lines[i][j] - '0' >= lines[i][j - 1] - '0')
			return (false);
		if (j + 1 < lines[i].Length && lines[i][j] - '0' >= lines[i][j + 1] - '0')
			return (false);
		if (i + 1 < lines.Length && lines[i][j] - '0' >= lines[i + 1][j] - '0')
			return (false);
		return (true);
	}
	static void Main()
	{
		int sum = 0;
		Console.WriteLine("Hello C# World!");
		string[] lines = System.IO.File.ReadAllLines("input_day9.txt");
		for(int i = 0; i < lines.Length; i++)
		{
			for(int j = 0; j < lines[0].Length; j++)
			{
				if (Is_Lowest(lines, i, j))
					sum += lines[i][j] - '0' + 1;
			}
		}
		Console.WriteLine("The sum is: {0}\n", sum);
	}
}
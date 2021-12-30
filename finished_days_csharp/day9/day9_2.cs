using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Basin
{
	public class String_list
	{
		private readonly List<StringBuilder> line_list;

		public String_list()
		{
			line_list = new List<StringBuilder>();
		}

		public List<StringBuilder> Line_list
		{
			get { return line_list; }
		}

		public int List_length()
		{
			return (line_list.Count);
		}

		public void Read_file(string path)
		{
			string[] lines = File.ReadAllLines(path);

			foreach (string line in lines)
			{
				line_list.Add(new StringBuilder(line));
			}
		}
		public void Mutate_string(int i, int j, char c)
		{
			StringBuilder line = line_list[i];

			line[j] = c;
		}
	}
	public class Basin_help
	{
		static public int get_basinsize_recursively(String_list stringList, int i, int j)
		{
			int basinsize = 0;

			List<StringBuilder> line_list = stringList.Line_list;

			if (line_list[i][j] != 'x' && line_list[i][j] != '9')
			{
				basinsize++;
				line_list[i][j] = 'x';
			}
			if (i > 0 && line_list[i - 1][j] != 'x' && line_list[i - 1][j] != '9')
			{
				basinsize += get_basinsize_recursively(stringList, i - 1, j);
			}
			if (j > 0 && line_list[i][j - 1] != 'x' && line_list[i][j - 1] != '9')
			{
				basinsize += get_basinsize_recursively(stringList, i, j - 1);
			}
			if (j + 1 < line_list[i].Length && line_list[i][j + 1] != 'x' && line_list[i][j + 1] != '9')
			{
				basinsize += get_basinsize_recursively(stringList, i, j + 1);
			}
			if (i + 1 < line_list.Count && line_list[i + 1][j] != 'x' && line_list[i + 1][j] != '9')
				basinsize += get_basinsize_recursively(stringList, i + 1, j);
			return (basinsize);
		}

		static public void organise_biggest_basins(int[] basins)
		{
			int temp;
			if (basins[3] > basins[2])
			{
				basins[2] = basins[3];
				if (basins[2] > basins[1])
				{
					temp = basins[1];
					basins[1] = basins[2];
					basins[2] = temp;
					if (basins[1] > basins[0])
					{
						temp = basins[0];
						basins[0] = basins[1];
						basins[1] = temp;
					}
				}
			}
		}
	}
	public class Basin_program
	{
		static void Main()
		{
			String_list stringList = new String_list();

			stringList.Read_file("input_day9.txt");

			int[] basins = {0, 0, 0, 0};
			for (int i = 0; i < stringList.List_length(); i++)
			{
				int line_length = stringList.Line_list[0].Length;
				for(int j = 0; j < line_length; j++)
				{
					List<StringBuilder> line_list = stringList.Line_list;

					if (line_list[i][j] != 'x')
					{
						basins[3] = Basin_help.get_basinsize_recursively(stringList, i, j);
						Basin_help.organise_biggest_basins(basins);
					}
				}
			}
			Console.WriteLine("Basin 1, 2, 3 and multiplied: {0}, {1}, {2}, {3}\n",
				basins[0], basins[1], basins[2], basins[0] * basins[1] * basins[2]);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day10
{

	public class SyntaxMain
	{
		static int GetPoints(char currentChar)
		{
			if (currentChar == '(')
				return (1);
			if (currentChar == '[')
				return (2);
			if (currentChar == '{')
				return (3);
			if (currentChar == '<')
				return (4);
			Console.WriteLine("Error: Invalid character");
			return (-1);
		}

		static long CalculateScore(Stack.Stack stack)
		{
			long score = 0;
			int points = 0;

			if (stack.IsEmpty())
			{
				return (-1);
			}

			while (!stack.IsEmpty())
			{
				score *= 5;
				points = GetPoints(stack.StackPop());
				if (points != -1)
				{
					score += points;
				}
				else
				{
					return (-1);
				}
			}
			return (score);
		}

		static bool ClosesIncorrectly(char currentChar, char poppedChar)
		{
			if (poppedChar == '(')
				return (currentChar != ')');
			if (poppedChar == '[')
				return (currentChar != ']');
			if (poppedChar == '{')
				return (currentChar != '}');
			if (poppedChar == '<')
				return (currentChar != '>');
			return (false);
		}
		static void Main()
		{
			string[] lines = File.ReadAllLines("input_day10.txt");
			Stack.Stack stack = new Stack.Stack();
			char poppedChar;
			long score;
			List<long> scoreList = new List<long>();

			foreach (string line in lines)
			{
				foreach (char currentChar in line)
				{
					if (currentChar == '(' || currentChar == '['
						|| currentChar == '{' || currentChar == '<')
						stack.StackPush(currentChar);
					else
					{
						poppedChar = stack.StackPop();
						if (ClosesIncorrectly(currentChar, poppedChar))
						{
							stack.Clear();
							break;
						}
					}
				}

				score = CalculateScore(stack);
				if (score == -1)
				{
					continue;
				}
				scoreList.Add(score);
			}
			scoreList.Sort();
			long middleScore = scoreList[scoreList.Count / 2];
			scoreList.ForEach(Console.WriteLine);
			Console.WriteLine("Middle score: {0}", middleScore);
		}
	}
}
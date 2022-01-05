using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Syntax
{
	public class Stack
	{
		private StringBuilder stack;
		private int top;

		public Stack()
		{
			stack = new StringBuilder();
			top = -1;
		}

		public void StackPush(char c)
		{
			if (stack is not null)
			{
				top++;
				stack.Append(c);
			}
			else
				Console.WriteLine("Error: Stack is null");
		}

		public char StackPop()
		{
			if (stack is not null)
			{
				top--;
				char c = stack[top + 1];
				stack.Remove(top + 1, 1);
				return (c);
			}
			Console.WriteLine("Error: Stack is null");
			return 'x';
		}
	}

	public class Syntax_main
	{
		static int GetPoints(char c)
		{
			if (c == ')')
				return (3);
			if (c == ']')
				return (57);
			if (c == '}')
				return (1197);
			if (c == '>')
				return (25137);
			Console.WriteLine("Error: Invalid character");
			return (-1);
		}

		static bool ClosesIncorrectly(char c, char poppedChar)
		{
			if (poppedChar == '(')
				return (c != ')');
			if (poppedChar == '[')
				return (c != ']');
			if (poppedChar == '{')
				return (c != '}');
			if (poppedChar == '<')
				return (c != '>');
			return (false);
		}
		static void Main1()
		{
			string[] lines = File.ReadAllLines("input_day10.txt");
			Stack stack = new Stack();
			char poppedChar;
			int total = 0;
			int points;

			foreach (string line in lines)
			{
				foreach (char c in line)
				{
					if (c == '(' || c == '[' || c == '{' || c == '<')
						stack.StackPush(c);
					else
					{
						poppedChar = stack.StackPop();
						if (ClosesIncorrectly(c, poppedChar))
						{
							points = GetPoints(c);
							if (points == -1)
								return;
							total += points;
							break;
						}
					}
				}
			}
			Console.WriteLine("Total Illegal Points: {0}", total);
		}
	}
}
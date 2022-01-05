using System;
using System.Text;

namespace Day10.Stack
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

		public bool IsEmpty()
		{
			if (top == -1)
			{
				return (true);
			}
			return (false);
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
				char c = stack[top];
				stack.Remove(top, 1);
				top--;
				return (c);
			}
			Console.WriteLine("Error: Stack is null");
			return 'x';
		}

		public void Clear()
		{
			if (stack is not null)
			{
				stack.Clear();
				top = -1;
			}
		}
	}
}

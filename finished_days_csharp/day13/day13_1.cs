using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day13
{
	public class PaperMain
	{
		static void Main()
		{
			Paper.Paper Paper = new Paper.Paper();

			Paper.PaperReader("input_day13.txt");

			// Uncomment these two lines to get the answer for the first challenge
			// Paper.FoldPaper(0);
			// Paper.PrintAmountOfDots();

			// These lines are to get the answer of the second challenge

			Paper.FoldFully();
			Paper.PrintPaper();
		}
	}
}

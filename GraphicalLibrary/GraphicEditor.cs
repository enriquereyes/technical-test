using System;
using System.Collections.Generic;

namespace GraphicalLibrary
{
	public class GraphicEditor
	{
		public static string[,] image { get; set; }

		public GraphicEditor()
		{

		}

		public static void InteractiveConsole(List<string> input)
		{
			switch (input[0])
			{
				case "I":
					int m = int.Parse(input[1]);
					int n = int.Parse(input[2]);
					CreateImage(m, n);
					break;

			}

		}

		public static void CreateImage(int m, int n)
		{
			image = new string[n, m];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					image[i, j] = "O";
				}
			}

		}


	}
}

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

				case "C":
                	ClearTable();
					break;


				case "S":
                    DisplayImage();
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

		public static void ClearTable()
		{
			int rowLength = image.GetLength(0);
			int colLength = image.GetLength(1);

			for (int i = 0; i < rowLength; i++)
			{
				for (int j = 0; j < colLength; j++)
				{
					image[i, j] = "O";
				}
			}
		}


		public static void DisplayImage()
		{
			int rowLength = image.GetLength(0);
			int colLength = image.GetLength(1);

			for (int i = 0; i < rowLength; i++)
			{
				for (int j = 0; j < colLength; j++)
				{
					Console.Write(string.Format("{0}", image[i, j]));
				}
				Console.Write("\n");
			
		}


	}
}

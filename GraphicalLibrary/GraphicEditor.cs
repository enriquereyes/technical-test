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
			int m;
			int n;
			int x;
			int y;
			int x1;
			int x2;
			int y1;
			int y2;
			char c;

			
			switch (input[0])
			{
				case "I":
					m = int.Parse(input[1]);
					n = int.Parse(input[2]);

					CreateImage(m, n);

					break;

				case "C":
					ClearTable();
					break;


				case "L":
					x = int.Parse(input[1]) - 1;
					y = int.Parse(input[2]) - 1;
					c = char.Parse(input[3]);

					ColorPixel(x, y, c);

					break;


				case "V":
					// V X Y1 Y2 C
					x = int.Parse(input[1]) -1;
					y1 = int.Parse(input[2]) - 1;
					y2 = int.Parse(input[3]) - 1;
					c = char.Parse(input[4]);	

                    DrawVertical(x, y1, y2, c);

					break;

				case "H":
					// H X1 X2 Y C. 
					x1 = int.Parse(input[1]) -1;
					x2 = int.Parse(input[2]) - 1;
					y = int.Parse(input[3]) - 1;
					c = char.Parse(input[4]);


					DrawHorizontal(x1, x2, y, c);
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

		public static void ColorPixel(int x, int y, char c)
		{
			image[y, x] = c.ToString();
		}

		public static void DrawVertical(int x, int y1, int y2, char c)
		{
			for (int i = y1; i <= y2; i++)
			{
				image[i, x] = c.ToString();
			}
		}

		public static void DrawHorizontal(int x1, int x2, int y, char c)
		{
			for (int i = x1; i <= x2; i++)
			{
				image[y, i] = c.ToString();
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
}

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
					// I M N

					m = int.Parse(input[1]);
					n = int.Parse(input[2]);

					CreateImage(m, n);

					break;

				case "C":
					// C
					
					ClearTable();

					break;


				case "L":
					// L X Y C

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
					// H X1 X2 Y C

					x1 = int.Parse(input[1]) -1;
					x2 = int.Parse(input[2]) - 1;
					y = int.Parse(input[3]) - 1;
					c = char.Parse(input[4]);


					DrawHorizontal(x1, x2, y, c);

					break;

				case "F":
					// F X Y C

					x = int.Parse(input[1]) - 1;
					y = int.Parse(input[2]) - 1;
					c = char.Parse(input[3]);

					FillRegion(x, y, c);

					break;


				case "S":
					// S
					
					DisplayImage();

					break;


			}

		}

		// I M N. Create a new M x N image with all pixels coloured.
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

		// C. Clears the table, setting all pixels to white (O).
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

		// L X Y C. Colours the pixel (X, Y) with colour C.
		public static void ColorPixel(int x, int y, char c)
		{

			image[y, x] = c.ToString();
		}

		// V X Y1 Y2 C. Draw a vertical segment of colour C in column Xbetween rows Y1 and Y2 (inclusive).
		public static void DrawVertical(int x, int y1, int y2, char c)
		{

			for (int i = y1; i <= y2; i++)
			{
				image[i, x] = c.ToString();
			}
		}

		// H X1 X2 Y C. Draw a horizontal segment of colour C in row Ybetween columns X1 and X2 (inclusive).
		public static void DrawHorizontal(int x1, int x2, int y, char c)
		{
			for (int i = x1; i <= x2; i++)
			{
				image[y, i] = c.ToString();
			}
		}

		// F X Y C. Fill the region R with the colour C. R is defined as: Pixel (X,Y) belongs to R. 
		// Any other pixel which is the same colour as (X,Y) and shares a common side with any pixel in R
		// also belongs to this region.
		public static void FillRegion(int x, int y, char c)
		{
			
		}

		// S. Show the contents of the current image.
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

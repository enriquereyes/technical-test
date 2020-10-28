using System;
using System.Collections.Generic;
using System.Linq;

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
			int rowLength = image.GetLength(0);
			int colLength = image.GetLength(1);
			string pColor = image[y, x].ToString();

			string regionPixels = string.Join(Environment.NewLine,
			                            FindNeighbors(image, new Tuple<int, int>(y, x), pColor, c.ToString()));
			image[y, x] = c.ToString();
		}


		private static IEnumerable<Tuple<int, int>> FindNeighbors(string[,] items,
													 Tuple<int, int> startAt,
		                                                       string previousColor, string newColor)
		{
			if (startAt.Item1 < 0 || startAt.Item1 >= items.GetLength(0) ||
				startAt.Item2 < 0 || startAt.Item2 >= items.GetLength(1))
				yield break; 
			else if (items[startAt.Item1, startAt.Item2] != previousColor)
				yield break;

			Queue<Tuple<int, int>> agenda = new Queue<Tuple<int, int>>();
			HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>() { startAt };

			agenda.Enqueue(startAt);

			while (agenda.Any())
			{
				for (int i = agenda.Count - 1; i >= 0; --i)
				{
					var point = agenda.Dequeue();

					yield return point;

					// Neighbors
					var validNeighbors = new Tuple<int, int>[] {
				 new Tuple<int, int>(point.Item1 - 1, point.Item2),     // Left
		         new Tuple<int, int>(point.Item1 + 1, point.Item2),     // Right
		         new Tuple<int, int>(point.Item1, point.Item2 - 1),     // Top
		         new Tuple<int, int>(point.Item1, point.Item2 + 1),}    // Bottom
					.Where(p => p.Item1 >= 0 && p.Item1 < items.GetLength(0)) // Within array
					.Where(p => p.Item2 >= 0 && p.Item2 < items.GetLength(1)) // Within array
						.Where(p => items[p.Item1, p.Item2] == previousColor)            // Valid point
					.Where(p => visited.Add(p));                              // Not visited 

					foreach (var p in validNeighbors)
					{
						agenda.Enqueue(p);
						image[p.Item1, p.Item2] = newColor;
					}
				}

		 }
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

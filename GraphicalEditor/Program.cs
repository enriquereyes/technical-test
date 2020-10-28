using System;
using System.Collections.Generic;
using System.Linq;
using GraphicalLibrary;

namespace GraphicalEditor
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			GraphicEditor graphicEditor = new GraphicEditor();
			List<string> input = new List<string>();

			do
			{
				input = Console.ReadLine().Split().ToList();
				GraphicEditor.InteractiveConsole(input);

			} while (input[0] != "X");

		}
	}
}

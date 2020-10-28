using NUnit.Framework;
using System;
using GraphicalLibrary;

namespace GraphicalLibrary.Tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase()
		{
			int m = 5;
			int n = 6;


			string[,] testImage = new string[,] { 	{ "O", "O", "O", "O", "O", "O" }, 
												  	{ "O", "O", "O", "O", "O", "O" }, 
												 	{ "O", "O", "O", "O", "O", "O" }, 
													{ "O", "O", "O", "O", "O", "O" }, 
													{ "O", "O", "O", "O", "O", "O" } };
			
			GraphicEditor.CreateImage(n, m);
			Assert.AreEqual(testImage, GraphicEditor.image);
		}

		[Test()]
		public void TestClearTable()
		{
			int m = 5;
			int n = 6;


			string[,] testImage = new string[,] {   { "O", "O", "O", "O", "O", "O" },
												  	{ "O", "O", "O", "O", "O", "O" },
												 	{ "O", "O", "O", "O", "O", "O" },
													{ "O", "O", "O", "O", "O", "O" },
													{ "O", "O", "O", "O", "O", "O" } };

			GraphicEditor.CreateImage(n, m);
			GraphicEditor.ClearTable();
			Assert.AreEqual(testImage, GraphicEditor.image);
		}
	}
}

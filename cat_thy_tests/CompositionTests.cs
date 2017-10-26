using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cat_thy.tests
{
	[TestClass]
	public class CompositionTests
	{
		[TestMethod]
		public void IdTest()
		{
			// Arrange
			// Setting up a function to pass to Id
			Func<int, int> triple = delegate (int x) { return x * 3; };
			

			// Act
			// Pass the function to Id
			Func<int, int> idTriple = Composition.FunctionId<int, int>(triple);

			// Assert
			Assert.AreEqual(triple, idTriple);
			
		}


		
		[TestMethod]
		public void ComposeTest()
		{
			// Arrange
			// Set up two functions
			Func<double, double> f = Math.Sqrt;
			Func<double, double> g = Math.Log10;

			// Act
			// Compose the f o g
			Func<double, double> FoG = Composition.Compose<double, double, double>(f, g);

			double test = 100.001;
			double sq = Math.Sqrt(test);
			double lg = Math.Log10(sq);
			Assert.AreEqual(lg, FoG(100.001));

		}

		[TestMethod]
		public void ComposeIdTest()
		{
			//Write a program that tries to test that your composition function	respects identity.

			// Arrange
			Func<double, double> f = Math.Sqrt;
			//Func<double, double> Id_f = Composition.DoubleId;
			Func<double, double> Id_f = Composition.Id;

			// Act
			Func<double, double> FoId_f = Composition.Compose<double, double, double>(f, Id_f);

			// Assert
			double test = 100.001;
			double sq = f(test);
			Assert.AreEqual(sq, FoId_f(test));


		}

	}
}

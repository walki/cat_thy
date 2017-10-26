using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat_thy
{
	public static class Composition
	{
		public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
		{
			return x => g(f(x));
		}

		public static Func<T1, T2> FunctionId<T1, T2>(Func<T1, T2> f)
		{
			return f;
		}


		public static T Id<T>(T t)
		{
			return t;
		}

		public static double DoubleId(double d)
		{
			return d;
		}

		public static void Test()
		{
			Func<Func<int, int>, Func<int, int>> identityInt = delegate (Func<int, int> f)
			{
				return f;
			};

			

			var incr = identityInt(AddOne);
			Func<int,int> incr2 = FunctionId<int,int>(AddOne);
			

			System.Console.WriteLine(incr(99));
			System.Console.WriteLine(incr2(999));


			var addThenDouble = Compose<int, int, double>(AddOne, Twice);
			Console.WriteLine(addThenDouble(12));

			var sqrtThenPrint = Compose<int, double, string>(SquareRoot, PrintResult);
			Console.WriteLine(sqrtThenPrint(122121));


		}

		public static double SquareRoot(int x)
		{
			return Math.Sqrt(x);
		}

		public static int AddOne(int x)
		{
			return x + 1;
		}

		public static double Twice(int x)
		{
			return x * 2.0;
		}

		public static string PrintResult(double x)
		{
			return String.Format("The result was {0:0.0000}", x);
		}

	}
}

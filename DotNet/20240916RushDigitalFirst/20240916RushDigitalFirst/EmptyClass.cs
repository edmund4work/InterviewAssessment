using System;
namespace _20240916RushDigitalFirst
{
	public class EmptyClass
	{
		public static int Calculate(int n)
		{
            //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144

            if (n < 2)
                return n;
            else
                return Calculate(n - 1) + Calculate(n - 2);
        }
    }
}


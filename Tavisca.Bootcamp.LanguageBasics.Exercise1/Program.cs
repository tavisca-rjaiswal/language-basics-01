using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            int indexOfQMark = equation.IndexOf("?");
            int indexOfMult = equation.IndexOf("*");
            int indexOfEqual = equation.IndexOf("=");
            int l = 0, cnt = 0, missDig = -1;
            if (indexOfQMark == 0 || indexOfQMark == indexOfMult + 1 || indexOfQMark == indexOfEqual + 1)
            {
                l = 1;
            }
            for (; l < 10; l++)
            {
                string newEquation = equation.Replace("?", l + "");
                int A = Convert.ToInt32(newEquation.Substring(0, indexOfMult));
                int B = Convert.ToInt32(newEquation.Substring(indexOfMult + 1, indexOfEqual - indexOfMult - 1));
                int C = Convert.ToInt32(newEquation.Substring(indexOfEqual + 1));
                if (A * B == C)
                {
                    cnt++;
                    missDig = l;
                }
            }
            if (cnt != 1) { missDig = -1; }
            return missDig;
        }
    }
}

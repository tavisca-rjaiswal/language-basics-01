using System;
using System.Data;

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
            int start, cnt = 0, missDig = -1;

            start = isLeadingDigit(equation) ? 1 : 0;

            for (int digit=start; digit <= 9; digit++)
            { 
                string newEquation = equation.Replace("?", digit.ToString());
                if(isDigitCorrect(newEquation))
                {
                    cnt++;
                    missDig = digit;
                }
            }
            if (cnt != 1) { missDig = -1; }
            return missDig;
        }

        private static bool isLeadingDigit(string equation)
        {
            int indexOfQMark = equation.IndexOf("?");
            int indexOfMult = equation.IndexOf("*");
            int indexOfEqual = equation.IndexOf("=");

            if (indexOfQMark == 0 || indexOfQMark == indexOfMult + 1 || indexOfQMark == indexOfEqual + 1)
            {
                return true;
            }
            return false;
        }

        private static bool isDigitCorrect(string newEquation)
        {
            DataTable dt = new DataTable();
            if (Convert.ToBoolean(dt.Compute(newEquation, "")))
            {
                return true;
            }
            return false;
        }

    }
}

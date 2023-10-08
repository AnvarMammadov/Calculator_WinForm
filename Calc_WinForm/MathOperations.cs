using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_WinForm
{
    public static class MathOperations
    {
        public static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subt(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Mult(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Devide(double num1, double num2)
        {
            if (Validation.CheckDevision(num2)) return num1 / num2;
            throw new ArgumentException("Can not devide by zero");
        }

        public static double Sqrt2(double num)
        {
            if (Validation.CheckSquareRoot(num)) return Math.Sqrt(num);
            throw new ArgumentException("When taking the square root, the number under the " +
                "radical (radicand) cannot be negative when the exponent is 2.");
        }

        public static double Pow2(double num)
        {
            return num * num;
        }

        public static double GetPercentNumber(double num)
        {
            return num / 100;
        }

        public static double GetDenominatorNum(double num)
        {
            return 1 / num;
        }
    }
}

using System;


namespace Lab_5
{
    class Simpson
    {
        public static double Get(ref double a, ref double b, ref int n, Function func)
        {
            double h = Math.Abs(b - a) / n;//Шаг
            double x = a + h;
            double S = 0;
            while (x < b)
            {
                S += 4 * func(x);
                x += h;
                S += 2 * func(x);
                x += h;
            }
            return (h / 3) * (func(a) + S + func(b));
        }
    }
}
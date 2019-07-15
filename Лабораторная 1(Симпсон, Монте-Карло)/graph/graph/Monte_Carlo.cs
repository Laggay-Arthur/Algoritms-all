using System;
using System.Collections.Generic;


namespace graph
{
    class Monte_Carlo
    {
        int n,         //Число испытаний
            N,         //Общее число бросков
            K;         //Число точек попавших под интеграл  
        double a,      //Нижный предел интегрирования
               b,      //Верхних предел интегрирования
               min,    //Точка с минимальной высотой
               max;    //Точка с максимальной высотой
        List<double> Area;//Список площадей

        public Monte_Carlo(double a, double b, int N, int n, double min, double max)
        {
            this.a = a;
            this.b = b;
            this.N = N;
            this.n = n;
            this.min = min;
            this.max = max;
            Area = new List<double>();
            Get();
        }
        Random rand;
        Form1 mw = new Form1();
        private void Get()
        {   //Запускаем Монте-Карло
            rand = new Random();
            double x, y;
            for (int i = 0; i < n; i++)
            {   //проводим эксперимент n раз
                K = 0;
                for (int p = 0; p < N; p++)
                {//Бросаем точки N раз
                    x = rand.NextDouble() * (b - a);
                    y = rand.NextDouble() * (max - min);
                    if (y < mw.Function(x)) K++;
                }
                Area.Add(GetS);//Добавляем площадь в общий список
            }
        }

        private double MiddleArea()
        {   //Средняя площадь
            double S = 0;
            foreach (double a in Area) S += a;
            return (1d / n) * (S);
        }

        private double MiddleAreaSquare()
        {   //Средняя площадь^2
            double S = 0;
            foreach (double a in Area) S += a * a;
            return (1d / n) * (S);
        }
        private double GetS0    //Площадь прямоугольника ограничивающего интеграл
        => (b - a) * (max);
        public double GetS      //Получаем площадь
        => GetS0 * ((double)K / N);
        public double GetEpsilon//Получаем погрешность
        => Math.Sqrt(Math.Abs(MiddleAreaSquare() - Math.Pow(MiddleArea(), 2)));
    }
}
using System;
using System.Collections.Generic;


namespace graph
{
    class Simpson
    {
        Form1 mw = new Form1();
        double h = 0,       //Шаг
               epsilon = 0, //искомая погрешность
               a = 0, b = 0;//минимальное и максимальное значение интеграла

        int min_Hop, max_Hop;//Число разбиений
        //2 4 8 16 32 64 128 256 512 1024 2048 4096 8192
        public Simpson(double a, double b, double epsilon, int min_Hop, int max_Hop)
        {
            this.a = a;
            this.b = b;
            this.epsilon = epsilon;
            this.min_Hop = min_Hop;
            this.max_Hop = max_Hop;

            epsilon = Math.Pow(epsilon, 0.25);
            RoundN();// огругляем до числа кратного 4
            h = (b - a) / this.min_Hop;

            Get();
        }

        private void RoundN()
        {   // огругляем число разбиений до числа кратного 4
            while (min_Hop % 4.0 != 0) min_Hop++;
        }
        private void Get()
        {
            double x = a + h; //Интегрируемая точка
            while (x < b)
            {
                S += 4 * mw.Function(x);
                x += h;
                S += 2 * mw.Function(x);
                x += h;
            }
            S = (h / 3) * (GetS + mw.Function(a) - mw.Function(b));
            Area.Add(GetS);//Добавляем площадь в список чтобы можно было проверить погрешность по формуле Рунге
            iteration++;
            Runge();//Проверяем погрешность по формуле Рунге
        }

        double S1 = 0, S = 0;
        List<double> Area = new List<double>();
        int iteration = 0;
        private void Runge()
        {   //Проверяем достигнута ли заданная точность
            if (Area.Count > 1)
            {
                GetEpsilon = (Area[Area.Count - 1] - Area[Area.Count - 2]) / (Math.Pow(2, iteration) - 1);
                if (GetEpsilon < 0) GetEpsilon = -GetEpsilon;
                if (GetEpsilon > epsilon) Get();
            }
            else Get();//Если в списке только одна площадь
        }

        public void SimpsonAdaptive()
        {
            Area = new List<double>
            { 0, 0 };
            for (int N = 2; (N <= 4) || (Math.Abs(Area[0] - Area[1]) / 15 > epsilon); N *= 2)
            {
                S = S1 = 0;
                h = (b - a) / (2 * N);
                for (int i = 1; i <= 2 * N - 1; i += 2)
                {
                    S += mw.Function(a + h * i);
                    S1 += mw.Function(a + h * (i + 1));
                }
                Area[0] = Area[1];
                Area[1] = (h / 3) * (mw.Function(a) + 4 * S + 2 * S1 - mw.Function(b));
            }
            S = Area[1];
            GetEpsilon = Math.Abs(Area[0] - Area[1]);
        }

        public double GetS { get => S; }//Возвращаем площадь
        public double GetEpsilon { get; set; }//Возвращаем реальную погрешность
    }
}
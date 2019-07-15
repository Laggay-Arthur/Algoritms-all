using System;
using System.Collections.Generic;


namespace Lab_5
{
    public delegate double Function(double x);
    public class DPoint
    {
        public double x, y;
        public DPoint(double x, double y)
        { this.x = x; this.y = y; }
    }
    public class Furie
    {
        double mp = -Math.PI, pp = Math.PI;//Отрезок в котором видим функцию
        public List<DPoint> DPoints { get; set; }
        public List<DPoint> Get(double a, double b, int hop, Function Basefunc)
        {
            int n = hop;//Число разбиений
            Function func;
            DPoints = new List<DPoint>();
            int k = 1000;
            double ak, bk, y;
            double T = 2 / (2 * Math.PI);

            for (double i = a; i < b; i += 0.1)
            {
                y = T * Simpson.Get(ref mp, ref pp, ref k, Basefunc);

                for (int j = 1; j <= n; j++)
                {
                    func = x => Basefunc(x) * Math.Cos((x * j));
                    ak = T * Simpson.Get(ref mp, ref pp, ref k, func);

                    func = x => Basefunc(x) * Math.Sin((x * j));
                    bk = T * Simpson.Get(ref mp, ref pp, ref k, func);

                    y += ak * Math.Cos(i * j) + bk * Math.Sin(i * j);
                }
                DPoints.Add(new DPoint(i, y));
            }
            return DPoints;
        }
    }
}
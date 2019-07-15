using System;
using System.Windows.Forms;


namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        double eps = 0.00001;//Искомая погрешность
        private void Get_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0, J,
            next_X, next_Y;         //Следущее приблежение для корней
            while (true)
            {
                J = f1_X(x) * f2_Y(y) - f1_Y(y) * f2_X(x);

                next_X = x + (-f1(x, y) * f2_Y(y) + f2(x, y) * f1_Y(y)) / J;
                next_Y = y + (-f2(x, y) * f1_X(x) + f1(x, y) * f2_X(x)) / J;
                if (Math.Abs(next_X - x) < eps && Math.Abs(next_Y - y) < eps) break;//Если достигнута заданная точность отстанавливаем вычисления
                x = next_X; y = next_Y;//Переопределяем приблежения для корней
            }
            label1.Text = "X: " + x.ToString();
            label2.Text = "Y: " + y.ToString();
        }

        //Вариант 1
        //sin(x + 1) - y = 1.2
        //2*x + cos(y) = 2
        private double f1(double x, double y)
        { return Math.Sin(x + 1) - y - 1.2; }
        private double f1_X(double x)
        { return Math.Cos(x + 1); }
        private double f1_Y(double y)
        { return -1; }

        private double f2(double x, double y)
        { return 2 * x + Math.Cos(y) - 2; }
        private double f2_X(double x)
        { return 2; }
        private double f2_Y(double y)
        { return -Math.Sin(y); }


        ////Вариант 3
        ////2*x + cos(y) = 2
        ////sin(x) + 2*y = 2
        //private double f1(double x, double y)
        //{ return 2 * x + Math.Cos(y) - 2; }
        //private double f1_X(double x)
        //{ return 2; }
        //private double f1_Y(double y)
        //{ return -Math.Sin(y); }

        //private double f2(double x, double y)
        //{ return Math.Sin(x) + 2 * y - 2; }
        //private double f2_X(double x)
        //{ return Math.Cos(x); }
        //private double f2_Y(double y)
        //{ return 2; }


        ////Вариант 5
        ////sin(x + 0.5) - y = 1
        ////cos(y - 2) + x = 0
        //private double f1(double x, double y)
        //{ return Math.Sin(x + 0.5) - y - 1; }
        //private double f1_X(double x)
        //{ return Math.Cos(x + 0.5); }
        //private double f1_Y(double y)
        //{ return -1; }

        //private double f2(double x, double y)
        //{ return Math.Cos(y - 2) + x; }
        //private double f2_X(double x)
        //{ return 1; }
        //private double f2_Y(double y)
        //{ return -Math.Sin(y - 2); }


        ////Вариант 9
        ////cos(x + 0.5) - y = 2
        //sin(y) -2*x = 1
        //private double f1(double x, double y)
        //{ return Math.Cos(x + 0.5) - y - 2; }
        //private double f1_X(double x)
        //{ return -Math.Sin(x + 0.5); }
        //private double f1_Y(double y)
        //{ return -1; }

        //private double f2(double x, double y)
        //{ return Math.Sin(y) - 2 * x - 1; }
        //private double f2_X(double x)
        //{ return -2; }
        //private double f2_Y(double y)
        //{ return Math.Cos(y); }


        //Будет долго считать
        ////Вариант 12
        ////cos(y-1) + x = 0.5
        //y - cos(x) = 3
        //private double f1(double x, double y)
        //{ return Math.Cos(y - 1) + x - 0.5; }
        //private double f1_X(double x)
        //{ return 1; }
        //private double f1_Y(double y)
        //{ return Math.Sin(y - 1); }

        //private double f2(double x, double y)
        //{ return y - Math.Cos(x) - 3; }
        //private double f2_X(double x)
        //{ return Math.Sin(x); }
        //private double f2_Y(double y)
        //{ return 1; }


        ////Вариант 23
        ////sin(x) + 2*y = 1.6
        //cos(y-1) + x = 1
        //private double f1(double x, double y)
        //{ return Math.Sin(x) + 2 * y - 1.6; }
        //private double f1_X(double x)
        //{ return Math.Cos(x); }
        //private double f1_Y(double y)
        //{ return 2; }

        //private double f2(double x, double y)
        //{ return Math.Cos(y - 1) + x - 1; }
        //private double f2_X(double x)
        //{ return 1; }
        //private double f2_Y(double y)
        //{ return -Math.Sin(y - 1); }
    }
}
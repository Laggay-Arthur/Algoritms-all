using System;
using System.Windows.Forms;


namespace Lab_4_1_spline_
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        const int Max = 1000;//Размерность интерполируемой области
        double[] Y = new double[Max];
        double[] X = new double[Max];

        Spline[] splines;// Сплайн
        private struct Spline// Структура, описывающая сплайн на каждом сегменте сетки
        { public double a, b, c, d, x; }
        void Sin_Click(object sender, EventArgs e) => BaseMedthod(Math.Sin); //Интерполяция Sin
        void Cos_Click(object sender, EventArgs e) => BaseMedthod(Math.Cos); //Интерполяция Cos
        void Tan_Click(object sender, EventArgs e) => BaseMedthod(Math.Tan); //Интерполяция Tan
        /// <summary>
        /// Построение сплайна
        /// x - узлы сетки, должны быть упорядочены по возрастанию, кратные узлы запрещены
        /// y - значения функции в узлах сетки
        /// n - количество узлов сетки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="n"></param>
        void BuildSpline(double[] x, double[] y, int n)
        {
            splines = new Spline[n]; // Инициализация массива сплайнов
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = x[i];
                splines[i].a = y[i];
            }
            splines[0].c = splines[n - 1].c = .0;
            // Решение СЛАУ относительно коэффициентов сплайнов c[i] методом прогонки для трехдиагональных матриц
            // Вычисление прогоночных коэффициентов - прямой ход метода прогонки
            double[] alpha = new double[n - 1];
            double[] beta = new double[n - 1];
            alpha[0] = beta[0] = 0.0;
            double hi, hi1, A, C, B, F, z;
            for (int i = 1; i < n - 1; i++)
            {
                hi = x[i] - x[i - 1];
                hi1 = x[i + 1] - x[i];
                A = hi;
                C = 2.0 * (hi + hi1);
                B = hi1;
                F = 6.0 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                z = (A * alpha[i - 1] + C);
                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }

            for (int i = n - 2; i > 0; --i)//Нахождение решения - обратный ход метода прогонки
                splines[i].c = alpha[i] * splines[i + 1].c + beta[i];

            for (int i = n - 1; i > 0; --i)
            {// По известным коэффициентам c[i] находим значения b[i] и d[i]
                hi = x[i] - x[i - 1];
                splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y[i] - y[i - 1]) / hi;
            }
        }
        delegate double method(double x);//Делегат для задания расчётной функции
        void BaseMedthod(method method)
        {
            chart1.Series[0].Points.Clear();
            double h = 0.04;//Шаг
            double z = 0; int N = 0;
            while (N < Max)
            {
                X[N] = z;
                Y[N] = method(z += h);
                N++;
            }
            BuildSpline(X, Y, N);

            for (double x = 1.00; x <= 1.21; /*x += h*/) //Отрисовка
            {
                chart1.Series[0].Points.AddXY(x, Interpolate(x));
                if(check)
                    MessageBox.Show($"x{x + h}: " + Interpolate(x).ToString());
                x += h;
            
            }
        }
        double Interpolate(double x)
        {// Вычисление значения интерполированной функции в произвольной точке
            if (splines == null) return double.NaN; // Если сплайны ещё не построены - возвращаем NaN

            int n = splines.Length;
            Spline s;

            if (x <= splines[0].x) // Если x меньше точки сетки x[0] - пользуемся первым эл-тов массива
                s = splines[0];

            else if (x >= splines[n - 1].x) // Если x больше точки сетки x[n - 1] - пользуемся последним эл-том массива
                s = splines[n - 1];

            else // Иначе x лежит между граничными точками сетки - производим бинарный поиск нужного эл-та массива
            {
                int i = 0;
                int j = n - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (x <= splines[k].x)
                        j = k;
                    else
                        i = k;
                }
                s = splines[j];
            }

            double dx = x - s.x;
            return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;// Вычисляем значение сплайна в заданной точке по схеме Горнера
        }
        bool check = false;
        private void checkBox1_Click(object sender, EventArgs e)
        {
            check = (bool)checkBox1.Checked;
        }
    }
}
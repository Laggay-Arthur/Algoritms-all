using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Draw_Grafic();
        }/// <summary> Структура для хранения пределов </summary>
        struct p
        { public double a, b; }

        List<p> k;
        void Draw_Grafic()
        {   //Отрисовка графика + Определение отрезков (a,b) где есть корни 
            double last_func = 0,//Последня посчитанная функция
                   cur_func = 0; //Текущая посчитанная функция
            k = new List<p>();
            chart1.Series[0].Points.Clear();
            double h = (b - a) / 100;
            for (double i = a; i < b; i += h)
            {
                cur_func = func(i);
                chart1.Series[0].Points.AddXY(i, cur_func);

                if (cur_func > 0 && last_func < 0 || cur_func < 0 && last_func > 0)//Проверяем что функция сменила знак
                    k.Add(new p { a = i - h * 2, b = i + h * 2 });

                last_func = cur_func;
            }
        }

        double c;                  //Середина отрезка
        const double a = -2,       //Нижний предел
                     b = 2,        //Верхний предел
                     eps = 0.00001;//Погрешность

        private void Newton_Click(object sender, EventArgs e)
        {   //Запускаем метод Ньютона(касательных)
            comboBox2.Items.Clear();
            double x = 0,//Начальное приближение
            xi = 0;      //Следущее приближение

            foreach (p d in k)
            {// Считаем точку ответа для каждого отрезка
                MessageBox.Show(d.a.ToString() + " : " +d.b.ToString());
                x = xi = d.b;

                while (true)
                {
                    xi = x - (func(x) / func1(x));                   //Считаем следущее приближение
                    if (Math.Abs(xi - x) < eps) break; x = xi;
                }

                chart1.Series[2].Points.AddXY(x, func(x));//Ставим точку в месте приближения
                comboBox2.Items.Add(xi);//Добавляем точку ответа в общий список
            }
            comboBox2.SelectedIndex = 0;
        }

        double func1(double x)
        {
            //return Math.Pow(Math.E, x) + 2 * x;//Вариант 7
            //return x * Math.Cos(x);//Вариант 31
            return 1 - Math.Cos(2 * x);//Вариант 12
            return 2 * x + Math.Sin(x);//Вариант 13
            return Math.Pow(2, x) * Math.Log(2) - 4;//Вариант 17
            return Math.Cos(x) - 2 * x;//Вариант 18
            return 2 * x + Math.Cos(x);//Вариант 24
            return 4 * x - 7 * Math.Sin(x);//Вариант 29
            return 4 - 7 * Math.Cos(x);//Вариант 29
        }

        double func(double x)
        {
            //return Math.Pow(Math.E, x) + x * x - 2;//Вариант 7
            //return x * Math.Sin(x) - 1;//Вариант 31
            return x - Math.Sin(2 * x);//Вариант 12
            return x * x - Math.Cos(x);//Вариант 13
            return Math.Pow(2, x) - 4 * x;//Вариант 17
            return 8 * Math.Sin(x) - x * x;//Вариант 18
            return x * x + 4 * Math.Sin(x);//Вариант 24
            return 4 * x - 7 * Math.Sin(x);//Вариант 29
        } /// <summary> Список корней уровнения </summary>
        List<double> points = new List<double>();
        private void Get_Click(object sender, EventArgs e)
        {
            points.Clear();//Очищаем список точек с ответами
            double x = 0;
            double a, b;
            foreach (p d in k)
            {   //Считаем точку ответа для каждого отрезка
                a = d.a;//Задаём начальные условия для a
                b = d.b;//Задаём начальные условия для b
                while (Math.Abs(b - a) >= eps)
                {   //Пока точность не достигнута выполняем поиск ответа
                    c = (a + b) / 2;
                    if ((func(b) * func(c)) <= 0)
                        a = c;//Смещаем левую границу вправо
                    else
                        b = c;//Смещаем правую границу влево
                }
                x = (a + b) / 2;
                points.Add(x);//Добавляем точку ответа в общий список
                chart1.Series[1].Points.AddXY(x, func(x));//Ставим точку в месте ответа   
            }
            label1.Text = "Корней: " + k.Count;
            comboBox1.Items.Clear();
            foreach (double value in points)//Выводим список всех корней в comboBox
                comboBox1.Items.Add(value);
            comboBox1.SelectedIndex = 0;
        }
    }
}
using System;
using System.Windows.Forms;


namespace graph
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        Graphic gh;

        Simpson sm;
        Monte_Carlo mc;

        int n,         //число испытаний
            N,         //число бросков
            min_Hop,   //миниманье число разбиений
            max_Hop;   //максимально число разбиений
        double a,      //нижний  предел интегрирования
               b,      //верхний предел интегрирования
               epsilon;//погрешность
        bool type = true;//true - Монте-Карло,false - Симпсон
        private bool Data_get()//Считываем входные данные
        {
            //Парсим пределы интегрирования
            if (!double.TryParse(downLimit.Text.Replace('.', ','), out a) || !double.TryParse(upLimit.Text.Replace('.', ','), out b))
                return true;
            if (a > b) return true;
            if (tabControl1.SelectedIndex == 0)//Monet
            {//Парсим число бросков и экспериментов
                type = true;
                if (!int.TryParse(countDots.Text, out N) || !int.TryParse(timesExp.Text, out n))
                    return true;
            }
            else//Simpson
            {//Парсим погрешность и число разбиений
                type = false;
                if (!double.TryParse(epsilonInput.Text.Replace('.', ','), out epsilon) || !int.TryParse(CountHop_min.Text, out min_Hop) || !int.TryParse(CountHop_max.Text, out max_Hop))
                    return true;
            }

            if (type)// Монте-Карло
            { if (N < 1 || n < 1) return true; }
            else// Симпсон
                if (epsilon <= 0 || min_Hop > max_Hop) return true;
            return false;
        }

        private void Res_Click(object sender, EventArgs e)
        {
            if (Data_get())//Считываем входные данные
            { MessageBox.Show("Ошибка в входных данных"); return; }

            if (gh == null || gh.IsDisposed)//Показываем график
            { gh = new Graphic() { Owner = this }; gh.Show(); }
            gh.Draw(a, b);

            if (tabControl1.SelectedIndex == 0)
            {// Монте-Карло
                mc = new Monte_Carlo(a, b, N, n, gh.GetMin, gh.GetMax);
                label6.Text = mc.GetS.ToString(); ////Выводим данные для Монте-Карло
                label7.Text = mc.GetEpsilon.ToString();
            }
            else
            {//Симпсон + адаптивность
                sm = new Simpson(a, b, epsilon, min_Hop, max_Hop); //Запускаем обычного Симпсона

                ////Выводим данные для обычного Симпсона
                label9.Text = sm.GetS.ToString();
                label11.Text = sm.GetEpsilon.ToString();

                //Запускаем адаптивного Симпсона
                sm.SimpsonAdaptive();

                ////Выводим данные для адаптивного Симпсона
                label17.Text = sm.GetS.ToString();
                label15.Text = sm.GetEpsilon.ToString();
            }
        }

        public double Function(double x)
        {
            //return Math.Pow(Math.Sin(x), 0.4) * Math.Sin(0.4 * x);//Вариант 2 ++
            //return Math.Sqrt(Math.Sin(x)) * Math.Cos(0.5 * x);//Вариант 3 ++
            //return 1 / Math.Pow((0.5 * Math.Sin(x) + 3 * Math.Cos(x)), 2);//Вариант 5 ++
            return Math.Pow(Math.Sin(x), 2) / (9 + 0.3 * Math.Cos(x));//Вариант 8 ++
            //return Math.Pow(Math.Sin(x), 2) / (13 - 12 * Math.Cos(x));//Вариант 11 ++
        }
    }
}
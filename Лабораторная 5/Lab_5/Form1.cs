using System;
using System.Windows.Forms;


namespace Lab_5
{
    public partial class Form1 : Form
    {
        Furie fr = new Furie();
        public Form1() => InitializeComponent();
        int hop;    //Число разбиений
        double a, b;//Нижний и верхний пределы интегрирования
        bool GetData()
        {// Парсим входные данные(Нижний и верхний пределы + Число разбиений)
            if (!double.TryParse(downLimit.Text.Replace('.', ','), out a) || !double.TryParse(upLimit.Text.Replace('.', ','), out b) || !int.TryParse(couthop.Text, out hop)) return true; return false;
        }

        void Counting_Click(object sender, EventArgs e)
        {
            if (GetData()) return;//Парсим данные
            if (hop == 0) return;
            chart1.Series[0].Points.Clear();//Очищаем график

            foreach (DPoint point in fr.Get(a, b, hop, MainFunc))//Запускаем Фурье и выводим точки на холст
                chart1.Series[0].Points.AddXY(point.x, point.y);
        }

        private void Graph_Click(object sender, EventArgs e)
        {
            if (GetData()) return;//Парсим данные
            chart1.Series[1].Points.Clear();

            for (double i = a; i < b; i += 0.1 / hop)
                chart1.Series[1].Points.AddXY(i, MainFunc(i));
        }

        double MainFunc(double x)//Функции для Фурье
        {
            //return Math.Tan(x);
            return Math.Sign(Math.Sin(x));
            return -Math.Atan(1 / Math.Tan(x));
        }
    }
}
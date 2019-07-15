using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;


namespace Lab_7
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1() => InitializeComponent();
        int city_count = 0;//Число городов
        List<int> path_mas = new List<int>(),
                  list_city = new List<int>();
        List<Point> points = new List<Point>();
        Random rand = new Random();
        void Draw_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out city_count) && city_count > 2)
            {   /* *** Отрисовка городов *** */
                Pen point_pen = new Pen(Color.Red, 10); Font lfont = new Font("Arial", 14);//Задаём цвет, шрифт и размер точки
                points.Clear(); path_mas.Clear(); list_city.Clear(); listBox1.Items.Clear();
                Graphics g = pictureBox1.CreateGraphics(); g.Clear(Color.White);
                for (int i = 0; i < city_count; i++)
                {// Отрисовка точек в случайном месте + добавление их в общий список городов
                    points.Add(new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)));
                    g.DrawEllipse(point_pen, points[i].X, points[i].Y, 2, 2);
                    g.DrawString((i + 1).ToString(), lfont, Brushes.Black, points[i].X, points[i].Y);
                    list_city.Add(i);
                }


                /* *** Поиск кратчайшего пути между городами *** */
                int k = 0, k1, n = city_count - 1;
                double max_len, len = 0;//Расстояние между двумя городами 
                List<double> mat_d = new List<double>();//Хранит расстояние до каждого города(ki)
                while (n-- > 0)
                {
                    max_len = k1 = 0;
                    list_city.Remove(k);
                    while (k1 < list_city.Count)
                    {// Считаем расстояние между всеми городами
                        if ((len = Math.Sqrt(Math.Pow((points[k1].X - points[k].X), 2) + Math.Pow((points[k1].Y - points[k].Y), 2))) > 0) mat_d.Add(len); k1++;
                    }
                    max_len = mat_d.Min();//Расстояние до самого дальнего города
                    k = list_city.ElementAt(index: mat_d.IndexOf(max_len));
                    path_mas.Add(k);
                    listBox1.Items.Add(k + 1);
                    mat_d.Clear();
                }
                path_mas.Insert(0, 0); listBox1.Items.Insert(0, 1); listBox1.Items.Add(1);


                /* *** Отрисовка путей рандомным цветом *** */
                Point p(int i) => new Point(points[path_mas.ElementAt(i)].X, points[path_mas.ElementAt(i)].Y);
                for (int i = 0; i + 1 < path_mas.Count; i++)
                    g.DrawLine(pen(), p(i), p(i + 1));
                Pen pen() => new Pen(Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), 2);

                g.DrawLine(pen(), p(path_mas.Count - 1), p(0));//Соединяем первый и последний город
            }
        }
    }
}
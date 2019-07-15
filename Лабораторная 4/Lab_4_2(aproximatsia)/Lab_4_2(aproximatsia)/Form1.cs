using System;
using System.Drawing;
using System.Windows.Forms;


namespace Lab_4_2_aproximatsia_
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        void Draw_Click(object sender, EventArgs e)
        {
            DrawPoints();//Рисуем точки

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush LineNewton = new SolidBrush(Color.Black);//Задаём цвет для линии
            for (float i = -10; i <= 10; i += 0.001f)//Отрисовка апроксимации точек
                g.FillRectangle(LineNewton, ChangeCoordinates(i, 0), ChangeCoordinates(Lagrange(i), 1), 1, 1);
        }
        int ChangeCoordinates(float a, int isY)
        { return (isY == 1) ? (int)(yc - a * 30) : (int)(xc + a * 30); }
        ////Вариант 1
        /// <summary>
        /// Координаты точек
        /// </summary>
        //float[,] points = { { 1, 1.1f }, { 2, 1.4f }, { 3, 1.6f }, { 4, 1.7f }, { 5, 1.9f } };
        ////Вариант 12
        float[,] points = { { 1, 5.1f }, { 2, 4.4f }, { 3, 3.2f }, { 4, 2.7f }, { 5, 2.55f } };
        //Вариант 14
        //float[,] points = { { 1, 3 }, { 2, 3.5f }, { 3, 3.67f }, { 4, 3.75f }, { 5, 3.8f } };

        int xc = 100, yc = 300;//Нужно для правильного пересчёта координат
        /// <summary>
        /// Возвращат значение x для точки с индексом i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private float px(int i) => points[i, 0];
        /// <summary>
        /// Возвращат значение y для точки с индексом i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private float py(int i) => points[i, 1];

        float Lagrange(float x)
        {
            float res = 0f, s1, s2;
            for (int i = 0; i < len; i++)
            {
                s1 = 1f; s2 = 1f;
                for (int j = 0; j < len; j++)
                    if (i != j)
                    {
                        s1 *= x - px(j);
                        s2 *= px(i) - px(j);
                    }
                res += py(i) * (s1 / s2);
            }
            return res;
        }
        Font drawFont = new Font("Arial", 8);//Задаём шрифт для координат
        int len = 0;//Длина массива с точками
        void DrawPoints()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);//Очищаем холст

            SolidBrush pointBrush = new SolidBrush(Color.Red);     //Задаём цвет точек
            SolidBrush drawPointBrush = new SolidBrush(Color.Gray);//Задаём цвет текста
            len = points.Length / 2;
            for (int i = 0; i < len; i++)
            {
                g.FillEllipse(pointBrush, xc + px(i) * 30 - 2, yc - py(i) * 30 - 2, 4, 4);
                String drawString = $"({ px(i)};{ py(i)})";
                PointF drawPoint = new PointF(xc + px(i) * 30, yc - py(i) * 30);//Задаём координаты точки с текстом
                g.DrawString(drawString, drawFont, drawPointBrush, drawPoint);
            }
        }
    }
}
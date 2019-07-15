using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace graph
{
    public partial class Graphic : Form
    {
        Form1 mw;
        public Graphic() => InitializeComponent();
        public void Draw(double a, double b)
        {   //Очищаем график
            chart.Series.Clear();
            chart.Legends.Clear();

            chart.Series.Add(new Series()
            {
                Color = Color.FromArgb(0, 0, 0),
                ChartType = SeriesChartType.SplineRange//чтобы ресовать линиями
            });

            double x = a;
            while (x < b)
            {
                chart.Series[0].Points.AddXY(x, mw.Function(x));
                x += 0.01;
            }
        }

        public double GetMin//Находим точку с минимальной высотой
        => chart.Series[0].Points.FindMinByValue().YValues[0];
        public double GetMax//Находим точку с максимальной высотой
        => chart.Series[0].Points.FindMaxByValue().YValues[0];
    }
}
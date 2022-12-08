using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PhasePortrait
{
    public partial class Form1 : Form
    {
        // Получение значения функции
        private decimal GetY2(decimal y) => y + 0.1m * (-8m);

        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].ChartType = SeriesChartType.Point;  // Тип графика (точечный)

            decimal h = 0.1m;  // Шаг
            decimal x = 1m;  // x0
            decimal y = 1m;  // y0

            for (int i = 0; i < 100; i++)
            {
                x += h;
                y += h * GetY2(y);
                File.AppendAllText("file.txt", $"{x} {y}\n");
            }
        }

        // Добавление точки на график
        private void AddPoint(decimal x, decimal y) => chart1.Series[0].Points.AddXY(x, y);
    }
}

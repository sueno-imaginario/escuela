using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ������ ������� ���������
        private int[] xValues = { 10, 30, 50, 70, 90 };
        private int[] yValues = { 20, 40, 10, 60, 30 };

        public Form1()
        {
            InitializeComponent();
            // ������������� �� ������� Paint
            this.Paint += Form1_Paint;
            this.Resize += (s, e) => this.Invalidate(); // ����������� ��� ��������� �������
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // ������ �������
            int margin = 40;
            int width = this.ClientSize.Width - 2 * margin;
            int height = this.ClientSize.Height - 2 * margin;

            if (xValues.Length == 0 || yValues.Length == 0 || xValues.Length != yValues.Length)
                return;

            // ������� ����������� � ������������ �������� ��� ���������������
            int xMin = xValues[0], xMax = xValues[0];
            int yMin = yValues[0], yMax = yValues[0];
            foreach (var x in xValues)
            {
                if (x < xMin) xMin = x;
                if (x > xMax) xMax = x;
            }
            foreach (var y in yValues)
            {
                if (y < yMin) yMin = y;
                if (y > yMax) yMax = y;
            }

            // ������ ���
            g.DrawLine(Pens.Black, margin, margin, margin, margin + height); // Y
            g.DrawLine(Pens.Black, margin, margin + height, margin + width, margin + height); // X

            // ������ ����� �������
            for (int i = 0; i < xValues.Length - 1; i++)
            {
                float x1 = margin + (float)(xValues[i] - xMin) / (xMax - xMin) * width;
                float y1 = margin + height - (float)(yValues[i] - yMin) / (yMax - yMin) * height;

                float x2 = margin + (float)(xValues[i + 1] - xMin) / (xMax - xMin) * width;
                float y2 = margin + height - (float)(yValues[i + 1] - yMin) / (yMax - yMin) * height;

                g.DrawLine(Pens.Blue, x1, y1, x2, y2);
            }

            // ������ �����
            foreach (var i in Enumerable.Range(0, xValues.Length))
            {
                float x = margin + (float)(xValues[i] - xMin) / (xMax - xMin) * width;
                float y = margin + height - (float)(yValues[i] - yMin) / (yMax - yMin) * height;
                g.FillEllipse(Brushes.Red, x - 3, y - 3, 6, 6);
            }
        }
    }
}

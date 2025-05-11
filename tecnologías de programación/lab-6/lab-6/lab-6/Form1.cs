using System.Windows.Forms;

namespace lab_6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteLogFile();

            try
            {
                //gValues.Items.Clear();
                double x = Convert.ToDouble(x0Value.Text.Replace('.', ','));
                double xn = Convert.ToDouble(xnValue.Text.Replace('.', ','));
                double xstep = Convert.ToDouble(xStepValue.Text.Replace('.', ','));
                double y = Convert.ToDouble(y0Value.Text.Replace('.', ','));
                double yn = Convert.ToDouble(ynValue.Text.Replace('.', ','));
                double ystep = Convert.ToDouble(yStepValue.Text.Replace('.', ','));

                if ((Math.Ceiling((xn - x) / xstep)) == (Math.Ceiling((yn - y) / ystep)))
                {
                    int N = Convert.ToInt32(Math.Ceiling((xn - x) / xstep));
                    double[] arr = G(x, xn, xstep, y, yn, ystep, N);
                    for (int i = 0; i < N; i++)
                        gValues.Items.Add(Math.Round(arr[i], 2));
                    WriteBinaryFiles(arr, x, xn, xstep, y, yn, ystep, N);

                    MessageBox.Show("������� ���������. ������ ��������� � ����� GXXXX.dat");
                }
                else
                {
                    MessageBox.Show("��������� 'x' � 'y' �� ���������");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("�������� ������� ������.\n�������� ����� �������� '.' �� ','");
            }
            catch (OverflowException)
            {
                MessageBox.Show("������� ������� ����� �� ����� ��� ������.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static double[] G(double x, double xn, double xstep, double y, double yn, double ystep, int N)
        {
            double[] arr = new double[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = Math.Exp(y / Math.Log(x));
                x += xstep;
                y += ystep;
            }
            return arr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gValues.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x0Value.Text = "1";
            xnValue.Text = "10";
            xStepValue.Text = "0,1";
            y0Value.Text = "1";
            ynValue.Text = "10";
            yStepValue.Text = "0,1";
        }

        private void WriteLogFile()
        {
            //string logFilePath = "myProgram.log";
            string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "myProgram.log");

            using (StreamWriter writer = new StreamWriter(logFilePath))
            {
                writer.WriteLine("���������: lab_6 (������� 12)");
                writer.WriteLine($"���� � ����� ������: {DateTime.Now}");
                writer.WriteLine("�������������� �������: G(x, y) = exp(y / ln(x))");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int fileNumber = (int)nudFileNumber.Value; 
                string fileName = $"G{fileNumber:D4}.dat";

                if (!File.Exists(fileName))
                {
                    MessageBox.Show($"���� {fileName} �� ������!");
                    return;
                }

                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    double x = reader.ReadDouble();
                    double y = reader.ReadDouble();
                    double result = reader.ReadDouble();

                    MessageBox.Show($"������ �� ����� {fileName}:\nX = {x}\nY = {y}\nG(x,y) = {result:F3}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������ �����: {ex.Message}");
            }
        }
        private void WriteBinaryFiles(double[] results, double x0, double xn, double xstep,
                                    double y0, double yn, double ystep, int N)
        {
            for (int i = 0; i < N; i++)
            {
                string fileName = $"G{(i + 1):D4}.dat";
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    double currentX = x0 + i * xstep;
                    double currentY = y0 + i * ystep;

                    writer.Write(currentX);  // ���������� x
                    writer.Write(currentY);  // ���������� y
                    writer.Write(results[i]); // ���������� ��������� G(x,y)
                }
            }
        }

    }
}

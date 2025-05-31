using static System.Runtime.InteropServices.JavaScript.JSType;

namespace script
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowValue_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(enterNumberValue.Text.Replace('.', ','));
                MessageBox.Show("�� �����: " + number.ToString(), "�����:");
            }
            catch (FormatException) 
            {
                MessageBox.Show("�� ����� �� �����.\n������� ����� ����� ��� ����� � ��������� ������");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������:");
            }

        }
    }
}

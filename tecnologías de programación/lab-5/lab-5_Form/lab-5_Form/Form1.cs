namespace lab_5_Form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void setDefaultValue_Click(object sender, EventArgs e)
        {
            value.Text = "0";
            decimal UserValue = Convert.ToDecimal(value.Text);
            //MessageBox.Show("The value of variable is: " + UserValue);
        }

        private void setValue_Click(object sender, EventArgs e)
        {
            try
            {
                decimal UserValue = Convert.ToDecimal(value.Text.Replace('.', ','));
                MessageBox.Show("The value of variable is: " + UserValue);
            }
            catch(FormatException)
            {
                MessageBox.Show("�� ����� �� �����." + "\n����������� ���������� ������ �������� ��� ���������� �������� �� ���������");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n����������� ���������� ������ �������� ��� ���������� �������� �� ���������");
            }
        }
    }
}

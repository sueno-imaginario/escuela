namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private Thread workerThread;
        private volatile bool isPaused = false;
        private volatile bool isRunning = false;
        private int iteration = 0;


        public MainForm()
        {
            InitializeComponent();
            cmbPriority.SelectedIndex = 1;
        }

        private void WorkerMethod()
        {
            while (isRunning)
            {
                if (!isPaused)
                {
                    iteration++;
                    Invoke(new Action(() => lblIteration.Text = iteration.ToString()));
                    Thread.Sleep(1000); // �������� � 1 �������
                }
                else
                {
                    Thread.Sleep(100); // ��������, ����� ����� �� �����
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                workerThread = new Thread(WorkerMethod);
                workerThread.Start();
            }
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            btnPauseResume.Text = isPaused ? "�����������" : "�����";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
            if (workerThread != null && workerThread.IsAlive)
            {
                workerThread.Join(); // �������� ���������� ������
            }
            lblIteration.Text = "0"; // ����� ��������
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (workerThread != null && workerThread.IsAlive)
            {
                switch (cmbPriority.SelectedItem.ToString())
                {
                    case "������":
                        workerThread.Priority = ThreadPriority.Lowest;
                        break;
                    case "�������":
                        workerThread.Priority = ThreadPriority.Normal;
                        break;
                    case "�������":
                        workerThread.Priority = ThreadPriority.AboveNormal;
                        break;
                }
            }
        }

    }
}

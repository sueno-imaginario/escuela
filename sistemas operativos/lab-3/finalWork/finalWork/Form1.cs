using System.Diagnostics;
using System.IO.Packaging;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace finalWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CreateFile();
        }

        private void showInfo_Click(object sender, EventArgs e)
        {
            FileInfo();
            DeleteFile();
        }

        void CreateFile(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log", string newPath = "C:\\Users\\que mienten\\Documents\\waste\\drives.txt")
        {
            pathValue.Text = "C:\\Users\\que mienten\\Documents\\waste\\drives.log";
            File.Create(path).Close();
            File.Copy(path, newPath, overwrite: true);
            //File.Move(path, newPath);
            //File.Move(path, newPath);
        }

        public void FileInfo(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log")
        {
            infoValue.Clear();

            if (!File.Exists(path))
            {
                MessageBox.Show("���� �� ������.");
                infoValue.Text = "���� �� ������.";
                return;
            }

            FileInfo fileInfo = new FileInfo(path);

            infoValue.Multiline = true;
            infoValue.Text = "��� �����: " + fileInfo.Name +
                             "������ ����: " + fileInfo.FullName + "\n" +
                             "����������: " + fileInfo.Extension + "\n" +
                             "������: " + fileInfo.Length + " ����" + "\n" +
                             "������: " + fileInfo.CreationTime + "\n" +
                             "������: " + fileInfo.LastWriteTime + "\n" +
                             "��������� ������: " + fileInfo.LastAccessTime + "\n" +
                             "��������: " + fileInfo.Attributes + "\n" +
                             "������ ��� ������: " + fileInfo.IsReadOnly + "\n" +
                             "������������ ����������: " + fileInfo.DirectoryName + "\n" +
                             "����� �������� UTC: " + fileInfo.CreationTimeUtc + "\n" +
                             "������ UTC: " + fileInfo.LastWriteTimeUtc + "\n" +
                             "������ UTC: " + fileInfo.LastAccessTimeUtc;
        }

        public void DeleteFile(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log", string newPath = "C:\\Users\\que mienten\\Documents\\waste\\drives.txt")
        {
            File.Delete(path);
            File.Delete(newPath);
        }



    }
}

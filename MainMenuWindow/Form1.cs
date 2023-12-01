using System.Windows.Forms;

namespace MainMenuWindow
{
    public partial class Form1 : Form
    {
        private ToolTip tooltipSelect, tooltipCheck;
        public Form1()
        {
            InitializeComponent();
            tooltipSelect = new ToolTip();
            tooltipSelect.SetToolTip(SelectPicButton, "ѡ������Ҫ��������ͼƬ");
            tooltipCheck = new ToolTip();
            tooltipCheck.SetToolTip(StartCheckButton, "��ʼ������ͼƬ�ļ�飬����ȱ������ʾ���·�");
        }

        private void SelectPicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ȡѡ���ͼƬ·��
                string imagePath = openFileDialog.FileName;

                // ����ͼƬ��չʾ��ͼƬ����
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
            }
        }

        private void StartCheckButton_Click(object sender, EventArgs e)
        {
            /* ���ú�������/ֱ�Ӵ���ͼƬ */
            int count = checkPicture(pictureBox1.Image);
            MessageBox.Show("�����ɣ�", "��ʾ");
            CountLabel.Text = count.ToString();
        }

        private int checkPicture(Image img)
        {

            int count = 54;
            /* ��img���д������ 
                count�Ǽ������������ı�����
                ����ģ�ͷ���ͼƬ
             
             */

            return count;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "�����ּ��ʶ��������ϵ�ȱ�ݲ����������������ʹ�÷���Ϊѡ����Ҫ����ͼƬ��Ȼ������ʼ��鼴��"
                , "���ڱ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
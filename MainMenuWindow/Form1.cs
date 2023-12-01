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
            tooltipSelect.SetToolTip(SelectPicButton, "选择您需要检查的螺纹图片");
            tooltipCheck = new ToolTip();
            tooltipCheck.SetToolTip(StartCheckButton, "开始对螺纹图片的检查，并将缺陷数显示在下方");
        }

        private void SelectPicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取选择的图片路径
                string imagePath = openFileDialog.FileName;

                // 加载图片并展示在图片框中
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
            }
        }

        private void StartCheckButton_Click(object sender, EventArgs e)
        {
            /* 调用函数处理/直接处理图片 */
            int count = checkPicture(pictureBox1.Image);
            MessageBox.Show("检查完成！", "提示");
            CountLabel.Text = count.ToString();
        }

        private int checkPicture(Image img)
        {

            int count = 54;
            /* 对img进行处理分析 
                count是计算损伤数量的变量。
                调用模型分析图片
             
             */

            return count;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "本软件旨在识别出螺纹上的缺陷并标出（？），具体使用方法为选择需要检查的图片，然后点击开始检查即可"
                , "关于本软件", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
using System.Drawing.Imaging;
using System.Windows.Forms;
using App;
using Microsoft.VisualBasic.ApplicationServices;
using MLModel1_ConsoleApp1;

namespace MainMenuWindow
{
    public partial class Form1 : Form
    {
        public static float Threshold { get; set; } = 0.4f;
        public static float PassRate { get; set; } = 95.0f;
        private ToolTip tooltipSelect, tooltipCheck;
        string imagePath = string.Empty;
        string processPath = AppDomain.CurrentDomain.BaseDirectory;
        string slicedPath, enhancedPath, combinedPath, outSitePath;
        private float scaleFactor = 1.0f;
        private Point previousMouseLocation;
        Image originalImage;
        private List<DefectInfo> defectList = new List<DefectInfo>();

        public Form1()
        {
            InitializeComponent();
            tooltipSelect = new ToolTip();
            tooltipSelect.SetToolTip(SelectPicButton, "选择您需要检查的螺纹图片");
            tooltipCheck = new ToolTip();
            tooltipCheck.SetToolTip(StartCheckButton, "开始对螺纹图片的检查，并将缺陷数显示在下方");
            for (int i = 0; i < 5; i++)
            {
                processPath = Path.GetDirectoryName(processPath);
            }
            processPath = Path.Combine(processPath, "ProcessedImages");
            slicedPath = Path.Combine(processPath, "sliced") + @"\";
            enhancedPath = Path.Combine(processPath, "enhanced") + @"\";
            combinedPath = Path.Combine(processPath, "combined") + @"\";
            outSitePath = Path.Combine(processPath, "缺陷位置信息.txt");
            initializeDir(processPath);
            initializeDir(slicedPath);
            initializeDir(enhancedPath);
            initializeDir(combinedPath);
        }

        private void initializeDir(string dirpath)
        {
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            else
            {
                string[] oldimgs = Directory.GetFiles(dirpath);
                if (oldimgs.Length > 0)
                {
                    foreach (string img in oldimgs)
                    {
                        File.Delete(img);
                    }
                }
            }
        }

        private void SelectPicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取选择的图片路径
                imagePath = openFileDialog.FileName;

                // 加载图片并展示在图片框中
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
                originalImage = image;
            }
        }

        private async void StartCheckButton_Click(object sender, EventArgs e)
        {
            /* 调用函数处理/直接处理图片 */
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("未选择图片！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            progressBarofCheck.Value = 0;
            StartCheckButton.Enabled = false;
            SelectPicButton.Enabled = false;
            setBtn.Enabled = false;
            int count = await checkPicture(imagePath);
            StartCheckButton.Enabled = true;
            SelectPicButton.Enabled = true;
            setBtn.Enabled = true;
            CountLabel.Text = count.ToString();
            MessageBox.Show("检查完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void drawBorder(string imgpath, int serialNumber)
        {
            imgpath = imgpath.Replace(@"\", @"\\");
            using (Bitmap img = new Bitmap(imgpath))
            {
                Bitmap borderedImg = new Bitmap(img.Width, img.Height);
                using (Graphics graphics = Graphics.FromImage(borderedImg))
                {
                    graphics.DrawImage(img, Point.Empty);
                    using (Pen pen = new Pen(Color.Red, 4))
                    {
                        graphics.DrawRectangle(pen, new Rectangle(0, 0, img.Width - 1, img.Height - 1));
                    }
                }

                // 存储缺陷信息
                DefectInfo defectInfo = new DefectInfo
                {
                    SerialNumber = serialNumber,
                    XCoordinate = (serialNumber % 5) * 256, // 假设256是图像大小
                    YCoordinate = (serialNumber / 5) * 256
                };
                defectList.Add(defectInfo);



                // 释放原始图片资源
                img.Dispose();
                borderedImg.Save(imgpath);
            }
        }


        private async Task<int> checkPicture(string originalPath)
        {
            initializeDir(slicedPath);
            initializeDir(enhancedPath);
            initializeDir(combinedPath);
            int count = 0;
            await Task.Run(() =>
           {
               using (UsePy py = new())
               {
                   //处理图片
                   //UsePy py = new UsePy();
                   py.Crop(originalPath, slicedPath, 256);
                   py.Enhan(slicedPath, enhancedPath);
                   //获取增强的图片地址
                   string[] ipaths = Directory.GetFiles(enhancedPath, "*.jpg");
                   int m = progressBarofCheck.Maximum = ipaths.Length;
                   int prog = 0;
                   foreach (string ipath in ipaths)
                   {
                       MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                       {
                           ImageSource = File.ReadAllBytes(ipath),
                       };
                       var predictionResult = MLModel1.Predict(sampleData);
                       var WScore = predictionResult.Score[0];
                       var Rscore = predictionResult.Score[1];
                       if (WScore >= Threshold)
                       {
                           //暂时取0.4作为阈值
                           count++;
                           //获取对应的裁剪后图片位置并画上框
                           string imgname = Path.GetFileNameWithoutExtension(ipath);
                           string[] matchimg = Directory.GetFiles(slicedPath, imgname + ".bmp", SearchOption.TopDirectoryOnly);
                           if (matchimg.Length != 0)
                           {
                               drawBorder(matchimg[0],count);
                           }
                       }
                       prog++;
                       float t = 100.0f * prog / m;
                       progressBarofCheck.Invoke((Action)delegate { progressBarofCheck.Value = prog; });
                       progLabel.Invoke((Action)delegate { progLabel.Text = t.ToString("0.00") + "%"; });
                   }
                   //将处理后的裁剪图片拼接起来
                   string filepath = py.Com(slicedPath, combinedPath);
                   Image image = Image.FromFile(filepath);
                   pictureBox1.Image = image;
                   originalImage = image;
               }
           });
            float passRatio = 100.0f * (progressBarofCheck.Maximum - count) / progressBarofCheck.Maximum;
            ratioLabel.Text = passRatio.ToString("0.00") + "%";
            if (passRatio < PassRate)
            {
                ratioLabel.ForeColor = Color.Red;
                result_label.ForeColor = Color.Red;
                result_label.Text = "不合格!";
            }
            else
            {
                ratioLabel.ForeColor = Color.Green;
                result_label.ForeColor = Color.Green;
                result_label.Text = "合格!";
            }
            return count;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "本软件旨在识别出零件上的缺陷并标出，具体使用方法为选择需要检查的图片，然后点击开始检查即可，用户可自定义设置模型阈值和标准合格率"
                , "关于本软件", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyImageTransform()
        {
            // 应用图片的缩放变换
            int newWidth = (int)(originalImage.Width * scaleFactor);
            int newHeight = (int)(originalImage.Height * scaleFactor);
            Image scaledImage = new Bitmap(originalImage, newWidth, newHeight);
            pictureBox1.Image = scaledImage;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            scaleFactor *= 1.2f;
            ApplyImageTransform();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            scaleFactor /= 1.2f;
            ApplyImageTransform();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            previousMouseLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 拖动图片
                int deltaX = e.Location.X - previousMouseLocation.X;
                int deltaY = e.Location.Y - previousMouseLocation.Y;

                pictureBox1.Left += deltaX;
                pictureBox1.Top += deltaY;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                return;
            }
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Dock = DockStyle.None;
        }

        private void originalBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Dock = DockStyle.None;
            btnZoomIn.Visible = true;
            btnZoomOut.Visible = true;
            overviewBtn.Visible = true;
            originalBtn.Visible = false;
        }

        private void overviewBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            btnZoomIn.Visible = false;
            btnZoomOut.Visible = false;
            overviewBtn.Visible = false;
            originalBtn.Visible = true;
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            using (SettingsDialog settingsDialog = new SettingsDialog())
            {
                settingsDialog.Threshold = Threshold;
                settingsDialog.PassRate = PassRate;
                DialogResult result = settingsDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // 用户点击了保存按钮
                    Threshold = settingsDialog.Threshold;
                    PassRate = settingsDialog.PassRate;
                    hold_label.Text = "当前模型阈值：" + Threshold.ToString();
                    rateLabel.Text = "当前标准合格率：" + PassRate.ToString() + "%";
                }
            }

        }

        private void outBtn_Click(object sender, EventArgs e)
        {
            ExportDefectInformation();
            MessageBox.Show("导出成功！导出文本在" + outSitePath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public class DefectInfo
        {
            public int SerialNumber { get; set; }
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
        }

        // 实现一个方法以将缺陷信息导出到文本文件
        private void ExportDefectInformation()
        {
            
            using (StreamWriter sw = new StreamWriter(outSitePath))
            {
                for (int i = 0; i < defectList.Count; i++)
                {
                    DefectInfo defect = defectList[i];
                    sw.WriteLine($"({defect.SerialNumber}, {defect.XCoordinate}, {defect.YCoordinate})");
                }
            }
        }

    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenuWindow
{
    public partial class SettingsDialog : Form
    {
        public float Threshold { get; set; }
        public float PassRate { get; set; }

        public SettingsDialog()
        {

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 获取用户输入的阈值和标准合格率
            if (float.TryParse(txtThreshold.Text, out float threshold) &&
                float.TryParse(txtPassRate.Text, out float passRate))
            {
                // 验证阈值和合格率的范围
                if (threshold >= 0 && threshold <= 1 && passRate >= 0 && passRate <= 100)
                {
                    Threshold = threshold;
                    PassRate = passRate;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("请输入有效的阈值（0 到 1 之间）和合格率（0 到 100 之间）。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请输入有效的数字。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
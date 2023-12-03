namespace MainMenuWindow
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SelectPicButton = new Button();
            StartCheckButton = new Button();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            progLabel = new Label();
            progressBarofCheck = new ProgressBar();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            originalBtn = new Button();
            overviewBtn = new Button();
            ratioLabel = new Label();
            label4 = new Label();
            btnZoomOut = new Button();
            label2 = new Label();
            CountLabel = new Label();
            btnZoomIn = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SelectPicButton
            // 
            SelectPicButton.Location = new Point(3, 69);
            SelectPicButton.Name = "SelectPicButton";
            SelectPicButton.Size = new Size(75, 23);
            SelectPicButton.TabIndex = 0;
            SelectPicButton.Text = "选择图片";
            SelectPicButton.UseVisualStyleBackColor = true;
            SelectPicButton.Click += SelectPicButton_Click;
            // 
            // StartCheckButton
            // 
            StartCheckButton.Location = new Point(3, 109);
            StartCheckButton.Name = "StartCheckButton";
            StartCheckButton.Size = new Size(75, 23);
            StartCheckButton.TabIndex = 1;
            StartCheckButton.Text = "开始检查";
            StartCheckButton.UseVisualStyleBackColor = true;
            StartCheckButton.Click += StartCheckButton_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(progLabel);
            splitContainer2.Panel1.Controls.Add(progressBarofCheck);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(SelectPicButton);
            splitContainer2.Panel1.Controls.Add(StartCheckButton);
            splitContainer2.Panel1.Controls.Add(menuStrip1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(originalBtn);
            splitContainer2.Panel2.Controls.Add(overviewBtn);
            splitContainer2.Panel2.Controls.Add(ratioLabel);
            splitContainer2.Panel2.Controls.Add(label4);
            splitContainer2.Panel2.Controls.Add(btnZoomOut);
            splitContainer2.Panel2.Controls.Add(label2);
            splitContainer2.Panel2.Controls.Add(CountLabel);
            splitContainer2.Panel2.Controls.Add(btnZoomIn);
            splitContainer2.Panel2.Controls.Add(label1);
            splitContainer2.Size = new Size(300, 450);
            splitContainer2.SplitterDistance = 225;
            splitContainer2.TabIndex = 6;
            // 
            // progLabel
            // 
            progLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            progLabel.AutoSize = true;
            progLabel.Font = new Font("Microsoft YaHei UI", 12F);
            progLabel.Location = new Point(75, 175);
            progLabel.Name = "progLabel";
            progLabel.Size = new Size(55, 21);
            progLabel.TabIndex = 5;
            progLabel.Text = "0.00%";
            // 
            // progressBarofCheck
            // 
            progressBarofCheck.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBarofCheck.Location = new Point(3, 199);
            progressBarofCheck.Name = "progressBarofCheck";
            progressBarofCheck.Size = new Size(294, 23);
            progressBarofCheck.Step = 1;
            progressBarofCheck.Style = ProgressBarStyle.Continuous;
            progressBarofCheck.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.Location = new Point(3, 175);
            label3.Name = "label3";
            label3.Size = new Size(74, 21);
            label3.TabIndex = 3;
            label3.Text = "当前进度";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(300, 25);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(55, 21);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // originalBtn
            // 
            originalBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            originalBtn.Location = new Point(222, 3);
            originalBtn.Name = "originalBtn";
            originalBtn.Size = new Size(75, 23);
            originalBtn.TabIndex = 10;
            originalBtn.Text = "查看原始";
            originalBtn.UseVisualStyleBackColor = true;
            originalBtn.Click += originalBtn_Click;
            // 
            // overviewBtn
            // 
            overviewBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            overviewBtn.Location = new Point(222, 90);
            overviewBtn.Name = "overviewBtn";
            overviewBtn.Size = new Size(75, 23);
            overviewBtn.TabIndex = 9;
            overviewBtn.Text = "查看缩略";
            overviewBtn.UseVisualStyleBackColor = true;
            overviewBtn.Visible = false;
            overviewBtn.Click += overviewBtn_Click;
            // 
            // ratioLabel
            // 
            ratioLabel.AutoSize = true;
            ratioLabel.Font = new Font("Microsoft YaHei UI", 12F);
            ratioLabel.Location = new Point(75, 72);
            ratioLabel.Name = "ratioLabel";
            ratioLabel.Size = new Size(55, 21);
            ratioLabel.TabIndex = 8;
            ratioLabel.Text = "0.00%";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F);
            label4.Location = new Point(3, 72);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 7;
            label4.Text = "合格率：";
            // 
            // btnZoomOut
            // 
            btnZoomOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnZoomOut.Location = new Point(222, 61);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(75, 23);
            btnZoomOut.TabIndex = 6;
            btnZoomOut.Text = "缩小图片";
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.Visible = false;
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(101, 19);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 4;
            label2.Text = "处缺陷";
            // 
            // CountLabel
            // 
            CountLabel.AutoSize = true;
            CountLabel.Font = new Font("Microsoft YaHei UI", 12F);
            CountLabel.Location = new Point(75, 19);
            CountLabel.Name = "CountLabel";
            CountLabel.Size = new Size(19, 21);
            CountLabel.TabIndex = 5;
            CountLabel.Text = "0";
            // 
            // btnZoomIn
            // 
            btnZoomIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnZoomIn.Location = new Point(222, 32);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(75, 23);
            btnZoomIn.TabIndex = 4;
            btnZoomIn.Text = "放大图片";
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.Visible = false;
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 3;
            label1.Text = "共有：";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(496, 450);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "螺纹缺陷检查";
            SizeChanged += Form1_SizeChanged;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button SelectPicButton;
        private Button StartCheckButton;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label CountLabel;
        private SplitContainer splitContainer2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label3;
        private Button btnZoomOut;
        private Button btnZoomIn;
        private ProgressBar progressBarofCheck;
        private Label progLabel;
        private Label label4;
        private Label ratioLabel;
        private Button originalBtn;
        private Button overviewBtn;
    }
}
namespace MainMenuWindow
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtThreshold = new TextBox();
            txtPassRate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSave = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // txtThreshold
            // 
            txtThreshold.Location = new Point(143, 92);
            txtThreshold.Name = "txtThreshold";
            txtThreshold.Size = new Size(100, 23);
            txtThreshold.TabIndex = 0;
            // 
            // txtPassRate
            // 
            txtPassRate.Location = new Point(143, 177);
            txtPassRate.Name = "txtPassRate";
            txtPassRate.Size = new Size(100, 23);
            txtPassRate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F);
            label1.Location = new Point(84, 94);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 2;
            label1.Text = "阈值";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(36, 179);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 3;
            label2.Text = "标准合格率";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(209, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(74, 295);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // SettingsDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 429);
            Controls.Add(cancelBtn);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassRate);
            Controls.Add(txtThreshold);
            Name = "SettingsDialog";
            Text = "SettingsDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtThreshold;
        private TextBox txtPassRate;
        private Label label1;
        private Label label2;
        private Button btnSave;
        private Button cancelBtn;
    }
}
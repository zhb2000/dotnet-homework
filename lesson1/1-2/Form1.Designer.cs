namespace WinFormHomework
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.operand1TextBox = new System.Windows.Forms.TextBox();
            this.operand2TextBox = new System.Windows.Forms.TextBox();
            this.showResultButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // operand1TextBox
            // 
            this.operand1TextBox.Location = new System.Drawing.Point(105, 80);
            this.operand1TextBox.Name = "operand1TextBox";
            this.operand1TextBox.Size = new System.Drawing.Size(100, 35);
            this.operand1TextBox.TabIndex = 0;
            // 
            // operand2TextBox
            // 
            this.operand2TextBox.Location = new System.Drawing.Point(522, 80);
            this.operand2TextBox.Name = "operand2TextBox";
            this.operand2TextBox.Size = new System.Drawing.Size(100, 35);
            this.operand2TextBox.TabIndex = 1;
            // 
            // showResultButton
            // 
            this.showResultButton.Location = new System.Drawing.Point(285, 303);
            this.showResultButton.Name = "showResultButton";
            this.showResultButton.Size = new System.Drawing.Size(211, 62);
            this.showResultButton.TabIndex = 2;
            this.showResultButton.Text = "show result";
            this.showResultButton.UseVisualStyleBackColor = true;
            this.showResultButton.Click += new System.EventHandler(this.getResultButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.listBox1.Location = new System.Drawing.Point(322, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(110, 76);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.showResultButton);
            this.Controls.Add(this.operand2TextBox);
            this.Controls.Add(this.operand1TextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox operand1TextBox;
        private System.Windows.Forms.TextBox operand2TextBox;
        private System.Windows.Forms.Button showResultButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}


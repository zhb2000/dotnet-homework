namespace CayleyTree
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
            this.generateButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nLael = new System.Windows.Forms.Label();
            this.nTxtBox = new System.Windows.Forms.TextBox();
            this.lengLabel = new System.Windows.Forms.Label();
            this.lengTxtBox = new System.Windows.Forms.TextBox();
            this.per1Label = new System.Windows.Forms.Label();
            this.per1TxtBox = new System.Windows.Forms.TextBox();
            this.per2Label = new System.Windows.Forms.Label();
            this.per2TxtBox = new System.Windows.Forms.TextBox();
            this.th1Label = new System.Windows.Forms.Label();
            this.th1TxtBox = new System.Windows.Forms.TextBox();
            this.th2Label = new System.Windows.Forms.Label();
            this.th2TxtBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generateButton.Location = new System.Drawing.Point(442, 54);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(141, 56);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.drawPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.67488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.32512F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1568, 1175);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // drawPanel
            // 
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(3, 257);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(1562, 915);
            this.drawPanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.nLael);
            this.flowLayoutPanel1.Controls.Add(this.nTxtBox);
            this.flowLayoutPanel1.Controls.Add(this.lengLabel);
            this.flowLayoutPanel1.Controls.Add(this.lengTxtBox);
            this.flowLayoutPanel1.Controls.Add(this.per1Label);
            this.flowLayoutPanel1.Controls.Add(this.per1TxtBox);
            this.flowLayoutPanel1.Controls.Add(this.per2Label);
            this.flowLayoutPanel1.Controls.Add(this.per2TxtBox);
            this.flowLayoutPanel1.Controls.Add(this.th1Label);
            this.flowLayoutPanel1.Controls.Add(this.th1TxtBox);
            this.flowLayoutPanel1.Controls.Add(this.th2Label);
            this.flowLayoutPanel1.Controls.Add(this.th2TxtBox);
            this.flowLayoutPanel1.Controls.Add(this.colorLabel);
            this.flowLayoutPanel1.Controls.Add(this.colorPanel);
            this.flowLayoutPanel1.Controls.Add(this.colorButton);
            this.flowLayoutPanel1.Controls.Add(this.generateButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1562, 248);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // nLael
            // 
            this.nLael.AutoSize = true;
            this.nLael.Location = new System.Drawing.Point(15, 15);
            this.nLael.Margin = new System.Windows.Forms.Padding(5);
            this.nLael.Name = "nLael";
            this.nLael.Size = new System.Drawing.Size(130, 24);
            this.nLael.TabIndex = 2;
            this.nLael.Text = "递归深度：";
            // 
            // nTxtBox
            // 
            this.nTxtBox.Location = new System.Drawing.Point(153, 13);
            this.nTxtBox.Name = "nTxtBox";
            this.nTxtBox.Size = new System.Drawing.Size(100, 35);
            this.nTxtBox.TabIndex = 1;
            // 
            // lengLabel
            // 
            this.lengLabel.AutoSize = true;
            this.lengLabel.Location = new System.Drawing.Point(261, 15);
            this.lengLabel.Margin = new System.Windows.Forms.Padding(5);
            this.lengLabel.Name = "lengLabel";
            this.lengLabel.Size = new System.Drawing.Size(130, 24);
            this.lengLabel.TabIndex = 3;
            this.lengLabel.Text = "主干长度：";
            // 
            // lengTxtBox
            // 
            this.lengTxtBox.Location = new System.Drawing.Point(399, 13);
            this.lengTxtBox.Name = "lengTxtBox";
            this.lengTxtBox.Size = new System.Drawing.Size(100, 35);
            this.lengTxtBox.TabIndex = 4;
            // 
            // per1Label
            // 
            this.per1Label.AutoSize = true;
            this.per1Label.Location = new System.Drawing.Point(507, 15);
            this.per1Label.Margin = new System.Windows.Forms.Padding(5);
            this.per1Label.Name = "per1Label";
            this.per1Label.Size = new System.Drawing.Size(178, 24);
            this.per1Label.TabIndex = 5;
            this.per1Label.Text = "右分支长度比：";
            // 
            // per1TxtBox
            // 
            this.per1TxtBox.Location = new System.Drawing.Point(693, 13);
            this.per1TxtBox.Name = "per1TxtBox";
            this.per1TxtBox.Size = new System.Drawing.Size(100, 35);
            this.per1TxtBox.TabIndex = 6;
            // 
            // per2Label
            // 
            this.per2Label.AutoSize = true;
            this.per2Label.Location = new System.Drawing.Point(801, 15);
            this.per2Label.Margin = new System.Windows.Forms.Padding(5);
            this.per2Label.Name = "per2Label";
            this.per2Label.Size = new System.Drawing.Size(178, 24);
            this.per2Label.TabIndex = 7;
            this.per2Label.Text = "左分支长度比：";
            // 
            // per2TxtBox
            // 
            this.per2TxtBox.Location = new System.Drawing.Point(987, 13);
            this.per2TxtBox.Name = "per2TxtBox";
            this.per2TxtBox.Size = new System.Drawing.Size(100, 35);
            this.per2TxtBox.TabIndex = 8;
            // 
            // th1Label
            // 
            this.th1Label.AutoSize = true;
            this.th1Label.Location = new System.Drawing.Point(1095, 15);
            this.th1Label.Margin = new System.Windows.Forms.Padding(5);
            this.th1Label.Name = "th1Label";
            this.th1Label.Size = new System.Drawing.Size(154, 24);
            this.th1Label.TabIndex = 9;
            this.th1Label.Text = "右分支角度：";
            // 
            // th1TxtBox
            // 
            this.th1TxtBox.Location = new System.Drawing.Point(1257, 13);
            this.th1TxtBox.Name = "th1TxtBox";
            this.th1TxtBox.Size = new System.Drawing.Size(100, 35);
            this.th1TxtBox.TabIndex = 11;
            // 
            // th2Label
            // 
            this.th2Label.AutoSize = true;
            this.th2Label.Location = new System.Drawing.Point(1365, 15);
            this.th2Label.Margin = new System.Windows.Forms.Padding(5);
            this.th2Label.Name = "th2Label";
            this.th2Label.Size = new System.Drawing.Size(154, 24);
            this.th2Label.TabIndex = 10;
            this.th2Label.Text = "左分支角度：";
            // 
            // th2TxtBox
            // 
            this.th2TxtBox.Location = new System.Drawing.Point(13, 54);
            this.th2TxtBox.Name = "th2TxtBox";
            this.th2TxtBox.Size = new System.Drawing.Size(100, 35);
            this.th2TxtBox.TabIndex = 12;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(121, 56);
            this.colorLabel.Margin = new System.Windows.Forms.Padding(5);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(82, 24);
            this.colorLabel.TabIndex = 13;
            this.colorLabel.Text = "颜色：";
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(252, 54);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(184, 56);
            this.colorButton.TabIndex = 15;
            this.colorButton.Text = "Select Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(211, 54);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(35, 35);
            this.colorPanel.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 1175);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Cayley Tree";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label nLael;
        private System.Windows.Forms.TextBox nTxtBox;
        private System.Windows.Forms.Label lengLabel;
        private System.Windows.Forms.TextBox lengTxtBox;
        private System.Windows.Forms.Label per1Label;
        private System.Windows.Forms.TextBox per1TxtBox;
        private System.Windows.Forms.Label per2Label;
        private System.Windows.Forms.TextBox per2TxtBox;
        private System.Windows.Forms.Label th1Label;
        private System.Windows.Forms.TextBox th1TxtBox;
        private System.Windows.Forms.Label th2Label;
        private System.Windows.Forms.TextBox th2TxtBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Panel colorPanel;
    }
}


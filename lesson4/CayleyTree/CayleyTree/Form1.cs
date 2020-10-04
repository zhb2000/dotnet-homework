using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetControlDefaultValue();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetValueFromControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (graphics == null)
            {
                graphics = drawPanel.CreateGraphics();
            }
            graphics.Clear(drawPanel.BackColor);
            double x0 = drawPanel.Width / 2;
            double y0 = drawPanel.Height;
            DrawCayleyTree(recursiveDepth, x0, y0, mainLen, -Math.PI / 2);
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                color = new Pen(dialog.Color);
                dialog.Dispose();
                colorPanel.BackColor = color.Color;
            }
        }

        /// <summary>
        /// 递归绘制 Cayley 树
        /// </summary>
        /// <param name="n">递归深度</param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="leng">主干长度</param>
        /// <param name="th"></param>
        private void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            DrawLine(x0, y0, x1, y1);
            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        private void DrawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(color, (float)x0, (float)y0, (float)x1, (float)y1);
        }

        /// <summary>
        /// 设置控件显示的默认值
        /// </summary>
        private void SetControlDefaultValue()
        {
            nTxtBox.Text = defaultN.ToString();
            lengTxtBox.Text = defaultLeng.ToString();
            th1TxtBox.Text = defaultTh1.ToString();
            th2TxtBox.Text = defaultTh2.ToString();
            per1TxtBox.Text = defaultPer1.ToString();
            per2TxtBox.Text = defaultPer2.ToString();
            colorPanel.BackColor = color.Color;
        }

        /// <summary>
        /// 从控件获取值
        /// </summary>
        private void GetValueFromControl()
        {
            recursiveDepth = int.Parse(nTxtBox.Text);
            if (recursiveDepth <= 0)
                throw new ApplicationException("invalid n");
            mainLen = int.Parse(lengTxtBox.Text);
            if (mainLen <= 0)
                throw new ApplicationException("invalid leng");
            th1 = double.Parse(th1TxtBox.Text);
            if (th1 <= 0)
                throw new ApplicationException("invalid th1");
            th2 = double.Parse(th2TxtBox.Text);
            if (th2 <= 0)
                throw new ApplicationException("invalid th2");
            per1 = double.Parse(per1TxtBox.Text);
            if (per1 <= 0)
                throw new ApplicationException("invalid per1");
            per2 = double.Parse(per2TxtBox.Text);
            if (per2 <= 0)
                throw new ApplicationException("invalid per2");
        }

        private Graphics graphics;

        /// <summary>
        /// 递归深度
        /// </summary>
        private int recursiveDepth = defaultN;
        /// <summary>
        /// 主干长度
        /// </summary>
        private int mainLen = defaultLeng;
        /// <summary>
        /// 右分支角度
        /// </summary>
        private double th1 = defaultTh1;
        /// <summary>
        /// 左分支角度
        /// </summary>
        private double th2 = defaultTh2;
        /// <summary>
        /// 右分支长度比
        /// </summary>
        private double per1 = defaultPer1;
        /// <summary>
        /// 左分支长度比
        /// </summary>
        private double per2 = defaultPer2;
        /// <summary>
        /// 画笔颜色
        /// </summary>
        private Pen color = defaultColor;

        private const int defaultN = 10;
        private const int defaultLeng = 100;
        private const double defaultTh1 = 30 * Math.PI / 180;
        private const double defaultTh2 = 20 * Math.PI / 180;
        private const double defaultPer1 = 0.6;
        private const double defaultPer2 = 0.7;
        private static readonly Pen defaultColor = Pens.Blue;
    }
}

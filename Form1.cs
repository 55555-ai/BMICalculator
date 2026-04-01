using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1133516_bmi_hw1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPreview = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            bool isHeightValid = double.TryParse(textBox1.Text, out double h);
            bool isWeightValid = double.TryParse(textBox2.Text, out double w);

            if (!isHeightValid || !isWeightValid)
            {
                MessageBox.Show("請輸入有效的數字。", "輸入錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (h <= 0 || w <= 0)
            {
                MessageBox.Show("身高和體重必須大於 0。", "輸入錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double bmi = 10000 * w / h / h;

            string[] x = { "過輕", "適中", "過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = { Color.LightBlue, Color.LightGreen, Color.Yellow, Color.Orange, Color.OrangeRed, Color.Red };

            string strResult = "";
            Color colorResult = Color.Black;
            int resultIndex = 0;

            if (bmi < 18.5)
            {
                resultIndex = 0;
            }
            else if (bmi < 24)
            {
                resultIndex = 1;
            }
            else if (bmi < 27)
            {
                resultIndex = 2;
            }
            else if (bmi < 30)
            {
                resultIndex = 3;
            }
            else if (bmi < 35)
            {
                resultIndex = 4;
            }
            else
            {
                resultIndex = 5;
            }

            strResult = x[resultIndex];
            colorResult = colorList[resultIndex];

            textBox3.Text = $"BMI={bmi:F2} ({strResult})";
            textBox3.BackColor = colorResult;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox2.Focus();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox3.BackColor = Color.White;
                textBox1.Focus();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

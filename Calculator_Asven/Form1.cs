using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Asven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"c:\\Users\\alkin\\Desktop\\R&M.jpeg");
            this.StartPosition = FormStartPosition.CenterScreen;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void One_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "1";
        }

        private void Two_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "2";
        }

        private void Three_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "3";
        }

        private void Four_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "4";
        }

        private void Five_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "5";
        }

        private void Six_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "6";
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "7";
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "8";
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "9";
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "0";
        }

        private void Addition_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "+";
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "-";
        }

        private void Multiplication_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "*";
        }

        private void Division_Click(object sender, EventArgs e)
        {
            MainDisplay.Text = MainDisplay.Text + "/";1
        }

        private void Equally_Click(object sender, EventArgs e)
        {
            ReversePolishEntry rpe = new ReversePolishEntry(MainDisplay.Text);
        }

        private void MainDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

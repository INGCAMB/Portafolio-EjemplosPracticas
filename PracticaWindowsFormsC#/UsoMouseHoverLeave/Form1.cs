using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsoMouseHoverLeave
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            label1.ForeColor = Color.Black;
            label1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Red = random.Next(250);
            int Blue = random.Next(250);
            int Green = random.Next(250);
            this.BackColor = Color.FromArgb(Red, Green, Blue);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Hola mundo";
            label1.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}

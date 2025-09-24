using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        CrossLines a = new CrossLines(4, 1, 5, 6);
        CrossLines b = new CrossLines(2, 2, 7, 3);
        double angle = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            (double, double) inter = (0, 0);
            string h = label1.Text;
            bool s = a.Intersection(a, b, out inter, ref h);
            label1.Text = h;
            bool d = a.Angle(a, b, out angle);
            label2.Text = $"Угол между отрезками: {360 * angle/Math.PI}";
        }
    }
}

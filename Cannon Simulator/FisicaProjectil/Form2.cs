using System;
using System.Drawing;
using System.Windows.Forms;

namespace FisicaProjectil
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Size size = new Size(1389, 781);
            InitializeComponent();
            this.Width = 1366;
            this.Height = 781;
            this.CenterToScreen();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}

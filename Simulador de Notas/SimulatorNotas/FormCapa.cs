using System;
using System.Windows.Forms;



namespace SimulatorNotas
{
    public partial class FormCapa : Form
    {
        System.Windows.Forms.Timer theTimer;
        static int i = 0;

        public FormCapa()
        {
            
            InitializeComponent();


            theTimer = new System.Windows.Forms.Timer();

            theTimer.Enabled = true;
            theTimer.Interval = 2000;
            theTimer.Tick += PollUpdates;
            theTimer.Start();
            
        }


        private void PollUpdates(object sender, EventArgs e)
        {
            Console.WriteLine(i.ToString());
            i++;
            if(i == 2)
            {
                theTimer.Stop();
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

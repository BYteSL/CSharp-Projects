using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorNotas
{
    public partial class Form2 : Form
    {
        public event EventHandler ButtonOkClicked;
        public event EventHandler ActivateFlag;
        bool mouseDown;
        Point lastLocation;
        float n, p;

        public Form2(string titulo)
        {
            InitializeComponent();
            this.CenterToScreen();
            lblTitulo.Text = "Inserir a Nota do";
            lblNome.Text = titulo;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ActivateFlag != null)
            {
                ActivateFlag(sender, e);
            }
            this.Visible=false;
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        public string Nota
        {
            get { return tbNota.Text; }
            set { tbNota.Text = value; }
        }
        public float NotaF
        {
            get { return n; }
            set { n = value; }
        }
        public string Peso
        {
            get { return cbPeso.Text; }
            set { cbPeso.Text = value; }
        }
        public float PesoF
        {
            get { return p; }
            set { p = value; }
        }
        public bool BtnOkPressed
        {
            get { return BtnOkPressed; }
        }
        public PictureBox PicTeste
        {
            get { return pictureBox3; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            float.TryParse(Nota, out n);
            float.TryParse(Peso, out p);
            int cont = 0;
            if (ActivateFlag != null)
            {
                ActivateFlag(sender, e);
            }
            ButtonOkClicked.Invoke(sender,e);
            if (ButtonOkClicked != null && cont == 0)
            {
                ButtonOkClicked(sender, e);
                cont++;
            }
            ButtonOkClicked = null;   
            this.Visible=false;
        }

        
    }
}

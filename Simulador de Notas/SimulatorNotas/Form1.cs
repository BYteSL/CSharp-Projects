using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SimulatorNotas
{
    public partial class Form1 : Form
    {
        Avaliacao av = new Avaliacao();
        
        List<float> testesNotas = new List<float>();
        List<float> testesPesos = new List<float>();
        List<float> trabalhosNotas = new List<float>();
        List<float> trabalhosPesos = new List<float>();
        int i;
        bool flag=false;
        bool mouseDown;
        Point lastLocation;
        public Form1( Form form)
        {
            InitializeComponent();
            this.CenterToScreen();
            form.Hide();
            
            listView1.Columns[0].Width = 1;
            listView1.Columns[1].Width = 123;
            listView1.Columns[2].Width = 123;
            listView1.Columns[1].TextAlign = HorizontalAlignment.Center;
            listView1.Columns[2].TextAlign = HorizontalAlignment.Center;

            listView2.Columns[0].Width = 1;
            listView2.Columns[1].Width = 121;
            listView2.Columns[2].Width = 121;
            listView2.Columns[1].TextAlign = HorizontalAlignment.Center;
            listView2.Columns[2].TextAlign = HorizontalAlignment.Center;
        }
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            listView1.Columns[0].Width = 1;
            listView1.Columns[1].Width = 123;
            listView1.Columns[2].Width = 123;
            listView1.Columns[1].TextAlign = HorizontalAlignment.Center;
            listView1.Columns[2].TextAlign = HorizontalAlignment.Center;

            listView2.Columns[0].Width = 1;
            listView2.Columns[1].Width = 121;
            listView2.Columns[2].Width = 121;
            listView2.Columns[1].TextAlign = HorizontalAlignment.Center;
            listView2.Columns[2].TextAlign = HorizontalAlignment.Center;
            
            
        }



        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2("Teste");
            
            if (form2.Visible == true || flag == true)
            {
                form2.Visible = false;
            }
            else
            {
                flag = true;
                for (int i = 0; i < 2; i++)
                {
                    pictureBox2.Image = SimulatorNotas.Properties.Resources.btnAddNota2;
                    Refresh();
                }
                for (int i = 0; i < 2; i++)
                {
                    pictureBox2.Image = SimulatorNotas.Properties.Resources.btnAddNota4;
                    Refresh();
                }


                int c = 0;
                form2.Visible = true;
                form2.ActivateFlag += (s, eee) => { flag = false; };
                form2.ButtonOkClicked += (s, ee) =>
                {
                    listView1.Items.Clear();
                    if (c == 0)
                    {
                        av.AdicionarNotaTeste(form2.NotaF, form2.PesoF);
                        testesNotas.Add(form2.NotaF);
                        testesPesos.Add(form2.PesoF);
                        c++;
                    }
                    i = 0;
                    foreach(float f in testesNotas)
                    {
                        string[] values = { "", f.ToString(), testesPesos[i].ToString() };
                        listView1.Items.Add(new ListViewItem(values));
                        i++;
                    }
                    flag = false;
                };
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("Trabalho");
            
            if (form2.Visible == true || flag == true)
            {
                form2.Visible = false;
            }
            else
            {
                flag = true;
                for (int i = 0; i < 2; i++)
                {
                    pictureBox3.Image = SimulatorNotas.Properties.Resources.btnAddNota2;
                    Refresh();
                }
                for (int i = 0; i < 2; i++)
                {
                    pictureBox3.Image = SimulatorNotas.Properties.Resources.btnAddNota4;
                    Refresh();
                }


                int c = 0;
                form2.Visible = true;
                form2.ActivateFlag += (s, eee) => { flag = false; };
                form2.ButtonOkClicked += (s, ee) =>
                {
                    listView2.Items.Clear();
                    if (c == 0)
                    {
                        av.AdicionarNotaTrabalho(form2.NotaF, form2.PesoF);
                        trabalhosNotas.Add(form2.NotaF);
                        trabalhosPesos.Add(form2.PesoF);
                        c++;
                    }
                    i = 0;
                    foreach (float f in trabalhosNotas)
                    {
                        string[] values = { "", f.ToString(), trabalhosPesos[i].ToString() };
                        listView2.Items.Add(new ListViewItem(values));
                        i++;
                    }
                    flag = false;
                };

            }
        }
    }
}

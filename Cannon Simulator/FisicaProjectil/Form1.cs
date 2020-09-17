using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace FisicaProjectil
{
    public partial class Form1 : Form
    {
        Graphics g,g2;
        Pen p,p2;
        Image cannonImg = Properties.Resources.cannon1;
        Graphics graphicsObj;
        
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            
            userTxtBxPosX.Text = "300";
            userTxtBxPosY.Text = "200";
            userTxtBxAngulo.Text = "45";
            p = new Pen(Color.Black, 5);
            //p2 = new Pen(Color.Red, 5);

            

            g = pnlGraphic.CreateGraphics();
            g2 = pnlGraphic.CreateGraphics();
            graphicsObj = pnlGraphic.CreateGraphics();

            //c.ScaleTransform(1.0F, -1.0F);
            //c.TranslateTransform(1.0F, -600.0F);//-524

            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(1.0F, -600.0F);//-524
           
            g2.ScaleTransform(1.0F, -1.0F);
            g2.TranslateTransform(1.0F, -600.0F);

            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            

        }

        private void userTxtBxPosX_MouseClick(object sender, MouseEventArgs e)
        {            
            userTxtBxPosX.SelectAll();
        }

        private void userTxtBxPosY_MouseClick(object sender, MouseEventArgs e)
        {
            userTxtBxPosY.SelectAll();
        }

        private void userTxtBxAngulo_MouseClick(object sender, MouseEventArgs e)
        {
            userTxtBxAngulo.SelectAll();
        }

        private void pnlGraphic_Click(object sender, EventArgs e)
        {

            graphicsObj = pnlGraphic.CreateGraphics();
            graphicsObj.DrawImage(cannonImg, 0, 550);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            double  vX, alcance, alturaMax;
            bool flag = false;
            Cannonball cannon = new Cannonball();
            double x, y, angulo,yfinal;
            //userTxtBxPosX.Text = "800";
            //userTxtBxPosY.Text = "800";
            //userTxtBxAngulo.Text = "46";
            Double.TryParse(userTxtBxPosX.Text,out x);
            Double.TryParse(userTxtBxPosY.Text, out y);
            Double.TryParse(userTxtBxAngulo.Text, out angulo);
            
            if (x > 0 && y > 0 && angulo > 0)
            {
                if(x <= 1000 &&  y <= 1000 && angulo <= 90)
                {
                    if (cannon.VerificaY(y,angulo,x,out yfinal))
                    {
                        cannon.VerificaY(y,angulo,x,out yfinal);
                        cannon.X = x;
                        cannon.Y = yfinal;
                        cannon.Angulo = angulo;
                    }
                    else
                    {
                        MessageBox.Show("Valores para Y estavam incorretos!\nValores foram actualizados!");
                        cannon.VerificaY(y,angulo,x,out yfinal);
                        cannon.X = x;
                        cannon.Y = yfinal;
                        cannon.Angulo = angulo;
                    }



                    lblResultAngulo.Text = String.Format("{0} º", cannon.Angulo.ToString("0.##"));





                    cannon.InicialVelocity();
                    lblResultV0.Text = String.Format("{0} m/s", cannon.V0.ToString("0.###"));


                    cannon.TimeTotal = cannon.TimeOfMovement(cannon.V0);
                    lblResultTime.Text = String.Format("{0} s", cannon.TimeTotal.ToString("0.##"));




                    vX = cannon.VelocityX();

                    alturaMax = cannon.MaxHeigth(cannon.V0);

                    alcance = cannon.Maxlength(cannon.TimeTotal, cannon.V0);
                    //MessageBox.Show("X:" + cannon.X + "\nY:" + cannon.Y);
                    lblResultX.Text = String.Format("{0} m/s", vX.ToString("0.##"));
                    lbAlturaMax.Text = String.Format("{0} m", alturaMax.ToString("0.##"));
                    lbAlcanceMax.Text = String.Format("{0} m", alcance.ToString("0.##"));
                    if (alcance > 1000) flag = true;

                    DrawVelocityY(cannon.TimeTotal, cannon, vX, flag, alcance, alturaMax);
                }
                else
                {
                    MessageBox.Show("Valores máximos:\nX:1000\nY:1000\nAngulo:90º");
                }
                
        }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
}

        private void DrawVelocityY(double time, Cannonball obj, double vx, bool flag, double alcance, double alturaMax)
        {
            
            double vy = 0;
            Image img = Properties.Resources.pointXY;
            Image imgBall = Properties.Resources.ballfinal;

            int comprimento, largura, escalax, escalay,pwidth = 3, pheight = 3;
            comprimento = pnlGraphic.Size.Width - 25;//25
            largura = pnlGraphic.Size.Height - 25;//25
            escalax = ((int)alcance / comprimento);
            escalay = ((int)alturaMax / largura);
            //g.TranslateTransform(0.0F, -(float)Height);
            //comprimento_imagem = imgCannon.Size.Width-73;
            //largura_imagem = imgCannon.Size.Height-150;
            //largura_imagem = pnlGraphic.Size.Height;
            //MessageBox.Show("altura" + largura_imagem.ToString());
            //g.TranslateTransform(0.0F, -(float)524);

            pnlGraphic.Refresh();

            if (comprimento < alcance && largura < alturaMax)
            {
                graphicsObj.DrawImage(cannonImg, 0, 550);
                g2.DrawImage(img, (int)(obj.X / (escalax * 2)), (int)(obj.Y / (escalay * 2)));
                //g2.DrawIcon(Properties.Resources.ball,(int) (obj.X / (escalax * 2)),(int) (obj.Y / (escalay * 2)));
                //g2.DrawEllipse(p2, ((float)obj.X/ (escalax * 2)), ((float)obj.Y / (escalay * 2)), pwidth, pheight);
                
                for (double i = 0.00; i <= time + 1; i += 0.1)
                {
                    if (i >= time)
                    {
                        vy = obj.VelocityY(time);

                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(time).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(time).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(time).ToString("0.##"));
                        
                        //g.DrawEllipse(p, ((float)obj.getXLocation(i)) / escalax, ((float)obj.getYLocation(i) + 440) / escalay, 3, 3);
                        //panel1.Refresh();

                    }
                    else
                    {
                        vy = obj.VelocityY(i);

                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(i).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(i).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(i).ToString("0.##"));
                        labelgetX.Text = String.Format("{0} m", obj.X.ToString());
                        labelgetY.Text = String.Format("{0} m", obj.Y.ToString());
                        labelXuser.Text = String.Format("1:{0}",(escalax*2).ToString("0.##"));
                        labelYuser.Text = String.Format("1:{0}", (escalay*2).ToString("0.##"));
                        if (obj.getXLocation(i) / (escalax * 2) < 33 && (obj.getYLocation(i)) < 33)
                        {

                        }
                        else
                        {
                            pnlGraphic.Refresh();
                            graphicsObj.DrawImage(cannonImg, 0, 554);
                            g2.DrawImage(img, (int)(obj.X / (escalax * 2)), (int)(obj.Y / (escalay * 2)));
                            g2.DrawImage(imgBall, (int)(obj.getXLocation(i) - 200 / (escalax * 2)), (int)(obj.getYLocation(i) / (escalay * 2)));
                            //g.DrawImage(img, (int)(obj.getXLocation(i) - 200 / (escalax * 2)), (int)(obj.getYLocation(i) / (escalay * 2)));
                        }
                        
                        //g.DrawIcon(Properties.Resources.ball, (int)(obj.getXLocation(i) / (escalax * 2)), (int)(obj.getYLocation(i) / (escalay * 2)));
                        //g.DrawEllipse(p, ((float)obj.getXLocation(i) / (escalax * 2)), ((float)obj.getYLocation(i) / (escalay * 2)), pwidth, pheight);
                        //panel4.Refresh();

                    }
                    panel1.Refresh();
                }
            }
            else if (comprimento < alcance && largura > alturaMax)
            {
                graphicsObj.DrawImage(cannonImg, 0, 554);
                g2.DrawImage(img, (int)(obj.X / (escalax * 2))+10, (int)(obj.Y));
                g2.DrawImage(imgBall,28,28);
                //g2.DrawIcon(Properties.Resources.ball, (int)(obj.X / (escalax * 2)), (int)(obj.Y));
                //g2.DrawEllipse(p2, ((float)obj.X) / (escalax*2), ((float)obj.Y), pwidth, pheight);
                for (double i = 0.00; i <= time + 1; i += 0.1)
                {
                    if (i >= time)
                    {
                        vy = obj.VelocityY(time);
                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(time).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(time).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(time).ToString("0.##"));
                       // g.DrawEllipse(p, ((float)obj.getXLocation(i)) / escalax, ((float)obj.getYLocation(i) + 440), 3, 3);
                        //panel1.Refresh();


                    }
                    else
                    {
                        vy = obj.VelocityY(i);
                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(i).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(i).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(i).ToString("0.##"));
                        if(obj.getXLocation(i) / (escalax * 2) < 33 && (obj.getYLocation(i)) < 33)
                        {

                        }
                        else
                        {
                            pnlGraphic.Refresh();
                            graphicsObj.DrawImage(cannonImg, 0, 554);
                            g2.DrawImage(img, (int)(obj.X / (escalax * 2)) + 10, (int)(obj.Y));
                            g2.DrawImage(imgBall, (int)(obj.getXLocation(i) / (escalax * 2)) + 10, (int)(obj.getYLocation(i)));
                            //g.DrawImage(img, (int)(obj.getXLocation(i) / (escalax * 2)) + 10, (int)(obj.getYLocation(i)));
                        }
                        
                        //g.DrawIcon(Properties.Resources.ball, (int)(obj.getXLocation(i) / (escalax * 2)), (int)(obj.getYLocation(i)));
                        //g.DrawEllipse(p, ((float)obj.getXLocation(i) / (escalax*2)), ((float)obj.getYLocation(i)), pwidth, pheight);
                        labelgetX.Text = String.Format("{0} m", obj.X.ToString());
                        labelgetY.Text = String.Format("{0} m", obj.Y.ToString());
                        labelXuser.Text = String.Format("1:{0}", (escalax * 2).ToString("0.##"));
                        //labelXuser.Text = "0";

                        //panel4.Refresh();


                    }
                    panel1.Refresh();
                }
            }
            else if (comprimento > alcance && largura < alturaMax)
            {
                graphicsObj.DrawImage(cannonImg, 0, 554);
                g2.DrawImage(img, (int)(obj.X), (int)(obj.Y / (escalay * 2)));
                //g2.DrawIcon(Properties.Resources.ball, (int)(obj.X), (int)(obj.Y / (escalay * 2)));
                //g2.DrawEllipse(p2, ((float)obj.X), ((float)obj.Y) / (escalay*2), pwidth, pheight);
                for (double i = 0.00; i <= time + 1; i += 0.1)
                {
                    if (i >= time)
                    {
                        vy = obj.VelocityY(time);
                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(time).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(time).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(time).ToString("0.##"));
                        //g.DrawEllipse(p, ((float)obj.getXLocation(i)), ((float)obj.getYLocation(i) + 440) / escalay, 3, 3);
                        panel1.Refresh();


                    }
                    else
                    {
                        vy = obj.VelocityY(i);
                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(i).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(i).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(i).ToString("0.##"));
                        if (obj.getXLocation(i) / (escalax * 2) < 33 && (obj.getYLocation(i)) < 33)
                        {

                        }
                        else
                        {
                            pnlGraphic.Refresh();
                            graphicsObj.DrawImage(cannonImg, 0, 554);
                            g2.DrawImage(img, (int)(obj.X), (int)(obj.Y / (escalay * 2)));
                            g2.DrawImage(imgBall, (int)(obj.getXLocation(i)), (int)(obj.getYLocation(i) / (escalay * 2)));
                            //g.DrawImage(img, (int)(obj.getXLocation(i)), (int)(obj.getYLocation(i) / (escalay * 2)));
                        }
                        
                        //g.DrawIcon(Properties.Resources.ball, (int)(obj.getXLocation(i)), (int)(obj.getYLocation(i) / (escalay * 2)));
                        //g.DrawEllipse(p, ((float)obj.getXLocation(i)), ((float)obj.getYLocation(i)) / (escalay*2), pwidth, pheight);
                        labelgetX.Text = String.Format("{0} m", obj.X.ToString());
                        labelgetY.Text = String.Format("{0} m", obj.Y.ToString());
                        //labelXuser.Text = "0";
                        labelYuser.Text = String.Format("1:{0}", (escalay * 2).ToString("0.##"));
                        //panel4.Refresh();


                    }
                    panel4.Refresh();
                }
            }
            else
            {
                graphicsObj.DrawImage(cannonImg, 0, 554);
                g2.DrawImage(img, (int)(obj.X), (int)(obj.Y));
                //g2.DrawIcon(Properties.Resources.ball, (int)(obj.X), (int)(obj.Y));
                //g2.DrawEllipse(p2, ((float)obj.X), ((float)obj.Y), pwidth, pheight);
                for (double i = 0.00; i <= time + 1; i += 0.1)
                {
                    if (i >= time)
                    {
                        vy = obj.VelocityY(time);
                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(time).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(time).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(time).ToString("0.##"));
                       // g.DrawEllipse(p, ((float)obj.getXLocation(i)), ((float)obj.getYLocation(i) + 440), 3, 3);
                        panel1.Refresh();

                    }
                    else
                    {

                        vy = obj.VelocityY(i);
                        lblResultY.Text = String.Format("{0} m/s", obj.VelocityY(i).ToString("0.##"));
                        lbVelToatal.Text = String.Format("{0} m/s", obj.VelocityTotal(vx, vy).ToString("0.##"));
                        lbMostraPosx.Text = String.Format("{0} m", obj.getXLocation(i).ToString("0.##"));
                        lbMostraPosy.Text = String.Format("{0} m", obj.getYLocation(i).ToString("0.##"));
                        if (obj.getXLocation(i) < 40 && obj.getYLocation(i) < 40)
                        {

                        }
                        else
                        {
                            pnlGraphic.Refresh();
                            graphicsObj.DrawImage(cannonImg, 0, 554);
                            g2.DrawImage(img, (int)(obj.X), (int)(obj.Y));
                            g2.DrawImage(imgBall, (int)(obj.getXLocation(i)), (int)(obj.getYLocation(i)));
                            //g.DrawImage(img, (int)(obj.getXLocation(i)), (int)(obj.getYLocation(i)));
                        }
                        
                        //g.DrawIcon(Properties.Resources.ball, (int)(obj.getXLocation(i)), (int)(obj.getYLocation(i)));
                        //g.DrawEllipse(p, ((float)obj.getXLocation(i)), ((float)obj.getYLocation(i)), pwidth, pheight);
                        labelgetX.Text = String.Format("{0} m", obj.X.ToString());
                        labelgetY.Text = String.Format("{0} m", obj.Y.ToString());
                        labelXuser.Text = "0";
                        labelYuser.Text = "0";
                        //panel4.Refresh();


                    }
                    panel1.Refresh();
                }
                panel1.Refresh();
            }
            panel1.Refresh();

        }  
    }
}


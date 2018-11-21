using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _4thProject
{
    public partial class MainForm : Form
    {
        TrafficLight tl1;
        Auto au1;
        Pedestrian ped1;
        ES help;
        public delegate void MyDelegate();
        int k;

        public MainForm()
        {
            InitializeComponent();

            tl1 = new TrafficLight();
            au1 = new Auto(80, Width);
            ped1 = new Pedestrian(40, Height);
            help = new ES(60, Width);
            k = 0;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
            
            if (k != 50)
            {
            Thread tm1 = new Thread(TrL);
            tm1.Start();

            Thread tm2 = new Thread(Car);
            tm2.Start();

            Thread tm3 = new Thread(PedMove);
            tm3.Start();

            Thread tm4 = new Thread(Dang);
            tm4.Start();

            Thread.Sleep(1000);
            }

        }
        private void Draw(Graphics g)
        {
            g = CreateGraphics();
            g.DrawLine(Pens.Black, 0, Height / 2, Width, Height / 2);
            for (int i = 0; i < Height / 2; i++)
                g.DrawLine(Pens.Black, Width / 4, Height / 2 + i * 10, Width * 3 / 4, Height / 2 + i * 10);
            g.DrawLine(Pens.Black, Width * 3 / 4, Height / 2, Width * 3 / 4, Height / 4);
            g.DrawRectangle(Pens.Black, new Rectangle(Width * 3 / 4 - 50, 0, 100, Height / 4));
            if (au1.X + 50 < Width)
                g.FillRectangle(Brushes.Yellow, new Rectangle(au1.X, Height * 3 / 4, 50, Height * 3 / 8));
            if (tl1.red)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(Width * 3 / 4 - 25, 10, 50, 50));
                g.FillEllipse(Brushes.White, new Rectangle(Width * 3 / 4 - 25, 90, 50, 50));
                g.DrawEllipse(Pens.Black, new Rectangle(Width * 3 / 4 - 25, 10, 50, 50));
                g.DrawEllipse(Pens.Black, new Rectangle(Width * 3 / 4 - 25, 90, 50, 50));
            }
            else
            {
                g.FillEllipse(Brushes.White, new Rectangle(Width * 3 / 4 - 25, 10, 50, 50));
                g.FillEllipse(Brushes.Green, new Rectangle(Width * 3 / 4 - 25, 90, 50, 50));
                g.DrawEllipse(Pens.Black, new Rectangle(Width * 3 / 4 - 25, 10, 50, 50));
                g.DrawEllipse(Pens.Black, new Rectangle(Width * 3 / 4 - 25, 90, 50, 50));
            }
            if (ped1.Y + 50 < Height)
            {
                g.FillEllipse(Brushes.Pink, new Rectangle(Width / 2 - 25, ped1.Y - 50, 50, 50));
            }
            if (help.IsOn == true && help.X - 50 > 0)
            {
                g.FillRectangle(Brushes.Red, new Rectangle(help.X, Height/2, 50, Height / 8));
            }

        }
        private void Car(object obj)
        {
            if (au1.X + 50 < Width)
            {
                if (au1.X + 100 < Width / 4 || (tl1.red || (!tl1.red && au1.X + 100 > Width / 4)) && ped1.On == false || au1.X + 100 > Width *3 / 4)
                    au1.Move();     
            }
            else
                au1 = new Auto(60, Width);
            BeginInvoke(new MyDelegate(Refresh));
        }
        private void TrL(object obj)
        {
            if (k%7 == 0)
                tl1.Change();
            k++;
            BeginInvoke(new MyDelegate(Refresh));
        }
        private void PedMove(object obj)
        {
            if (ped1.Y + 50 < Height)
            {
                if ((!tl1.red || ped1.Y > Height / 2) && (au1.X < Width / 4 || au1.X > Width * 3 / 4) || (help.X>Width / 4 && help.X < Width * 3 / 4 && ped1.Y > Height / 2 && ped1.Y < Height * 5 / 8))
                {
                    ped1.Move();
                    ped1.On = true;
                }
                else
                    ped1.On = false;
            }
            else
            {
                ped1.On = false;
                ped1 = new Pedestrian(40, Height);
            }
            BeginInvoke(new MyDelegate(Refresh));
        }
        private void Dang(object obj)
        {
            if (help.IsOn == false)
            {
                help = new ES(60, Width);
                help.Dangerous();
            }
            else
            {
                if (help.X - 50 > 0)
                {
                    help.Move();
                    BeginInvoke(new MyDelegate(Refresh));
                }
                else
                    help.IsOn = false;
            }
        }
    }
}

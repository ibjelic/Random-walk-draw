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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }
        float x, y;
        Random rng = new Random();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(this.Width, this.Height);
            x = this.Width / 2;
            y = this.Height / 2;
            timer1.Interval = 1;
            
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            x = this.Width / 2;
            y = this.Height / 2;
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp,new Point(0,0));
            e.Graphics.FillEllipse(Brushes.Red, x, y, 10, 10);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ket();
            this.Invalidate();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        void ket()
        {
            int x_, y_;
            int ax, ay;
            float tx, ty;
            tx = x;ty = y;
            x_ = rng.Next(3); y_ = rng.Next(3);
            ax = rng.Next(3); ay = rng.Next(3);
            switch (x_)
            {
                case (0): break;
                case (1):
                    {
                        if (x >= this.Width) ax *= -1;
                        x += ax;
                    }
                    break;
                case (2):
                    {
                        if (x <= 0) ax *= -1;
                        x -= ax;
                    }
                    break;
            }
            switch (y_)
            {
                case (0): break;
                case (1):
                    {
                        if (y >= this.Height) ay *= -1;
                        y += ay;
                    }
                    break;
                case (2):
                    {
                        if (y <= 0) ay *= -1;
                        y -= ay;
                    }
                    break;
            }
            int red = rng.Next(0, byte.MaxValue + 1);
            int green = rng.Next(0, byte.MaxValue + 1);
            int blue = rng.Next(0, byte.MaxValue + 1);
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(Color.FromArgb(red, green, blue));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen rac = new Pen(brush);
                g.DrawLine(rac, tx, ty, x+5, y+5);
                
            }       
            this.BackgroundImage = bmp;
        }
    }
}

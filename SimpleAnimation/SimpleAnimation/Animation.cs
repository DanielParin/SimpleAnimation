using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAnimation
{
    internal class Animation : Form
    {
        private string santaPath = "C:\\Users\\Daniel\\source\\repos\\SimpleAnimation\\SimpleAnimation\\resources\\Santa.jpg";
        private string reindeerPath = "C:\\Users\\Daniel\\source\\repos\\SimpleAnimation\\SimpleAnimation\\resources\\reno.jpg";

        private int santaPos=0;
        private int reindeerPos=50;

        private bool power = true;
        private Color[] colors = { Color.Red,Color.Cyan,Color.Yellow};
        private Color[] dColors = { Color.DarkRed, Color.DarkCyan, Color.DarkGoldenrod };

        
        public Animation() 
        {
            InitializeForm();
            this.Paint += new PaintEventHandler(Animation_Paint);

            this.DoubleBuffered = true;
            moveSantaReindeer();

            this.Click += Animation_ScreenClick;
        }

        private void Animation_ScreenClick(object? sender ,EventArgs e)
        {

            this.Paint += new PaintEventHandler(Ball_Paint);
            power = !power;
     
        }

        private void Ball_Paint(object? sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush redBrush = new SolidBrush(colors[0]);
            Brush cyanBrush = new SolidBrush(colors[1]);
            Brush goldenBrush = new SolidBrush(colors[2]);
            Brush dRedBrush = new SolidBrush(dColors[0]);
            Brush dCyanBrush = new SolidBrush(dColors[1]);
            Brush dGoldenBrush = new SolidBrush(dColors[2]);

            if (power)
            {



                gr.FillEllipse(redBrush, 260, 310, 15, 15);
                gr.FillEllipse(cyanBrush, 215, 310, 15, 15);
                gr.FillEllipse(redBrush, 195, 370, 15, 15);
                gr.FillEllipse(goldenBrush, 280, 370, 15, 15);
                gr.FillEllipse(goldenBrush, 190, 410, 15, 15);
                gr.FillEllipse(cyanBrush, 285, 410, 15, 15);
            }
            else
            {
                gr.FillEllipse(dRedBrush, 260, 310, 15, 15);
                gr.FillEllipse(dCyanBrush, 215, 310, 15, 15);
                gr.FillEllipse(dRedBrush, 195, 370, 15, 15);
                gr.FillEllipse(dGoldenBrush, 280, 370, 15, 15);
                gr.FillEllipse(dGoldenBrush, 190, 410, 15, 15);
                gr.FillEllipse(dCyanBrush, 285, 410, 15, 15);
            }
        }

        private void moveSantaReindeer()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += (_, _) =>
            {
                if(santaPos==500)
                {
                    santaPos = -50;
                    reindeerPos = 0;
                }
       
                santaPos += 5;
                reindeerPos += 5;
                this.Invalidate();
            };
            
            timer.Start();
        }

        public void InitializeForm()
        {
            SuspendLayout();

            //Proportions of the app
            ClientSize = new Size(500,500);

            //Position on the screen
            StartPosition = FormStartPosition.CenterScreen;

            //Made not resizable
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;


            //Name of the app
            Name = "Simple Animation Work";
            Text = "Simple Animation Work";

            //Icon, for my route
            Icon = new Icon("C:\\Users\\Daniel\\source\\repos\\SimpleAnimation\\SimpleAnimation\\resources\\icon.ico");

            //Color of backgroundo
            BackColor = Color.DarkBlue;

        }

        protected void Animation_Paint (object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Moon and Stars
            gr.FillEllipse(Brushes.GhostWhite, 50, 50, 40, 40);
            gr.FillEllipse(Brushes.GhostWhite, 60, 130, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 160, 165, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 360, 290, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 300, 170, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 75, 160, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 400, 45, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 120, 330, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 350, 80, 5, 5);
            gr.FillEllipse(Brushes.GhostWhite, 250, 40, 5, 5);


            //Soil
            gr.FillRectangle(Brushes.DarkGreen,0, 450, 500, 50);


            //Tree trunk
            gr.FillRectangle(Brushes.SaddleBrown, 230, 420, 30, 50);


            //Leaves of the tree
            Point[] threePartA = new Point[]
           {
                new Point(245,350),
                new Point(300,420),
                new Point(190,420)
           };
            gr.FillPolygon(Brushes.DarkGreen, threePartA);


            Point[] threePartB = new Point[]
           {
                new Point(245,300),
                new Point(290,380),
                new Point(200,380)
           };
            gr.FillPolygon(Brushes.DarkGreen, threePartB);


            Point[] threePartC = new Point[]
            {
                new Point(245,280),
                new Point(270,320),
                new Point(220,320)
            };
            gr.FillPolygon(Brushes.DarkGreen,threePartC);


            //Tree star
            gr.FillEllipse(Brushes.Yellow, 232, 268, 25, 25);

            //Santa image
            Image santaImg = Image.FromFile(santaPath);
            gr.DrawImage(santaImg,new Rectangle(santaPos,150,50,60));


            //Raindeer image
            Image reindeerImg = Image.FromFile(reindeerPath);
            gr.DrawImage(reindeerImg, new Rectangle(reindeerPos, 150, 50, 60));


            //Christmas balls
            Brush redBrush = new SolidBrush(colors[0]);
            Brush cyanBrush = new SolidBrush(colors[1]);
            Brush goldenBrush = new SolidBrush(colors[2]);

            gr.FillEllipse(redBrush,260,310,15,15);
            gr.FillEllipse(cyanBrush, 215, 310, 15, 15);
            gr.FillEllipse(redBrush,195,370,15,15);
            gr.FillEllipse(goldenBrush,280,370,15,15);
            gr.FillEllipse(goldenBrush, 190, 410, 15, 15);
            gr.FillEllipse(cyanBrush,285,410,15,15);

        }
    }
}

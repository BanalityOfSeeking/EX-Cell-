using Game.Components;
using Game.Systems;
using Game.World;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        Bitmap Backbuffer;
        private BodyComponent BodyComponent { get; }


        Point MonsterPos;
        int Direction = 0;
        int stepDuration = 10;
        int step = 3;

        bool HasJumped = false;
        Random random = new Random();
        Image image = Image.FromFile("gespenst.gif");


        public Form1()
        {
            ImageAnimator.Animate(image, OnFrameChanged);
            
            //int WorldId = EntityComponent.GetEntityId();
            
            short PlayerId = EntityComponent.GetEntityId();
            
            EntityComponent.SetEntityComponent<BodyComponent>(PlayerId);
            
            BodyComponent = (BodyComponent)EntityComponent.GetEntityComponents(PlayerId).FirstOrDefault();

            BodyComponent
                .StrengthInit(random.Next(1, 10))
                .IntelligenceInit(random.Next(1, 10))
                .ConstitutionInit(random.Next(1, 10))
                .DexterityInit(random.Next(1, 10))
                .CharismaInit(random.Next(1, 10));

            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);

            System.Windows.Forms.Timer GameTimer = new System.Windows.Forms.Timer();
            GameTimer.Interval = 10;
            GameTimer.Tick += new EventHandler(GameTimer_Tick);
            GameTimer.Start();

            this.ResizeEnd += new EventHandler(Form1_CreateBackBuffer);
            this.Load += new EventHandler(Form1_CreateBackBuffer);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }



        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var head = BodyComponent.BodyParts.Head;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        e.Handled = true;
                        head.Location = new Point(head.Location.X - 2, head.Location.Y);
                        Direction = -2;
                        break;
                    }

                case Keys.Right:
                    {
                        e.Handled = true;
                        head.Location = new Point(head.Location.X + 2, head.Location.Y);
                        Direction = 2;
                        break;
                    }

                case Keys.Up:
                    {
                        e.Handled = true;
                        head.Location = new Point(head.Location.X + Direction, head.Location.Y + (HasJumped ? 1 : -40));
                        break;
                    }

                default:
                    {
                        e.Handled = true;
                        break;
                    }
            }
            BodyComponent.BodyParts.Head = head;
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Backbuffer != null)
            {
                e.Graphics.DrawImageUnscaled(Backbuffer, Point.Empty);
            }
        }

        void Form1_CreateBackBuffer(object sender, EventArgs e)
        {
            if (Backbuffer != null)
                Backbuffer.Dispose();
            if (ClientSize.Width > 400)
            {
                MonsterPos = new Point(ClientSize.Width - BodyComponent.BodyParts.Head.Size.Width * 3, ClientSize.Height - BodyComponent.BodyParts.Head.Size.Width * 3);
            }
            Backbuffer = new Bitmap(ClientSize.Width, ClientSize.Height > 0 ? ClientSize.Height : 1);
        }

        int InnerDraw(Graphics g, Point right, Point left)
        {
            ImageAnimator.UpdateFrames(image);

            g.DrawImage(image, 0, 0, ClientSize.Width, ClientSize.Height);

            var pen = new Pen(Color.White, 2.5f);
            g.FillEllipse(Brushes.White, BodyComponent.BodyParts.Head.Location.X - 5, BodyComponent.BodyParts.Head.Location.Y - 5, BodyComponent.BodyParts.Head.Size.Width, BodyComponent.BodyParts.Head.Size.Height);
            g.DrawLine(pen, BodyComponent.BodyParts.Torso.Start, BodyComponent.BodyParts.Torso.End);
            g.DrawLine(pen, BodyComponent.BodyParts.LeftArm.Start, left);
            g.DrawLine(pen, BodyComponent.BodyParts.RightArm.Start, right);
            g.DrawLine(pen, BodyComponent.BodyParts.Torso.End, Point.Add(left, new Size(0, BodyComponent.BodyParts.Head.Size.Width * 2)));
            g.DrawLine(pen, BodyComponent.BodyParts.Torso.End, Point.Add(right, new Size(0, BodyComponent.BodyParts.Head.Size.Width * 2)));
            pen.Dispose();
            return 0;
        }


        void Compute()
        {
            stepDuration -= 1;
            if (stepDuration == 0)
            {
                stepDuration = 8;
                step--;
                if(step <0)
                {
                    step = 3;
                }
            }
            //Force a call to the Paint event handler.
            var resX = BodyComponent.BodyParts.Head.Location.X;
            var resY = BodyComponent.BodyParts.Head.Location.Y;
            bool test1 = resX > ClientSize.Width - BodyComponent.BodyParts.Head.Size.Width;
            bool test2 = resX < 0 + 10;
            int result = test1 ? ClientSize.Width - BodyComponent.BodyParts.Head.Size.Width : test2 ? BodyComponent.BodyParts.Head.Size.Width : resX;

            /// Control the Jump size.
            if (resY < ClientSize.Height - BodyComponent.BodyParts.Head.Size.Width * 5)
            {
                HasJumped = true;
                resY += 2;
                result += Direction;
                // Set result
                BodyComponent.BodyParts.Config(result, resY);
            }
            else
            {
                HasJumped = false;
                // reset position
                BodyComponent.BodyParts.Config(result, resY);
            }
        }

        void Draw()
        {

            if (Backbuffer != null)
            {
                using (var g = Graphics.FromImage(Backbuffer))
                {
                    int istep = step switch
                    {
                        0 => InnerDraw(g, BodyComponent.BodyParts.RightArm.Start, BodyComponent.BodyParts.LeftArm.Start),
                        int i when i == 1 || i == 3 => InnerDraw(g, Point.Add(BodyComponent.BodyParts.RightArm.End, new Size(0, 5)), Point.Add(BodyComponent.BodyParts.LeftArm.End, new Size(0, 5))),
                        _ => InnerDraw(g, Point.Add(BodyComponent.BodyParts.RightArm.End, new Size(0, -5)), Point.Add(BodyComponent.BodyParts.LeftArm.End, new Size(0, -5)))
                    };
                }
                Compute();

            }
        }
        void OnFrameChanged(object o, EventArgs e)
        {
            Invalidate();

        }
        void GameTimer_Tick(object sender, EventArgs e)
        {

            Draw();
            Invalidate();
        }

        private void InitializeComponent()
        {
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Name = "Form1";

        }
    }

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}


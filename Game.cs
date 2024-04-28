using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;


namespace Game
{
    
    public partial class Game : Form
    {
        public static int CounterOfWin = 0;
        Image player;
        private int currFrame = 0;
        private int currAnimation = -1;
        private bool IsPressedAnyKey = false;
        public bool NormalRoom = true;
        public bool Eye = true;
        public Game()
        {
            InitializeComponent();
            player = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 4.png");

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(Keyboard);
            this.KeyUp += new KeyEventHandler(FreeKeyB);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
           
        }


        private void Keyboard(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    currAnimation = 0;
                    if (pictureBox1.Location.X >= 950) break;
                    if (pictureBox1.Location.X >= 930 && (pictureBox1.Location.Y >= 300 || pictureBox1.Location.Y <= 400)) 
                    { 
                        Labyrinth laby = new Labyrinth();
                        laby.Show();
                        Hide();
                        break; 
                    }
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X + 5, pictureBox1.Location.Y);
                        break;
                    }

                case "A":
                    currAnimation = 1;
                    if (pictureBox1.Location.X <= 600) break;
                    if (pictureBox1.Location.Y <= 320 && (pictureBox1.Location.X <= 706 && pictureBox1.Location.X >= 650))
                    {
                        Mirror mirror = new Mirror();
                        mirror.Show();
                        break;
                    }
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y);
                        break;
                    }
                case "W":
                    currAnimation = 0;
                    if (pictureBox1.Location.Y <= 300) break;
                    if (pictureBox1.Location.Y <= 320 && (pictureBox1.Location.X <= 706 && pictureBox1.Location.X >= 650))
                    {
                        Mirror mirror = new Mirror();
                        mirror.Show();
                        break;
                    }
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 5);
                        break;
                    }
                case "S":
                    currAnimation = 0;
                    if (pictureBox1.Location.Y > 600)
                    {
                        NextLoca loca = new NextLoca();
                        loca.Show();
                        Hide();
                        break;
                    }
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 5);
                        break;
                    }
            }
            IsPressedAnyKey = true;
        }

        private void FreeKeyB(object sender, KeyEventArgs e)
        {
            IsPressedAnyKey = false;
            currAnimation = -1;
            currFrame = 0;
        }

        private void update(object sender, EventArgs e)
        {
            if (Labyrinth.FirstWin)
            {
                pictureBox6.Hide();
                pictureBox4.Visible = true;
            }
            if (IsPressedAnyKey)
            {
                PlayAnimation();
                if (currFrame == 2)
                    currFrame = 0;
            }
            else
            {
                PlayAnimationStop();
                if (currFrame == 2)
                    currFrame = 0;
            }
            currFrame++;
            
        }

        private void PlayAnimation()
        {
            if (currAnimation != -1)
            {
                Image part = new Bitmap(143, 250);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(player, 0, 0,
                    new Rectangle(new Point(143 * currFrame, 250 * currAnimation),
                    new Size(143, 250)), GraphicsUnit.Pixel);
                pictureBox1.Size = new Size(143, 250);
                pictureBox1.Image = part;
            }
        }
        private void PlayAnimationStop()
        {
            if (currAnimation == -1)
            {
                Image part = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 1.png");
                pictureBox1.Image = part;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (NormalRoom && Eye)
            {
                NormalRoom = false;
                Eye = false;
                BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 4 (2).png");
                pictureBox2.BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 1 (10).png");
            }
            else
            {
                NormalRoom = true;
                Eye = true;
                BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 4 (1).png");
                pictureBox2.BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 1 (9).png");
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox3.Hide();
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox6.Hide();
        }
    }
}

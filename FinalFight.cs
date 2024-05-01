using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FinalFight : Form
    {
        public int mouseClickCounter = 0;
        public bool NormalRoom = true;
        public bool Eye = true;
        Image player;
        private int currFrame = 0;
        private int currAnimation = -1;
        private bool IsPressedAnyKey = false;
        public bool FinalWin = false;
        public bool FinalDie = false;
        public FinalFight()
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
                    if (pictureBox1.Location.X >= 1300) break;
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X + 5, pictureBox1.Location.Y);
                        break;
                    }

                case "A":
                    currAnimation = 1;
                    if (pictureBox1.Location.X <= 330) break;
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y);
                        break;
                    }
                case "W":
                    currAnimation = 0;
                    if (pictureBox1.Location.Y <= 350) break;
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 5);
                        break;
                    }
                case "S":
                    currAnimation = 0;
                    if (pictureBox1.Location.Y >= 540)
                    {
                        var loca = new NextLoca();
                        loca.Show();
                        Close();
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
                pictureBox4.Visible = true;
            }
            if (ThirdPlace.PlatformWin)
            {
                pictureBox5.Visible = true;
            }
            for (var i = 0; i < 3; i++)
            {
                currFrame++;


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
            }

        }

        private void PlayAnimation()
        {
            if (currAnimation != -1)
            {
                Image part = new Bitmap(150, 250);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(player, 0, 0,
                    new Rectangle(new Point(143 * currFrame, 250 * currAnimation),
                    new Size(150, 250)), GraphicsUnit.Pixel);
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

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (NormalRoom && Eye)
            {
                NormalRoom = false;
                Eye = false;
                pictureBox2.BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 1 (10).png");
                MessageBox.Show("If you want to talk, click on the white dialog icon",
                    "", MessageBoxButtons.OK);
            }
            else
            {
                NormalRoom = true;
                Eye = true;
                BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 8.png");
                pictureBox2.BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 1 (9).png");
            }
        }

        private void DialogGO(object sender, MouseEventArgs e)
        {
            mouseClickCounter++;
            if (mouseClickCounter == 1)
            {
                label1.Text = "I hate you... you know!";
                label2.Text = "...";
            }
            if (mouseClickCounter == 2)
            {
                label1.Text = "I wouldn't give your freedom. You're here with me forever";
                label2.Text = "It's not your fault!";
            }
            if (mouseClickCounter == 3)
            {
                label1.Text = "Stop talking, please! You've forgotten me!";
                label2.Text = "I want to fix everything, Nina!";
            }
            if (mouseClickCounter == 4)
            {
                label1.Text = "Don't say my name!";
                label2.Text = "AXAXAXAXAXAX, it's my name too";
            }
            if (mouseClickCounter == 5)
            {
                label1.Text = "Shut just up! You've lost your memory!";
                label2.Text = "No, I remember, that you are beautifull girl forever";
            }
            if (mouseClickCounter == 6)
            {
                label1.Text = "I'm not hearing you! I'm not hearing you!";
                label2.Text = "And your birthday... is on 27 of March. Today is 27 March";                            
            }
            if (mouseClickCounter == 7)
            {
                label1.Text = "You came here to make fun of me?";
                label2.Text = "I just wanted to say I'm sorry";
            }
            if (mouseClickCounter == 8)
            {
                label1.Text = "Is that all you wanted?";
                if (pictureBox4.Visible && pictureBox5.Visible)
                {
                    FinalWin = true;
                    label2.Text = "I'm going to re-draw the drawing that I tore up";
                }
                else
                {
                    FinalDie = true;
                    label2.Text = "That's all...";
                }
            }
            if (mouseClickCounter == 9)
            {
                if (FinalDie)
                {
                    label1.Text = "Well... get ready for eternal suffering with me";
                    
                }
                if(FinalWin)
                {
                    label1.Text = "What... do you still remember?";
                    label2.Text = "Yeeeh... I remember... I am you... you are me... I lost memory, but I find you... so I win";
                }
            }
            if (mouseClickCounter == 10)
            {
                if (FinalDie)
                {
                    this.Close();
                }
                if(FinalWin)
                {
                    label1.Text = "What is it? I found eternal peace... and now I can set your free. Thank you, Nina!";
                    BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 6 (5).png");
                    label2.Text = "Goodbye... I will never forget about you... me... again";
                }
            }
            if(mouseClickCounter == 11)
            {
                this.Close();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FinalFight : Form
    {
        public bool NormalRoom = true;
        public bool Eye = true;
        Image player;
        private int currFrame = 0;
        private int currAnimation = -1;
        private bool IsPressedAnyKey = false;
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
                pictureBox4.Visible = true;
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
            }
            else
            {
                NormalRoom = true;
                Eye = true;
                BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 8.png");
                pictureBox2.BackgroundImage = new Bitmap("C:\\Users\\712\\source\\repos\\Game\\Resources\\Component 1 (9).png");
            }
        }
    }
}

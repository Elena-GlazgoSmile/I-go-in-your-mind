using Game.GameObj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Game
{
    public partial class ThirdPlace : Form
    {
        bool goLeft, goRight, jump, gameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 15;
        int verticalSpeed = 3;
        int horizontalSpeed = 13;
        int enemy1Speed = 5;
        int enemy2Speed = 3;
        public static bool PlatformWin = false;
        
        public ThirdPlace()
        {
            InitializeComponent();
            MessageBox.Show("Collect 8 hearts and find the door to escape.\nDon't touch Nina!",
                    "", MessageBoxButtons.OK);
            timer1.Interval = 200;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyIsUp);


        }


        

        private void Update(object sender, EventArgs e)
        {
            label1.Text = "Score:" + score;
            pictureBox1.Top += jumpSpeed;
            if (goLeft)
            {
                pictureBox1.Left -= playerSpeed;
            }
            if (goRight)
            {
                pictureBox1.Left += playerSpeed;
            }
            if (jump && force < 0)
            {
                jump = false;
            }
            if (jump)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 17;
            }
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if ((string)x.Tag == "platform") 
                    { 
                        if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 13;
                            pictureBox1.Top = x.Top - pictureBox1.Height;

                            if ((string)x.Name == "pictureBox12" && goLeft == false || (string)x.Name == "pictureBox12" && goRight == false)
                            {
                                pictureBox1.Left -= horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                
                    }
                    if ((string)x.Tag == "h")
                    {
                        if (pictureBox1.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if (((string)x.Tag == "enemy"))
                    {
                        if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                        {
                            timer1.Stop();
                            gameOver = true;
                            label1.Text = "Score: " + score + Environment.NewLine + "Don't touch me!\nPress Enter to continue";
                        }
                    }                          
                }   
            }
            pictureBox12.Left -= horizontalSpeed;
            if (pictureBox12.Left < 0 || pictureBox12.Left + pictureBox12.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            pictureBox7.Top += verticalSpeed;
            if (pictureBox7.Top <= 232 || pictureBox7.Top >= 780)
            {
                verticalSpeed = -verticalSpeed;
            }
            pictureBox15.Left -= enemy1Speed;
            if (pictureBox15.Left < pictureBox4.Left || pictureBox15.Left + pictureBox15.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemy1Speed = -enemy1Speed;
            }
            pictureBox16.Left += enemy2Speed;
            if (pictureBox16.Left < pictureBox5.Left || pictureBox16.Left + pictureBox16.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemy2Speed = -enemy2Speed;
            }
            if (pictureBox1.Top + pictureBox1.Height > this.ClientSize.Height + 100)
            {
                timer1.Stop();
                gameOver = true;
                label1.Text = "Score: " + score + Environment.NewLine + "You fell to your death!\nPress Enter to continue";
            }
            if (pictureBox1.Bounds.IntersectsWith(door.Bounds) && score >= 8)
            {
                timer1.Stop();
                PlatformWin = true;
                gameOver = false;
                MessageBox.Show("No!!!!! You didn't win!\nMy game goes on forever!",
                    "It's not your door!", MessageBoxButtons.OK);
                this.Close();
                NextLoca nextLoca = new NextLoca();
                nextLoca.Hide();
                    
                
            }
        }


        private void ThirdPlace_Load(object sender, EventArgs e)
        {
            
        }

        private void KeyIsDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jump == false)
            {
                jump = true;
            }
        }

        private void KeyIsUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (jump)
            {
                jump = false;
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }
        private void RestartGame()
        {
            jump = false;
            goLeft = false;
            goRight = false;
            gameOver = false;
            score = 0;
            label1.Text = "Score" + score;

            foreach(Control x in this.Controls) 
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            pictureBox1.Left = 100;
            pictureBox1.Top = 600;

            pictureBox15.Left = 300;

            pictureBox16.Left = 1000;
            pictureBox12.Left = 600;


            pictureBox7.Top = 600;
            timer1.Start();
        }
    }
}
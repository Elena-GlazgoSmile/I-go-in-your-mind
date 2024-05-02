using System;
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
    public partial class Labyrinth : Form
    {
        Point StartLocation;
        int CountDown;
        public static bool FirstWin = false;
        public Labyrinth()
        {
            InitializeComponent();
            InitializeGame();           
            CountDown = 30;
        }

        private void InitializeGame()
        {
            GameTimer.Start();
            StartLocation = panelInner.Location;
            Cursor.Position = PointToScreen(StartLocation);

        }
        private void LabyWall_MouseEnter(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (CountDown < 0) 
            {
                GameTimer.Stop();
                DialogResult userChoice = MessageBox.Show("You can't find me?\nDo you want remember again?", "Err000000000r", MessageBoxButtons.YesNo);
                if (userChoice == DialogResult.Yes)
                {
                    InitializeGame();
                }
                else
                {
                    Game game = new Game();
                    game.Show();
                    this.Close();
                }
            }
            Timer.BackColor = Color.White;
            Timer.Text = CountDown.ToString();
            CountDown--;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            GameTimer.Stop();
            Game.CounterOfWin++;
            DialogResult userChoice = MessageBox.Show("Yeeees, it's me...\n Do you still remember?", "AXAXAXXAXAXAXAXXA", MessageBoxButtons.YesNo);
            if (userChoice == DialogResult.Yes)
            {
                FirstWin = true;
                Game game = new Game();
                game.Show();               
                this.Close();
            }
            else
            {
                InitializeGame();
            }
        }

        
    }
}

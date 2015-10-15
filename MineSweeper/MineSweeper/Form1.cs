using System;
using System.Drawing;
using System.Windows.Forms;
using MineSweeper.ButtonsListCreation;
using Utilits;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        bool endGameRound = false;
        public Form1()
        {
            InitializeComponent();
            AddButtons();
        }

        public void AddButtons()
        {
            Reset();
            AddEventsToButtons addEvents = new AddEventsToButtons(null);
            ModifyButtons modButtons = new ModifyButtons(addEvents);
            CreateButtons buttons = new CreateButtons(modButtons, this);
            buttons.Upgrade();

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (!endGameRound)
            {
                DialogResult dialogResult = MessageBox.Show("Are You sure?", "New Game", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    NewGame();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            else
            {
                endGameRound = false;
                NewGame();
            }
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.GameDifficulty = Tools.Difficulty.Easy;
            NewGame();
        }

        private void middleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.GameDifficulty = Tools.Difficulty.Middle;
            NewGame();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.GameDifficulty = Tools.Difficulty.Hard;
            NewGame();
        }


        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSize(Tools.Size.Small);

        }

        private void middToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSize(Tools.Size.Meddium);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSize(Tools.Size.Large);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You sure?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        public void ChangeSize(Tools.Size size)
        {
            DisposeButtons();
            Tools.GameSize = size;
            this.ClientSize = new Size(20 * ((int)Tools.GameSize + 3), 20 * ((int)Tools.GameSize + 3));
            AddButtons();
        }

        public void DisposeButtons()
        {
            for (int y = 0; y < Tools.array.GetLength(0); y++)
            {
                for (int x = 0; x < Tools.array.GetLength(1); x++)
                {
                    Tools.array[y, x].Dispose();
                }
            }
        }
        private void NewGame()
        {
            Tools.defuseKitNumber = 10;
            label2.Text = "10";
            DisposeButtons();
            AddButtons();            
        }

        private void Reset()
        {
            menuStrip1.BackColor = Color.Silver;
            label1.Text = "";
            Tools.defuseKitNumber = 10;
            Tools.bombCount = 0;
            label2.Text = "10";
        }

        public void GameOver()
        {
            menuStrip1.BackColor = Color.Red;
            label1.ForeColor = Color.Red;
            label1.Text = "Game over";
            label1.Location = new Point(this.ClientSize.Width / 2 - 50, 30);
            endGameRound = true;
        }

        public void YouWin()
        {
            label1.Text = "YouWin";
            label1.ForeColor = Color.Green;
            menuStrip1.BackColor = Color.Green;
            label1.Location = new Point(this.ClientSize.Width / 2 - 50, 30);
            endGameRound = true;
        }

        public void Defuse()
        {
            label2.Text = Tools.defuseKitNumber.ToString();
        }       
    }
}

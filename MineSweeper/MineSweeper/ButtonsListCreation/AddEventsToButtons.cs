using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Utilits;
using MineSweeper.ButtonsListAction;

namespace MineSweeper.ButtonsListCreation
{
    public class AddEventsToButtons : Decorator
    {       
        RunCascade runCuscade = new RunCascade();
        DefuseButton defuseButton = new DefuseButton();

        public AddEventsToButtons(ButtonsBase butbase)
            : base(butbase)
        {                        
        }

        public override void Upgrade()
        {
            for (int y = 0; y < Tools.array.GetLength(0); y++)
            {
                for (int x = 0; x < Tools.array.GetLength(1); x++)
                {
                    Tools.array[y, x].CoordinateX = x;
                    Tools.array[y, x].CoordinateY = y;
                    Tools.array[y, x].MouseDown += new MouseEventHandler(RightButton_Click);
                    Tools.array[y, x].MouseDown += new MouseEventHandler(LeftButton_Click);
                }
            }
        }
        protected void RightButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MyButton button = (MyButton)sender;
                if (Tools.defuseKitNumber != 0 && button.Enabled)
                {
                    if (defuseButton.Defused(button))
                    {
                        button.MouseDown += new MouseEventHandler(LeftButton_Click);
                    }
                    else
                    {
                        button.MouseDown -= new MouseEventHandler(LeftButton_Click);
                    }
                    if (Tools.defuseKitNumber >= 0)
                    {
                        Form1 form = Form1.ActiveForm as Form1;
                        form.Defuse();
                    }
                }
            }
        }

        protected void LeftButton_Click(object sender, MouseEventArgs e)
        {
            Form1 form = Form1.ActiveForm as Form1;
            GamePlayResult gameResult = new GamePlayResult(form);
            if (e.Button == MouseButtons.Left)
            {
                MyButton button = (MyButton)sender;
                if (button.ButtonContainner == "free")
                {
                    button.Enabled = false;
                    button.BackgroundImage = SetPicture.SetBackgroundPicture(button.ButtonContainner);
                    button.FlatStyle = FlatStyle.Popup;
                    runCuscade.CreateCascadeCell(button.CoordinateY, button.CoordinateX);
                 
                    gameResult.YouWin();
                   
                }
                else if (button.ButtonContainner == "bomb")
                {
                    gameResult.GameOver(button);
                }
                else
                {
                    button.Enabled = false;
                    button.Checked = true;                  
                    button.BackgroundImage = SetPicture.SetBackgroundPicture(button.ButtonContainner);
                    button.FlatStyle = FlatStyle.Popup;
                    gameResult.YouWin();
                }
            }
        }       
    }
}

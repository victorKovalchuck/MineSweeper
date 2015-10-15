using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;

namespace MineSweeper
{
    public class GamePlayResult
    {
        Form1 form1;
        public GamePlayResult(Form1 form1)
        {
            this.form1 = form1;
        }

        public void GameOver(MyButton button)
        {
            for (int x = 0; x < Tools.array.GetLength(1); x++)
            {
                for (int y = 0; y < Tools.array.GetLength(0); y++)
                {
                    Tools.array[y, x].Enabled = false;
                    Tools.array[y, x].FlatStyle = FlatStyle.Popup;
                    if (Tools.array[y, x].Defused == true)
                    {
                        Tools.array[y, x].BackgroundImage = SetPicture.SetBackgroundPicture(Tools.array[y, x].ButtonContainner + "defused");
                    }
                    else
                    {
                        Tools.array[y, x].BackgroundImage = SetPicture.SetBackgroundPicture(Tools.array[y, x].ButtonContainner);
                    }
                }

            }
            button.BackgroundImage = SetPicture.SetBackgroundPicture("boom");
            form1.GameOver();
        }


        public void YouWin()
        {
            int bombsRemain = 0;
            for (int x = 0; x < Tools.array.GetLength(1); x++)
            {
                for (int y = 0; y < Tools.array.GetLength(0); y++)
                {
                    if (!Tools.array[y, x].Checked)
                    {
                        bombsRemain++;
                    }
                }
            }
            if (bombsRemain == Tools.bombCount)
            {
                DisableAllButtons();
                form1.YouWin();
            }
        }

        private void DisableAllButtons()
        {
            for (int x = 0; x < Tools.array.GetLength(1); x++)
            {
                for (int y = 0; y < Tools.array.GetLength(0); y++)
                {
                    Tools.array[y, x].Enabled = false;
                    if (!Tools.array[y, x].Checked)
                    {
                        Tools.array[y, x].FlatStyle = FlatStyle.Popup;
                        if (Tools.array[y, x].Defused)
                        {
                            Tools.array[y, x].BackgroundImage = SetPicture.SetBackgroundPicture(Tools.array[y, x].ButtonContainner + "defused");
                        }
                        else
                        {
                            Tools.array[y, x].BackgroundImage = SetPicture.SetBackgroundPicture(Tools.array[y, x].ButtonContainner);
                        }
                    }
                }
            }
        }
    }

}

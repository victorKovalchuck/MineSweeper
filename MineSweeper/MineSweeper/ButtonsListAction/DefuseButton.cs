using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;

namespace MineSweeper.ButtonsListAction
{
    public class DefuseButton
    {
        public bool Defused(MyButton button)
        {
            MyButton myButton = Tools.array[button.CoordinateY, button.CoordinateX];
            if (!button.Defused)
            {
                myButton.BackgroundImage = SetPicture.SetBackgroundPicture("defused");
                myButton.Defused = true;
                Tools.defuseKitNumber -= 1;
                return false;
            }
            else
            {
                myButton.Defused = false;
                myButton.Enabled = true;
                myButton.BackgroundImage = null;
                Tools.defuseKitNumber += 1;
                return true;
            }
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilits
{
    public class MyButton : Button
    {
        private int X;
        private int Y;
        private string buttonContainner;
        private bool checkedButton = false;
        private bool defused = false;

        public bool Defused
        {
            get
            {
                return defused;
            }
            set
            {
                defused = value;
            }
        }

        public string ButtonContainner
        {
            get
            {
                return buttonContainner;
            }
            set
            {
                buttonContainner = value;
            }
        }

        public int CoordinateX
        {
            get
            {
                return X;
            }
            set
            {
                X = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return Y;
            }
            set
            {
                Y = value;
            }
        }

        public bool Checked
        {
            get
            {
                return checkedButton;
            }
            set
            {
                checkedButton = value;
            }
        }
    }
}

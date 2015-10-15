using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilits
{
    public static class Tools
    {
        public enum Difficulty { Easy = 30, Middle = 15, Hard = 10 };
        public enum Size { Small = 10, Meddium = 15, Large = 20 };

        public static int defuseKitNumber = 10;
        public static int bombCount;
        private static Difficulty dif = Difficulty.Middle;
        private static Size size = Size.Small;

        public static MyButton[,] array=new MyButton[10, 13];
        public static Size GameSize
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                array = new MyButton[(int)size, (int)size + 3];
            }
        }      

        public static Difficulty GameDifficulty 
        {
            get
            {
                return dif;
            }
            set
            {
                dif = value;
            }
        }      

    }
}

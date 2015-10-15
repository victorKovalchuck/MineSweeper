using System;
using System.Drawing;

namespace MineSweeper
{
    public static class SetPicture
    {
        public static Image SetBackgroundPicture(string bombOrNot)
        {
            if (bombOrNot != "free")
            {
                if (!CurrentProjectIsTestProject())
                {
                    return Image.FromFile(@"..\..\Images\" + bombOrNot + ".png");
                }
                else
                {
                    return Image.FromFile(@"..\..\..\MineSweeper\Images\" + bombOrNot + ".png");
                }
            }
            return null;
        }

        private static bool CurrentProjectIsTestProject()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            string[] words = path.Split(new char[] { '\\' });
            foreach (string word in words)
            {
                if (word == "MineSweeperTest")
                {
                    return true;
                }
            }
            return false;
                
        }
    }
}

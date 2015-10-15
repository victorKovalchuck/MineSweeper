using System.Windows.Forms;
using System.Threading.Tasks;
using Utilits;
using System.Threading;
using MineSweeper;

namespace MineSweeper.ButtonsListAction
{
    public class RunCascade
    {
        TaskScheduler waitTasks = new WaitAllTasks();
        int maxX, maxY;

        public RunCascade()
        {
            maxX = Tools.array.GetLength(1) - 1;
            maxY = Tools.array.GetLength(0) - 1;
        }
        public void CreateCascadeCell(int coordinatY, int coordinatX)
        {
            MoveRight(coordinatY, coordinatX);
            MoveLeft(coordinatY, coordinatX);
            MoveUp(coordinatY, coordinatX);
            MoveDown(coordinatY, coordinatX);
        }

        private void MoveRight(int coordinatY, int coordinatX)
        {
            if (coordinatX != maxX)
            {
                int x = coordinatX + 1;
                int y = coordinatY;
                OpenCell(x, y);
            }
        }

        private void MoveLeft(int coordinatY, int coordinatX)
        {
            if (coordinatX != 0)
            {
                int x = coordinatX - 1;
                int y = coordinatY;
                OpenCell(x, y);
            }
        }

        private void MoveUp(int coordinatY, int coordinatX)
        {
            if (coordinatY != 0)
            {
                int x = coordinatX;
                int y = coordinatY - 1;
                OpenCell(x, y);
            }
        }

        private void MoveDown(int coordinatY, int coordinatX)
        {
            if (coordinatY != maxY)
            {
                int x = coordinatX;
                int y = coordinatY + 1;
                OpenCell(x, y);
            }
        }
        private void OpenCell(int x, int y)
        {
            if (!Tools.array[y, x].Checked)
            {
                Tools.array[y, x].Enabled = false;
                Tools.array[y, x].FlatStyle = FlatStyle.Popup;
                Tools.array[y, x].Checked = true;
                SetPictureOrRunCascadeTask(y, x);                
            }
        }

        private void SetPictureOrRunCascadeTask(int y, int x)
        {              
            if (Tools.array[y, x].ButtonContainner != "free")
            {
                if (Tools.array[y, x].Defused)
                {
                    Tools.array[y, x].BackgroundImage = SetPicture.SetBackgroundPicture(Tools.array[y, x].ButtonContainner + "defused");
                }
                else
                {
                    Tools.array[y, x].BackgroundImage = SetPicture.SetBackgroundPicture(Tools.array[y, x].ButtonContainner);
                }

            }
            else
            {
                Task.Factory.StartNew(() => CreateCascadeCell(y, x), CancellationToken.None, TaskCreationOptions.None, waitTasks);
            }
        }       
    }
}

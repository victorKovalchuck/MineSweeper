using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilits;

namespace MineSweeper.ButtonsListCreation
{
    public class ModifyButtons : Decorator
    {
        int arrayXMax;
        int arrayYMax;
        public ModifyButtons(ButtonsBase butbase)
            : base(butbase)
        {
            arrayXMax = Tools.array.GetLength(1) - 1;
            arrayYMax = Tools.array.GetLength(0) - 1;
        }

        public override void Upgrade()
        {
            for (int x = 0; x <= arrayXMax; x++)
            {
                for (int y = 0; y <= arrayYMax; y++)
                {
                    if (Tools.array[y, x].ButtonContainner == "bomb")
                    {
                        DigitPlanter(y, x);
                    }
                }
            }            
            base.Upgrade();
        }

        private void DigitPlanter(int y, int x)
        {
            if (x != 0 & y != 0 & x != arrayXMax & y != arrayYMax)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (x == 0 && y != 0 && y != arrayYMax)
            {
                for (int i = x; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (y == 0 && x != 0 && x != arrayXMax)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y; j <= y + 1; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }

            else if (y == arrayYMax && x != 0 && x != arrayXMax)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (x == arrayXMax && y != 0 && y != arrayYMax)
            {
                for (int i = x - 1; i <= x; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (x == 0 && y == 0)
            {
                for (int i = x; i <= x + 1; i++)
                {
                    for (int j = y; j <= y + 1; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (x == arrayXMax && y == arrayYMax)
            {
                for (int i = x - 1; i <= x; i++)
                {
                    for (int j = y - 1; j <= y; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (x == arrayXMax && y == 0)
            {
                for (int i = x - 1; i <= x; i++)
                {
                    for (int j = y; j <= y + 1; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
            else if (x == 0 && y == arrayYMax)
            {
                for (int i = x; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y; j++)
                    {
                        SetDigit(j, i);
                    }
                }
            }
        }

        private void SetDigit(int j, int i)
        {
            if (Tools.array[j, i].ButtonContainner != "bomb")
            {
                int summedDigit = SumDigit(Tools.array[j, i].ButtonContainner);
                Tools.array[j, i].ButtonContainner = summedDigit.ToString();
            }
        }

        private int SumDigit(string digit)
        {
            int result = 0;
            int.TryParse(digit, out result);
            result++;
            return result;
        }
    }
}

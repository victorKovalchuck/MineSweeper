using System;
using System.Windows.Forms;
using Utilits;

namespace MineSweeper.ButtonsListCreation
{
    public class CreateButtons : Decorator
    {
        Form _form1;        
        Random random = new Random();
        public CreateButtons(ButtonsBase butbase, Form form1)
            : base(butbase)
        {           
            this._form1 = form1;
        }

        public override void Upgrade()
        {
            for (int y = 0; y < Tools.array.GetLength(0); y++)
            {
                for (int x = 0; x < Tools.array.GetLength(1); x++)
                {
                    MyButton button = new MyButton();                    
                    button.ButtonContainner = BombPlanter();
                    button.Size = new System.Drawing.Size(20, 20);
                    button.Location = new System.Drawing.Point(20 * x, 20 * y + 60);                 
                    _form1.Controls.Add(button);
                    Tools.array[y, x] = button;
                }
            }
            base.Upgrade();
        }

        private string BombPlanter()
        {
            string result = random.Next(1, (int)Tools.GameDifficulty) > 1 ? "free" : "bomb";
            if (result == "bomb")
                Tools.bombCount++;
            return result;
        }
    }
}

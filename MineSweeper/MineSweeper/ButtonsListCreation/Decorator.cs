using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.ButtonsListCreation
{
    public abstract class Decorator:ButtonsBase
    {
        protected ButtonsBase buttonBase;

        public Decorator(ButtonsBase buttonBase)
        {
            this.buttonBase = buttonBase;
        }

        public override void Upgrade()
        {
            buttonBase.Upgrade();
        }
    }
}

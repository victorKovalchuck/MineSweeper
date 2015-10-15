using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MineSweeper.ButtonsListCreation;

namespace MineSweeperTest
{
    public class ButtonsBaseGag : Decorator
    {
        public ButtonsBaseGag() : base(null) { }
        public override void Upgrade()
        {
        }
    }
}

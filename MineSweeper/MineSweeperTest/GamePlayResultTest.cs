using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using MineSweeper;
using Utilits;

namespace MineSweeperTest
{
    [TestClass]
    public class GamePlayResultTest
    {
        [TestMethod]
        public void GameOverTest()
        {
            GamePlayResult gameResult = new GamePlayResult(new Form1());
            Assert.IsTrue(Tools.array[1, 1].BackgroundImage == null); ;          
            gameResult.GameOver(Tools.array[1, 1]);
            Assert.IsFalse(Tools.array[1, 1].BackgroundImage == null);
            
        }       
    }
}

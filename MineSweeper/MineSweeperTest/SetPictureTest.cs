using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using MineSweeper;
using System.IO;

namespace MineSweeperTest
{
    [TestClass]
    public class SetPictureTest
    {
        [TestMethod]
        public void SetBackGroundPictureTest()
        {
            Image imageExpected = SetPicture.SetBackgroundPicture("bomb");
            Image imageActual= Image.FromFile(@"..\..\..\MineSweeper\Images\bomb.png");
            MemoryStream ms = new MemoryStream();
            imageExpected.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String expectedImage = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;
            imageActual.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String actualImage = Convert.ToBase64String(ms.ToArray());

            Assert.AreEqual(expectedImage, actualImage);            
        }

    }
}

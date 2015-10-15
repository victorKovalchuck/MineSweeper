using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.ButtonsListCreation;
using System.Windows.Forms;
using Utilits;
using MineSweeper.ButtonsListAction;

namespace MineSweeperTest
{
    [TestClass]
    public class ButtonsListTest
    {
        CreateButtons createButtons;
        ModifyButtons modifyButtons;
        AddEventsToButtons addEvents;
        ButtonsBaseGag flip;

        [TestInitialize]
        public void Init()
        {
            flip = new ButtonsBaseGag();
        }

        [TestMethod]
        public void RunMineSweeperCreation()
        {
            SetMineSweeperSize();
            CreateButtonsTest();
            ModifyButtonsTest();
            AddEventsToButtonsTest();
            RunCascadeTest();
                       
        }

        public void RunCascadeTest()
        {
            RunCascade cascade = new RunCascade();
            int enabledBefore = CountEnabledButton();
            cascade.CreateCascadeCell(0, 0);
            int enabledAfter = CountEnabledButton();
            Assert.IsTrue(enabledBefore > enabledAfter);
        }

        private void SetMineSweeperSize()
        {
            Tools.GameSize = Tools.Size.Large;
            Assert.AreEqual(Tools.array.GetLength(0), (int)Tools.Size.Large);
        }
      
        private void CreateButtonsTest()
        {
            createButtons = new CreateButtons(flip, new Form());
            createButtons.Upgrade();
            Assert.IsTrue(hasElement("bomb"));
            Assert.IsFalse(hasElement("1"));
        }

        private void ModifyButtonsTest()
        {
            modifyButtons = new ModifyButtons(flip);
            modifyButtons.Upgrade();
            Assert.IsTrue(hasElement("1"));
        }


        private void AddEventsToButtonsTest()
        {
            addEvents = new AddEventsToButtons(flip);
            Assert.AreNotEqual(1, Tools.array[1, 1].CoordinateX);
            addEvents.Upgrade();
            Assert.AreEqual(1, Tools.array[1, 1].CoordinateX);            
        }
       
        private bool hasElement(string value)
        {
            for (int y = 0; y < Tools.array.GetLength(0); y++)
            {
                for (int x = 0; x < Tools.array.GetLength(1); x++)
                {
                    if (Tools.array[y, x].ButtonContainner == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int CountEnabledButton()
        {
            int enabledCells = 0;
            for (int y = 0; y < Tools.array.GetLength(0); y++)
            {
                for (int x = 0; x < Tools.array.GetLength(1); x++)
                {
                    if (Tools.array[y, x].Enabled)
                    {
                        enabledCells++;
                    }
                }
            }
            return enabledCells;
        }     
    }
}

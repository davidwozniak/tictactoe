using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kolkokrzyzyk;
using Class_Library;


namespace CheckForWinnerTest
{

    [TestClass]
    public class LogicTest

    {
        [TestMethod]
        public void Test_CHeCkwin_Outcome()
        {

            //arrange
            MarkType [] mResults = new MarkType [25];
            mResults[24] = MarkType.Cross;
            mResults[18] = MarkType.Cross;
            mResults[12] = MarkType.Cross;

            //act
            CheckForWinner check = new CheckForWinner();
            var mark = check.CheckWin(mResults);
            //assert

            var value = MarkType.Cross;
            Assert.AreEqual(mark,value);

        }
    }
}

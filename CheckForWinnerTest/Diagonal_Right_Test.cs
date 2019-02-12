using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kolkokrzyzyk;
using Class_Library;

namespace CheckForWinnerTest
{
    [TestClass]
    public class Diagonal_Right_Test
    {
        [TestMethod]
        public void Test_CheCkwin_Outcome_Cross_DiagonalRight()
        {

            MarkType[] mResults = new MarkType[25];
            CheckForWinner check = new CheckForWinner();

            for (int i = 2; i < 15; i++)
            {
                if (i % 5 >= 2)
                {
                    mResults[i] = MarkType.Cross;
                    mResults[i + 4] = MarkType.Cross;
                    mResults[i + 8] = MarkType.Cross;

                    var mark = check.CheckWin(mResults);
                    var value = MarkType.Cross;

                    Assert.AreEqual(mark, value);
                }


            }
        }
        [TestMethod]
        public void Test_CheCkwin_Outcome_Nought_DiagonalRight()
        {

            MarkType[] mResults = new MarkType[25];
            CheckForWinner check = new CheckForWinner();

            for (int i = 2; i < 15; i++)
            {
                if (i % 5 >= 2)
                {
                    mResults[i] = MarkType.Nought;
                    mResults[i + 4] = MarkType.Nought;
                    mResults[i + 8] = MarkType.Nought;

                    var mark = check.CheckWin(mResults);
                    var value = MarkType.Nought;

                    Assert.AreEqual(mark, value);
                }


            }
        }
    }
}

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
    public class Diagonal_Left_Test
    {
        [TestMethod]
        public void Test_CheCkwin_Outcome_Cross_DiagonalLeft()
        {

            MarkType[] mResults = new MarkType[25];
            CheckForWinner check = new CheckForWinner();

            for (int i = 12; i < 25; i++)
            {
                if (i % 5 >= 2)
                {
                    mResults[i] = MarkType.Cross;
                    mResults[i - 6] = MarkType.Cross;
                    mResults[i - 12] = MarkType.Cross;

                    var mark = check.CheckWin(mResults);
                    var value = MarkType.Cross;

                    Assert.AreEqual(mark, value);
                }


            }
        }
        [TestMethod]
        public void Test_CheCkwin_Outcome_Nought_DiagonalLeft()
        {

            MarkType[] mResults = new MarkType[25];
            CheckForWinner check = new CheckForWinner();

            for (int i = 12; i < 25; i++)
            {
                if (i % 5 >= 2)
                {
                    mResults[i] = MarkType.Nought;
                    mResults[i - 6] = MarkType.Nought;
                    mResults[i - 12] = MarkType.Nought;

                    var mark = check.CheckWin(mResults);
                    var value = MarkType.Nought;

                    Assert.AreEqual(mark, value);
                }


            }
        }
    }
}

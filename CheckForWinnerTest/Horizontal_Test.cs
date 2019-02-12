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
    public class Horizontal_Test

    {
        [TestMethod]
        public void Test_CheCkwin_Outcome_Cross_Horizontal()
        {
            CheckForWinner check = new CheckForWinner();
            MarkType[] mResults = new MarkType[25];

            for (int i =0; i<23;i++)
            {
                if (i % 5 < 3)
                {
                    mResults[i] = MarkType.Cross;
                    mResults[i + 1] = MarkType.Cross;
                    mResults[i + 2] = MarkType.Cross;

                    var mark = check.CheckWin(mResults);
                    var value = MarkType.Cross;
                    Assert.AreEqual(mark, value);
                }


            }


        }

        [TestMethod]
        public void Test_CheCkwin_Outcome_Nought_Horizontal()
        {
            CheckForWinner check = new CheckForWinner();
            MarkType[] mResults = new MarkType[25];

            for (int i = 0; i < 23; i++)
            {
                if (i % 5 < 3)
                {
                    mResults[i] = MarkType.Nought;
                    mResults[i + 1] = MarkType.Nought;
                    mResults[i + 2] = MarkType.Nought;

                    var mark = check.CheckWin(mResults);
                    var value = MarkType.Nought;
                    Assert.AreEqual(mark, value);
                }


            }


        }
    }
}

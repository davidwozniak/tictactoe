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
    public class Vertical_Test

    {
        [TestMethod]
        public void Test_CHeCkwin_Outcome_Cross_Vertical()
        {

            CheckForWinner check = new CheckForWinner();
            MarkType[] mResults = new MarkType[25];

            for (int i = 0; i < 15; i++)
            {
                
              
               mResults[i] = MarkType.Cross;
               mResults[i + 5] = MarkType.Cross;
               mResults[i + 10] = MarkType.Cross;

               var mark = check.CheckWin(mResults);
               var value = MarkType.Cross;
               Assert.AreEqual(mark, value);
              

            }


        }

        [TestMethod]
        public void Test_CHeCkwin_Outcome_Nought_Vertical()
        {
            CheckForWinner check = new CheckForWinner();
            MarkType[] mResults = new MarkType[25];

            for (int i = 0; i < 15; i++)
            {


                mResults[i] = MarkType.Nought;
                mResults[i + 5] = MarkType.Nought;
                mResults[i + 10] = MarkType.Nought;

                var mark = check.CheckWin(mResults);
                var value = MarkType.Nought;
                Assert.AreEqual(mark, value);


            }


        }
    }
}

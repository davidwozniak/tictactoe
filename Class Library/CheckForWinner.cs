using kolkokrzyzyk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class CheckForWinner
    {
        /// <summary>
        /// checking for win (checking possible cominations for the same MarkType with each Click)
        /// </summary>
        /// <returns></returns>
        public MarkType CheckWin(MarkType [] mResults)
        {
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    var offset = y * 5 + x;
                    var mark = mResults[offset];
                    if (mark == MarkType.Free)
                    {
                        // Don't do the checks when we are on a free mark
                        continue;

                    }

                    if (x <= 2 && mark == mResults[offset + 1] && mark == mResults[offset + 2])
                    {
                        // Horizontal match at (x,y)..(x+2,y)
                        return mark;

                    }

                    if (y <= 2 && mark == mResults[offset + 5] && mark == mResults[offset + 10])
                    {
                        // Vertical match at (x,y)..(x,y+2)
                        return mark;
                    }

                    if (x <= 2 && y <= 2 && mark == mResults[offset + 6] && mark == mResults[offset + 12])
                    {
                        // Diagonal - right match at (x,y)..(x+2,y+2)
                        return mark;
                    }
                    if (x <= 2 && y >= 2 && mark == mResults[offset - 4] && mark == mResults[offset - 8])
                    {
                        // Diagonal - left match at (x,y)..(x+2,y-2)
                        return mark;
                    }
                }
            }


            return MarkType.Free;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolkokrzyzyk
{   
    /// <summary>
    /// The type of value the cell in game have
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// cell wasnt clicked
        /// </summary>
        Free,
        /// <summary>
        /// cell is a O
        /// </summary>
        Nought,
        /// <summary>
        /// cell is an X
        /// </summary>
        Cross
    }
}

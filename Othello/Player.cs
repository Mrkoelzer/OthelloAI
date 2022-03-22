/* Player.cs
 * Author: Jacob Koelzer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    /// <summary>
    /// The values that can occupy a square on the board.
    /// </summary>
    public enum Player
    {
        /// <summary>
        /// A black piece
        /// </summary>
        Black, 
        
        /// <summary>
        /// A white piece
        /// </summary>
        White, 
        
        /// <summary>
        /// No piece
        /// </summary>
        None, 
        
        /// <summary>
        /// The contents of a location off the board
        /// </summary>
        Invalid
    }
}

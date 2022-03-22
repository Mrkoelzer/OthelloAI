/* Direction.cs
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
    /// The directions of eight surrounding squares on the board.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Up and left
        /// </summary>
        Northwest, 
        
        /// <summary>
        /// Up
        /// </summary>
        North, 
        
        /// <summary>
        /// Up and right
        /// </summary>
        Northeast, 
        
        /// <summary>
        /// Right
        /// </summary>
        East, 
        
        /// <summary>
        /// Down and right
        /// </summary>
        Southeast, 
        
        /// <summary>
        /// Down
        /// </summary>
        South, 
        
        /// <summary>
        /// Down and left
        /// </summary>
        Southwest, 
        
        /// <summary>
        /// Left
        /// </summary>
        West, 
        
        /// <summary>
        /// No direction
        /// </summary>
        None
    }
}

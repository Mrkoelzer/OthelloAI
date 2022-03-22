/* Play.cs
 * Author: Jacob Koelzer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Othello
{
    /// <summary>
    /// A representation of a single play with enough information to undo it.
    /// </summary>
    public class Play
    {
        /// <summary>
        /// The board location of the play.
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// The number of pieces flipped by the play in each direction.
        /// </summary>
        public int[] Flipped { get; }

        /// <summary>
        /// Constructs a new play a the given location, flipping the given pieces
        /// </summary>
        /// <param name="loc">The location of the play.</param>
        /// <param name="flipped">The number of pieces flipped by the play in each 
        /// direction.</param>
        public Play(Point loc, int[] flipped)
        {
            Location = loc;
            Flipped = flipped;
        }
    }
}

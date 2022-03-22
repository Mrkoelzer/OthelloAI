/*BoardSquare.cs
 *Author: Jacob Koelzer 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class BoardSquare
    {
        /// <summary>
        /// gets or sets the Player occupying this square.
        /// </summary>
        public Player WhichPlayer
        {
            get;
            set;
        } = Player.None;

        /// <summary>
        ///  gets the location of this square.
        /// </summary>
        public Point Location
        {
            get;
        }

        /// <summary>
        /// gets or sets whether this square is on the perimete
        /// </summary>
        public bool OnPerimeter
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the next square in the perimeter list
        /// </summary>
        public BoardSquare Next
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the previous square in the perimeter list
        /// </summary>
        public BoardSquare Previous
        {
            get;
            set;
        }

        /// <summary>
        /// gets a list of the directions in which adjacent occupied squares lie.
        /// </summary>
        public List<Direction> OccupiedDirections
        {
            get;
        } = new List<Direction>();

        /// <summary>
        /// Point should be used to initialize the Location property
        /// </summary>
        /// <param name="loc">giving its location</param>
        public BoardSquare(Point loc)
        {
            Location = loc;
        }
    }
}

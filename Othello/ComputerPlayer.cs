/*ComputerPlayer.cs
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
    /// <summary>
    /// represents the computer player
    /// </summary>
    public class ComputerPlayer
    {
        /// <summary>
        /// giving the number of simulations that should be done to find the best play
        /// </summary>
        private int _simulations;

        /// <summary>
        /// giving the current state of the game.
        /// </summary>
        private Board _state;

        /// <summary>
        /// giving the root of the stored game tree.
        /// </summary>
        private GameTreeNode _root=new GameTreeNode(-1);

        /// <summary>
        /// two parameters should be used to initialize the corresponding fields
        /// </summary>
        /// <param name="simulations"> giving the number of simulations that should be done to find the best play</param>
        /// <param name="played"> which the game will be played.</param>
        public ComputerPlayer(int simulations, Board played)
        {
            _simulations = simulations;
            _state=played;
            _root.Simulate(played);
            _root.Simulate(played);
        }

        /// <summary>
        /// Makes the opponent play
        /// </summary>
        /// <param name="location">giving the location of the opponent's play.</param>
        /// <returns>indicating whether this play was legal. </returns>
        public bool MakeOpponentPlay(Point location)
        {
          int temp = _state.MakePlay(location);
            if(temp < 0)
            {
                return false;
            }
            _root = _root.GetChild(temp);
            return true;
        }

        /// <summary>
        /// making a play by the computer
        /// </summary>
        public void MakePlay()
        {
            for (int i = 0; i < _simulations; i++) 
            {
                _root.Simulate(_state);
            }
            _root = _root.GetBestChild();
            _state.MakePlay(_root.Play);  
        }

    }
}

/* Board.cs
 * Author: Jacob Koelzer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// A representation of an othello board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The board.
        /// </summary>
        private BoardSquare[,] _board = new BoardSquare[8, 8];

        /// <summary>
        /// The number of pieces each player currently has on the board.
        /// </summary>
        private int[] _score = new int[2];

        /// <summary>
        /// The values that must be added to a cell to move in the corresponding
        /// direction from the Direction enumeration.
        /// </summary>
        private Point[] _directions =
        {
            new Point(-1, -1), new Point(0, -1), new Point(1, -1), new Point(1, 0),
            new Point(1, 1), new Point(0, 1), new Point(-1, 1), new Point(-1, 0)
        };

        /// <summary>
        /// The history of plays up to the current point in the game.
        /// </summary>
        private Stack<Play> _history = new Stack<Play>();

        /// <summary>
        /// The current player.
        /// </summary>
        public Player CurrentPlayer { get; private set; } = Player.Black;

        /// <summary>
        /// The player who is not currently playing.
        /// </summary>
        public Player OtherPlayer { get; private set; } = Player.White;

        /// <summary>
        /// The number of black pieces currently on the board.
        /// </summary>
        public int BlackScore => _score[(int)Player.Black];

        /// <summary>
        /// The number of white pieces currently on the board.
        /// </summary>
        public int WhiteScore => _score[(int)Player.White];

        /// <summary>
        /// Indicates whether the current player has a play.
        /// </summary>
        public bool HasPlay { get; private set; } = true;

        /// <summary>
        /// Indicates whether the game is over.
        /// </summary>
        public bool IsOver => _plays.Count == 0;
        
        /// <summary>
        /// Indicates whether there is a move to undo.
        /// </summary>
        public bool CanUndo => _history.Count > 0;

        /// <summary>
        /// The representation of a pass.
        /// </summary>
        public static Point Pass => new Point(-1, -1);

        /// <summary>
        ///  containing the list of available plays for the current player, or for the other player
        /// </summary>
        private List<Play> _plays;

        /// <summary>
        /// store the history of available plays
        /// </summary>
        private Stack<List<Play>> _playhistory = new Stack<List<Play>>();

        /// <summary>
        /// Front and back header cells for the perimeter list
        /// </summary>
        private BoardSquare _header = new BoardSquare(Pass);

        /// <summary>
        /// gets the number of legal plays to the board for the current player.
        /// </summary>
        public int AvailablePlayCount
        {
            get
            {
                if (HasPlay == true)
                {
                    return _plays.Count;
                }
                return 0;
            }
        }

        /// <summary>
        /// gets the score of the current player.
        /// </summary>
        public int CurrentPlayerScore
        {
            get
            {
                return _score[(int)CurrentPlayer];
            }
        }

        /// <summary>
        /// gets the score of the other player
        /// </summary>
        public int OtherPlayerScore
        {
            get
            {
                return _score[(int)OtherPlayer];
            }
        }

        /// <summary>
        ///  add a square to the perimeter list using the values already in its Next and Previous properties
        /// </summary>
        /// <param name="square">a location on the board</param>
        private void RestoreToPerimeter(BoardSquare square)
        {
            square.OnPerimeter = true;
            square.Next.Previous = square;
            square.Previous.Next = square;



        }

        /// <summary>
        /// add a square to the perimeter list without using any values already in its Next and Previous properties
        /// </summary>
        /// <param name="square">a location on the board</param>
        private void AddToPerimeter(BoardSquare square)
        {
            square.Previous=_header;
            square.Next = _header.Next;
            RestoreToPerimeter(square);
        }

        /// <summary>
        /// remove from the perimeter lis
        /// </summary>
        /// <param name="square">a location on the board</param>
        private void RemoveAtPerimeter(BoardSquare square)
        {
            square.Next.Previous = square.Previous;
            square.Previous.Next = square.Next;
            square.OnPerimeter=false;

        }

        /// <summary>
        /// opposite of a given Direction
        /// </summary>
        /// <param name="direction">Direction of a play</param>
        /// <returns>Direction giving the opposite of the given Direction</returns>
        private Direction OppositeOfDirection(Direction direction)
        {
            Direction temp = direction + 4;
            if (temp >= Direction.None)
            {
                return temp - 8;
            }
            else
            {
                return temp;
            }
        }


        /// <summary>
        /// Constructs a new Board representing a new game.
        /// </summary>
        public Board()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {

                    _board[x, y] = new BoardSquare(new Point(x,y));
                }
            }
            _header.Next = _header;
            _header.Previous = _header;
            AddToPerimeter(_board[3, 3]);
            AddPiece(Player.White, _board[3, 3]);
            AddPiece(Player.Black, _board[3, 4]);
            AddPiece(Player.Black, _board[4, 3]);
            AddPiece(Player.White, _board[4, 4]);
            _plays = AvailablePlays(CurrentPlayer);
        }

        /// <summary>
        /// Adds a piece for the given player at the given board location,
        /// updating the score.
        /// </summary>
        /// <param name="player">The player whose piece is to be added.</param>
        /// <param name="loc">The location at which to add the piece.</param>
        private void AddPiece(Player player, BoardSquare square)
        {
            square.WhichPlayer = player;
            _score[(int)player]++;
            RemoveAtPerimeter(square);
            for(Direction i = 0; i<Direction.None; i++)
            {
                Point adjacentsquare = MoveInDirection(square.Location, i, 1);
                if (GetContents(adjacentsquare) == Player.None)
                {
                   BoardSquare temp = _board[adjacentsquare.X, adjacentsquare.Y];
                    if (temp.OnPerimeter == false)
                    {
                        AddToPerimeter(temp);
                    }
                    temp.OccupiedDirections.Add(OppositeOfDirection(i));
                }
            }
        }

        /// <summary>
        /// Removes the piece at the given location, updating the score.
        /// </summary>
        /// <param name="loc">The board location of the piece to be removed.</param>
        private void RemovePiece(BoardSquare square)
        {
            _score[(int)square.WhichPlayer]--;
            square.WhichPlayer = Player.None;
            for (Direction i = 0; i < Direction.None; i++)
            {
                Point adjacentsquare = MoveInDirection(square.Location, i, 1);
                if (GetContents(adjacentsquare) == Player.None)
                {
                    BoardSquare temp = _board[adjacentsquare.X, adjacentsquare.Y];
                    temp.OccupiedDirections.RemoveAt(temp.OccupiedDirections.Count-1);
                    if (temp.OccupiedDirections.Count == 0)
                    {
                        RemoveAtPerimeter(temp);
                    }
                    
                }
            }
            RestoreToPerimeter(square);

        }

        /// <summary>
        /// find a play in the list of available plays
        /// </summary>
        /// <param name="location"> location of a play.</param>
        /// <returns>int giving the location of this play in the list of available plays,</returns>
        private int FindPlay(Point location)
        {
            if (HasPlay == true) {
                for (int i = 0; i < _plays.Count; i++)
                {
                    if (_plays[i].Location == location)
                    {
                        return i;
                    }
                }
                return -1;
            }
         return -1;
            
        }


        /// <summary>
        /// Gets the Player at the given location, or Player.Invalid if the location
        /// is off the board.
        /// </summary>
        /// <param name="p">The location.</param>
        /// <returns>The board contents at the given location.</returns>
        public Player GetContents(Point p)
        {
            if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
            {
                return _board[p.X, p.Y].WhichPlayer;
            }
            else
            {
                return Player.Invalid;
            }
        }

        /// <summary>
        /// Gets the point that is reached by moving the given distance from the given
        /// point in the given direction from the given location.
        /// </summary>
        /// <param name="loc">The starting location.</param>
        /// <param name="d">The direction in which to move.</param>
        /// <param name="dist">The distance in which to move.</param>
        /// <returns>The point reached.</returns>
        private Point MoveInDirection(Point loc, Direction d, int dist)
        {
            Point dir = _directions[(int)d];
            return new Point(loc.X + dist * dir.X, loc.Y + dist * dir.Y);
        }

        /// <summary>
        /// Gets the length of the chain of pieces belonging to the given player
        /// going the given direction from the given location. The given location
        /// is not counted in the chain.
        /// </summary>
        /// <param name="player">The player whose pieces are to belong to the chain.</param>
        /// <param name="loc">The starting location.</param>
        /// <param name="dir">The direction of the chain.</param>
        /// <returns>The length of the chain.</returns>
        private int ChainLength(Player player, Point loc, Direction dir)
        {
            int count = 0;
            Point cur;
            for (cur = MoveInDirection(loc, dir, 1); GetContents(cur) == player; cur = MoveInDirection(cur, dir, 1))
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Sets the given number of cells in the given direction from the given location
        /// to the current player. The score is updated, assuming all of these locations
        /// originally contained pieces belonging to the other player.
        /// The contents of the given location are not changed.
        /// </summary>
        /// <param name="count">The number of cells to change.</param>
        /// <param name="loc">The starting location.</param>
        /// <param name="dir">The direction to move.</param>
        private void FlipChain(int count, Point loc, Direction dir)
        {
            for (int i = 0; i < count; i++)
            {
                loc = MoveInDirection(loc, dir, 1);
                _board[loc.X, loc.Y].WhichPlayer=CurrentPlayer;
            }
            _score[(int)CurrentPlayer] += count;
            _score[(int)OtherPlayer] -= count;
        }

        /// <summary>
        /// Makes all flips that result from the current player playing at the given
        /// location, and fills in the given array with the number of flips made in each
        /// direction.
        /// </summary>
        /// <param name="loc">The location at which the play is made.</param>
        /// <param name="flips">Returns the number of flips made in each direction.</param>
        /// <returns>Whether any pieces were flipped.</returns>
        private void FlippedPieces(Play play)
        {
            for (Direction d = 0; d < Direction.None; d++)
            {
                FlipChain(play.Flipped[(int)d], play.Location, d);
            }
        }

        /// <summary>
        /// Determines whether the given player can play at the give location.
        /// </summary>
        /// <param name="player">The player making the play.</param>
        /// <param name="loc">The board location of the play.</param>
        /// <returns>Whether the given player can play at loc.</returns>
        private Play IsValidPlay(Player player, BoardSquare square)
        {
            if (_board[square.Location.X, square.Location.Y].WhichPlayer == Player.None)
            {
                int[] numberofpieces = new int[8];
                bool flips = false;
                foreach (Direction d in square.OccupiedDirections)
                {
                    
                    
                    int len = ChainLength(1 - player, square.Location, d);
                    if (len > 0 && GetContents(MoveInDirection(square.Location, d, len + 1)) == player)
                    {
                        flips = true;
                        numberofpieces[(int)d]=len;
                    }

                }
                if (flips)
                {
                    Play numflips = new Play(square.Location, numberofpieces);
                    return numflips;
                }
            }
            return null;
        }

        /// <summary>
        /// Determines whether the given player has a play.
        /// </summary>
        /// <param name="player">Player making the play.</param>
        /// <returns>Whether the given player has a play.</returns>
        private List<Play> AvailablePlays(Player player)
        {

            List<Play> plays = new List<Play>();
            BoardSquare b = _header.Next;
            while (b!=_header)
            {
                Play p = IsValidPlay(player, b);

               if (p!=null)
               {
                    plays.Add(p);
               }
                b = b.Next;
            }
            return plays;
        }
     
    

        /// <summary>
        /// Swaps the current player with the other player.
        /// </summary>
        private void SwapPlayers()
        {
            Player temp = CurrentPlayer;
            CurrentPlayer = OtherPlayer;
            OtherPlayer = temp;
        }

        /// <summary>
        /// Ends the current player's turn.
        /// </summary>
        private void EndTurn()
        {
            SwapPlayers();
            _plays = AvailablePlays(CurrentPlayer);
            if (_plays.Count==0)
            {
                _plays = AvailablePlays(OtherPlayer);
                HasPlay = false;
            }
            else
            {
                HasPlay = true;
            }
        }

        /// <summary>
        /// Tries to make a play at the given location. If the given location is NoPlay,
        /// tries to pass.
        /// </summary>
        /// <param name="loc">The location at which to play.</param>
        /// <returns>Whether the play was allowed.</returns>
        public void MakePlay(int i)
        {
            if (HasPlay == true)
            {
                Play temp = _plays[i];
                FlippedPieces(temp);
                AddPiece(CurrentPlayer, _board[temp.Location.X, temp.Location.Y]);
                _history.Push(temp);
                _playhistory.Push(_plays);
                EndTurn();
            }
            else if (i == 0)
            {
                _history.Push(new Play(Pass, new int[8]));
                SwapPlayers();
                HasPlay = true;
            }
        }

        /// <summary>
        /// Tries to make a play at the given location. by calling the other method
        /// </summary>
        /// <param name="location">location of the play</param>
        /// <returns>int giving the index of this play in the list of available plays</returns>
        public int MakePlay(Point location)
        {
            int plays = FindPlay(location);
            if (plays>=0)
            {
                MakePlay(plays);
                return plays;
            }
            else if(location==Pass && HasPlay==false && IsOver == false)
            {
                MakePlay(0);
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// Undoes the last play if a play has been made.
        /// </summary>
        public void Undo()
        {
            if (CanUndo)
            {
                Play play = _history.Pop();
                Point loc = play.Location;
                if (loc == Pass)
                {
                    HasPlay = false;
                }
                else
                {
                    HasPlay = true;
                    _plays = _playhistory.Pop();
                    RemovePiece(_board[loc.X, loc.Y]);
                    for (Direction d = 0; d < Direction.None; d++)
                    {
                        FlipChain(play.Flipped[(int)d], loc, d);
                    }
                }
                SwapPlayers();
            }
        }
    }
}

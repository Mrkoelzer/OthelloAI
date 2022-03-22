/* UserInterface.cs
 * Author: Jacob Koelzer
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// A GUI for a program that allows 2 people to play Othello.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The size of a board square in pixels.
        /// </summary>
        private const int _squareSize = 60;

        /// <summary>
        /// The diameter of a piece in pixels.
        /// </summary>
        private const int _pieceDiameter = 55;

        /// <summary>
        /// The margin between board squares in pixels.
        /// </summary>
        private const int _margin = 1;

        /// <summary>
        /// The Othello board.
        /// </summary>
        private Board _board = new Board();

        /// <summary>
        /// The brush to use to fill a white piece.
        /// </summary>
        private Brush _whiteBrush = new SolidBrush(Color.WhiteSmoke);

        /// <summary>
        /// The brush to use to fill a black piece.
        /// </summary>
        private Brush _blackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// storing the dialog for setting up a new game
        /// </summary>
        private NewGameDialog _newGame = new NewGameDialog();

        /// <summary>
        /// storing the computer player if there is one
        /// </summary>
        private ComputerPlayer _computerPlayer;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            DrawBoard();
            UpdateStatus();


        }

        /// <summary>
        /// Sets up the board.
        /// </summary>
        private void DrawBoard()
        {
            // The width and height of the board must be the sizes of
            // 8 squares, plus the margins between
            uxBoard.Width = (_squareSize + 2 * _margin) * 8;
            uxBoard.Height = uxBoard.Width;

            // Sets the padding between the squares. Because the background
            // color of the panel is black, these will show as black lines.
            Padding p = new Padding();
            p.Left = p.Right = p.Top = p.Bottom = _margin;

            // Add the squares. When adding controls to a FlowLayoutPanel, by
            // default, they are added left to right. When there is no more
            // horizontal room, the layout continues below these controls, starting
            // from the left edge. Therefore, we set up nested loops, with the
            // outer loop laying out the rows, and the inner loop laying out the
            // squares within a row.
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    PictureBox square = new PictureBox(); // An individual square.
                    square.BackColor = Color.DarkSeaGreen;
                    square.Width = square.Height = _squareSize;
                    square.Margin = p;
                    square.BorderStyle = BorderStyle.FixedSingle;

                    // We will use the Name property of a PictureBox to store the
                    // location of the square. We use a string of the form "x,y".
                    square.Name = x + "," + y;

                    // Sets the ToolTip so that when the mouse enters a square, its location
                    // is displayed.
                    uxSquareLocation.SetToolTip(square, square.Name);

                    // Add an event handler to handle a click on a square.
                    square.Click += new EventHandler(BoardSquare_Click);

                    // Add an event handler to handle a Paint event. This will be
                    // called every time the PictureBox needs to be redrawn. It will
                    // contain code to draw any piece on that square.
                    square.Paint += new PaintEventHandler(BoardSquare_Paint);
                    uxBoard.Controls.Add(square); // Add to the panel.
                }
            }

            // The Form's AutoSize property is set to true. This causes the form to
            // expand to hold the FlowLayoutPanel, whose size was set above. However,
            // the resizing doesn't take into account the status bar. We therefore
            // explicitly add its height to the form's height.
            Size = new Size(Width, Height + uxStatusBar.Height);
        }

        /// <summary>
        /// Converts a string of the form "x,y", where x and y are single digits, to
        /// a Point.
        /// </summary>
        /// <param name="squareName">The string to convert.</param>
        /// <returns>The Point representation of the given string.</returns>
        private Point GetPoint(string squareName)
        {
            // For the x-coordinate, use the substring starting at location 0 and having
            // length 1.
            int x = Convert.ToInt32(squareName.Substring(0, 1)); 

            // For the y-coordinate, use the substring starting at location 2 and having
            // length 1.
            int y = Convert.ToInt32(squareName.Substring(2, 1));
            return new Point(x, y);
        }

        /// <summary>
        /// Handles a Paint event on one of the board squares. Draws any piece that belongs
        /// on this square.
        /// </summary>
        /// <param name="sender">The PictureBox that needs redrawing.</param>
        /// <param name="e">Arguments for the Paint event.</param>
        private void BoardSquare_Paint(object sender, PaintEventArgs e)
        {
            PictureBox square = (PictureBox)sender;
            Point p = GetPoint(square.Name); // Convert the Name property to a Point.
            Graphics g = e.Graphics; // The graphics context on which to draw.

            // Depending on the contents of the corresponding square on the Board object,
            // we may need to draw a piece.
            switch (_board.GetContents(p)) 
            {
                case Player.Black:
                    // Draw a black piece.
                    g.FillEllipse(_blackBrush, _margin, _margin, _pieceDiameter, _pieceDiameter);
                    break;
                case Player.White:
                    // Draw a white piece.
                    g.FillEllipse(_whiteBrush, _margin, _margin, _pieceDiameter, _pieceDiameter);
                    break;
                default: // No piece - no need to draw anything.
                    break;
            }
        }

        /// <summary>
        /// Handles a Click event on a board square.
        /// </summary>
        /// <param name="sender">The PictureBox that was clicked.</param>
        /// <param name="e"></param>
        private void BoardSquare_Click(object sender, EventArgs e)
        {
            Point square = GetPoint(((PictureBox)sender).Name);
            MakePlay(square);
        }

        /// <summary>
        /// Updates all of the information on the GUI.
        /// </summary>
        private void UpdateStatus()
        {
            uxBlackScore.Text = _board.BlackScore.ToString();
            uxWhiteScore.Text = _board.WhiteScore.ToString();
            uxBoard.Enabled = !_board.IsOver;
            uxPass.Enabled = !_board.IsOver;
            ///uxUndo.Enabled = _board.CanUndo;

            if (_computerPlayer == null)
            {
                uxUndo.Enabled = _board.CanUndo;
            }
            else
            {
                uxUndo.Enabled = false;
            }


            if (_board.IsOver)
            {
                if (_board.BlackScore > _board.WhiteScore)
                {
                    uxStatus.Text = "Black wins!";
                }
                else if (_board.WhiteScore > _board.BlackScore)
                {
                    uxStatus.Text = "White wins!";
                }
                else
                {
                    uxStatus.Text = "The game is drawn.";
                }
            }
            else if (_board.CurrentPlayer == Player.Black)
            {
                uxStatus.Text = "Black's Turn";
            }
            else
            {
                uxStatus.Text = "White's Turn";
            }
            foreach (Control c in uxBoard.Controls)
            {
                c.Invalidate();
            }
            Update();
        }

        /// <summary>
        /// Tries to make a play at the given location. If the play is invalid, tells wether the computer needs to be played
        /// shows an appropriate message.
        /// </summary>
        /// <param name="play">The location of the play.</param>
        private void MakePlay(Point play)
        {

            if (_computerPlayer == null)
            {
                if (_board.MakePlay(play)>=0)
                {
                    UpdateStatus();
                }
                else
                {
                    MessageBox.Show("Invalid Move.");
                }
            }
            else if (_newGame.Computervscomputer == true)
            {
                UpdateStatus();
                if (_board.IsOver == false)
                {
                    _computerPlayer.MakePlay();
                    UpdateStatus();
                    Point square = GetPoint("0,0");
                    MakePlay(square);
                }
            }
            else
            {

                if (_computerPlayer.MakeOpponentPlay(play) == true)
                {
                    UpdateStatus();
                    if (_board.IsOver == false)
                    {
                        _computerPlayer.MakePlay();
                        UpdateStatus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Move.");
                }
            }
           
        }

        /// <summary>
        /// Handles a Click event on the "New Game" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        /// <summary>
        /// Handles a Click event on the Pass button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPass_Click(object sender, EventArgs e)
        {
            MakePlay(Board.Pass);
        }

        /// <summary>
        /// Handles a Click event on the Undo button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUndo_Click(object sender, EventArgs e)
        {
            _board.Undo();
            UpdateStatus();
        }

        /// <summary>
        /// responsible for displaying the setup dialog and starting a new game.
        /// </summary>
        /// <returns>value indicates whether the user actually set up a new game or canceled the dialog</returns>
        private bool NewGame()
        {
           if(_newGame.ShowDialog() == DialogResult.OK)
            {
                _board = new Board();
                if (_newGame.NoComputerPlayer == true)
                {
                    _computerPlayer = null;
                    UpdateStatus();
                }
                else
                {
                    _computerPlayer = new ComputerPlayer(_newGame.Level*500, _board);
                    Visible = true;
                    Focus();
                    UpdateStatus();
                    if (_newGame.ComputerFirst == true)
                    {
                        _computerPlayer.MakePlay();
                        UpdateStatus();
                    }
                    if (_newGame.Computervscomputer == true)
                    {
                         _computerPlayer.MakePlay();
                         UpdateStatus();
                        Point square = GetPoint("0,0");
                        MakePlay(square);
                    }
                }
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// call the NewGame method, and if the user doesn't click the "OK" button 
        /// (as indicated by the value returned by the method), you should terminate the program with the following statement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            if(NewGame()== false)
            {
                Application.Exit();
            }
        }
    }
}

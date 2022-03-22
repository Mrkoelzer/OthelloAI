/* Common.cs
 * Author: Jacob Koelzer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;

namespace Othello.Tests
{
    /// <summary>
    /// Common data and methods for the unit test classes.
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// A sequence used to test various cases at the beginning of a game.
        /// </summary>
        public static Point[] ShortSequence => new Point[]
        {
            new Point(2, 3), new Point(2, 2), new Point(3, 2), new Point(4, 2),
                new Point(5, 4), new Point(5, 5), new Point(5, 6), new Point(6, 6), new Point(7, 6)
        };

        /// <summary>
        /// A sequence of plays ending in a Pass.
        /// </summary>
        public static Point[] PassSequence => new Point[]
        {
            new Point(5, 4), new Point(5, 3), new Point(3, 2), new Point(3, 5), new Point(5, 2),
            new Point(3, 1), new Point(2, 5), new Point(4, 2), new Point(3, 0), new Point(1, 5),
            new Point(5, 5), new Point(2, 1), new Point(2, 2), new Point(4, 5), new Point(4, 6),
            new Point(2, 3), new Point(1, 2), new Point(6, 5), new Point(5, 6), new Point(5, 7),
            new Point(3, 7), new Point(5, 1), new Point(7, 6), new Point(7, 4), new Point(6, 1),
            new Point(7, 1), new Point(5, 0), new Point(1, 0), new Point(3, 6), new Point(0, 3),
            new Point(1, 6), new Point(1, 3), new Point(7, 2), new Point(2, 7), new Point(6, 4),
            new Point(4, 7), new Point(7, 0), new Point(1, 7), new Point(1, 1), new Point(6, 3),
            new Point(2, 4), new Point(2, 0), new Point(7, 5), new Point(4, 0), new Point(0, 0),
            new Point(2, 6), new Point(6, 7), new Point(6, 6), new Point(7, 3), new Point(0, 1),
            new Point(0, 5), new Point(6, 2), new Point(0, 2), new Point(0, 6), new Point(1, 4),
            new Point(0, 4), new Point(0, 7), new Point(6, 0), new Point(7, 7), Board.Pass
        };

        /// <summary>
        /// The white pieces after PassSequence is played.
        /// </summary>
        public static Point[] WhiteAfterPassSequence => new Point[]
        {
            new Point(6, 0), new Point(2, 1), new Point(3, 1), new Point(5, 1), new Point(6, 1),
            new Point(3, 2), new Point(4, 2), new Point(5, 2), new Point(6, 2), new Point(1, 3),
            new Point(5, 3), new Point(6, 3), new Point(1, 4), new Point(2, 4), new Point(3, 4),
            new Point(5, 4), new Point(6, 4), new Point(1, 5), new Point(3, 5), new Point(6, 5),
            new Point(2, 6), new Point(3, 6), new Point(4, 6), new Point(5, 6)
        };

        /// <summary>
        /// The black pieces after PassSequence is played.
        /// </summary>
        public static Point[] BlackAfterPassSequence => new Point[]
        {
            new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0),
            new Point(5, 0), new Point(7, 0), new Point(0, 1), new Point(1, 1), new Point(7, 1),
            new Point(0, 2), new Point(1, 2), new Point(2, 2), new Point(7, 2), new Point(0, 3),
            new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(7, 3), new Point(0, 4),
            new Point(4, 4), new Point(7, 4), new Point(0, 5), new Point(2, 5), new Point(4, 5),
            new Point(5, 5), new Point(7, 5), new Point(0, 6), new Point(1, 6), new Point(6, 6),
            new Point(7, 6), new Point(0, 7), new Point(1, 7), new Point(2, 7), new Point(3, 7),
            new Point(4, 7), new Point(5, 7), new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// A game that white wins.
        /// </summary>
        public static Point[] WhiteWinSequence => new Point[]
        {
            new Point(4, 5), new Point(5, 5), new Point(6, 5), new Point(5, 3), new Point(3, 2),
            new Point(2, 5), new Point(6, 3), new Point(5, 6), new Point(4, 7), new Point(5, 2),
            new Point(3, 5), new Point(7, 4), new Point(7, 3), new Point(4, 6), new Point(6, 1),
            new Point(2, 2), new Point(1, 1), new Point(7, 0), new Point(1, 5), new Point(6, 4),
            new Point(5, 7), new Point(3, 7), new Point(2, 7), new Point(4, 2), new Point(6, 2),
            new Point(3, 1), new Point(4, 0), new Point(7, 1), new Point(7, 5), new Point(5, 4),
            new Point(2, 3), new Point(2, 6), new Point(6, 6), new Point(3, 0), new Point(5, 1),
            new Point(1, 3), new Point(2, 4), new Point(1, 6), new Point(1, 2), new Point(0, 5),
            new Point(0, 2), new Point(6, 0), new Point(4, 1), new Point(7, 2), new Point(0, 7),
            new Point(1, 7), new Point(5, 0), new Point(6, 7), new Point(7, 6), new Point(2, 1),
            new Point(2, 0), new Point(7, 7), new Point(0, 6), new Point(1, 0), new Point(3, 6),
            new Point(0, 3), new Point(0, 4), new Point(0, 1), new Point(0, 0), new Point(1, 4)
        };

        /// <summary>
        /// The white pieces after WhiteWinSequence is played.
        /// </summary>
        public static Point[] WhiteWinWhitePieces => new Point[]
        {
            new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
            new Point(6, 0), new Point(7, 0), new Point(2, 1), new Point(6, 1), new Point(7, 1),
            new Point(1, 2), new Point(3, 2), new Point(7, 2), new Point(1, 3), new Point(2, 3),
            new Point(3, 3), new Point(4, 3), new Point(6, 3), new Point(7, 3), new Point(1, 4),
            new Point(2, 4), new Point(3, 4), new Point(4, 4), new Point(5, 4), new Point(6, 4),
            new Point(7, 4), new Point(1, 5), new Point(2, 5), new Point(5, 5), new Point(6, 5),
            new Point(7, 5), new Point(1, 6), new Point(3, 6), new Point(6, 6), new Point(7, 6),
            new Point(1, 7), new Point(2, 7), new Point(3, 7), new Point(4, 7), new Point(5, 7),
            new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// The black pieces after WhiteWinSequence is played.
        /// </summary>
        public static Point[] WhiteWinBlackPieces => new Point[]
        {
            new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(3, 1), new Point(4, 1),
            new Point(5, 1), new Point(0, 2), new Point(2, 2), new Point(4, 2), new Point(5, 2),
            new Point(6, 2), new Point(0, 3), new Point(5, 3), new Point(0, 4), new Point(0, 5),
            new Point(3, 5), new Point(4, 5), new Point(0, 6), new Point(2, 6), new Point(4, 6),
            new Point(5, 6), new Point(0, 7)
        };

        /// <summary>
        /// A game that black wins with the board not completely filled.
        /// </summary>
        public static Point[] BlackWinSequence => new Point[]
        {
            new Point(4, 5), new Point(5, 3), new Point(6, 2), new Point(5, 5), new Point(3, 5),
            new Point(2, 5), new Point(4, 6), new Point(5, 6), new Point(2, 6), new Point(6, 3),
            new Point(3, 2), new Point(7, 1), new Point(5, 2), new Point(3, 6), new Point(3, 7),
            new Point(2, 4), new Point(6, 7), new Point(3, 1), new Point(3, 0), new Point(1, 6),
            new Point(1, 5), new Point(5, 4), new Point(7, 3), new Point(1, 3), new Point(2, 3),
            new Point(6, 6), new Point(0, 3), new Point(2, 1), new Point(2, 7), new Point(4, 1),
            new Point(1, 0), new Point(5, 1), new Point(1, 7), new Point(1, 2), new Point(7, 6),
            new Point(7, 2), new Point(5, 0), new Point(4, 0), new Point(0, 1), new Point(7, 4),
            new Point(6, 1), new Point(1, 1), new Point(6, 4), new Point(0, 2), new Point(1, 4),
            new Point(0, 0), Board.Pass, new Point(4, 2), new Point(2, 0), new Point(5, 7),
            new Point(2, 2), new Point(7, 5), new Point(7, 7), new Point(0, 6), new Point(0, 5),
            new Point(6, 0), new Point(7, 0), new Point(0, 4), new Point(4, 7), new Point(6, 5)
        };

        /// <summary>
        /// The white pieces after BlackWinSequence is played.
        /// </summary>
        public static Point[] BlackWinWhitePieces => new Point[]
        {
            new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(4, 1), new Point(5, 1),
            new Point(0, 2), new Point(4, 2), new Point(6, 2), new Point(0, 3), new Point(3, 3),
            new Point(5, 3), new Point(0, 4), new Point(1, 4), new Point(2, 4), new Point(5, 4),
            new Point(6, 4), new Point(0, 5), new Point(1, 5), new Point(3, 5), new Point(4, 5),
            new Point(5, 5), new Point(6, 5), new Point(0, 6), new Point(2, 6), new Point(5, 6)
        };

        /// <summary>
        /// The black pieces after BlackWinSequence is played.
        /// </summary>
        public static Point[] BlackWinBlackPieces => new Point[]
        {
            new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
            new Point(6, 0), new Point(7, 0), new Point(2, 1), new Point(3, 1), new Point(6, 1),
            new Point(7, 1), new Point(1, 2), new Point(2, 2), new Point(3, 2), new Point(5, 2),
            new Point(7, 2), new Point(1, 3), new Point(2, 3), new Point(4, 3), new Point(6, 3),
            new Point(7, 3), new Point(3, 4), new Point(4, 4), new Point(7, 4), new Point(2, 5),
            new Point(7, 5), new Point(1, 6), new Point(3, 6), new Point(4, 6), new Point(6, 6),
            new Point(7, 6), new Point(1, 7), new Point(2, 7), new Point(3, 7), new Point(4, 7),
            new Point(5, 7), new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// A game that ends in a tie.
        /// </summary>
        public static Point[] TieSequence => new Point[]
        {
            new Point(4, 5), new Point(3, 5), new Point(2, 4), new Point(5, 5), new Point(4, 6),
            new Point(1, 5), new Point(6, 4), new Point(3, 6), new Point(2, 6), new Point(5, 4),
            new Point(2, 2), new Point(5, 2), new Point(6, 3), new Point(4, 7), new Point(3, 7),
            new Point(1, 7), new Point(2, 5), new Point(2, 7), new Point(1, 6), new Point(6, 6),
            new Point(0, 5), new Point(7, 3), new Point(6, 5), new Point(3, 2), new Point(5, 3),
            new Point(5, 6), new Point(7, 7), new Point(1, 2), new Point(1, 3), new Point(7, 5),
            new Point(4, 1), new Point(7, 6), new Point(6, 7), new Point(2, 3), new Point(1, 1),
            new Point(6, 1), new Point(1, 4), new Point(5, 7), new Point(4, 2), new Point(0, 6),
            new Point(0, 7), new Point(3, 1), new Point(6, 2), new Point(0, 1), new Point(4, 0),
            new Point(0, 0), new Point(7, 0), new Point(7, 1), new Point(0, 2), new Point(6, 0),
            new Point(1, 0), new Point(3, 0), new Point(5, 0), new Point(0, 4), new Point(0, 3),
            new Point(7, 2), new Point(2, 0), new Point(7, 4), new Point(2, 1), new Point(5, 1)
        };

        /// <summary>
        /// The white pieces after TieSequence is played.
        /// </summary>
        public static Point[] TieWhitePieces => new Point[]
        {
            new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 1),
            new Point(4, 1), new Point(5, 1), new Point(6, 1), new Point(7, 1), new Point(4, 2),
            new Point(5, 2), new Point(6, 2), new Point(7, 2), new Point(3, 3), new Point(5, 3),
            new Point(6, 3), new Point(7, 3), new Point(2, 4), new Point(3, 4), new Point(4, 4),
            new Point(5, 4), new Point(6, 4), new Point(7, 4), new Point(1, 5), new Point(4, 5),
            new Point(5, 5), new Point(6, 5), new Point(7, 5), new Point(2, 6), new Point(5, 6),
            new Point(6, 6), new Point(7, 6)
        };

        /// <summary>
        /// The black pieces after TieSequence is played.
        /// </summary>
        public static Point[] TieBlackPieces => new Point[]
        {
            new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0),
            new Point(6, 0), new Point(7, 0), new Point(0, 2), new Point(1, 2), new Point(2, 2),
            new Point(3, 2), new Point(0, 3), new Point(1, 3), new Point(2, 3), new Point(4, 3),
            new Point(0, 4), new Point(1, 4), new Point(0, 5), new Point(2, 5), new Point(3, 5),
            new Point(0, 6), new Point(1, 6), new Point(3, 6), new Point(4, 6), new Point(0, 7),
            new Point(1, 7), new Point(2, 7), new Point(3, 7), new Point(4, 7), new Point(5, 7),
            new Point(6, 7), new Point(7, 7)
        };

        /// <summary>
        /// A game in which Black plays last and wins.
        /// </summary>
        public static Point[] BlackWinBlackLast => new Point[]
        {
            new Point(5, 4), new Point(5, 3), new Point(3, 2), new Point(3, 5), new Point(5, 2), 
            new Point(3, 1), new Point(2, 5), new Point(4, 2), new Point(3, 0), new Point(1, 5), 
            new Point(5, 5), new Point(2, 1), new Point(2, 2), new Point(4, 5), new Point(4, 6), 
            new Point(2, 3), new Point(1, 2), new Point(6, 5), new Point(5, 6), new Point(5, 7), 
            new Point(3, 7), new Point(5, 1), new Point(7, 6), new Point(7, 4), new Point(6, 1), 
            new Point(7, 1), new Point(5, 0), new Point(1, 0), new Point(3, 6), new Point(0, 3), 
            new Point(1, 6), new Point(1, 3), new Point(7, 2), new Point(2, 7), new Point(6, 4), 
            new Point(4, 7), new Point(7, 0), new Point(1, 7), new Point(1, 1), new Point(6, 3), 
            new Point(2, 4), new Point(2, 0), new Point(7, 5), new Point(4, 0), new Point(0, 0), 
            new Point(2, 6), new Point(6, 7), new Point(6, 6), new Point(7, 3), new Point(0, 1), 
            new Point(0, 5), new Point(6, 2), new Point(0, 2), new Point(0, 6), new Point(1, 4), 
            new Point(0, 4), new Point(0, 7), new Point(6, 0), new Point(7, 7), Board.Pass, 
            new Point(4, 1)
        };

        /// <summary>
        /// A game in which Black plays last and loses.
        /// </summary>
        public static Point[] WhiteWinsBlackLast => new Point[]
        {
            new Point(4, 5), new Point(3, 5), new Point(2, 5), new Point(5, 3), new Point(3, 2),
            new Point(2, 3), new Point(1, 4), new Point(5, 5), new Point(6, 2), new Point(6, 3),
            new Point(6, 4), new Point(7, 1), new Point(4, 6), new Point(3, 1), new Point(2, 2),
            new Point(1, 3), new Point(1, 2), new Point(0, 2), new Point(1, 1), new Point(2, 4),
            new Point(0, 4), new Point(5, 7), new Point(4, 7), new Point(0, 3), new Point(4, 1),
            new Point(2, 1), new Point(5, 2), new Point(5, 1), new Point(3, 6), new Point(5, 6),
            new Point(6, 5), new Point(6, 7), new Point(6, 6), new Point(1, 5), new Point(1, 0),
            new Point(3, 7), new Point(1, 6), new Point(0, 6), new Point(4, 2), new Point(0, 7),
            new Point(2, 0), new Point(7, 4), new Point(5, 0), new Point(5, 4), new Point(0, 1),
            new Point(4, 0), new Point(3, 0), new Point(7, 6), new Point(7, 7), new Point(7, 5),
            new Point(7, 3), new Point(7, 2), new Point(0, 5), new Point(0, 0), new Point(2, 7),
            new Point(6, 0), new Point(1, 7), new Point(2, 6), new Point(7, 0), Board.Pass,
            new Point(6, 1)
        };

        /// <summary>
        /// A game in which Black plays last and draws.
        /// </summary>
        public static Point[] TieBlackLast => new Point[]
        {
            new Point(3, 2), new Point(2, 2), new Point(1, 2), new Point(5, 3), new Point(5, 4),
            new Point(3, 1), new Point(6, 3), new Point(5, 5), new Point(3, 0), new Point(6, 2), 
            new Point(4, 5), new Point(1, 1), new Point(5, 2), new Point(5, 1), new Point(4, 1), 
            new Point(3, 5), new Point(5, 0), new Point(4, 0), new Point(4, 6), new Point(3, 7), 
            new Point(5, 6), new Point(6, 5), new Point(3, 6), new Point(2, 0), new Point(7, 6), 
            new Point(7, 5), new Point(2, 1), new Point(7, 7), new Point(7, 2), new Point(4, 7), 
            new Point(6, 1), new Point(2, 3), new Point(1, 0), new Point(7, 0), new Point(6, 0), 
            new Point(7, 4), new Point(6, 6), new Point(4, 2), new Point(7, 3), new Point(2, 4), 
            new Point(6, 4), new Point(7, 1), new Point(2, 5), new Point(0, 0), new Point(1, 3), 
            new Point(1, 5), new Point(0, 1), new Point(5, 7), new Point(1, 4), new Point(0, 5), 
            new Point(0, 3), new Point(0, 2), new Point(2, 6), new Point(1, 7), new Point(1, 6), 
            new Point(0, 6), new Point(0, 4), Board.Pass, new Point(2, 7), Board.Pass, 
            new Point(6, 7), Board.Pass, new Point(0, 7)
        };

        /// <summary>
        /// A sequence leading to a position in which Black has two moves. (2, 7) draws and (6, 7)
        /// loses.
        /// </summary>
        public static Point[] TwoOutcomeSequence => new Point[]
        {
            new Point(3, 2), new Point(2, 2), new Point(1, 2), new Point(5, 3), new Point(5, 4),
            new Point(3, 1), new Point(6, 3), new Point(5, 5), new Point(3, 0), new Point(6, 2),
            new Point(4, 5), new Point(1, 1), new Point(5, 2), new Point(5, 1), new Point(4, 1),
            new Point(3, 5), new Point(5, 0), new Point(4, 0), new Point(4, 6), new Point(3, 7),
            new Point(5, 6), new Point(6, 5), new Point(3, 6), new Point(2, 0), new Point(7, 6),
            new Point(7, 5), new Point(2, 1), new Point(7, 7), new Point(7, 2), new Point(4, 7),
            new Point(6, 1), new Point(2, 3), new Point(1, 0), new Point(7, 0), new Point(6, 0),
            new Point(7, 4), new Point(6, 6), new Point(4, 2), new Point(7, 3), new Point(2, 4),
            new Point(6, 4), new Point(7, 1), new Point(2, 5), new Point(0, 0), new Point(1, 3),
            new Point(1, 5), new Point(0, 1), new Point(5, 7), new Point(1, 4), new Point(0, 5),
            new Point(0, 3), new Point(0, 2), new Point(2, 6), new Point(1, 7), new Point(1, 6),
            new Point(0, 6), new Point(0, 4), Board.Pass, new Point(0, 7), Board.Pass
        };

        /// <summary>
        /// This method is used by several of the tests to check that the state of the
        /// board is correct.
        /// </summary>
        /// <param name="b">The board to check.</param>
        /// <param name="correctWhite">The expected locations of the white pieces.</param>
        /// <param name="correctBlack">The expected locations of hte black pieces.</param>
        /// <param name="current">The expected current player.</param>
        /// <param name="hasPlay">The expected value of HasPlay.</param>
        /// <param name="isOver">The expected value of IsOver.</param>
        /// <param name="canUndo">The expected value of CanUndo.</param>
        /// <param name="avail">The expected value of AvailablePlayCount.</param>
        /// <param name="curIsBlack">Indicates whether the current player is Black.</param>
        public static void TestContents(Board b, Point[] correctWhite, Point[] correctBlack,
            Player current, bool hasPlay, bool isOver, bool canUndo, int avail, bool curIsBlack)
        {
            List<Point> whitePieces = new List<Point>();
            List<Point> blackPieces = new List<Point>();
            bool valid = GetBoardContents(b, blackPieces, whitePieces);
            int curScore = correctWhite.Length;
            int otherScore = correctBlack.Length;
            if (curIsBlack)
            {
                curScore = correctBlack.Length;
                otherScore = correctWhite.Length;
            }
            Assert.Multiple(() =>
            {
                Assert.That(valid, Is.True); // No values other than White, Black, or None
                Assert.That(whitePieces, Is.EqualTo(correctWhite), "The set of white pieces is incorrect.");
                Assert.That(blackPieces, Is.EqualTo(correctBlack), "The set of black pieces is incorrect.");
                Assert.That(b.WhiteScore, Is.EqualTo(correctWhite.Length), "WhiteScore is incorrect.");
                Assert.That(b.BlackScore, Is.EqualTo(correctBlack.Length), "BlackScore is incorrect.");
                Assert.That(b.CurrentPlayer, Is.EqualTo(current), "CurrentPlayer is incorrect.");
                Assert.That(b.OtherPlayer, Is.EqualTo(1 - current), "OtherPlayer is incorrect.");
                Assert.That(b.HasPlay, Is.EqualTo(hasPlay), "HasPlay is incorrect.");
                Assert.That(b.IsOver, Is.EqualTo(isOver), "IsOver is incorrect.");
                Assert.That(b.CanUndo, Is.EqualTo(canUndo), "CanUndo is incorrect.");
                Assert.That(b.AvailablePlayCount, Is.EqualTo(avail), "AvailablePlayCount is incorrect.");
                Assert.That(b.CurrentPlayerScore, Is.EqualTo(curScore), "CurrentPlayerScore is incorrect.");
                Assert.That(b.OtherPlayerScore, Is.EqualTo(otherScore), "OtherPlayerScore is incorrect.");
            });
        }

        /// <summary>
        /// Places the entire contents of the given board into the given lists.
        /// If the two lists are the same list, the locations of all pieces will be placed into it.
        /// The lists will be ordered, first by Y, then by X.
        /// </summary>
        /// <param name="b">The board.</param>
        /// <param name="blackPieces">The list in which the locations of the black 
        /// pieces are to be placed.</param>
        /// <param name="whitePieces">The list in which the locations of the white
        /// pieces are to be placed.</param>
        /// <returns>Whether the board's contents are all valid.</returns>
        public static bool GetBoardContents(Board b, List<Point> blackPieces, List<Point> whitePieces)
        {
            bool valid = true;

            // Get the locations of all the pieces.
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Point loc = new Point(x, y);
                    switch (b.GetContents(loc))
                    {
                        case Player.White:
                            whitePieces.Add(loc);
                            break;
                        case Player.Black:
                            blackPieces.Add(loc);
                            break;
                        case Player.None:
                            break;
                        default:
                            valid = false; // A value other than White, Black, or None was found.
                            break;
                    }
                }
            }
            return valid;
        }

        /// <summary>
        /// Makes the play at the given index on the given board, and returns
        /// the location at which the play was made. If the play was a Pass, 
        /// returns Board.Pass.
        /// </summary>
        /// <param name="b">The board.</param>
        /// <param name="p">The play index.</param>
        /// <returns>The location of the play, or Board.Pass if the play was 
        /// a Pass.</returns>
        public static Point GetPlayLocation(Board b, int p)
        {
            List<Point> before = new List<Point>();
            GetBoardContents(b, before, before);
            b.MakePlay(p);
            List<Point> after = new List<Point>();
            GetBoardContents(b, after, after);
            for (int i = 0; i < before.Count; i++)
            {
                if (after[i] != before[i])
                {
                    return after[i];
                }
            }
            if (after.Count > before.Count)
            {
                return after[after.Count - 1];
            }
            else
            {
                return Board.Pass;
            }
        }

        /// <summary>
        /// This method is used by several tests to construct a new board and
        /// make a given sequence of plays on it.
        /// </summary>
        /// <param name="plays">The plays.</param>
        /// <param name="n">The number of plays to make from the given array.</param>
        /// <returns>The resulting board.</returns>
        public static Board PlaySequence(Point[] plays, int n)
        {
            Board b = new Board();
            for (int i = 0; i < n; i++)
            {
                b.MakePlay(plays[i]);
            }
            return b;
        }

        /// <summary>
        /// Gets the available play list after a sequence of plays are made.
        /// If there are no available plays but the game is not over, the
        /// only play returned will be Board.Pass.
        /// </summary>
        /// <param name="plays">The sequence of plays.</param>
        /// <param name="n">The number of plays to make from the beginning of
        /// the sequence.</param>
        /// <returns>The available play list.</returns>
        public static List<Point> GetAvailableAfter(Point[] plays, int n)
        {
            List<Point> avail = new List<Point>();
            int i = 0;
            Board b;
            int listLen;
            do
            {
                b = PlaySequence(plays, n);
                listLen = b.AvailablePlayCount;
                if (b.IsOver)
                {
                    return avail;
                }
                avail.Add(GetPlayLocation(b, i));
                i++;
            } while (i < listLen);
            return avail;
        }
        
        /// <summary>
        /// Tests that the available list is the same after the given play as it is after
        /// the given play, followed by another play, two Undos, and the given play. The play is made
        /// to the initial board.
        /// </summary>
        /// <param name="play1">The first play.</param>
        /// <param name="play2">The second play.</param>
        public static void TestAvailableAfterPlayUndoRestore(Point play1, Point play2)
        {
            List<Point> avail = GetAvailableAfter(new Point[] { play1 }, 1); // The available play list after play1
            List<int> pos = new List<int>(); // The position of each available play in the available list after play1, play2, undo, undo, play1
            List<int> nums = new List<int>(); // The integers 0, 1, ...
            for (int i = 0; i < avail.Count; i++)
            {
                Board b = new Board();
                b.MakePlay(play1);
                b.MakePlay(play2);
                b.Undo();
                b.Undo();
                b.MakePlay(play1);
                pos.Add(b.MakePlay(avail[i]));
                nums.Add(i);
            }
            Assert.That(pos, Is.EqualTo(nums));
        }

        /// <summary>
        /// Makes the given sequence of plays, then runs RandomSimulate; repeats until the
        /// given result is obtained.
        /// </summary>
        /// <param name="plays">The sequence of plays to make before the random simulation.</param>
        /// <param name="n">The number of plays to make before the random simulation.</param>
        /// <param name="result">The desired result.</param>
        public static void SimulateUntilDesiredResult(Point[] plays, int n, float result)
        {
            Board b;
            do
            {
                b = PlaySequence(plays, n);
            } while (GameTreeNode.RandomSimulate(b) != result);
        }

        /// <summary>
        /// Repeatedly simulates a game from the beginning for 100 simulations until this
        /// results in the best child being the one with the given play index. Because all
        /// four plays from the initial position are symmetric, each is equally good; hence,
        /// each is equally likely to be the best.
        /// </summary>
        /// <param name="result">The desired best play index.</param>
        public static void SimulateUntilDesiredResult(int result)
        {
            Board b = new Board();
            GameTreeNode t;
            do
            {
                t = new GameTreeNode(-1);
                for (int i = 0; i < 100; i++)
                {
                    t.Simulate(b);
                }
            } while (t.GetBestChild().Play != result);
        }
    }
}

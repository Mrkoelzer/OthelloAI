/* OthelloTester.cs
 * Author: Jacob Koelzer
 */
using System;
using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace Othello.Tests
{
    /// <summary>
    /// A suite of tests for the Board class in Ksu.Cis300.Othello.
    /// </summary>
    [TestFixture]
    public class BoardTests
    {
        /// <summary>
        /// A sequence used to test various cases at the beginning of a game.
        /// </summary>
        private static Point[] _shortSequence = Common.ShortSequence;

        /// <summary>
        /// A sequence of plays ending in a Pass.
        /// </summary>
        private static Point[] _passSequence = Common.PassSequence;

        /// <summary>
        /// The white pieces after _passSequence is played.
        /// </summary>
        private static Point[] _whiteAfterPassSequence = Common.WhiteAfterPassSequence;

        /// <summary>
        /// The black pieces after _passSequence is played.
        /// </summary>
        private static Point[] _blackAfterPassSequence = Common.BlackAfterPassSequence;

        /// <summary>
        /// A game that white wins.
        /// </summary>
        private static Point[] _whiteWinSequence = Common.WhiteWinSequence;

        /// <summary>
        /// The white pieces after _whiteWinSequence is played.
        /// </summary>
        private static Point[] _whiteWinWhitePieces = Common.WhiteWinWhitePieces;

        /// <summary>
        /// The black pieces after _whiteWinSequence is played.
        /// </summary>
        private static Point[] _whiteWinBlackPieces = Common.WhiteWinBlackPieces;

        /// <summary>
        /// A game that black wins with the board not completely filled.
        /// </summary>
        private static Point[] _blackWinSequence = Common.BlackWinSequence;

        /// <summary>
        /// The white pieces after _blackWinSequence is played.
        /// </summary>
        private static Point[] _blackWinWhitePieces = Common.BlackWinWhitePieces;

        /// <summary>
        /// The black pieces after _blackWinSequence is played.
        /// </summary>
        private static Point[] _blackWinBlackPieces = Common.BlackWinBlackPieces;

        /// <summary>
        /// A game that ends in a tie.
        /// </summary>
        private static Point[] _tieSequence = Common.TieSequence;

        /// <summary>
        /// The white pieces after _tieSequence is played.
        /// </summary>
        private static Point[] _tieWhitePieces = Common.TieWhitePieces;

        /// <summary>
        /// The black pieces after _tieSequence is played.
        /// </summary>
        private static Point[] _tieBlackPieces = Common.TieBlackPieces;

        /// <summary>
        /// Tests that the GetContents method returns Player.Invalid when the given
        /// location is off the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAInvalidContents()
        {
            Board b = new Board();
            Assert.That(b.GetContents(new Point(8, 8)), Is.EqualTo(Player.Invalid));
        }

        /// <summary>
        /// Tests that the initial board setup is correct.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBInitialBoard()
        {
            Board b = new Board();
            Common.TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(4, 3), new Point(3, 4) },
                Player.Black, true, false, false, 4, true);
        }

        /// <summary>
        /// Tests that making the first play at (2, 3) returns true.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCValidPlay()
        {
            Board b = new Board();
            Assert.That(b.MakePlay(new Point(2, 3)), Is.GreaterThanOrEqualTo(0));
        }

        /// <summary>
        /// Tests that trying to play at (2, 4) on a new game returns false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCInvalidPlay()
        {
            Board b = new Board();
            Assert.That(b.MakePlay(new Point(2, 4)), Is.LessThan(0));
        }

        /// <summary>
        /// Tests that play 0 is valid on the initial board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCValidNumericPlay0()
        {
            Board b = new Board();
            Assert.That(Common.GetPlayLocation(b, 0), Is.Not.EqualTo(Board.Pass));
        }

        /// <summary>
        /// Tests that play 3 is valid on the initial board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCValidNumericPlay3()
        {
            Board b = new Board();
            Assert.That(Common.GetPlayLocation(b, 3), Is.Not.EqualTo(Board.Pass));
        }

        /// <summary>
        /// Tests that passing in a new game returns false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCInitialPass()
        {
            Board b = new Board();
            Assert.That(b.MakePlay(Board.Pass), Is.LessThan(0));
        }

        /// <summary>
        /// Test the initial list of available plays.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCInitialAvailableList()
        {
            Assert.That(Common.GetAvailableAfter(new Point[0], 0),
                Is.EquivalentTo(new Point[] { new Point(2, 3), new Point(3, 2), new Point(5, 4), new Point(4, 5) }));
        }

        /// <summary>
        /// Tests that the board is correct after one play.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDOnePlay()
        {
            Board b = new Board();
            b.MakePlay(new Point(2, 3));
            Common.TestContents(b, new Point[] { new Point(4, 4) }, new Point[] { new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(3, 4) },
                Player.White, true, false, true, 3, false);
        }

        /// <summary>
        /// Tests the available plays after a play is made at (2, 3).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDOnePlayAvailableList()
        {
            Assert.That(Common.GetAvailableAfter(new Point[] { new Point(2, 3) }, 1),
                Is.EquivalentTo(new Point[] { new Point(2, 4), new Point(2, 2), new Point(4, 2) }));
        }

        /// <summary>
        /// Tests that making an invalid play doesn't change the board contents.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDInvalidPlayNoChange()
        {
            Board b = new Board();
            b.MakePlay(new Point(2, 4));
            Common.TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(4, 3), new Point(3, 4) }, Player.Black,
                true, false, false, 4, true);
        }

        /// <summary>
        /// Tests that the value returned by MakePlay, given location (2, 3), is the
        /// index of the play at this location.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEMakePlayReturn1()
        {
            Board b = new Board();
            Point loc = new Point(2, 3);
            int i = b.MakePlay(loc);
            b = new Board();
            b.MakePlay(i);
            Assert.That(b.GetContents(loc), Is.EqualTo(Player.Black));
        }

        /// <summary>
        /// Tests that the value returned by MakePlay, given location (5, 4), is the
        /// index of the play at this location.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEMakePlayReturn2()
        {
            Board b = new Board();
            Point loc = new Point(5, 4);
            int i = b.MakePlay(loc);
            b = new Board();
            b.MakePlay(i);
            Assert.That(b.GetContents(loc), Is.EqualTo(Player.Black));
        }

        /// <summary>
        /// Tests an Undo after playing (2, 4).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEOnePlayUndo()
        {
            Board b = new Board();
            b.MakePlay(new Point(2, 4));
            b.Undo();
            Common.TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(4, 3), new Point(3, 4) }, Player.Black,
                true, false, false, 4, true);
        }

        /// <summary>
        /// Tests the play sequence (2, 3), (2, 2).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestETwoPlays()
        {
            Board b = Common.PlaySequence(_shortSequence, 2);
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(3, 3), new Point(4, 4) },
                new Point[] { new Point(2, 3), new Point(4, 3), new Point(3, 4) }, Player.Black, true, false, true, 4, true);
        }

        /// <summary>
        /// Tests the available plays after one play is made, followed by an undo.
        /// This tests the restoration of the available play list by an undo.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFAvailableAfterUndo()
        {
            // Make the play and undo it.
            Board b = Common.PlaySequence(_shortSequence, 1);
            b.Undo();
            int availCount = b.AvailablePlayCount;
            int[] results = new int[4];

            // Try to make one of the plays that should be available. The returned value should be its index in the available play list.
            results[0] = b.MakePlay(new Point(2, 3));

            // Run the test again, this time checking another play that should be available.
            b = Common.PlaySequence(_shortSequence, 1);
            b.Undo();
            results[1] = b.MakePlay(new Point(3, 2));

            // Run the test two more times on the remaining plays that should be available.
            b = Common.PlaySequence(_shortSequence, 1);
            b.Undo();
            results[2] = b.MakePlay(new Point(4, 5));
            b = Common.PlaySequence(_shortSequence, 1);
            b.Undo();
            results[3] = b.MakePlay(new Point(5, 4));

            Assert.Multiple(() =>
            {
                Assert.That(availCount, Is.EqualTo(4)); // The number of available plays.
                Assert.That(results, Is.EquivalentTo(new int[] { 0, 1, 2, 3 })); // Each play was available.
            });
        }

        /// <summary>
        /// Test an Undo after the play sequence (2, 3), (2, 2).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFTwoPlaysOneUndo()
        {
            Board b = Common.PlaySequence(_shortSequence, 2);
            b.Undo();
            Common.TestContents(b, new Point[] { new Point(4, 4) }, new Point[] { new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(3, 4) },
                Player.White, true, false, true, 3, false);
        }

        /// <summary>
        /// Tests that the list of available plays contains the correct plays
        /// after two plays and an undo. This tests the restoration of the
        /// previous available play list by an undo.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestGAvailableAfterTwoPlaysOneUndo()
        {
            // Make the play sequence and undo it.
            Board b = Common.PlaySequence(_shortSequence, 2);
            b.Undo();
            int avail = b.AvailablePlayCount;
            int[] results = new int[3];

            // Try to make a play that should be available, and store the results.
            results[0] = b.MakePlay(new Point(2, 4));

            // Run the test again using a different play that should be available.
            b = Common.PlaySequence(_shortSequence, 2);
            b.Undo();
            results[1] = b.MakePlay(new Point(2, 2));

            // Run the test on the last available play.
            b = Common.PlaySequence(_shortSequence, 2);
            b.Undo();
            results[2] = b.MakePlay(new Point(4, 2));

            Assert.Multiple(() =>
            {
                Assert.That(avail, Is.EqualTo(3)); // AvailablePlayCount
                Assert.That(results, Is.EquivalentTo(new int[] { 0, 1, 2 })); // Each play was available.
            });
        }

        /// <summary>
        /// Tests the play sequence (2, 3), (2, 2), followed by two Undos.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestGTwoPlaysTwoUndos()
        {
            Board b = Common.PlaySequence(_shortSequence, 2);
            b.Undo();
            b.Undo();
            Common.TestContents(b, new Point[] { new Point(3, 3), new Point(4, 4) }, new Point[] { new Point(4, 3), new Point(3, 4) }, Player.Black,
                true, false, false, 4, true);
        }

        /// <summary>
        /// Tests the sequence (2, 3), (2, 2), (3, 2), (4, 2).
        /// The last play of this sequence should flip a piece in two directions.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHFlipTwoDirections()
        {
            Board b = Common.PlaySequence(_shortSequence, 4);
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(4, 3), new Point(4, 4) },
                new Point[] { new Point(2, 3), new Point(3, 3), new Point(3, 4) }, Player.Black, true, false, true, 9, true);
        }

        /// <summary>
        /// Tests that the available list is the same after playing (2, 3) on the initial position
        /// as it is after playing (2, 3), (2, 2), Undo, Undo, (2, 3). This tests that the perimeter 
        /// was restored in the correct order.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHAvailableAfterPlayUndoRestore1()
        {
            Common.TestAvailableAfterPlayUndoRestore(new Point(2, 3), new Point(2, 2));
        }

        /// <summary>
        /// Tests that the available list is the same after playing (3, 2) on the initial position
        /// as it is after playing (3, 2), (2, 2), Undo, Undo, (3, 2). This tests that the perimeter 
        /// was restored in the correct order.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHAvailableAfterPlayUndoRestore2()
        {
            Common.TestAvailableAfterPlayUndoRestore(new Point(3, 2), new Point(2, 2));
        }

        /// <summary>
        /// Tests that the available list is the same after playing (4, 5) on the initial position
        /// as it is after playing (4, 5), (5, 5), Undo, Undo, (4, 5). This tests that the perimeter 
        /// was restored in the correct order.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHAvailableAfterPlayUndoRestore3()
        {
            Common.TestAvailableAfterPlayUndoRestore(new Point(4, 5), new Point(5, 5));
        }

        /// <summary>
        /// Tests that the available list is the same after playing (5, 4) on the initial position
        /// as it is after playing (5, 4), (5, 5), Undo, Undo, (5, 4). This tests that the perimeter
        /// was restored in the correct order.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHAvailableAfterPlayUndoRestore4()
        {
            Common.TestAvailableAfterPlayUndoRestore(new Point(5, 4), new Point(5, 5));
        }

        /// <summary>
        /// Tests the sequence (2, 3), (2, 2), (3, 2), (4, 2), followed by an Undo.
        /// The Undo will need to flip pieces in two directions.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestIUndoTwoDirections()
        {
            Board b = Common.PlaySequence(_shortSequence, 4);
            b.Undo();
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(4, 4) },
                new Point[] { new Point(3, 2), new Point(2, 3), new Point(3, 3), new Point(4, 3), new Point(3, 4) },
                Player.White, true, false, true, 2, false);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5).
        /// The last play should flip two pieces in a line.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestIFlipTwoInLine()
        {
            Board b = Common.PlaySequence(_shortSequence, 6);
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(3, 3),
                new Point(4, 3), new Point(4, 4), new Point(5, 5) },
                new Point[] { new Point(2, 3), new Point(3, 4), new Point(5, 4) }, Player.Black, true, false, true, 6, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), followed by an Undo.
        /// The Undo will need to flip two pieces in a line.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestJUndoTwoInLine()
        {
            Board b = Common.PlaySequence(_shortSequence, 6);
            b.Undo();
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(4, 3) },
                new Point[] { new Point(2, 3), new Point(3, 3), new Point(3, 4), new Point(4, 4), new Point(5, 4) },
                Player.White, true, false, true, 8, false);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), (5, 6), (6, 6), (7, 6).
        /// The last play is at an edge.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestJPlayAtEdge()
        {
            Board b = Common.PlaySequence(_shortSequence, 9);
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(3, 3), new Point(4, 3), new Point(4, 4), new Point(5, 5) },
                new Point[] { new Point(2, 3), new Point(3, 4), new Point(5, 4), new Point(5, 6), new Point(6, 6), new Point(7, 6) },
                Player.White, true, false, true, 10, false);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), (5, 6), (6, 6), (7, 6),
        /// followed by an Undo. This Undoes a play at the edge.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestKUndoAtEdge()
        {
            Board b = Common.PlaySequence(_shortSequence, 9);
            b.Undo();
            Common.TestContents(b, new Point[] { new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(3, 3),
                new Point(4, 3), new Point(4, 4), new Point(5, 5), new Point(6, 6) },
                new Point[] { new Point(2, 3), new Point(3, 4), new Point(5, 4), new Point(5, 6) },
                Player.Black, true, false, true, 6, true);
        }

        /// <summary>
        /// Tests the sequence, (2, 3), (2, 2), (3, 2), (4, 2), (5, 4), (5, 5), (5, 6), (6, 6), (7, 6),
        /// followed by an attempt to play at (4, 6). This play is invalid, but it must check a sequence
        /// that runs to the edge of the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestKInvalidPlayNearEdge()
        {
            Board b = Common.PlaySequence(_shortSequence, 9);
            Assert.That(b.MakePlay(new Point(4, 6)), Is.LessThan(0));
        }

        /// <summary>
        /// Tests that the Pass at the end of _passSequence is a valid play.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestLValidPass()
        {
            Board b = Common.PlaySequence(_passSequence, _passSequence.Length - 1);
            Assert.That(b.MakePlay(Board.Pass), Is.EqualTo(0));
        }

        /// <summary>
        /// Tests the board contents after a sequence that results in no valid play
        /// to the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestLContentBeforePass()
        {
            Board b = Common.PlaySequence(_passSequence, _passSequence.Length - 1);
            Common.TestContents(b, _whiteAfterPassSequence, _blackAfterPassSequence, Player.White, false, false, true, 0, false);
        }

        /// <summary>
        /// Tests a sequence ending with a valid pass.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestMContentAfterPass()
        {
            Board b = Common.PlaySequence(_passSequence, _passSequence.Length);
            Common.TestContents(b, _whiteAfterPassSequence, _blackAfterPassSequence, Player.Black, true, false, true, 1, true);
        }

        /// <summary>
        /// Tests an Undo of a Pass.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNUndoPass()
        {
            Board b = Common.PlaySequence(_passSequence, _passSequence.Length);
            b.Undo();
            Common.TestContents(b, _whiteAfterPassSequence, _blackAfterPassSequence, Player.White, false, false, true, 0, false);
        }

        /// <summary>
        /// Tests a game that white wins.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNWhiteWin()
        {
            Board b = Common.PlaySequence(_whiteWinSequence, _whiteWinSequence.Length);
            Common.TestContents(b, _whiteWinWhitePieces, _whiteWinBlackPieces, Player.Black, false, true, true, 0, true);
        }

        /// <summary>
        /// Tests a game that black wins without filling the board.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNBlackWin()
        {
            Board b = Common.PlaySequence(_blackWinSequence, _blackWinSequence.Length);
            Common.TestContents(b, _blackWinWhitePieces, _blackWinBlackPieces, Player.Black, false, true, true, 0, true);
        }

        /// <summary>
        /// Tests a game that ends in a tie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestNTie()
        {
            Board b = Common.PlaySequence(_tieSequence, _tieSequence.Length);
            Common.TestContents(b, _tieWhitePieces, _tieBlackPieces, Player.Black, false, true, true, 0, true);
        }

        /// <summary>
        /// Tests Undoing all but the first play in a full game.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestOUndoGame()
        {
            Board b = Common.PlaySequence(_blackWinSequence, _blackWinSequence.Length);
            for (int i = 0; i < _blackWinSequence.Length - 1; i++)
            {
                b.Undo();
            }
            Common.TestContents(b, new Point[] { new Point(3, 3) }, new Point[] { new Point(4, 3), new Point(3, 4), new Point(4, 4), new Point(4, 5) },
                Player.White, true, false, true, 3, false);
        }

        /// <summary>
        /// Tests that always making the last play in the available list (or passing if the list is empty)
        /// gives the same final score as is reached after all these plays are undone and the same sequence
        /// of play indices is followed.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestONumericGameUndoRepeat()
        {
            Board b = new Board();
            List<int> plays = new List<int>();
            while (!b.IsOver)
            {
                int i = Math.Max(0, b.AvailablePlayCount - 1); // If no available plays, use 0.
                plays.Add(i);
                b.MakePlay(i);
            }
            int blackScore = b.BlackScore;
            int whiteScore = b.WhiteScore;
            for (int i = 0; i < plays.Count; i++)
            {
                b.Undo();
            }
            foreach (int i in plays)
            {
                b.MakePlay(i);
            }
            Assert.Multiple(() =>
            {
                Assert.That(b.BlackScore, Is.EqualTo(blackScore), "BlackScore is incorrect.");
                Assert.That(b.WhiteScore, Is.EqualTo(whiteScore), "WhiteScore is incorrect.");
            });
        }
    }
}

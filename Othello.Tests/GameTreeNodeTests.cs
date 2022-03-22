/* ComputerPlayerTests.cs
 * Author: Jacob Koelzer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Drawing;

namespace Othello.Tests
{
    /// <summary>
    /// A suite of tests for the GameTreeNode class in Ksu.Cis300.Othello.
    /// </summary>
    [TestFixture]
    public class GameTreeNodeTests
    {
        /// <summary>
        /// A game that black wins with the board not completely filled.
        /// White makes the last play.
        /// </summary>
        private static Point[] _blackWinSequence = Common.BlackWinSequence;

        /// <summary>
        /// A game that white wins, making the last play.
        /// </summary>
        private static Point[] _whiteWinSequence = Common.WhiteWinSequence;

        /// <summary>
        /// A game that ends in a tie.
        /// </summary>
        private static Point[] _tieSequence = Common.TieSequence;

        /// <summary>
        /// A game that black wins, playing last.
        /// </summary>
        private static Point[] _blackWinBlackLast = Common.BlackWinBlackLast;

        /// <summary>
        /// A game that black loses, playing last.
        /// </summary>
        private static Point[] _whiteWinBlackLast = Common.WhiteWinsBlackLast;

        /// <summary>
        /// A tie game in which black plays last.
        /// </summary>
        private static Point[] _tieBlackLast = Common.TieBlackLast;

        /// <summary>
        /// A sequence leading to a position in which Black has two plays. (2, 7)
        /// draws, and (6, 7) loses.
        /// </summary>
        private static Point[] _twoOutcomeSequence = Common.TwoOutcomeSequence;

        /// <summary>
        /// Tests calling RandomSimulate after White has made a play and lost.
        /// No moves can be simulated - this just tests whether it returns the
        /// correct result.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARandomSimulateAtLoss()
        {
            Board b = Common.PlaySequence(_blackWinSequence, _blackWinSequence.Length);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0));
        }

        /// <summary>
        /// Tests calling RandomSimulate after White has made a play a won.
        /// No moves can be simulated - this just tests whether it returns the 
        /// correct result.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARandomSimulateAtWin()
        {
            Board b = Common.PlaySequence(_whiteWinSequence, _whiteWinSequence.Length);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(1f));
        }

        /// <summary>
        /// Tests calling RandomSimulate after a tie game. No moves can be simulated -
        /// this just tests whether it returns the correct result.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARandomSimulateAtTie()
        {
            Board b = Common.PlaySequence(_tieSequence, _tieSequence.Length);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0.5f));
        }

        /// <summary>
        /// Tests calling RandomSimulate after black wins, playing last. No moves can
        /// be simulated - this just tests whether it returns the correct result.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARandomSimulateAtWinBlackLast()
        {
            Board b = Common.PlaySequence(_blackWinBlackLast, _blackWinBlackLast.Length);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(1f));
        }

        /// <summary>
        /// Tests calling RandomSimulate after black loses, playing last. No moves can
        /// be simulated - this just tests whether it returns the correct result.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARandomSimulateAtLossBlackLast()
        {
            Board b = Common.PlaySequence(_whiteWinBlackLast, _whiteWinBlackLast.Length);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0));
        }

        /// <summary>
        /// Tests calling RandomSimulate after a tie game in which black plays last.
        /// No moves can be simulated - this just tests whether it returns the correct result.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARandomSimulateAtTieBlackLast()
        {
            Board b = Common.PlaySequence(_tieBlackLast, _tieBlackLast.Length);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0.5f));
        }

        /// <summary>
        /// Tests a random simulation from a position from which there is only one play
        /// for white. This play wins the game. This tests that the value returned is
        /// correctly converted to black's perspective, as black was the last to play 
        /// before the random simulation. It also tests that the simulation restores
        /// the board to its original state.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBRandomSimulateBeforeWhiteWin()
        {
            Board b = Common.PlaySequence(_whiteWinSequence, _whiteWinSequence.Length - 1);
            List<Point> whiteBefore = new List<Point>();
            List<Point> blackBefore = new List<Point>();
            Common.GetBoardContents(b, blackBefore, whiteBefore);
            float result = GameTreeNode.RandomSimulate(b);
            List<Point> whiteAfter = new List<Point>();
            List<Point> blackAfter = new List<Point>();
            Common.GetBoardContents(b, blackAfter, whiteAfter);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(0));
                Assert.That(whiteAfter, Is.EqualTo(whiteBefore), "The white pieces aren't restored");
                Assert.That(blackAfter, Is.EqualTo(blackBefore), "The black pieces aren't restored.");
            });
        }

        /// <summary>
        /// Tests a random simulation from a position from which there is only one play
        /// for black. This play loses the game. This tests that the value returned is
        /// correctly converted to white's perspective, as white was the last to play
        /// before the random simulation.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBRandomSimulateBeforeBlackPlayWhiteWin()
        {
            Board b = Common.PlaySequence(_whiteWinBlackLast, _whiteWinBlackLast.Length - 1);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(1f));
        }

        /// <summary>
        /// Tests a random simulation from a position from which there is only one play
        /// for white. This play draws. This tests that the value returned is correct.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBRandomSimulateBeforeTie()
        {
            Board b = Common.PlaySequence(_tieSequence, _tieSequence.Length - 1);
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0.5f));
        }

        /// <summary>
        /// Tests a random simulation from a position from which White has no legal play to
        /// the board. White must pass, then Black must play to the only remaining square,
        /// losing the game. This tests that the random simulation correctly handles a Pass.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBRandomSimulateBeforePass()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length);
            b.MakePlay(new Point(6, 7));
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0));
        }

        /// <summary>
        /// Tests a random simulation from a position from which White has no legal play to
        /// the board. White must pass, then Black must play to the only remaining square,
        /// drawing the game. This tests that the random simulation correctly handles a Pass.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBRandomSimulateBeforePass2()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length);
            b.MakePlay(new Point(2, 7));
            Assert.That(GameTreeNode.RandomSimulate(b), Is.EqualTo(0.5f));
        }

        /// <summary>
        /// This test runs random simulations from a position that can lead to either a draw
        /// or a win. It should eventually simulate a draw; otherwise, it will time out.
        /// When the random simulation starts, two plays are possible for Black: (2, 7)
        /// leads to a draw, and (6, 7) leads to a White win. This tests that 
        /// some simulations choose (2, 7).
        /// </summary>
        [Test, Timeout(10000)]
        public void TestCRandomSimulateEventualDraw()
        {
            Common.SimulateUntilDesiredResult(_twoOutcomeSequence, _twoOutcomeSequence.Length, 0.5f);
            Assert.Pass();
        }

        /// <summary>
        /// This test runs random simulations from a position that can lead to either a draw
        /// or a win. It should eventually simulate a win; otherwise, it will time out.
        /// When the random simulation starts, two plays are possible for Black: (2, 7)
        /// leads to a draw, and (6, 7) leads to a White win. This tests that 
        /// some simulations choose (6, 7).
        /// </summary>
        [Test, Timeout(10000)]
        public void TestCRandomSimulateEventualWin()
        {
            Common.SimulateUntilDesiredResult(_twoOutcomeSequence, _twoOutcomeSequence.Length, 1f);
            Assert.Pass();
        }

        /// <summary>
        /// Does random simulations from the beginning of the game until White wins. If this
        /// doesn't happen, it will time out.
        /// </summary>
        [Test, Timeout(10000)]
        public void TestDRandomSimulateEventualWin()
        {
            Common.SimulateUntilDesiredResult(new Point[0], 0, 1f);
            Assert.Pass();
        }

        /// <summary>
        /// Does random simulations from the beginning of the game until Black wins. If this
        /// doesn't happen, it will time out.
        /// </summary>
        [Test, Timeout(10000)]
        public void TestDRandomSimulateEventualLoss()
        {
            Common.SimulateUntilDesiredResult(new Point[0], 0, 0);
            Assert.Pass();
        }

        /// <summary>
        /// Tests that the GameTreeNode constructor constructs a node with the given play
        /// and no children.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestENewGameTreeNode()
        {
            GameTreeNode t = new GameTreeNode(3);
            GameTreeNode child = null;
            try
            {
                child = t.GetChild(0);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.Multiple(() =>
            {
                Assert.That(t.Play, Is.EqualTo(3));
                Assert.That(child, Is.Null);
            });
        }

        /// <summary>
        /// Tests that a single simulation on a node when the board is at the
        /// end of a game doesn't create any children.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFOneTreeSimulationAtEnd()
        {
            Board b = Common.PlaySequence(_whiteWinSequence, _whiteWinSequence.Length);
            GameTreeNode t = new GameTreeNode(-1);
            t.Simulate(b);
            GameTreeNode child = null;
            try
            {
                child = t.GetChild(0);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.That(child, Is.Null);
        }

        /// <summary>
        /// Tests that two simulations on a node when the board is at the
        /// end of a game doesn't create any children.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestGTwoTreeSimulationsAtEnd()
        {
            Board b = Common.PlaySequence(_whiteWinSequence, _whiteWinSequence.Length);
            GameTreeNode t = new GameTreeNode(-1);
            t.Simulate(b);
            t.Simulate(b);
            GameTreeNode child = null;
            try
            {
                child = t.GetChild(0);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.That(child, Is.Null);
        }

        /// <summary>
        /// Tests one simulation on a node with a board near the end of the game.
        /// Tests that no children are created and that the board is restored to
        /// its state prior to the simulation.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHOneSimulationNearEnd()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length);
            GameTreeNode t = new GameTreeNode(-1);
            List<Point> blackBefore = new List<Point>();
            List<Point> whiteBefore = new List<Point>();
            Common.GetBoardContents(b, blackBefore, whiteBefore);
            t.Simulate(b);
            List<Point> blackAfter = new List<Point>();
            List<Point> whiteAfter = new List<Point>();
            Common.GetBoardContents(b, blackAfter, whiteAfter);
            GameTreeNode child = null;
            try
            {
                child = t.GetChild(0);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.Multiple(() =>
            {
                Assert.That(child, Is.Null);
                Assert.That(blackAfter, Is.EqualTo(blackBefore), "The black pieces aren't restored.");
                Assert.That(whiteAfter, Is.EqualTo(whiteBefore), "The white pieces aren't restored.");
            });
        }

        /// <summary>
        /// Tests two simulations on a node with a board on which there are two legal plays.
        /// Tests that exactly two children are added, and that the last one stores the
        /// correct play index.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestITwoSimulationsTwoChildren()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length);
            GameTreeNode t = new GameTreeNode(-1);
            t.Simulate(b);
            t.Simulate(b);
            GameTreeNode lastChild = t.GetChild(1);
            int play = lastChild.Play;
            GameTreeNode missingChild = null;
            try
            {
                missingChild = t.GetChild(2);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.Multiple(() =>
            {
                Assert.That(play, Is.EqualTo(1));
                Assert.That(missingChild, Is.Null);
            });
        }

        /// <summary>
        /// Tests two simulations on a node using a board to which there is no legal play.
        /// Tests that exactly one child is added, and that it stores the correct play index.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestITwoSimulationsAtPass()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length - 1);
            GameTreeNode t = new GameTreeNode(-1);
            t.Simulate(b);
            t.Simulate(b);
            GameTreeNode lastChild = t.GetChild(0);
            int play = lastChild.Play;
            GameTreeNode missingChild = null;
            try
            {
                missingChild = t.GetChild(1);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.Multiple(() =>
            {
                Assert.That(play, Is.EqualTo(0));
                Assert.That(missingChild, Is.Null);
            });
        }

        /// <summary>
        /// Tests three simulations on a node using a board on which two plays are possible.
        /// Tests that the third simulation is on the second child; i.e., that the first
        /// child still has no children.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestJThreeSimulationsTwoChildren()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length);
            GameTreeNode t = new GameTreeNode(-1);
            t.Simulate(b);
            t.Simulate(b);
            t.Simulate(b);
            t = t.GetChild(0);
            GameTreeNode missingChild = null;
            try
            {
                missingChild = t.GetChild(0);
            }
            catch
            {
                // Ignore any exception.
            }
            Assert.That(missingChild, Is.Null);
        }

        /// <summary>
        /// Tests four simulations on a node using a board at which there are two legal
        /// plays for Black. The play (2, 7) always leads to a draw, and the play (6, 7)
        /// always leads to a loss. Thus, the child corresponding to (2, 7) should always
        /// be chosen for the fourth simulation, and hence should be chosen as the best
        /// child.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestKFourSimulationsTwoChildren()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length);
            GameTreeNode t = new GameTreeNode(-1);
            t.Simulate(b);
            t.Simulate(b);
            t.Simulate(b);
            t.Simulate(b);
            GameTreeNode child = t.GetBestChild();
            int bestPlay = b.MakePlay(new Point(2, 7));
            Assert.That(child.Play, Is.EqualTo(bestPlay));
        }

        /// <summary>
        /// Tests the results of 1000 simulations on a node using a board with three legal
        /// plays. (2, 7) always leads to a draw, (0, 7) can lead to either a draw or a loss,
        /// and (6, 7) always leads to a loss. The best child should therefore be (2, 7).
        /// </summary>
        [Test, Timeout(1000)]
        public void TestLBestOfThree()
        {
            Board b = Common.PlaySequence(_twoOutcomeSequence, _twoOutcomeSequence.Length - 2);
            GameTreeNode t = new GameTreeNode(-1);
            for (int i = 0; i < 1000; i++)
            {
                t.Simulate(b);
            }
            GameTreeNode child = t.GetBestChild();
            int bestPlay = b.MakePlay(new Point(2, 7));
            Assert.That(child.Play, Is.EqualTo(bestPlay));
        }

        /// <summary>
        /// Repeats 100 simulations on a node using the initial board position until
        /// play index 0 is the best. Because each first play is equally good, each
        /// is equally likely to be chosen as the best. If 0 is never chosen, the
        /// test will time out.
        /// </summary>
        [Test, Timeout(10000)]
        public void TestMRepeatUntilBestPlayIs0()
        {
            Common.SimulateUntilDesiredResult(0);
            Assert.Pass();
        }

        /// <summary>
        /// Repeats 100 simulations on a node using the initial board position until
        /// play index 1 is the best. Because each first play is equally good, each
        /// is equally likely to be chosen as the best. If 1 is never chosen, the
        /// test will time out.
        /// </summary>
        [Test, Timeout(10000)]
        public void TestMRepeatUntilBestPlayIs1()
        {
            Common.SimulateUntilDesiredResult(1);
            Assert.Pass();
        }

        /// <summary>
        /// Repeats 100 simulations on a node using the initial board position until
        /// play index 2 is the best. Because each first play is equally good, each
        /// is equally likely to be chosen as the best. If 2 is never chosen, the
        /// test will time out.
        /// </summary>
        [Test, Timeout(10000)]
        public void TestMRepeatUntilBestPlayIs2()
        {
            Common.SimulateUntilDesiredResult(2);
            Assert.Pass();
        }

        /// <summary>
        /// Repeats 100 simulations on a node using the initial board position until
        /// play index 3 is the best. Because each first play is equally good, each
        /// is equally likely to be chosen as the best. If 3 is never chosen, the
        /// test will time out.
        /// </summary>
        [Test, Timeout(10000)]
        public void TestMRepeatUntilBestPlayIs3()
        {
            Common.SimulateUntilDesiredResult(3);
            Assert.Pass();
        }
    }
}

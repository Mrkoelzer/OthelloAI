/*GameTreeNode.cs
 *Author: Jacob Koelzer 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    /// <summary>
    ///  implements a single node of the stored game tree.
    /// </summary>
    public class GameTreeNode
    {
        /// <summary>
        /// storing the children of this node.
        /// </summary>
        private List<GameTreeNode> _childrenUsed;

        /// <summary>
        ///  number of simulations that have been done using this node.
        /// </summary>
        private int _simulations;

        /// <summary>
        /// otal score of simulations involving this node
        /// </summary>
        private float _score;

        /// <summary>
        ///  number of this node's children that have been used in simulations.
        /// </summary>
        private int _numberofnodes;

        /// <summary>
        /// generate random number
        /// </summary>
        private static Random _randomNumbers = new Random();

        /// <summary>
        /// gets an int giving the index of this node 
        /// </summary>
        public int Play
        {
            get;
        }

        /// <summary>
        /// single int parameter giving the index of a play. initialize the play property
        /// </summary>
        /// <param name="playindex">giving the index of this play</param>
        public GameTreeNode(int playindex)
        {
            Play = playindex;
        }

        /// <summary>
        /// add children to this node
        /// </summary>
        /// <param name="position"> board position corresponding to this node</param>
        private void AddChildren(Board position)
        {
            _childrenUsed = new List<GameTreeNode>();

            if (position.AvailablePlayCount == 0)
            {
                _childrenUsed.Add(new GameTreeNode(0));
            }
            else
            {
                for (int i = 0; i < position.AvailablePlayCount; i++)
                {
                    _childrenUsed.Add(new GameTreeNode(i));
                }
            }

        }

        /// <summary>
        ///  get the result of a simulation
        /// </summary>
        /// <param name="position"> position at the end of a simulated game.</param>
        /// <returns>float giving the score of the simulation</returns>
        private static float GetResult(Board position)
        {
            if (position.OtherPlayerScore > position.CurrentPlayerScore)
            {
                return 1;
            }
            else if (position.OtherPlayerScore == position.CurrentPlayerScore)
            {
                return 0.5f;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        ///  update the statistics for this node
        /// </summary>
        /// <param name="score"></param>
        /// <returns>same float that it was given</returns>
        private float UpdateStatistics(float score)
        {
            _score = score + _score;
            _simulations++;
            return _score;
        }

        /// <summary>
        ///  heart of the Monte Carlo tree search algorithm
        /// </summary>
        /// <returns> child GameTreeNode to be used in the current simulation.</returns>
        private GameTreeNode ChildSimulation()
        {
            if (_numberofnodes < _childrenUsed.Count)
            {
                GameTreeNode child = _childrenUsed[_numberofnodes];
                _numberofnodes++;
                return child;
            }
            else
            {
                double max = Double.NegativeInfinity;
                GameTreeNode child = null;
                double twologn = 2 * Math.Log(_simulations);

                foreach (GameTreeNode c in _childrenUsed)
                {
                    double result = c._score / c._simulations + Math.Sqrt(twologn / c._simulations);
                    if (result > max)
                    {
                        max = result;
                        child = c;
                    }
                }
                return child;
            }
        }

        /// <summary>
        ///  get the result of a simulation
        /// </summary>
        /// <param name="position"> which to simulate a game</param>
        /// <returns>giving the result of the simulation</returns>
        public static float RandomSimulate(Board position)
        {
            if (position.IsOver == true)
            {
                return GetResult(position);

            }
            else if (position.HasPlay)
            {
                int temp = _randomNumbers.Next(position.AvailablePlayCount);
                position.MakePlay(temp);
            }
            else
            {
                position.MakePlay(0);

            }
            float score = 1 - RandomSimulate(position);
            position.Undo();
            return score;
        }

        /// <summary>
        /// d completes the Monte Carlo tree search algorithm. 
        /// </summary>
        /// <param name="position"> which to simulate a game.</param>
        /// <returns> giving the result of the simulation, </returns>
        public float Simulate(Board position)
        {
            if (_simulations == 0)
            {
                return UpdateStatistics(RandomSimulate(position));
            }
            else
            {
                if (_childrenUsed == null)
                {
                    if (position.IsOver)
                    {
                        return UpdateStatistics(GetResult(position));
                    }
                    else
                    {
                        AddChildren(position);
                    }
                }
            }
            GameTreeNode child = ChildSimulation();
            position.MakePlay(child.Play);
            float score = 1 - child.Simulate(position);
            position.Undo();
            return UpdateStatistics(score);
        }

        /// <summary>
        /// child of this node corresponding to this index
        /// </summary>
        /// <param name="index">giving a play index.</param>
        /// <returns>giving the child of this node corresponding to this index</returns>
        public GameTreeNode GetChild(int index)
        {
            return _childrenUsed[index];
        }

        /// <summary>
        /// child that was used in the most simulations
        /// </summary>
        /// <returns> giving a child that was used in the most simulations</returns>
        public GameTreeNode GetBestChild()
        {
            int max = -1;
            GameTreeNode child = null;

            foreach(GameTreeNode node in _childrenUsed)
            {
                if (node._simulations > max)
                {
                    max = node._simulations;
                    child = node;
                }
            }
            return child;
        }

    }
}

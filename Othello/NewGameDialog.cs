/*NewGameDialog.cs
 *Author: Jacob Koelzer 
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
    public partial class NewGameDialog : Form
    {
        /// <summary>
        /// implements the dialog to show to set up a new game.
        /// </summary>
        public NewGameDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// gets the level chosen by the user. 
        /// </summary>
        public int Level
        {
            get
            {
               return (int)uxNumericLevel.Value;
            }
        }

        /// <summary>
        /// gets whether the user chose the "Computer plays first
        /// </summary>
        public bool ComputerFirst
        {
            get
            {
                return uxComputerFirstButton.Checked;
            }
        }

        /// <summary>
        /// gets whether the user chose the "No computer player" 
        /// </summary>
        public bool NoComputerPlayer
        {
            get
            {
                return uxNoComputerButton.Checked;
            }
        }

        public bool Computervscomputer
        {
            get
            {
                return uxComputervscomputer.Checked;
            }
        }


    }
}

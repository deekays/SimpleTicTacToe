/* ID: SDraperAssignmentOne
 * 
 * Purpose: Create a functional Tic Tac Toe game with two human players
 * 
 * History: 
 *      created September 2020 by Stephen Draper
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

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        public int turnCounter = 0; // keeps track of turns played for player and tie purposes.
        public int[,] container = new int[3,3]; // our array that will store played pieces
        
        /// <summary>
        /// Initialize form. Nothing special goes on here.
        /// </summary>
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This event occurs when the user clicks any of the picture boxes. Detects which picture box was clicked, places an X or O in it,
        /// and calls the ArrayContainer and WinCheck methods to store the placement and check for victory. Also shows a message box for victory
        /// if it occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox selectedSpace = sender as PictureBox; // this allows us to pull the specific one they clicked
            int tag = int.Parse(selectedSpace.Tag.ToString());
            turnCounter++; // put this here because if it was at the end then I had to put a bunch of return statements or it would increment once for the next game and O would start
            if (turnCounter%2 != 0) // if X
            {
                selectedSpace.Image = TicTacToe.Properties.Resources.x;
                selectedSpace.Enabled = false;
                ArrayContainer(tag);
                if (WinCheck() == true) // checks against the wincondition
                {
                    MessageBox.Show("X wins!");
                    Clear();
                }
                else if (turnCounter == 9) // x always plays last so there's no reason to repeat this below
                {
                    MessageBox.Show("It's a tie!");
                    Clear();
                }
            }
            else // if O
            {
                selectedSpace.Image = TicTacToe.Properties.Resources.o;
                selectedSpace.Enabled = false;
                ArrayContainer(tag);
                if(WinCheck() == true)
                {
                    MessageBox.Show("O wins!");
                    Clear();
                }
            }
        }

        /// <summary>
        /// Using the tag that we pulled, places the played character into an array holding positions. This allows us to use them to check positions later. 
        /// </summary>
        /// <param name="tag">The tag pulled from the picture box, saying its position</param>
        public void ArrayContainer(int tag)
        {
            int player;
            if(turnCounter%2 == 0) // used to say whether we are placing a 1 or a 2 in each row. This is important, because if we use the same number then
                                   // it will 'win' whenever there are 3 in a row regardless of if they match
            {
                player = 1;
            }
            else
            {
                player = 2;
            }

            switch (tag) // places a number into our 2D array based on where they played
            {
                case 0:
                    container[0, 0] = player;
                    break;
                case 1:
                    container[0, 1] = player;
                    break;
                case 2:
                    container[0, 2] = player;
                    break;
                case 3:
                    container[1, 0] = player;
                    break;
                case 4:
                    container[1, 1] = player;
                    break;
                case 5:
                    container[1, 2] = player;
                    break;
                case 6:
                    container[2, 0] = player;
                    break;
                case 7:
                    container[2, 1] = player;
                    break;
                case 8:
                    container[2, 2] = player;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks against every win condition individually, by testing if each row is the same, and not zero. Since X and Os are different numbers, this works.
        /// </summary>
        /// <returns>Returns true if win condition met, false if not.</returns>
        public bool WinCheck()
        {
            bool win = false;
            if(container[0,0]==container[0,1] && container[0,0]==container[0,2] && container[0,0] != 0)
            {
                win = true;
            }
            else if (container[1, 0] == container[1, 1] && container[1, 0] == container[1, 2] && container[1, 0] != 0)
            {
                win = true;
            }
            else if (container[2, 0] == container[2, 1] && container[2, 0] == container[2, 2] && container[2, 0] != 0)
            {
                win = true;
            }
            else if (container[0, 0] == container[1, 0] && container[0, 0] == container[2, 0] && container[0, 0] != 0)
            {
                win = true;
            }
            else if (container[0, 1] == container[1, 1] && container[0, 1] == container[2, 1] && container[0, 1] != 0)
            {
                win = true;
            }
            else if (container[0, 2] == container[1, 2] && container[0, 2] == container[2, 2] && container[0, 2] != 0)
            {
                win = true;
            }
            else if (container[0, 0] == container[1, 1] && container[0, 0] == container[2, 2] && container[0, 0] != 0)
            {
                win = true;
            }
            else if (container[0, 2] == container[1, 1] && container[0, 2] == container[2, 0] && container[0, 2] != 0)
            {
                win = true;
            }
            return win;
        }

        /// <summary>
        /// This will clear all of the played Xs and Os, as well as resetting the turn counter and resetting the array. Effectively starts the game over.
        /// </summary>
        public void Clear()
        {
            foreach(PictureBox item in this.Controls) // resets the picture in each picturebox
            {
                item.Image = null;
                item.Enabled = true;
            }
            container = new int[3, 3]; // creates a new array for our 'container' variable to point at. The old array gets cleaned up once unassociated.
                                       // I could have iterated through two for loops and set them all to 0, but this was easier and I'm lazy :)
            turnCounter = 0;
        }
    }
}
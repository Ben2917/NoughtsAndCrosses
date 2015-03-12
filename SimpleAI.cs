using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrossesWithAI
{
    class SimpleAI
    {
        /// <summary>
        /// Optimisation improved - Needs more testing.
        /// </summary>
        #region Constructor
        static Form1 myForm;
        public SimpleAI()
        {
 
        }
        public SimpleAI(Form1 form1)
        {
            myForm = form1;
        }
        #endregion

        #region Objects and Variables
        static Random rnd = new Random();
        static bool winFound = false, blockFound = false;
        #endregion

        #region AI main
        public void AIMain()
        {
            // Prioritise winning
            winFound = BlockOrWin("O");

            // otherwise go for a block
            if (winFound == false)
            {
                blockFound = BlockOrWin("X");
            }
            
            // otherwise choose randomly
            if(blockFound == false)
            {
                RandomChoice();
            }
        }
        #endregion

        #region Block or win
        // A method that can be used to determine
        // where to place noughts to block the 
        // human player or whether a win is
        // available.
        static bool BlockOrWin(string noughtOrCross)
        {
            bool column = false, row = false, diagonal = false;
            column = Columns(noughtOrCross);
            row = Rows(noughtOrCross);
            diagonal = Diagonals(noughtOrCross);

            if (column || row || diagonal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Optimised method
        static bool DecideButton(string button1, string button2, string button3, string noughtOrCross)
        {
            if (myForm.ButtonText(button1) == noughtOrCross
                && myForm.ButtonText(button2) == noughtOrCross
                && myForm.ButtonEnabled(button3))
            {
                myForm.ClickButtons(button3);
                Debug.WriteLine("{0} has been chosen.", button3);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Check current board
        // Method that covers checks for columns
        static bool Columns(string noughtOrCross)
        {
            #region A possible wins (efficient)
            if (DecideButton("a1", "a2", "a3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a1", "a3", "a2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a2", "a3", "a1", noughtOrCross))
            {
                return true;
            }
            #endregion
            #region B possible wins (efficient)
            else if (DecideButton("b1", "b2", "b3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b1", "b3", "b2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b2", "b3", "b1", noughtOrCross))
            {
                return true;
            }
            #endregion
            #region C possible wins (efficient)
            else if (DecideButton("c1", "c2", "c3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("c1", "c3", "c2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("c2", "c3", "c1", noughtOrCross))
            {
                return true;
            }
            else 
            {
                return false;
            }
            #endregion
        }

        // Method that covers checks for rows
        static bool Rows(string noughtOrCross)
        {
            #region 1 possible wins (efficient)
            if (DecideButton("a1", "b1", "c1", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a1", "c1", "b1", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b1", "c1", "a1", noughtOrCross))
            {
                return true;
            }
            #endregion
            #region 2 possible wins (efficient)
            else if (DecideButton("a2", "b2", "c2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a2", "c2", "b2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b2", "c2", "a2", noughtOrCross))
            {
                return true;
            }
            #endregion
            #region 3 possible wins (efficient)
            else if (DecideButton("a3", "b3", "c3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a3", "c3", "b3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b3", "c3", "a3", noughtOrCross))
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        // Method that covers checks for diagonals
        static bool Diagonals(string noughtOrCross)
        {
            #region All Diagonals
            if (DecideButton("a1", "c3", "b2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a3", "c1", "b2", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a1", "b2", "c3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b2", "c3", "a1", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("a3", "b2", "c1", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("b1", "c2", "a3", noughtOrCross))
            {
                return true;
            }
            else if (DecideButton("c1", "b2", "a3", noughtOrCross))
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
        #endregion

        #region Random choice
        // Random choice should be last resort
        // purely to keep the game going
        static void RandomChoice()
        {
            #region AI 1
            // Buttons need setting to the public
            // accessors.
            string buttonChosen = null;
            while (true)
            {
                switch (rnd.Next(0, 9))
                {
                    case 0:
                        buttonChosen = "a1";
                        break;
                    case 1:
                        buttonChosen = "a2";
                        break;
                    case 2:
                        buttonChosen = "a3";
                        break;
                    case 3:
                        buttonChosen = "b1";
                        break;
                    case 4:
                        buttonChosen = "b2";
                        break;
                    case 5:
                        buttonChosen = "b3";
                        break;
                    case 6:
                        buttonChosen = "c1";
                        break;
                    case 7:
                        buttonChosen = "c2";
                        break;
                    case 8:
                        buttonChosen = "c3";
                        break;
                }

                if (myForm.ButtonEnabled(buttonChosen))
                {
                    myForm.ClickButtons(buttonChosen);
                    break;
                }
                else
                {
                    continue;
                }
            }
            #endregion
        }
        #endregion
    }
}
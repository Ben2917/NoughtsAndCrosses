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
    /// <summary>
    /// This class holds the methods and properties 
    /// that allow the AI player to compete with a
    /// human player. It can currently check the board
    /// to see if a win is available or a block is available
    /// otherwise it will place its nought randomly.
    /// </summary>
    class SimpleAI
    {
        /// <summary>
        /// Extra method could be added to allow AI to
        /// set itself up for wins.
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
        public static string[] checkPattern = new string[]
        {
            // Columns
            "a1", "a2", "a3",
            "a1", "a3", "a2",
            "a2", "a3", "a1",
            "b1", "b2", "b3",
            "b1", "b3", "b2",
            "b2", "b3", "b1",
            "c1", "c2", "c3",
            "c1", "c3", "c2",
            "c2", "c3", "c1",
            // Rows
            "a1", "b1", "c1",
            "a1", "c1", "b1",
            "b1", "c1", "a1",
            "a2", "b2", "c2",
            "a2", "c2", "b2",
            "b2", "c2", "a2",
            "a3", "b3", "c3",
            "a3", "c3", "b3",
            "b3", "c3", "a3",
            // Diagonals
            "a1", "b2", "c3",
            "a1", "c3", "b2",
            "b2", "c3", "a1",
            "a3", "b2", "c1",
            "a3", "c1", "b2",
            "b2", "c1", "a3"  
        };
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
            if (IteratingCheck(noughtOrCross))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        // Checks every pattern in the array of patterns for
        // whether it needs to block or win.
        static bool IteratingCheck(string noughtOrCross)
        {
            for (int i = 0; i < 72; i += 3)
            {
                if (DecideButton(checkPattern[i], checkPattern[i + 1], checkPattern[i + 2], noughtOrCross))
                {
                    return true;
                }
            }
            return false;
        }

        // A method that checks to see if a line can be completed either to block or win
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
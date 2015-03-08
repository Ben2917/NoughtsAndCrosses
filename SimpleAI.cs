using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrossesWithAI
{
    class SimpleAI
    {
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


        static bool DecideButton(string button1, string button2, string button3, string noughtOrCross)
        {
            if (myForm.ButtonText(button1) == noughtOrCross
                && myForm.ButtonText(button2) == noughtOrCross
                && myForm.ButtonEnabled(button3))
            {
                myForm.ClickButtons(button3);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Check current board
        // Method that covers checks for columns
        static bool Columns(string noughtOrCross)
        {
            //DecideButton("a1", "a2", "a3", noughtOrCross);
            #region A possible wins
            if (myForm.ButtonText("a1") == noughtOrCross
                && myForm.ButtonText("a2") == noughtOrCross
                && myForm.ButtonEnabled("a3"))
            {
                myForm.ClickButtons("a3");
                return true;
            }
            else if (myForm.ButtonText("a1") == noughtOrCross
                && myForm.ButtonText("a3") == noughtOrCross
                && myForm.ButtonEnabled("a2"))
            {
                myForm.ClickButtons("a2");
                return true;
            }
            else if (myForm.ButtonText("a2") == noughtOrCross
                && myForm.ButtonText("a3") == noughtOrCross
                && myForm.ButtonEnabled("a1"))
            {
                myForm.ClickButtons("a1");
                return true;
            }
            #endregion
            #region B possible wins
            else if (myForm.ButtonText("b1") == noughtOrCross
                && myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonEnabled("b3"))
            {
                myForm.ClickButtons("b3");
                return true;
            }
            else if (myForm.ButtonText("b1") == noughtOrCross
                && myForm.ButtonText("b3") == noughtOrCross
                && myForm.ButtonEnabled("b2"))
            {
                myForm.ClickButtons("b2");
                return true;
            }
            else if (myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonText("b3") == noughtOrCross
                && myForm.ButtonEnabled("b1"))
            {
                myForm.ClickButtons("b1");
                return true;
            }
            #endregion
            #region C possible wins
            else if (myForm.ButtonText("c1") == noughtOrCross
                && myForm.ButtonText("c2") == noughtOrCross
                && myForm.ButtonEnabled("c3"))
            {
                myForm.ClickButtons("c3");
                return true;
            }
            else if (myForm.ButtonText("c1") == noughtOrCross
                && myForm.ButtonText("c3") == noughtOrCross
                && myForm.ButtonEnabled("c2"))
            {
                myForm.ClickButtons("c2");
                return true;
            }
            else if (myForm.ButtonText("c2") == noughtOrCross
                && myForm.ButtonText("c3") == noughtOrCross
                && myForm.ButtonEnabled("c1"))
            {
                myForm.ClickButtons("c1");
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
            if (myForm.ButtonText("a1") == noughtOrCross
                && myForm.ButtonText("b1") == noughtOrCross
                && myForm.ButtonEnabled("c1"))
            {
                myForm.ClickButtons("c1");
                return true;
            }
            else if (myForm.ButtonText("a1") == noughtOrCross
                && myForm.ButtonText("c1") == noughtOrCross
                && myForm.ButtonEnabled("b1"))
            {
                myForm.ClickButtons("b1");
                return true;
            }
            else if (myForm.ButtonText("b1") == noughtOrCross
                && myForm.ButtonText("c1") == noughtOrCross
                && myForm.ButtonEnabled("a1"))
            {
                myForm.ClickButtons("a1");
                return true;
            }
            else if (myForm.ButtonText("a2") == noughtOrCross
            && myForm.ButtonText("b2") == noughtOrCross
            && myForm.ButtonEnabled("c2"))
            {
                myForm.ClickButtons("c2");
                return true;
            }
            else if (myForm.ButtonText("a2") == noughtOrCross
                && myForm.ButtonText("c2") == noughtOrCross
                && myForm.ButtonEnabled("b2"))
            {
                myForm.ClickButtons("b2");
                return true;
            }
            else if (myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonText("c2") == noughtOrCross
                && myForm.ButtonEnabled("a2"))
            {
                myForm.ClickButtons("a2");
                return true;
            }
            else if (myForm.ButtonText("a3") == noughtOrCross
            && myForm.ButtonText("b3") == noughtOrCross
            && myForm.ButtonEnabled("c3"))
            {
                myForm.ClickButtons("c3");
                return true;
            }
            else if (myForm.ButtonText("a3") == noughtOrCross
                && myForm.ButtonText("c3") == noughtOrCross
                && myForm.ButtonEnabled("b3"))
            {
                myForm.ClickButtons("b3");
                return true;
            }
            else if (myForm.ButtonText("b3") == noughtOrCross
                && myForm.ButtonText("c3") == noughtOrCross
                && myForm.ButtonEnabled("a3"))
            {
                myForm.ClickButtons("a3");
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method that covers checks for diagonals
        static bool Diagonals(string noughtOrCross)
        {
            if ((myForm.ButtonText("a1") == noughtOrCross
                && myForm.ButtonText("c3") == noughtOrCross
                || myForm.ButtonText("c1") == noughtOrCross
                && myForm.ButtonText("a3") == noughtOrCross)
                && myForm.ButtonEnabled("b2"))
            {
                myForm.ClickButtons("b2");
                return true;
            }
            else if (myForm.ButtonText("a1") == noughtOrCross
                && myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonEnabled("c3"))
            {
                myForm.ClickButtons("c3");
                return true;
            }
            else if (myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonText("c3") == noughtOrCross
                && myForm.ButtonEnabled("a1"))
            {
                myForm.ClickButtons("a1");
                return true;
            }
            else if (myForm.ButtonText("a3") == noughtOrCross
                && myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonEnabled("c1"))
            {
                myForm.ClickButtons("c1");
                return true;
            }
            else if (myForm.ButtonText("c1") == noughtOrCross
                && myForm.ButtonText("b2") == noughtOrCross
                && myForm.ButtonEnabled("a3"))
            {
                myForm.ClickButtons("a3");
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

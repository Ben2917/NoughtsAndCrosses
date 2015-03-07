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
    /// <summary>
    /// This class holds all of the methods for
    /// an AI player to use.
    /// </summary>
    class AI
    {
        Button previousButton = new Button();
        static Form1 myForm;
        int turnCount = 0;

        public AI(Form1 form1)
        {
            myForm = form1;
        }

        void CalculateNextTurn()
        {
            // A method that will calculate what the AI
            // player should do next based on the information
            // it has about the current state of the board
            // and what it's previous turn was.
            switch (turnCount)
            {
                    // Which move the AI
                    // player should make
                    // is determined by how many
                    // turns it has already had
                case 0: 
                    TurnOne();
                    break;
                case 1:
                    TurnTwo();
                    break;
                case 2:
                    TurnThree();
                    break;
                case 3:
                    TurnFour();
                    break;
                case 4:
                    TurnFive();
                    break;
            }
            turnCount++;

        }

        static void TurnOne()
        {
            // A method that holds all of the play options that
            // the AI player has for turn one. The options here will
            // be based on whether the AI player has gone first or not

            /*PseudoCode
             * If(PlayingFirst)
             * {
             *     Click a corner
             * }
             * else must be playing second
             * {
             *     if(opponent started with corner)
             *     {
             *         Take centre
             *     }
             *     else if(opponent started in centre)
             *     {
             *         Take a corner
             *     }
             *     else must have taken an edge
             *     {
             *         Take centre
             *     }
             * }
             */
        }

        static void TurnTwo()
        {
            // A method to store all of the options that the AI
            // has for turn two. These will be based on both what the player
            // did in turn one and what the AI did in turn one. If the human
            // player came first blocking their moves may also be relevent.
            
            /*PseudoCode
             * if(ai has corner and player doesnt have centre)
             * {
             *     click any corner that will leave a blank between
             *     the two Os
             * }
             * else if(ai has corner and player has centre)
             * {
             *     place on edge or place diagonal
             * }
             */
        }

        static void TurnThree()
        {
            // At this point four or five squares will be filled
            // so blocking will be important. The current state of the
            // board will need to be analysed and blocking may need priority.
            // The AI player could also win depending on the current state of
            // the board.
            /*
             * if(win move possible)
             * {
             *     win
             * }
             * else if (block neccessary)
             * {
             *     block
             * }
             * else if(player doesnt have centre and player blocked)
             * {
             *     place third nought where two win moves are possible
             * }
             * else if 
             */
        }

        static void TurnFour()
        {
            // The final turn where both players get to play.
            // Similar checks to turn three will need to be applied.
            /*
             * if(win move possible)
             * {
             *     win
             * }
             */
        }

        static void TurnFive()
        {
            // This turn will only be necessary if the AI player
            // went first. No checks necessary as the only option
            // left is to click the last square.
            string[] buttons = new string[]
                {
                    "a1", "a2", "a3",
                    "b1", "b2", "b3",
                    "c1", "c2", "c3"
                };
            // Check the board and click the
            // last available button
            for (int i = 0; i < 9; i++)
            {
                if (myForm.ButtonEnabled(buttons[i]) == true)
                {
                    myForm.ClickButtons(buttons[i]);
                }
            }
        }

    }
}

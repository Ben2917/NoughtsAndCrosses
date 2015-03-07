using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrossesWithAI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            //AI AIPlayer = new AI(form1);
            SimpleAI AIPlayer = new SimpleAI(form1);
            Application.EnableVisualStyles();
            Application.Run(form1);
        }
    }
}

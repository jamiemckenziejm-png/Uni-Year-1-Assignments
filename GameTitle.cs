using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class GameTitle
    {
        public static void DisplayGameTitle()
        {
            Console.WriteLine("\t\t\t=========================================");
            Console.WriteLine("\t\t\t             DICE BATTLE GAME");
            Console.WriteLine("\t\t\t=========================================\n");
        }
        public static void LogGameTitle()
        {
            StreamWriter sw = new StreamWriter("Log.txt", true);
            sw.WriteLine("\t\t\t=========================================");
            sw.WriteLine("\t\t\t             DICE BATTLE GAME");
            sw.WriteLine("\t\t\t=========================================\n");
            sw.Close();
        }

       
    }
}
 
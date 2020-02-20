using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class UI
    {
        public string GetInputFromUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void GetInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[INFO]:\t"+message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

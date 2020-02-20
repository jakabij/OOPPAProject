using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class UI
    {
        public void Start()
        {
            Console.WriteLine("\t\t\t--Welcome to the restaurant's recepe store!--\n\nPress:");
            Console.WriteLine("\t- 1) List the known recepe(s).\n\t- 2) Add new recepe book.\n\t- 3) Update a recepe.\n\t- 4) Remove a recepe.");
        }

        public void TableCloser(bool isTop, int cellWidth)
        {
            if(isTop)
            {
                Console.Write("/");
                PrintLine(cellWidth * 3 + 2);
                Console.WriteLine("\\");
            }
            else
            {
                Console.Write("\\");
                PrintLine(cellWidth * 3 + 2);
                Console.WriteLine("/");
            }
        }
        public void PrintLine(int tableWidth)
        {
            Console.Write(new string('-', tableWidth));
        }

        public void TableDatas(List<RecipeBook> listOfBooks,int cellWidth)
        {
            for (int count = 0; count < listOfBooks.Count; count++)
            {
                Console.WriteLine($"|{listOfBooks[count].Id.PadLeft((cellWidth + listOfBooks[count].Id.Length) / 2).PadRight(cellWidth)}" +
                    $"|{listOfBooks[count].NameOfBook.PadLeft((cellWidth + listOfBooks[count].NameOfBook.Length) / 2).PadRight(cellWidth)}" +
                    $"|{listOfBooks[count].Pages.ToString().PadLeft((cellWidth + listOfBooks[count].Pages.ToString().Length) / 2).PadRight(cellWidth)}|");
                if (count < listOfBooks.Count - 1)
                {
                    Console.Write("|");
                    PrintLine(cellWidth * 3 + 2);
                    Console.WriteLine("|");
                }
            }
        }
        public string GetInputFromUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void GetInfo(string message,bool isFail)
        {
            if (isFail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[INFO]:\t"+message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[INFO]:\t"+message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void GetResult(List<string> result,bool isFail)
        {
            if(!isFail)
            {
                Console.WriteLine("The result:");
                foreach (var item in result)
                {
                    Console.WriteLine("\t-"+item);
                }
            }
            
                
            
        }
    }
}

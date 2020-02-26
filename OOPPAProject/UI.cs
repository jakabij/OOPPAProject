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

        public void TableCloser(bool isTop, int nameCellWidth, int idCellWidth, int pageCellWidth)
        {
            if(isTop)
            {
                Console.Write("/");
                PrintLine(nameCellWidth + 2, idCellWidth, pageCellWidth);
                Console.WriteLine("\\");
            }
            else
            {
                Console.Write("\\");
                PrintLine(nameCellWidth+2, idCellWidth, pageCellWidth);
                Console.WriteLine("/");
            }
        }
        public void PrintLine(int nameCellWidth, int idCellWidth, int pageCellWidth)
        {
            Console.Write(new string('-', nameCellWidth)+new string('-',idCellWidth)+new string('-',pageCellWidth));
        }

        public void TableDatas(List<RecipeBook> listOfBooks,int nameCellWidth,int idCellWidth,int pageCellWidth)
        {
            for (int count = 0; count < listOfBooks.Count; count++)
            {
                Console.WriteLine($"|{listOfBooks[count].Id.PadLeft((idCellWidth + listOfBooks[count].Id.Length) / 2).PadRight(idCellWidth)}" +
                    $"|{listOfBooks[count].NameOfBook.PadLeft((nameCellWidth + listOfBooks[count].NameOfBook.Length) / 2).PadRight(nameCellWidth)}" +
                    $"|{listOfBooks[count].Pages.ToString().PadLeft((pageCellWidth+ listOfBooks[count].Pages.ToString().Length) / 2).PadRight(pageCellWidth)}|");
                if (count < listOfBooks.Count - 1)
                {
                    Console.Write("|");
                    PrintLine(nameCellWidth + 2, idCellWidth, pageCellWidth);
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

        public void GetBookFoods(RecipeBook book)
        {
            Console.WriteLine(book.NameOfBook);
            PrintLine(book.NameOfBook.Length, 0, 0);
            Console.WriteLine();
            foreach(var item in book.ListOfFoods)
            {
                Console.WriteLine($"\t-{item.NameOfFood}");
            }

            string wantToContinues=GetInputFromUser("Do you want to read the recipe? ");
            if (wantToContinues.ToLower().Equals("yes") || wantToContinues.ToLower().Equals("y"))
            {
                GetFoodDatas(book);
            }
            else if (wantToContinues.ToLower().Equals("no") || wantToContinues.ToLower().Equals("n"))
            {

            }
            else
                throw new Exception("InvalidInput");
        }

        public void GetFoodDatas(RecipeBook book)
        {
            string foodName = GetInputFromUser("The searched food's name: ");

            foreach (var item in book.ListOfFoods)
            {
                if (item.NameOfFood.Equals(foodName))
                {
                    if (item is Appetizer)
                    {
                        Appetizer appetizer = (Appetizer)item;
                        Console.WriteLine("\nThis food is an appetizer.\nPreparing time: " + appetizer.TimeToPrepare);

                        Console.WriteLine("\n\tThe ingredients you need:");
                        foreach (var ingredient in appetizer.ListOfIngredients)
                        {
                            Console.WriteLine($"\t\t-{ingredient}");
                        }

                        if (appetizer.ServeCold)
                            Console.WriteLine("\nThis appetizer is need to be served cold.");
                        else
                            Console.WriteLine("\nThis appetizer is need to be served hot.");
                    }
                    else if (item is SecondMeal)
                    {
                        SecondMeal secondMeal = (SecondMeal)item;
                        Console.WriteLine("\n\tThis food is a second meal.\nPreparing time: " + secondMeal.TimeToPrepare);
                        if (secondMeal.NeedToCook)
                            Console.WriteLine("It needs to be cooked.");

                        Console.WriteLine("\n\tThe ingredients you need:");
                        foreach (var ingredient in secondMeal.ListOfIngredients)
                        {
                            Console.WriteLine($"\t\t-{ingredient}");
                        }

                        foreach (var spice in secondMeal.ListOfSpices)
                        {
                            Console.WriteLine($"\t\t-{spice}");
                        }

                        if (secondMeal.ServeCold)
                            Console.WriteLine("This meal is need to be served cold.");
                        else
                            Console.WriteLine("This meal is need to be served hot.");

                    }
                    else
                    {
                        Dessert dessert = (Dessert)item;
                        Console.WriteLine("\n\tThis food is a dessert.\nPreparing time: " + dessert.TimeToPrepare);
                        if (dessert.NeedToCook)
                            Console.WriteLine("It needs to be cooked.");

                        Console.WriteLine("\n\tThe ingredients you need:");
                        foreach (var ingredient in dessert.ListOfIngredients)
                        {
                            Console.WriteLine($"\t\t-{ingredient}");
                        }

                        if (dessert.ServeCold)
                            Console.WriteLine("This dessert is need to be served cold.");
                        else
                            Console.WriteLine("This dessert is need to be served hot.");

                    }
                }
            }
        }
    }
}

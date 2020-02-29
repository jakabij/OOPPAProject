using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class UI
    {
        public void Start()
        {
            Console.WriteLine("\n\n\t\t\t--Welcome to the CodeCool's recepe store!--\n\nPress:");
            Console.WriteLine("\t- 1) To list the known recepe(s).\n\t" +
                "- 2) To create new recepe book.\n\t" +
                "- 3) To modify a recepe book.\n\t" +
                "- 4) To remove a recepe book.\n\t" +
                "- 5) To find book by food name.\n\t" +
                "- 6) To show recepe by food ID.\n\t" +
                "- 7) To find recepe book(s) that contains food.\n\t" +
                "- 8) To save to xml.\n\t" +
                "- 0) To exit.\n\n\n");
        }

        public void PrintUpdateMenu(string bookName)
        {
            Console.WriteLine($"\tThe {bookName} is front of you.\nPress:\n\n\t- 1) To delete a food recepe.\n\t" +
                "- 2) To add new food.\n\t" +
                "- 3) To add comment to a food.\n\t" +
                "- 4) To back to main menu.\n\n\n");
        }

        public void TableCloser(bool isTop, int nameCellWidth, int idCellWidth)
        {
            if(isTop)
            {
                Console.Write("\n\n/");
                PrintLine(nameCellWidth + 1, idCellWidth);
                Console.WriteLine("\\");
            }
            else
            {
                Console.Write("\\");
                PrintLine(nameCellWidth+1, idCellWidth);
                Console.WriteLine("/\n\n");
            }
        }
        public void PrintLine(int nameCellWidth, int idCellWidth)
        {
            Console.Write(new string('-', nameCellWidth)+new string('-',idCellWidth));
        }

        public void TableDatas(List<RecipeBook> listOfBooks,int nameCellWidth,int idCellWidth)
        {
            string id = "ID";
            string name = "Name";
            
            Console.WriteLine($"|{id.PadLeft((idCellWidth + id.Length) / 2).PadRight(idCellWidth)}" +
                   $"|{name.PadLeft((nameCellWidth + name.Length) / 2).PadRight(nameCellWidth)}|");

            Console.Write("|");
            PrintLine(nameCellWidth + 1, idCellWidth);
            Console.WriteLine("|");

            for (int count = 0; count < listOfBooks.Count; count++)
            {
                Console.WriteLine($"|{listOfBooks[count].Id.PadLeft((idCellWidth + listOfBooks[count].Id.Length) / 2).PadRight(idCellWidth)}" +
                    $"|{listOfBooks[count].NameOfBook.PadLeft((nameCellWidth + listOfBooks[count].NameOfBook.Length) / 2).PadRight(nameCellWidth)}|");
                if (count < listOfBooks.Count - 1)
                {
                    Console.Write("|");
                    PrintLine(nameCellWidth + 1, idCellWidth);
                    Console.WriteLine("|");
                }
            }
        }

        public string IdGenerator()
        {
            string chars = "0123456789qwertzuiopasdfghjklyxcvbnmQWERTZUIOPASDFGHJKLYXCVBNM";
            Random rand = new Random();

            string id = "";
            for(int count=0;count<9;count++)
            {
                id+=chars[rand.Next(0, chars.Length)];
            }
            return id;
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
                Console.Write("[INFO]:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t"+message);
            }
            else
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[INFO]:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t" + message);
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
            PrintLine(book.NameOfBook.Length, 0);
            Console.WriteLine();
            foreach(var item in book.ListOfFoods)
            {
                Console.WriteLine($"\t-{item.NameOfFood}  ({item.Id})");
            }
            QuestionForRecepe(book);
        }

        public bool QuestionForFoodAdding()
        {
            string input=GetInputFromUser("Do you want to add food for it? ");
            if (input.ToLower().Equals("y") || input.ToLower().Equals("yes"))
                return true;
            else if (input.ToLower().Equals("n") || input.ToLower().Equals("no"))
                return false;
            else
                throw new Exception("NotValidAttribute");
        }

        public void QuestionForRecepe(RecipeBook book)
        {
            string wantToContinue = GetInputFromUser($"Do you want to read the recipe from {book.NameOfBook}? ");
            if (wantToContinue.ToLower().Equals("yes") || wantToContinue.ToLower().Equals("y"))
            {
                GetFoodDatas(book);
            }
            else if (wantToContinue.ToLower().Equals("no") || wantToContinue.ToLower().Equals("n"))
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
                    PrintLine(40, 0);
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
                            Console.WriteLine("\nThis appetizer is need to be served cold.\n");
                        else
                            Console.WriteLine("\nThis appetizer is need to be served hot.\n");
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
                            Console.WriteLine("\nThis meal is need to be served cold.\n");
                        else
                            Console.WriteLine("\nThis meal is need to be served hot.\n");

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
                            Console.WriteLine("\nThis dessert is need to be served cold.\n");
                        else
                            Console.WriteLine("\nThis dessert is need to be served hot.\n");
                    }
                    Console.WriteLine(item.Comment);
                    Console.ReadKey();
                    Console.Clear();
                    PrintUpdateMenu(book.NameOfBook);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPAProject
{
    public class Menu
    {
        UI ui = new UI();
        public void PrintingMenu()
        {
            Console.WriteLine("\t\t\t--Welcome to the restaurant's recepe store!--\n\nPress:");
            Console.WriteLine("\t- 1) List the known recepe(s).\n\t- 2) Add new recepe book.\n\t- 3) Update a recepe.\n\t- 4) Remove a recepe.");
        }

        public void PrintAllBooks(List<RecipeBook> listOfBooks)
        {
            var cellWidth = listOfBooks.Max(book => book.NameOfBook.Length)+4;

            Console.Write("/");
            PrintLine(cellWidth*3+2);
            Console.WriteLine("\\");


            for(int count=0; count < listOfBooks.Count;count++)
            {
                Console.WriteLine($"|{listOfBooks[count].Id.PadLeft((cellWidth+ listOfBooks[count].Id.Length)/2).PadRight(cellWidth)}" +
                    $"|{listOfBooks[count].NameOfBook.PadLeft((cellWidth+ listOfBooks[count].NameOfBook.Length)/2).PadRight(cellWidth)}" +
                    $"|{listOfBooks[count].Pages.ToString().PadLeft((cellWidth+ listOfBooks[count].Pages.ToString().Length)/2).PadRight(cellWidth)}|");
                if(count<listOfBooks.Count-1)
                {
                    Console.Write("|");
                    PrintLine(cellWidth * 3 + 2);
                    Console.WriteLine("|");
                }
            }
            
            Console.Write("\\");
            PrintLine(cellWidth*3+2);
            Console.WriteLine("/");

        }


        public void PrintLine(int tableWidth)
        {
            Console.Write(new string('-', tableWidth));
        }

        public RecipeBook CreateRecipeBook()
        {
            string id = "0";

            
            string nameOfBook = ui.GetInputFromUser("The name of the book: ");

            int pages;
            try 
            {
                pages = int.Parse(ui.GetInputFromUser("Page number: "));
            }
            catch
            {
                throw new Exception("ParseError");
            }
            ui.GetInfo("Recepe Book successfully made!");

            return new RecipeBook(id, nameOfBook, pages);
        }

        public void AddFoodToRecipeBook(RecipeBook book)
        {
            string typeOfFood=ui.GetInputFromUser("[1: Appetizer, 2: Second Meal, 3: Dessert]\nType of the food: ");
            if(!(typeOfFood.Equals("1") && typeOfFood.Equals("2") && typeOfFood.Equals("3")))
            {
                throw new Exception("NotValidAttribute!");
            }

            string nameOfFood = ui.GetInputFromUser("Name of food: ");

            bool serveCold;
            try
            {
                serveCold = bool.Parse(ui.GetInputFromUser("[yes or no]\nBest to serve cold: "));
            }
            catch
            {
                throw new Exception("ParseError");
            }

            string[] ingredients = ui.GetInputFromUser("The ingredients separated by ',': ").Split(",");
            List<string> listOfIngredients = new List<string>();
            listOfIngredients.AddRange(ingredients);

            Food food = book.CreateFood(typeOfFood, nameOfFood, serveCold, listOfIngredients);
            ui.GetInfo("Creating food was successfull!");
            book.AddFood(food);
            ui.GetInfo("Adding food to the book was successfull!");
        }





        public List<RecipeBook> FindBookByFoodName(string name)
        {
            return null;
        }

        public void RemoveRecepeById(string id)
        {

        }

        public void ShowRecepeByFoodId(string id)
        {

        }
    }
}

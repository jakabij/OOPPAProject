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
            ui.Start();
        }

        public void PrintAllBooks(List<RecipeBook> listOfBooks)
        {
            var cellWidth = listOfBooks.Max(book => book.NameOfBook.Length)+4;

            ui.TableCloser(true, cellWidth);
            ui.TableDatas(listOfBooks,cellWidth);
            ui.TableCloser(false, cellWidth);
        }

        public RecipeBook CreateRecipeBook()
        {
            string id = "0"; //generate ID

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
            ui.GetInfo("Recepe Book successfully made!",true);

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
            ui.GetInfo("Creating food was successfull!",true);
            book.AddFood(food);
            ui.GetInfo("Adding food to the book was successfull!",true);
        }

        public void FindBookByFoodName(string name, Store store)    //make a suggester
        {
            List<RecipeBook> searchedBooks = new List<RecipeBook>();
            foreach(var book in store.ListOfRecipeBooks)
            {
                foreach(var food in book.ListOfFoods)
                {
                    if(food.NameOfFood.Equals(name))
                    {
                        if(!searchedBooks.Contains(book))
                            searchedBooks.Add(book);
                    }
                }
            }
            if(searchedBooks.Count==0)
            {
                ui.GetInfo("No food like that!", true);
            }
            else
            {
                List<string> messages = new List<string>();
                foreach(var book in searchedBooks)
                {
                    messages.Add(book.NameOfBook);
                }
                ui.GetResult(messages,false);
            }
        }

        public void RemoveRecepeById(string id)
        {

        }

        public void ShowRecepeByFoodId(string id)
        {

        }
    }
}

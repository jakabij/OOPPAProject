using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OOPPAProject
{
    public class Menu
    {
        UI ui = new UI();
        Store store;
        public Menu()
        {
            if (File.Exists("store.xml"))
            {
                XmlLoader loader = new XmlLoader();
                store = loader.LoadFromXml("store.xml");
                ui.GetInfo("Loading from database was successful.", false);
            }
            else
            {
                store = new Store();
                ui.GetInfo("No database found.", true);
            }
        }
        public void MenuStart()
        {
            ui.Start();
            string choice = ui.GetInputFromUser("\nYour choice: ");

            if (choice.Equals("1"))
            {
                Console.Clear();
                ReadAllBooks();
            }

            else if (choice.Equals("2"))
            {
                try
                { 
                    CreateRecepeBook();
                }
                catch
                {
                    ui.GetInfo("Wrong attributes! Recepe book not created.", true);
                }
            }

            else if (choice.Equals("3"))
            {
                while (true)
                {
                    ReadAllBooks();
                    string bookId = ui.GetInputFromUser("The book's ID that you are searching for or press 0 to EXIT: ");
                    if (bookId.Equals("0"))
                        break;

                    bool foundIt = false;
                    RecipeBook recipeBook = null;
                    foreach (var book in store.ListOfRecipeBooks)
                    {
                        if (book.Id.Equals(bookId))
                        {
                            foundIt = true;
                            recipeBook = book;
                            break;
                        }
                    }

                    if (foundIt)
                    {
                        while (true)
                        {
                            ui.GetBookFoods(recipeBook);
                            ui.PrintUpdateMenu(recipeBook.NameOfBook);
                            string choice3 = ui.GetInputFromUser("\nYou chose: ");

                            if (choice3.Equals("1"))
                            {
                                DeleteFood(recipeBook);
                            }
                            else if (choice3.Equals("2"))
                            {
                                try
                                {
                                    Food food = CreateFoodForRecipeBook(recipeBook);
                                    recipeBook.AddFood(food);
                                    Console.Clear();
                                    ui.GetInfo("Food successfully added to the book.", false);
                                }
                                catch
                                {
                                    ui.GetInfo("Not valid attributes added!", true);
                                    ui.GetInfo("Food does not created.", true);
                                }
                            }
                            else if (choice3.Equals("3"))
                            {
                                CommentToFood(recipeBook);
                                Console.Clear();
                                ui.GetInfo("Commenting was successfull.", false);
                            }
                            else if (choice3.Equals("4"))
                            {
                                break;
                            }
                            else
                            {
                                ui.GetInfo("Invalid attribute!", true);
                            }
                        }
                    }
                    else
                    {
                        ui.GetInfo("Invalid ID.", true);
                    }
                }
            }

            else if (choice.Equals("4"))
            {
                Console.Clear();
                ReadAllBooks();
                string id = ui.GetInputFromUser("\nRecepe book's ID to delete: ");

                if (RemoveRecepeById(id, store))
                    ui.GetInfo("Recepe book successfully deleted.", false);

                else
                    ui.GetInfo("Recepe book not found.", true);
            }

            else if (choice.Equals("5"))
            {
                string bookName = ui.GetInputFromUser("\nFood name: ");
                Console.Clear();
                FindBookByFoodName(bookName, store);
            }
            else if (choice.Equals("6"))
            {
                Console.Clear();
                ReadAllBooks();
                string bookId = ui.GetInputFromUser("\nBook ID: ");
                
                ShowRecepeByBookId(bookId, store);
                Console.Clear();
            }
            else if (choice.Equals("7"))
            {
                XmlSaver saver = new XmlSaver();
                saver.SaveToXml("store.xml", store.ListOfRecipeBooks);
                Console.Clear();
                ui.GetInfo("Save was successfull.", false);
            }
            else if (choice.Equals("0"))
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                ui.GetInfo("Invalid attribute!", true);
            }
        }







        public void PrintAllBooks(List<RecipeBook> listOfBooks)
        {
            var nameCellWidth = listOfBooks.Max(book => book.NameOfBook.Length) + 4;
            int idCellWidth = 9;

            ui.TableCloser(true, nameCellWidth, idCellWidth);
            ui.TableDatas(listOfBooks, nameCellWidth, idCellWidth);
            ui.TableCloser(false, nameCellWidth, idCellWidth);
        }

        public void ReadAllBooks()
        {
            if (store.ListOfRecipeBooks.Count < 1)
            {
                Console.Clear();
                ui.GetInfo("There is no recepe in the store.", true);
            }
            else
            {
                Console.Clear();
                PrintAllBooks(store.ListOfRecipeBooks);
            }
        }


        public void CreateRecepeBook()
        {
            string bookName = ui.GetInputFromUser("Name of the book: ");

            RecipeBook recipeBook = new RecipeBook(bookName);
            ui.GetInfo("Recipe book successfully created.", false);

            while (true)
            {
                Console.Clear();
                if (ui.QuestionForFoodAdding())
                {
                    Food food = CreateFoodForRecipeBook(recipeBook);

                    recipeBook.AddFood(food);
                    ui.GetInfo("Food successfully added to recepe book.", false);
                }
                else
                    break;
            }
            store.AddRecipeBook(recipeBook);
            ui.GetInfo("Recipe book successfully added to store.", false);
        }

        public void DeleteFood(RecipeBook recipeBook)
        {
            string foodId = ui.GetInputFromUser("Food id to delete: ");
            bool foundTheFood = false;
            for (int count = 0; count < recipeBook.ListOfFoods.Count; count++)
            {
                if (recipeBook.ListOfFoods[count].Id.Equals(foodId))
                {
                    foundTheFood = true;
                    recipeBook.ListOfFoods.RemoveAt(count);
                    Console.Clear();
                    ui.GetInfo("Food successfully removed.", false);
                    break;
                }
            }
            if (!foundTheFood)
            {
                Console.Clear();
                ui.GetInfo("Not valid ID!", true);
                ui.GetInfo("Nothing changed.", true);
            }
        }

        public void CommentToFood(RecipeBook recipeBook)
        {
            string foodId = ui.GetInputFromUser("Food id to comment: ");
            bool foundTheFood = false;
            for (int count = 0; count < recipeBook.ListOfFoods.Count; count++)
            {
                if (recipeBook.ListOfFoods[count].Id.Equals(foodId))
                {
                    foundTheFood = true;
                    string comment = ui.GetInputFromUser("What to comment: ");
                    recipeBook.ListOfFoods[count].Comment = comment;
                    break;
                }
            }
            if (!foundTheFood)
            {
                ui.GetInfo("Not valid ID!", true);
                throw new Exception("NotValidId");
            }
        }

        public Food CreateFoodForRecipeBook(RecipeBook book)
        {
            string typeOfFood = ui.GetInputFromUser("[1: Appetizer, 2: Second Meal, 3: Dessert]\nType of the food: ");
            if (!(typeOfFood.Equals("1") || typeOfFood.Equals("2") || typeOfFood.Equals("3")))
            {
                throw new Exception("NotValidAttribute!");
            }
           
            string nameOfFood = ui.GetInputFromUser("\nName of food: ");

            bool serveCold;
           
            string toConvert = ui.GetInputFromUser("\n[yes or no]\nBest to serve cold: ");
            if(toConvert.ToLower().Equals("yes") || toConvert.ToLower().Equals("y"))
            {
                serveCold = true;
            }
            else if(toConvert.ToLower().Equals("no") || toConvert.ToLower().Equals("n"))
            {
                serveCold = false;
            }
            else
            {
                throw new Exception("ParseError");
            }


            string[] ingredients = ui.GetInputFromUser("\nThe ingredients separated by ',': ").Split(",");
            List<string> listOfIngredients = new List<string>();
            listOfIngredients.AddRange(ingredients);

            string toCheck = "'~ˇ+^!˘%°/˛=`´˝¨\\|€÷×łŁ$ß#&@<?;.:*";
            foreach (var ingredient in listOfIngredients)
            {
                for (int i = 0; i < toCheck.Length; i++)
                {
                    if (ingredient.Contains(toCheck[i]))
                        throw new Exception("InvalidAttribute");
                }
            }

            try
            {
                Food food = book.CreateFood(typeOfFood, nameOfFood, serveCold, listOfIngredients);
                ui.GetInfo("Creating food was successfull!", false);

                return food;
            }
            catch
            {
                throw new Exception("InvalidCreation");
            }
        }

        public void FindBookByFoodName(string name, Store store)
        {
            List<RecipeBook> searchedBooks = new List<RecipeBook>();
            foreach (var book in store.ListOfRecipeBooks)
            {
                foreach (var food in book.ListOfFoods)
                {
                    if (food.NameOfFood.Equals(name))
                    {
                        if (!searchedBooks.Contains(book))
                            searchedBooks.Add(book);
                    }
                }
            }
            Console.Clear();

            if (searchedBooks.Count == 0)
            {
                ui.GetInfo("No food like that!", true);
            }
            else
            {
                List<string> messages = new List<string>();
                foreach (var book in searchedBooks)
                {
                    messages.Add(book.NameOfBook+$"  ({book.Id})");
                }
                ui.GetInfo("Searching was successfull!", false);
                ui.GetResult(messages, false);
            }
        }

        public bool RemoveRecepeById(string id, Store store)
        {
            return store.RemoveRecipeBook(id);
        }

        public void ShowRecepeByBookId(string id, Store store)
        {
            RecipeBook searchedBook = null;
            bool foundIt = false;
            foreach (var book in store.ListOfRecipeBooks)
            {
                if (book.Id.Equals(id))
                {
                    searchedBook = book;
                    foundIt = true;
                    break;
                }
            }
            if (foundIt)
            { 
                ui.GetBookFoods(searchedBook);
            }
            else
            {
                ui.GetInfo("Book not found!", true);
            }
        }
    }
}

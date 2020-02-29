using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPAProject
{
    public class Menu
    {
        UI ui = new UI();
        Store store = new Store();
        public void MenuStart()
        {
            ui.Start();
            string choice = ui.GetInputFromUser("Your choice: ");

            if (choice.Equals("1"))
            {
                ReadAllBooks();
            }

            else if (choice.Equals("2"))
            {
                CreateRecepeBook();
            }

            else if (choice.Equals("3"))
            {
                while(true)
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
                        ui.PrintUpdateMenu(recipeBook.NameOfBook);
                        while (true)
                        {
                            ui.GetBookFoods(recipeBook);
                            string choice3 = ui.GetInputFromUser("You chose: ");

                            if (choice3.Equals("1"))
                            {
                                DeleteFood(recipeBook);
                            }
                            else if (choice3.Equals("2"))
                            {
                                Food food = CreateFoodForRecipeBook(recipeBook);
                                recipeBook.AddFood(food);
                            }
                            else if (choice3.Equals("3"))
                            {
                                CommentToFood(recipeBook);
                            }
                            else if (choice3.Equals("4"))
                            {
                                break;
                            }
                            else
                                throw new Exception("InvalidAttribute");
                        }
                    }
                    else
                        throw new Exception("InvalidId");
                }
            }

            else if (choice.Equals("4"))
            {
                string id=ui.GetInputFromUser("Recepe book's ID to delete: ");

                if (RemoveRecepeById(id, store))
                    ui.GetInfo("Recepe book successfully deleted.", false);

                else
                    ui.GetInfo("Recepe book not found.", true);
            }

            else if (choice.Equals("5"))
            {
                string bookName = ui.GetInputFromUser("Book name: ");
                FindBookByFoodName(bookName, store);
            }
            else if (choice.Equals("6"))
            {
                string foodId = ui.GetInputFromUser("Food ID: ");
                ShowRecepeByFoodId(foodId, store);
            }
            else if (choice.Equals("7"))
            {
                string foodName = ui.GetInputFromUser("Food name: ");
                ShowRecepeBooksByFoodName(foodName, store);
            }
            else if(choice.Equals("8"))
            {
                XmlSaver saver = new XmlSaver();
                saver.SaveToXml("store.xml",store.ListOfRecipeBooks);
            }
            else
            {
                System.Environment.Exit(0);
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
                ui.GetInfo("\nThere is no recepe in the store.", true);
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
                    ui.GetInfo("Food successfully removed.", false);
                    break;
                }
            }
            if (!foundTheFood)
            {
                throw new Exception("NotValidId");
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
            if(toConvert.ToLower().Equals("yes"))
            {
                serveCold = true;
            }
            else if(toConvert.ToLower().Equals("no"))
            {
                serveCold = false;
            }
            else
                throw new Exception("ParseError");
               

            string[] ingredients = ui.GetInputFromUser("\nThe ingredients separated by ',': ").Split(",");
            List<string> listOfIngredients = new List<string>();
            listOfIngredients.AddRange(ingredients);

            Food food = book.CreateFood(typeOfFood, nameOfFood, serveCold, listOfIngredients);
            ui.GetInfo("Creating food was successfull!", false);
            
            return food;
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
                ui.GetResult(messages, false);
            }
        }

        public bool RemoveRecepeById(string id, Store store)
        {
            return store.RemoveRecipeBook(id);
        }

        public void ShowRecepeByFoodId(string id, Store store)
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
                throw new Exception("BookNotFound");
        }

        public void ShowRecepeBooksByFoodName(string foodName, Store store)
        {
            List<string> searchedBooks = new List<string>();

            foreach (var book in store.ListOfRecipeBooks)
            {
                foreach (var food in book.ListOfFoods)
                {
                    if (food.NameOfFood.Equals(foodName))
                    {
                        searchedBooks.Add(book.NameOfBook+$"  ({book.Id})");
                        break;
                    }
                }
            }
            if (searchedBooks.Count > 0)
            {
                ui.GetResult(searchedBooks, false);
            }
            else
                throw new Exception("BookNotFound");
        }
    }
}

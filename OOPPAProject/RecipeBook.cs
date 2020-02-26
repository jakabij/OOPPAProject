using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class RecipeBook
    {
        UI ui = new UI();
        public string Id { get; set; }
        public int Pages { get; set; }
        public string NameOfBook { get; set; }
        public List<Food> ListOfFoods { get; set; }

        public RecipeBook(string id, string nameOfBook, int pages)
        {
            Id = id;
            Pages = pages;
            NameOfBook = nameOfBook;
            ListOfFoods = new List<Food>();
        }

        public Food CreateFood(string typeOfFood, string nameOfFood,bool serveCold, List<string> listOfIngredients)
        {
            Food food;
            if(typeOfFood.ToLower().Equals("1"))
            {
                int id = 0;
                //generator for ID needed
                TimeSpan timeToPrepare; //00:00:00 format
                
                string userInput =ui.GetInputFromUser("The time to prepare it: ");
                string[] timeAfterSplit = userInput.Split(":");
                if (timeAfterSplit.Length < 3 || timeAfterSplit.Length > 3)
                {
                    throw new Exception("ParseError");
                }
                else
                {
                    int hours = 0;
                    int minutes = 1;
                    int seconds = 2;

                    if (int.TryParse(timeAfterSplit[hours], out hours)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if (int.TryParse(timeAfterSplit[minutes], out minutes)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if (int.TryParse(timeAfterSplit[seconds], out seconds)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    timeToPrepare = new TimeSpan(hours, minutes, seconds);
                }
                food = new Appetizer(id, nameOfFood, serveCold, listOfIngredients,timeToPrepare);
            }
            else if(typeOfFood.ToLower().Equals("2"))
            {
                int id = 0;
                string userInput = ui.GetInputFromUser("Need to cook: ");
                bool needToCook;
                if(userInput.ToLower().Equals("yes") || userInput.ToLower().Equals("y"))
                {
                    needToCook = true;
                }
                else if(userInput.ToLower().Equals("no") || userInput.ToLower().Equals("n"))
                {
                    needToCook = false;
                }
                else
                {
                    throw new Exception("ParseError");
                }


                TimeSpan timeToPrepare; //00:00:00 format
                userInput = ui.GetInputFromUser("The time to prepare it: ");
                string[] inputSplitting = userInput.Split(":");
                if(inputSplitting.Length<3 || inputSplitting.Length>3)
                {
                    throw new Exception("ParseError");
                }
                else
                {
                    int hours=0;
                    int minutes=1;
                    int seconds=2;

                    if(int.TryParse(inputSplitting[hours], out hours)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if(int.TryParse(inputSplitting[minutes], out minutes)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if (int.TryParse(inputSplitting[seconds], out seconds)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    timeToPrepare = new TimeSpan(hours, minutes, seconds);
                }

                userInput = ui.GetInputFromUser("List of the spices divided by ',': ");
                inputSplitting = userInput.Split(",");
                List<string> listOfSpices = new List<string>();
                listOfSpices.AddRange(inputSplitting);

                food = new SecondMeal(id, nameOfFood, serveCold, listOfIngredients, needToCook, timeToPrepare, listOfSpices);
            }

            else if(typeOfFood.ToLower().Equals("3"))
            {
                int id = 0;

                string userInput = Console.ReadLine();
                bool needToCook;
                if (bool.TryParse(userInput, out needToCook)) { }
                else
                {
                    throw new Exception("ParseError");
                }

                TimeSpan timeToPrepare; //00:00:00 format
                userInput = ui.GetInputFromUser("The time to prepare it: ");
                string[] inputSplitting = userInput.Split(":");
                if (inputSplitting.Length < 3 || inputSplitting.Length > 3)
                {
                    throw new Exception("ParseError");
                }
                else
                {
                    int hours = 0;
                    int minutes = 1;
                    int seconds = 2;

                    if (int.TryParse(inputSplitting[hours], out hours)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if (int.TryParse(inputSplitting[minutes], out minutes)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if (int.TryParse(inputSplitting[seconds], out seconds)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    timeToPrepare = new TimeSpan(hours, minutes, seconds);
                }

                food = new Dessert(id, nameOfFood, serveCold, listOfIngredients, needToCook, timeToPrepare);
            }
            else
            {
                throw new Exception("NoFoodLikeThatException");
            }


            return food;
        }

        public void AddFood(Food food)
        {
            ListOfFoods.Add(food);
        }
    }
}

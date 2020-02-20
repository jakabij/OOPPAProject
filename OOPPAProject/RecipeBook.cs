using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class RecipeBook
    {
        public int Id { get; set; }
        public int Pages { get; set; }
        public string NameOfBook { get; set; }
        public List<Food> ListOfFoods { get; set; }

        public RecipeBook()
        {
            ListOfFoods = new List<Food>();
        }

        public Food CreateFood(string typeOfFood, string nameOfFood,bool serveCold, List<string> listOfIngredients)
        {
            Food food;
            if(typeOfFood.ToLower().Equals("appetizer"))
            {
                int id = 0;
                //generator for ID needed
                food = new Appetizer(id, nameOfFood, serveCold, listOfIngredients);
            }
            else if(typeOfFood.ToLower().Equals("secondmeal"))
            {
                int id = 0;
                string userInput = Console.ReadLine();
                bool needToCook;
                if(bool.TryParse(userInput, out needToCook)){ }
                else
                {
                    throw new Exception("ParseError");
                }


                TimeSpan timeToPrepare; //00:00:00 format
                userInput = Console.ReadLine();
                string[] timeAfterSplit = userInput.Split(":");
                if(timeAfterSplit.Length<3 || timeAfterSplit.Length>3)
                {
                    throw new Exception("ParseError");
                }
                else
                {
                    int hours=0;
                    int minutes=1;
                    int seconds=2;

                    if(int.TryParse(timeAfterSplit[hours], out hours)) { }
                    else
                    {
                        throw new Exception("ParseError");
                    }

                    if(int.TryParse(timeAfterSplit[minutes], out minutes)) { }
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

                userInput = Console.ReadLine();
                timeAfterSplit = userInput.Split(",");
                List<string> listOfSpices = new List<string>();
                listOfSpices.AddRange(timeAfterSplit);

                food = new SecondMeal(id, nameOfFood, serveCold, listOfIngredients, needToCook, timeToPrepare, listOfSpices);
            }

            else if(typeOfFood.ToLower().Equals("dessert"))
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
                userInput = Console.ReadLine();
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
